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
using AutomationFramework.Resources;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.DevTools.V117.Page;
using AventStack.ExtentReports;

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
        ExtentTest test;
        //IWebDriver webDriver;
        public BaseTest(BrowserType browserType, String huburl)
        {
            this.browserType = browserType;
            this.huburl = huburl;
        }
        [OneTimeSetUp]
        public void OneTimeSetup() {
            ExtentManager.createParenttest(GetType().Name, $"{browserType}");
        }
        [OneTimeTearDown] public void OneTimeTearDown()
        {
            ExtentService.GetExtent().Flush();
        }
        [SetUp]

        public void Setup()
        {
            test=ExtentManager.createtest(TestContext.CurrentContext.Test.Name);

            test.Info($"{browserType}");
            IWebDriver webDriver;
           
#pragma warning disable CS8601 // Possible null reference assignment.
            webDriver = Browsers.CreateInstance(browserType);
            driver.Value = webDriver;   
#pragma warning restore CS8601 // Possible null reference assignment.
        }
        [TearDown]
        public void TearUp()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var errormessage = string.IsNullOrEmpty(TestContext.CurrentContext.Result.Message) ? "" : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.Message);
                var stackTrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? "" : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.StackTrace);
                switch (status)
                {
                    case TestStatus.Failed:
                        ReportLog.Fail("Test Failed");
                        ReportLog.Fail(errormessage);
                        ReportLog.Fail(stackTrace);
                        ReportLog.Fail("Screenshot", CaptureScreenshot(TestContext.CurrentContext.Test.Name));
                        break;
                    case TestStatus.Passed:
                        
                        ReportLog.Pass("Screenshot", CaptureScreenshot(TestContext.CurrentContext.Test.Name));
                        break;
                    case TestStatus.Skipped:
                        ReportLog.Skip("Test skippeed");
                        break;
                    default:
                        break;

                }
            }
            catch (Exception e)
            {

                throw new Exception("Exception:" + e);
            }
            finally
            {
                IWebDriver webDriver;
                webDriver = driver.Value;
                webDriver.Quit();
            }
           
        }
        public IWebDriver GetWebDriver()
        {
            return driver.Value;
        }
        public MediaEntityModelProvider CaptureScreenshot(String name)
        {
            IWebDriver webDriver;
            webDriver = driver.Value;
            var screenshot=((ITakesScreenshot)webDriver).GetScreenshot().AsBase64EncodedString;   
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot,name).Build();
        }
    }
}
