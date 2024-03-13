using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Resources
{
    public class TestData
    {
        public string searchstring;
        public TestData(String searchstring)
        {
             this.searchstring = searchstring;   
        }
        public static TestData[] Whattosearch()
        {
            
            TestData[] myArray = new TestData[] { new TestData("search anything"), new TestData("search anything2") };
            return myArray;
        }
    }
    
}
