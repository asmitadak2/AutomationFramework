using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationFramework.Common;
using AutomationFramework.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationFramework.pages
{
    public class EcommerceHome:BasePage
    {
        IWebDriver driver;
        By Searchbox = By.XPath("//input[@placeholder='Search']");
        By Item=By.XPath($"//*[@class='product-thumb']//h4//a[normalize-space(text()) = 'itemname']");

        public EcommerceHome(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void SearchforItem(CartItem item)
        {
            
        }
        public void AddItemtoCart(CartItem item)
        {

        }

    }
}
