using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using System.Drawing.Imaging;
using Newtonsoft.Json;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using MongoDB.Driver;

namespace CompetitiontaskProjectMars.Utilities
{
    //CommonDriver
    #region driver
    public class CommonMethods
    {
        public class CommonDriver

        {
            public static IWebDriver driver;

        }

        #endregion

        //LoadJson
        #region loadjson
        public class LoadJson
        {
            public static List<T> Read<T>(string filePath)
            {
                string text = File.ReadAllText(filePath);
                List<T> testData = JsonConvert.DeserializeObject<List<T>>(text);
                return testData;
            }
        }
        #endregion

        //ExtentReports
        #region reports
        public class ExtentReportsM
        {
            private static ExtentReports extent;

            public static ExtentReports getReport()

            {
                var htmlReporter = new ExtentHtmlReporter(@"E:\CompetitiontaskProjectMars\CompetitiontaskProjectMars\Reports\index.html");
                htmlReporter.Config.ReportName = "AUTOMATION STATUS REPORT";
                htmlReporter.Config.DocumentTitle = "AUTOMATION STATUS REPORT";
                htmlReporter.Start();
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
                extent.AddSystemInfo("Application", "Project Mars");
                extent.AddSystemInfo("Browser", "Chrome");
                extent.AddSystemInfo("OS", "Windows");
                return extent;
            }

        }
        #endregion

        //Screenshots
        #region screenshots
        public class CaptureScreenshot
        {
            public static string SaveScreenshot(IWebDriver driver, string ScreenShotFileName)
            {
                //To take screenshot
                ITakesScreenshot screenshotDriver = (ITakesScreenshot)driver;
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                string screenshotTitle = Path.Combine($"{ScreenShotFileName}" + DateTime.Now.ToString("_yyyy_MM_dd_HH_mm_ss"));
                string screenshotFolderLocation = Path.Combine(@"E:\CompetitiontaskProjectMars\CompetitiontaskProjectMars\Screenshots", screenshotTitle);
                //To save screenshot
                screenshot.SaveAsFile(screenshotFolderLocation + ImageFormat.Png);
                return screenshotFolderLocation;

            }


        }
       
    #endregion

  
        //Element present
        #region wait
        public class Wait
        {
            public static void WaitToBeClickable(IWebDriver driver, string locatorType, string locatorValue, int seconds)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
                if (locatorType == "XPath")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locatorValue)));
                }
                if (locatorType == "Id")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(locatorValue)));
                }
                if (locatorType == "CssSelector")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(locatorValue)));
                }
            }
            public static void WaitToExist(IWebDriver driver, string locatorType, string locatorValue, int seconds)
            {

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds)); //line2
                if (locatorType == "XPath")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(locatorValue)));
                }
                if (locatorType == "Id")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(locatorValue)));
                }
                if (locatorType == "CssSelector")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(locatorValue)));
                }

            }

            public static void WaitToBeVisible(IWebDriver driver, string locatorType, string locatorValue, int seconds)
            {

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds)); //line2
                if (locatorType == "XPath")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(locatorValue)));
                }
                if (locatorType == "Id")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(locatorValue)));
                }
                if (locatorType == "CssSelector")
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(locatorValue)));
                }

            }

            internal static void WaitToBeClickable(IWebDriver driver, string v1, string v2)
            {
                throw new NotImplementedException();
            }
        }
        #endregion

    }
}













//https://www.youtube.com/@QAFox/search?query=screenshots%20in%20extent%20report%20c%23




//public class LoadJson
//{

//    public static T Read<T>(string filePath)
//    {
//        string text = File.ReadAllText(filePath);
//        return JsonConvert.DeserializeObject<T>(text);

//    }
//}


//Or, if you prefer something simpler/synchronous:

//class Program
//{
//    static void Main()
//    {
//        Item item = JsonFileReader.Read<Item>(@"C:\myFile.json");
//    }
//}

//public static class JsonFileReader
//{
//    public static T Read<T>(string filePath)
//    {
//        string text = File.ReadAllText(filePath);
//        return JsonSerializer.Deserialize<T>(text);
//    }
//}
//List<type> list = new List<type>() 
//https://code-maze.com/csharp-read-and-process-json-file/#:~:text=First%2C%20we%20use%20a%20StreamReader,data%20in%20the%20JSON%20file.