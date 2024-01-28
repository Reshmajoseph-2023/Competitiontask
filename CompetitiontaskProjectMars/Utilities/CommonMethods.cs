using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using System.Drawing.Imaging;
using Newtonsoft.Json;

namespace CompetitiontaskProjectMars.Utilities
{
    public class CommonMethods
    {
        //CommonDriver
        #region driver
        public class CommonDriver
        {

            //Initialize the browser
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
                extent.AddSystemInfo("Application", "ProjectMars");
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
                ITakesScreenshot screenshotDriver = (ITakesScreenshot)driver;
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                string screenshotTitle = Path.Combine("Screenshots", $"{ScreenShotFileName}" + DateTime.Now.ToString("_dd-mm-yyyy_mss"));
                string screenshotFolderLocation = Path.Combine(@"E:\CompetitiontaskProjectMars\CompetitiontaskProjectMars", screenshotTitle);
                screenshot.SaveAsFile(screenshotFolderLocation + ImageFormat.Png);
                return screenshotFolderLocation;

            }
        }
        #endregion
        
    }
}



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