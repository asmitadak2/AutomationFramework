using AutomationFramework.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AutomationFramework.DataReaders
{
    public class ItemListReader
    {
        private readonly string _sampleJsonFilePath;

        public ItemListReader(string _sampleJsonFilePath)
        {
            this._sampleJsonFilePath = _sampleJsonFilePath;    
        }
        public List<CartItem> ReadCartItemsfromJSON()
        {
            using StreamReader reader = new(_sampleJsonFilePath);
            var json = reader.ReadToEnd();
            List<CartItem> items = JsonConvert.DeserializeObject<List<CartItem>>(json);
            return items;
        }
    
    }
}
