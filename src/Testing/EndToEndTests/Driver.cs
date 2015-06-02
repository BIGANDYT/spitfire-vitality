namespace EndToEndTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.NetworkInformation;
    using System.Threading;
    using System.Xml.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    //// using Microsoft.Expression.Encoder.ScreenCapture;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Interactions;

    public class Driver
    {
        // TODO: get the screen recording setup so it helps with the script creation
        ////public static ScreenCaptureJob Recorder { get; set; }

        public static List<IWebElement> NewsNameCheck { get; set; }
        public static int NewsNameCount { get; set; }
        public static string NewNewsLink { get; set; }
        public static IWebDriver Instance { get; set; }
        public static string BaseAddress { get; private set; }
        public static string BaseAddressGoogle { get; private set; }
        public static string BaseAddressBing { get; private set; }
        public static string BaseAddressSitecore { get; private set; }
        public static bool IsBuildServer { get; private set; }

        //public static bool RecorderStatus { get; set; }

        private static void SetBaseUrls()
        {
            if (IsBuildServer)
            {
                var prefix = Environment.GetEnvironmentVariable("ci_prefix") + Environment.GetEnvironmentVariable("bamboo_prefix");
                BaseAddress = string.Format("http://{0}.officecore.net", prefix);
                BaseAddressGoogle = string.Format("http://{0}.officecore.google", prefix);
                BaseAddressBing = string.Format("http://{0}.officecore.bing", prefix);
                //RecorderStatus = false;
            }
            else
            {
                var currentFolder = Directory.GetCurrentDirectory();

                var pos = currentFolder.LastIndexOf("src\\");
                var srcFolder = currentFolder.Substring(0, pos + 4);

                var webConfigLocation = srcFolder + string.Format(@"Website\Web.{0}.config", Environment.MachineName);
                if (!File.Exists(webConfigLocation))
                {
                    webConfigLocation = srcFolder + @"Website\Web.config";
                }

                var webConfigXml = XDocument.Load(webConfigLocation);
                var variables = webConfigXml.Element("configuration").Element("sitecore").Elements("sc.variable").ToList();

                BaseAddress = GetHostnameFromElements(variables, "hostNameWeb");
                BaseAddressGoogle = GetHostnameFromElements(variables, "hostNameGoogle");
                BaseAddressBing = GetHostnameFromElements(variables, "hostNameBing");
                //RecorderStatus = true;
            }
            BaseAddressSitecore = BaseAddress + "/sitecore";
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

        public static void Initialize(String invokingScript)
        {
            IsBuildServer = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("bamboo_prefix"));
            SetBaseUrls();

            //String date = DateTime.Now.ToFileTime().ToString();
            //if (RecorderStatus)
            //{
            //    Recorder = new ScreenCaptureJob();
            //    Recorder.OutputScreenCaptureFileName = @"C:\Sitecore\ScriptVids\" + invokingScript + date + ".wmv";
            //    Recorder.Start();
            //}

            Instance = new ChromeDriver(@"C:\", CreateChromeOptions());
            //Instance = new FirefoxDriver();
            TurnOnWait(TimeSpan.FromSeconds(5));
        }

        public static void Close()
        {
            //if (RecorderStatus)
            //{
            //    Recorder.Stop();
            //}
            Instance.Close();
            Instance.Quit();
        }

        public static void Wait(TimeSpan timeSpan)
        {
            Thread.Sleep((int)(timeSpan.TotalSeconds * 1000));
        }

        public static ChromeOptions CreateChromeOptions()
        {
            var options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            options.AddArguments("--test-type");
            options.AddArguments("--ignore-certificate-errors");
            options.AddArgument(@"--incognito");
            return options;
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
            return;
        }

        public static void WaitWhenScriptBuild(int seconds)
        {
            WaitWhenHuman(seconds);
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

        public static void ClickWithOffset(IWebElement element, int xOffset, int yOffset)
        {
            var builder = new Actions(Instance);
            builder.MoveToElement(element).MoveByOffset(xOffset, yOffset).Click();
            var clickNextElement = builder.Build();
            clickNextElement.Perform();
        }

        public static void LogOut()
        {
            Instance.SwitchTo().Frame(Instance.FindElement(By.Id("scWebEditRibbon")));

            var logoutButton = Instance.FindElement(By.ClassName("logout"));
            Assert.IsTrue(logoutButton.Displayed);
            WaitWhenHuman(2);
            logoutButton.Click();
        }

        public static void CheckMenu()
        {
            var menu = Instance.FindElement(By.Id("nn-nav-menu")).Displayed;
            Assert.IsTrue(menu);
        }

        public static void Login(string username, string password)
        {
            Instance.Navigate().GoToUrl(BaseAddressSitecore);

            var userNameBox = Instance.FindElement(By.Id("UserName"));
            Assert.IsTrue(userNameBox.Displayed);
            userNameBox.Clear();
            userNameBox.SendKeys(username);

            var passBox = Instance.FindElement(By.Id("Password"));
            Assert.IsTrue(passBox.Displayed);
            passBox.Clear();
            passBox.SendKeys(password);

            var loginButton = Instance.FindElement(By.Name("ctl07"));
            Assert.IsTrue(loginButton.Displayed);
            loginButton.Click();
        }

        public static bool IsOnline()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                return true;
            }
            return false;
        }

        public static void Save()
        {
            Instance.SwitchTo().DefaultContent();
            Instance.SwitchTo().Frame(Instance.FindElement(By.Id("scWebEditRibbon")));

            var saveBtn = Instance.FindElement(By.XPath("//a[contains(@title, 'Save changes.')]"));
            Assert.IsNotNull(saveBtn);
            saveBtn.Click();
        }
    }
}