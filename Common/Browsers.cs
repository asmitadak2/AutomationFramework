using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using AutomationFramework.Common;
using AutomationFramework.Resources;

namespace AutomationFramework.Common
{
    public class Browsers
    {


        private static ThreadLocal<IWebDriver>? driver =new ThreadLocal<IWebDriver>();
        public static String remote_url = "http://localhost:4445/";
        public static IWebDriver CreateInstance(BrowserType browserType)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            IWebDriver driver = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            switch (browserType)
            {
                case BrowserType.Chrome:
                    var chromeoptions=new ChromeOptions();
                    driver = new ChromeDriver(chromeoptions);
                    break;
                case BrowserType.Edge:
                    var options = new EdgeOptions();
                    driver = new EdgeDriver(options);
                    break;
                case BrowserType.Firefox:
                    driver = new FirefoxDriver();
                    break;
                case BrowserType.Opera:
                    break;
            }

            return driver;
        }

        public static IWebDriver CreateInstance(BrowserType browserType, string hubUrl)
        {
            IWebDriver driver = null;
            TimeSpan timeSpan = new TimeSpan(0, 3, 0);

            switch (browserType)
            {
                case BrowserType.Chrome:
                    ChromeOptions chromeOptions = new ChromeOptions();
                    driver = GetWebDriver(hubUrl, chromeOptions.ToCapabilities());
                    ReportLog.Pass("Chrome Initialised successfully");
                    break;
                case BrowserType.Edge:
                    EdgeOptions options = new EdgeOptions();
                    driver = GetWebDriver(hubUrl, options.ToCapabilities());
                    ReportLog.Pass("Edge Initialised successfully");
                    break;
                case BrowserType.Firefox:
                    FirefoxOptions firefoxOptions = new FirefoxOptions();
                    driver = GetWebDriver(hubUrl, firefoxOptions.ToCapabilities());
                    ReportLog.Pass("Firefox Initialised successfully");
                    break;
                
            }

            return driver;
        }

        private static IWebDriver GetWebDriver(string hubUrl, ICapabilities capabilities)
        {
            TimeSpan timeSpan = new TimeSpan(0, 3, 0);
            return new RemoteWebDriver(
                        new Uri(hubUrl),
                        capabilities,
                        timeSpan
                    );
        }





    }
}
