using AutomationFramework.Common;
using AutomationFramework.pages;
using AutomationFramework.Resources;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Tests
{
    public class AnotherBrowserSearch:BaseTest
    {
        BrowserType browserType;
        String huburl;
        public AnotherBrowserSearch(BrowserType browserType, string huburl) : base(browserType, huburl)
        {
            this.browserType = browserType;
            this.huburl = huburl;
        }
        [Test]
        public void OpenBing()
        {
            HomePage homepage = new(GetWebDriver());

            GetWebDriver().Navigate().GoToUrl("https://www.bing.com");
            ReportLog.Pass("User is in URL");
            GetWebDriver().Manage().Window.Maximize();
            GetWebDriver().FindElement(By.Name("q")).SendKeys("I Want to se this on a remote machine");
           
        }
        [Test]
        public void SearchGoogle()
        {
            HomePage homepage = new(GetWebDriver());
            homepage.googleit();
        }
    }
}
