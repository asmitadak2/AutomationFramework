using AutomationFramework.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.pages
{
    public class BasePage
    {
        
        IWebDriver driver;
        public BasePage(IWebDriver driver) {
        this.driver = driver;
        }
        

        public void click(By keyword)
        {
            IWebElement element = driver.FindElement(keyword);
            try
            {
                element.Click();
                Console.WriteLine("Clicking on an Element : " + element);
                // ExtentListeners.test.log(Status.INFO, "Clicking on an Element : " + locatorKey);
            }
            catch (Exception t)
            {

                Console.WriteLine("Error while Clicking on an Element : " + element + " error message : " + t.Message);
                //ExtentListeners.test.log(Status.FAIL,
                // "Error while Clicking on an Element : " + locatorKey + " error message : " + t.Message);
                Assert.Fail(t.Message);

            }

        }
        public void ScrollToView(By keyword, IWebDriver driver)
        {
            IWebElement element = driver.FindElement(keyword);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            // Scrolling down the page till the element is found		
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            string xpathvariable = string.Empty;
            try
            {
                js.ExecuteScript("arguments[0].scrollIntoView();", element);
                Console.WriteLine("element in view : " + element);
                //ExtentListeners.test.log(Status.INFO,
                //        "typing in an Element : " + locatorKey + " entered the value as : " + value);
            }
            catch (Exception t)
            {

                Console.WriteLine("Error while scrolling to element: " + element + " error message : " + t.Message);
                //ExtentListeners.test.log(Status.FAIL,
                //        "Error while typing in an Element : " + locatorKey + " error message : " + t.getMessage());
                Assert.Fail(t.Message);

            }


        }
        public void SelectAllcheckboxes(By Keyword)
        {
            IList<IWebElement> webElements = driver.FindElements(Keyword);
            try
            {
                foreach (IWebElement element in webElements)
                {
                    element.Click();
                    Console.WriteLine(element + ": is clicked");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("failed to click");
                Assert.Fail(e.Message);
            }
        }
        //public IWebElement GetWebElement(By name)
        //{
        //    return driver
        //}

        public void Type(By keyword, string value)
        {
            IWebElement element= driver.FindElement(keyword);
            try
            {
                element.Clear();
                element.SendKeys(value);
                Console.WriteLine(element + "is clicked: " + value + " is entered");
            }
            catch (Exception e)
            {

                Console.WriteLine("failed");
                Assert.Fail(e.Message);
            }
        }
        

    }
}
