using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using OpenQA.Selenium;
using Testing.Library;

namespace WebsiteTests
{
    [TestClass]
    public class SmokeTests
    {
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            Driver.Initialize();
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            Driver.Close();
        }

        [TestMethod]
        public void HomepageTest()
        {
            TouchPage("/");
        }

        private static void TouchPage(string url)
        {
            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress + url);
            var menuExists = Driver.Instance.FindElements(By.Id("nn-nav-menu")).Any();
            Assert.IsTrue(menuExists);
        }
    }
}
