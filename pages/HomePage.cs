using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationFramework.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;


namespace AutomationFramework.pages
{
    public class HomePage:BasePage
    {
        IWebDriver driver;


        public HomePage(IWebDriver driver):base(driver)
        {
            this.driver = driver;
        }

        public void ValidateURL(IWebElement url) //IWebElement
        {
            String anything=url.GetAttribute("text");
            if (string.IsNullOrEmpty(anything)) {
                Assert.Fail();
            }
            click(url);
           
        }

        internal void googleit()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Name("q")).SendKeys("I Want to se this on a remote machine");
        }
    }
}
