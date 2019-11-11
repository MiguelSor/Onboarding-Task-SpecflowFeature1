using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowPages
{
    public class ConstantUtils
    {
        //Base Url
        public static string Url = "http://www.skillswap.pro/";

        //ScreenshotPath

        public static string ScreenshotPath = AppDomain.CurrentDomain.BaseDirectory.Replace(@"SpecflowTests\bin\Debug", @"SpecflowPages\TestReports\Screenshots\");

        //ExtentReportsPath
        public static string ReportsPath = AppDomain.CurrentDomain.BaseDirectory.Replace(@"SpecflowTests\bin\Debug", @"SpecflowPages\TestReports\Test.html");

        //ReportXML Path
        public static string ReportXMLPath = AppDomain.CurrentDomain.BaseDirectory.Replace(@"SpecflowTests\bin\Debug", @"SpecflowPages\TestReports\ReportXML.xml");



    }
}
