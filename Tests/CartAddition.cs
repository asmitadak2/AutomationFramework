using AutomationFramework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationFramework.Resources;
using AutomationFramework.Models;
using AutomationFramework.pages;

namespace AutomationFramework.Tests
{
    public class CartAddition:BaseTest
    {
        BrowserType browserType;
        String huburl;
        public CartAddition( BrowserType browserType,String huburl):base(browserType,huburl) { 
            this.browserType = browserType; this.huburl = huburl;   
        }
        
        [Test]
        //[TestCaseSource(typeof(CartItem), nameof(CartItem.Whattosearch))]
        //public void AddtoCart(CartItem cartItem) 
        public void AddtoCart()
        {
            EcommerceHome ecommerceHome = new EcommerceHome(GetWebDriver());
            //ecommerceHome.SearchforItem(item);
            ecommerceHome.SearchforItem();
            //ecommerceHome.AddItemtoCart(item);
            //ecommerceHome.AddItemtoCart();
            ecommerceHome.verifycartItem();
        }
        

    }
}
