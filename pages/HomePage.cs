﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationFramework.Common;
using AutomationFramework.Resources;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;


namespace AutomationFramework.pages
{
    public class HomePage:BasePage
    {
        IWebDriver driver;
        By searchbox = By.Name("q");

        public HomePage(IWebDriver driver):base(driver)
        {
            this.driver = driver;
        }

        //public void ValidateURL(IWebElement url) //IWebElement
        //{
        //    String anything = url.GetAttribute("text");
        //    if (string.IsNullOrEmpty(anything))
        //    {
        //        Assert.Fail();
        //    }
        //    click(url);

        //}

        internal void googleit(TestData testData)
        {
            driver.Navigate().GoToUrl("https://www.google.com");
           // driver.Navigate().GoToUrl(testData.searchstring);
            driver.Manage().Window.Maximize();
            Type(searchbox, testData.searchstring);
            if (searchbox != null)
            {
                Assert.Pass();
            }else
                Assert.Fail();
            //driver.FindElement(By.Name("q")).SendKeys("I Want to se this on a remote machine");
        }
       
        internal void bingit()
        {
            driver.Navigate().GoToUrl("https://www.bing.com");
            //ReportLog.Pass("User is in URL");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Name("q")).SendKeys("I Want to se this on a remote machine");
            if (searchbox != null)
            {
                Assert.Pass();
            }
            else
                Assert.Fail();
        }
    }

    
}
