using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Linq;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Testing.Library
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }

        public static string BaseAddress { get; private set; }

        public static string BaseAddressGoogle { get; private set; }

        public static string BaseAddressBing { get; private set; }

        public static bool IsBuildServer { get; private set; }

        public static void SetBaseUrls()
        {
            IsBuildServer = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("bamboo_prefix"));

            if (IsBuildServer)
            {
                var prefix = Environment.GetEnvironmentVariable("ci_prefix") + Environment.GetEnvironmentVariable("bamboo_prefix");
                BaseAddress = string.Format("http://{0}.officecore.net", prefix);
                BaseAddressGoogle = string.Format("http://{0}.officecore.google", prefix);
                BaseAddressBing = string.Format("http://{0}.officecore.bing", prefix);
            }
            else
            {
                var currentFolder = Directory.GetCurrentDirectory();

                var pos = currentFolder.LastIndexOf("src\\");
                var srcFolder = currentFolder.Substring(0, pos + 4);

                var webConfigLocation = srcFolder + string.Format(@"Spitfire.Website\Web.{0}.config", Environment.MachineName);
                if (!File.Exists(webConfigLocation))
                {
                    webConfigLocation = srcFolder + @"Spitfire.Website\Web.config";
                }

                var webConfigXml = XDocument.Load(webConfigLocation);
                var variables = webConfigXml.Element("configuration").Element("sitecore").Elements("sc.variable").ToList();

                BaseAddress = GetHostnameFromElements(variables, "hostNameWeb");
                BaseAddressGoogle = GetHostnameFromElements(variables, "hostNameGoogle");
                BaseAddressBing = GetHostnameFromElements(variables, "hostNameBing");
            }
        }

        private static string GetHostnameFromElements(List<XElement> variables, string key)
        {
            var hostname = variables.Where(x => x.Attribute("name").Value == key)
                    .Select(x => x.Attribute("value").Value)
                    .FirstOrDefault();

            if (hostname.Contains("|"))
            {
                hostname = hostname.Split('|')[0];
            }

            return "http://" + hostname;
        }

        public static void Initialize()
        {
            SetBaseUrls();
            Instance = new ChromeDriver("C:\\");
            TurnOnWait(TimeSpan.FromSeconds(5));
        }

        public static void Close()
        {
            Instance.Close();
        }

        public static void Wait(TimeSpan timeSpan)
        {
            Thread.Sleep((int)(timeSpan.TotalSeconds * 1000));
        }

        /// <summary>
        /// Forces browser to wait but only when we're building from Visual Studio
        /// i.e. not from the build server
        /// </summary>
        /// <param name="seconds">Number of seconds to wait</param>
        public static void WaitWhenHuman(int seconds)
        {
            if (IsBuildServer)
            {
                return;
            }

            int milliseconds = seconds * 1000;
            Thread.Sleep(milliseconds);
        }

        public static void WithWait(Action action)
        {
            TurnOnWait(TimeSpan.FromSeconds(5));
            action();
            TurnOffWait();
        }

        private static void TurnOnWait(TimeSpan timespan)
        {
            Instance.Manage().Timeouts().ImplicitlyWait(timespan);
        }

        private static void TurnOffWait()
        {
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0));
        }
    }
}