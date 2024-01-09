using AventStack.ExtentReports;
using AventStack.ExtentReports.Configuration;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using RazorEngine.Compilation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Resources
{
    public class ExtentService
    {
        public ExtentReports extentReports;
        public Utility utility;
       
        
        public ExtentReports GetExtentReports() { 
            if(extentReports==null) { 
                extentReports = new ExtentReports();
                string ReportDir = Path.Combine(utility.GetProjectRootDirectory(),"Report");
                if(!Directory.Exists(ReportDir))
                {
                    Directory.CreateDirectory(ReportDir);   
                }
                String path = Path.Combine(ReportDir, "index.html");
                var reporter = new ExtentHtmlReporter(path);
                reporter.Config.DocumentTitle = "Framework Report";  
                reporter.Config.ReportName = "Test Automation Report";
                reporter.Config.Theme = Theme.Standard;
                extentReports.AttachReporter(reporter);
            }
            return extentReports;
        }
    }
}
