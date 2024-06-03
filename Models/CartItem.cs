using AutomationFramework.DataReaders;
using AutomationFramework.Resources;
using RazorEngine.Compilation.ImpromptuInterface.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Models
{
    public class CartItem
    {

        public string ItemString { get; set; }  = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        //public string ItemString;
        //public string ItemName;


        //public CartItem(String ItemString, String ItemName)
        //{
        //    this.ItemString = ItemString;
        //    this.ItemName = ItemName;
        //}
        //public String get_ItemString{get{ return this.ItemString; } }
        //public String get_ItemName { get{ return this.ItemName; } }

        //public static CartItem[] Whattosearch()
        //{

        //    CartItem[] myArray = new CartItem[] { new CartItem("iPhone", "iPhone"), new CartItem("Canon EOS 5D", "Canon EOS 5D") };
        //    return myArray;
        //}
        public static CartItem[] Whattosearch()
        {
            ItemListReader reader=new ItemListReader("C:\\Users\\asadak\\source\\repos\\AutomationFramework\\JSONS\\ItemList.json");
            List<CartItem> cartitemlist=reader.ReadCartItemsfromJSON();
            CartItem[] items= cartitemlist.ToArray();
            return items;


        }
    }
}
