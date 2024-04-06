using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationFramework.Common;
using AutomationFramework.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V117.DOMStorage;
using OpenQA.Selenium.Support.UI;
using RazorEngine.Compilation.ImpromptuInterface;

namespace AutomationFramework.pages
{
    public class EcommerceHome:BasePage
    {
      
        IWebDriver driver;

        #region variables for dynamic locators  
        static string itemname = "default";
        static string itemstring= "default";
        #endregion

        #region page element locators    
        By Searchbox = By.XPath("//input[@placeholder='Search']");
        By Item = null;
        By addtocartBtn = null;
        #endregion
        public EcommerceHome(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }
        //public String GetItemName(CartItem item)
        //{
        //    return item.get_ItemName;
        //}
        //public String GetItemString(CartItem item)
        //{
        //    return item.get_ItemString;
        //}

        public void SearchforItem(CartItem item)
        {
            driver.Navigate().GoToUrl("https://tutorialsninja.com/demo/");
            click(Searchbox);
            Type(Searchbox, item.ItemName);
        }
        public void AddItemtoCart(CartItem item)
        {
            itemname= item.ItemName;
            Item = By.XPath($"//a[normalize-space()='{itemname}']");
            ScrollToView(Item, driver);
            addtocartBtn=By.XPath($"//a[normalize-space()='{itemname}'] //ancestor::div[@class='caption']//following-sibling::div//i[@class='fa fa-shopping-cart']");
            ScrollToView(addtocartBtn, driver);
            Thread.Sleep(3000);
            click(addtocartBtn);

        }


    }
}
