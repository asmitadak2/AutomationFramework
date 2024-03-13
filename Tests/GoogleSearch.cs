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
    
    public class GoogleSearch : BaseTest
    {
        BrowserType browserType;
        String huburl;
        public GoogleSearch(BrowserType browserType, string huburl) : base(browserType, huburl)
        {
            this.browserType = browserType;
            this.huburl = huburl;
        }
        [Test]
        [TestCaseSource(typeof(TestData), nameof(TestData.Whattosearch))]
        public void OpenGoogleAndSearch(TestData testData)
        {
            HomePage homepage=new(GetWebDriver());
            homepage.googleit(testData);
            //GetWebDriver().Navigate().GoToUrl("https://www.google.com");
            //GetWebDriver().Manage().Window.Maximize();
            //GetWebDriver().FindElement(By.Name("q")).SendKeys("I Want to se this on a remote machine");
        }
        [Test]
        [TestCaseSource(typeof(TestData), nameof(TestData.Whattosearch))]
        public void SearchGoogle(TestData testData)
        {
            HomePage homepage = new(GetWebDriver());
            homepage.googleit(testData);
        }

    }

}

