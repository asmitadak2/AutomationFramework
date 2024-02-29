using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Resources
{
    public class Utility
    {
        public static String GetProjectRootDirectory()
        {
            string currentdirectory=Directory.GetCurrentDirectory();
            return currentdirectory.Split("bin")[0];
        }
    }
}
