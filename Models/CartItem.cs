using AutomationFramework.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Models
{
    public class CartItem
    {
        public string ItemString;
        public string ItemName;
       

        public CartItem(String ItemString,String ItemName)
        {
            this.ItemString = ItemString;
            this.ItemName = ItemName;
        }
        public static CartItem[] Whattosearch()
        {

            CartItem[] myArray = new CartItem[] { new CartItem("search anything","anything"), new CartItem("search anything2", "anything" ) };
            return myArray;
        }
    }
}
