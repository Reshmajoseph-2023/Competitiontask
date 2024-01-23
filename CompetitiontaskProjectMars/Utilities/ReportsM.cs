using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompetitiontaskProjectMars.Utilities;

namespace CompetitiontaskProjectMars.Utilities
{
    //ExtentReports

    public class ReportsM
    {


        private static ExtentReports extent;
        
        public static ExtentReports getReport()

        {
            
                
            var htmlReporter = new ExtentHtmlReporter("E:\\CompetitiontaskProjectMars\\CompetitiontaskProjectMars\\Reports\\");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
          
            return extent;
        }

    }
}

//https://chat.openai.com/c/25121400-6060-47ed-9a94-43250da991ba