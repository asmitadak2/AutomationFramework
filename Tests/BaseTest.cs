using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support;
using AutomationFramework.Common;
using System.Threading;

namespace AutomationFramework.Tests
{
    [TestFixture(BrowserType.Chrome, "https://localhost:4444/wd/hub")]
    [TestFixture(BrowserType.Edge, "https://localhost:4444/wd/hub")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class BaseTest
    {
        ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        
        BrowserType browserType;
        String huburl;
        public BaseTest(BrowserType browserType, String huburl)
        {
            this.browserType = browserType;
            this.huburl = huburl;
        }
        [SetUp]

        public void Setup()
        {
            IWebDriver webDriver;
           
#pragma warning disable CS8601 // Possible null reference assignment.
            webDriver = Browsers.CreateInstance(browserType);
            driver.Value = webDriver;   
#pragma warning restore CS8601 // Possible null reference assignment.
        }
        [TearDown]
        public void TearUp()
        {
            IWebDriver webDriver;
            webDriver=driver.Value;
            webDriver.Quit();
        }
        public IWebDriver GetWebDriver()
        {
            return driver.Value;
        }
    }
}
