using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationFramework.Common;
using AutomationFramework.Models;
using NUnit.Framework;
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
        static string carttablelocator = "//*[@id='cart']/ul/li[1]/table";
        string itemnamelocator = "/td[2]/a";
        string itemquantitylocator = "/td[3]";
        string itempricelocator = "/td[4]";
        static string additionalert = "//div[@class='alert alert-success alert-dismissible']";
        #endregion;

        #region page element locators    

        By Searchbox = By.XPath("//input[@placeholder='Search']");
        By Item = null;
        By addtocartBtn = null;
        By cartbtnloc = By.XPath("//span[@id='cart-total']/parent::button[@class='btn btn-inverse btn-block btn-lg dropdown-toggle']");
        By carttable = By.XPath(carttablelocator);
        By cartaddtionalert = By.XPath(additionalert);
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
        //public void SearchforItem(CartItem item)
        public void SearchforItem()
        {
            driver.Navigate().GoToUrl("https://tutorialsninja.com/demo/");
            
            List<CartItem> items = Models.CartItem.GetCartItems();
            foreach (CartItem item in items)
            {
                click(Searchbox);
                Type(Searchbox, item.ItemName);
                AddItemtoCart(item);
            }
          
            
        }
        public void AddItemtoCart(CartItem item)
        {
            //itemname= item.ItemName;
            //Item= By.XPath($"//a[normalize-space()='{itemname}']");
            Item = By.XPath(String.Format(itemname, item.ItemName));
            ScrollToView(Item, driver);
            addtocartBtn=By.XPath(String.Format(addtocartbtn, item.ItemName));
            ScrollToView(addtocartBtn, driver);
            //Thread.Sleep(3000);
            click(addtocartBtn);

        }
        public void verifycartItem()
        {
            Thread.Sleep(300); 
            
            //ScrollToView(cartbtnloc, driver);
            waitforvisivility(cartbtnloc, driver);
            click(cartbtnloc);
            string tablerow = carttablelocator + "/tbody/tr";
            string tablecol = tablerow + "/td";

            int rowcount=driver.FindElements(By.XPath(tablerow)).Count;
            int colcount= driver.FindElements(By.XPath(tablecol)).Count;
            List<CartItem> items = Models.CartItem.GetCartItems();

            for (int i=1; i<=rowcount; i++)
            {
                string rowlocator=tablerow+"["+i.ToString()+"]";
                string itemlocator = rowlocator + itemnamelocator;
                string quantity = rowlocator + itemquantitylocator;
                string price = rowlocator + itempricelocator;

                string itemname = driver.FindElement(By.XPath(itemlocator)).Text;
                string quantityvalue = driver.FindElement(By.XPath(quantity)).Text;
                string pricevalue=driver.FindElement(By.XPath(price)).Text;
                Assert.That(items[i-1].ItemName, Is.EqualTo(itemname)); 
            }

        }


    }
}
