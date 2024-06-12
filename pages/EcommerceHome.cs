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
        string itemname = "//a[normalize-space()='{0}']";
        string addtocartbtn = "//a[normalize-space()='{0}'] //ancestor::div[@class='caption']//following-sibling::div//i[@class='fa fa-shopping-cart']";
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
            //itemname= item.ItemName;
            //Item= By.XPath($"//a[normalize-space()='{itemname}']");
            Item = By.XPath(String.Format(itemname, item.ItemName));
            ScrollToView(Item, driver);
            addtocartBtn=By.XPath(String.Format(addtocartbtn, item.ItemName));
            ScrollToView(addtocartBtn, driver);
            Thread.Sleep(3000);
            click(addtocartBtn);

        }


    }
}
