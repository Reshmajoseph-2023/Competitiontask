using AventStack.ExtentReports;
using CompetitiontaskProjectMars.Pages;
using CompetitiontaskProjectMars.TestModel;
using CompetitiontaskProjectMars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Buffers.Text;
using System.Drawing.Imaging;
using System.Linq.Expressions;
using System.Xml.Linq;


namespace CompetitiontaskProjectMars.Tests
{
   
    [TestFixture]
    public class Certification_Tests : CommonMethods.CommonDriver
    {
         
        Login LoginPageObj;
        Certifications CertificationPageObj;

        public static ExtentTest test;
        public static ExtentReports extent= CommonMethods.ExtentReportsM.getReport();
        public Certification_Tests()
        {
            LoginPageObj = new Login();
            CertificationPageObj = new Certifications();

        }
        [OneTimeSetUp]
        public static void ExtentStart()
        {
            CommonMethods.ExtentReportsM.getReport();
        }
        [OneTimeTearDown]
        public static void ExtentClose()
        {
            extent.Flush();
        }


        [SetUp]
        public void CertficationSetUp()
        {
            driver = new ChromeDriver();
            LoginPageObj.LoginSteps();
        }

        [Test, Order(1)]
        public void DeleteExistingRecords_Test()

        {
            test = extent.CreateTest("DeleteExistingRecords_Test").Info("Test1 Started- Deleting existing certification records ");
            CertificationPageObj.DeleteExistingRecords();
            Console.WriteLine("Existing certification records are deleted successfully");
            test.Pass("Test passed");
        }

        [Test, Order(2)]
        public void AddNewCertification_Test()

        {
            // Create an ExtentTest instance
            test = extent.CreateTest("AddNewCertification_Test").Info("Test2- Add New Certification record Started");
            List<Certification> item = CommonMethods.LoadJson.Read<Certification>("E:\\CompetitiontaskProjectMars\\CompetitiontaskProjectMars\\DataFiles\\AddValidCertificationDetails.json");
            foreach (var  input in item)
            {
                string certificateName = input.certificateorAward;
                Console.WriteLine(certificateName);
                string certifiedFrom = input.certifiedFrom;
                Console.WriteLine(certifiedFrom);
                string certifiedYear = input.certifiedYear;
                Console.WriteLine(certifiedYear);
                CertificationPageObj.AddNewCertification(input);
                string actualCertificateName = CertificationPageObj.GetCertificateName();
                test.Log(Status.Pass, "Test Passed");
                Assert.That(input.certificateorAward, Is.EqualTo(actualCertificateName), "Actual Certification and expected Certification does not match.");
                
            }
        }

        [Test, Order(3)]
        public void InvalidCertificationDetails1_Test()
        {
            
            // Create an ExtentTest instance
            test = extent.CreateTest("InvalidCertificationDetails1_Test").Info("Test3 Started- InvalidCertificationDetails-Acceptance of more than 100 characters ") ;
            List<Certification> item = CommonMethods.LoadJson.Read<Certification>("E:\\CompetitiontaskProjectMars\\CompetitiontaskProjectMars\\DataFiles\\InvalidCertificationDetails1.json");
            try
            {
                foreach (var input in item)
                {

                    string certificateName = input.certificateorAward;
                    Console.WriteLine(certificateName);
                    string certifiedFrom = input.certifiedFrom;
                    Console.WriteLine(certifiedFrom);
                    string certifiedYear = input.certifiedYear;
                    Console.WriteLine(certifiedYear);
                    CertificationPageObj.AddNewCertification(input);
                    int l = certificateName.Length;
                    if (l >= 100)
                    {
                       Assert.Fail("More than 100 chars are not allowed");
                    }
                    
                }
            }
            catch (Exception e)

            {
                //Log screenshot
                string screenshotFolder = CommonMethods.CaptureScreenshot.SaveScreenshot(driver, "100 chars-InvalidCertificationDetails1");
                test.Log(Status.Fail, "Screenshot of accepting more than 100characters", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotFolder + ImageFormat.Png).Build());
              
                //Log error into extent reports
                test.Log(Status.Fail, e.ToString());
               
            }
         }

        [Test, Order(4)]
        public void InvalidCertificationDetails2_Test()
        {
            test = extent.CreateTest("InvalidCertificationDetails2_Test").Info("Test4 Started- InvalidCertificationDetails-special characters ");
            List<Certification> item = CommonMethods.LoadJson.Read<Certification>("E:\\CompetitiontaskProjectMars\\CompetitiontaskProjectMars\\DataFiles\\InvalidCertificationDetails2.json");
            try
            {
                foreach (var input in item)
                {

                   string certificateName = input.certificateorAward;

                   Console.WriteLine(certificateName);
                   string certifiedFrom = input.certifiedFrom;
                   Console.WriteLine(certifiedFrom);
                   string certifiedYear = input.certifiedYear;
                   Console.WriteLine(certifiedYear);
                   CertificationPageObj.AddNewCertification(input);
                   
                   string chars = "@%!&";
                   if (input.certificateorAward.Contains(chars) || input.certifiedFrom.Contains(chars))
                   {
                    Assert.Fail("Special characters are not allowed");
                   }

                }
            }
            catch (Exception e)

            {
                //Log screenshot
                string screenshotFolder = CommonMethods.CaptureScreenshot.SaveScreenshot(driver, "Special characters-InvalidCertificationDetails2");
                test.Log(Status.Fail, "Screenshot of accepting special characters", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotFolder + ImageFormat.Png).Build());
                //Log error into extent reports
                test.Log(Status.Fail, e.ToString());

            }
        }

        [Test, Order(5)]
        public void InvalidCertificationDetails3_Test()
        {
            test = extent.CreateTest("InvalidCertificationDetails3_Test").Info("Test5 Started- InvalidCertificationDetails-Numerics ");
            List<Certification> item = CommonMethods.LoadJson.Read<Certification>("E:\\CompetitiontaskProjectMars\\CompetitiontaskProjectMars\\DataFiles\\InvalidCertificationDetails3.json");
            try
            {
                foreach (var input in item)
                {

                string certificateName = input.certificateorAward;

                Console.WriteLine(certificateName);
                string certifiedFrom = input.certifiedFrom;
                Console.WriteLine(certifiedFrom);
                string certifiedYear = input.certifiedYear;
                Console.WriteLine(certifiedYear);
                CertificationPageObj.AddNewCertification(input);
                
                string num = "123";

                if (input.certificateorAward.Contains(num)|| input.certifiedFrom.Contains(num))
                {
                   Assert.Fail("Numerics are not allowed");
                }

                }
            }
            
            catch (Exception e)
            {
                //Log screenshot
                string screenshotFolder = CommonMethods.CaptureScreenshot.SaveScreenshot(driver, "Numerics-InvalidCertificationDetails3");
                test.Log(Status.Fail, "Screenshot of accepting numerics", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotFolder + ImageFormat.Png).Build());
                //Log error into extent reports
                test.Log(Status.Fail, e.ToString());


            }
        }

        [Test, Order(6)]
        public void UpdateCertification_Test()

        {
            test = extent.CreateTest("UpdateCertification_Test").Info("Test6 Started- Update Certification ");
            List<Certification> item = CommonMethods.LoadJson.Read<Certification>("E:\\CompetitiontaskProjectMars\\CompetitiontaskProjectMars\\DataFiles\\UpdateCertificate.json");
            foreach (var updateInput in item)
            {
                string updatecertificateName = updateInput.certificateorAward;
                Console.WriteLine(updatecertificateName);
                string certifiedFrom = updateInput.certifiedFrom;
                Console.WriteLine(certifiedFrom);
                string certifiedYear = updateInput.certifiedYear;
                Console.WriteLine(certifiedYear);
                test.Pass("Test passed");
                CertificationPageObj.EditCertification(updateInput);
            }
        }

        [Test, Order(7)]
        public void DeleteCertification_Test()
        {
            test = extent.CreateTest("DeleteCertification_Test").Info("Test7 Started- Delete Certification ");
            List<Certification> item = CommonMethods.LoadJson.Read<Certification>("E:\\CompetitiontaskProjectMars\\CompetitiontaskProjectMars\\DataFiles\\DeleteCertificate.json");
            foreach (var deleteInput in item)
            {
                string certificateName = deleteInput.certificateorAward;
                Console.WriteLine(certificateName);
                string certifiedFrom = deleteInput.certifiedFrom;
                Console.WriteLine(certifiedFrom);
                string certifiedYear = deleteInput.certifiedYear;
                Console.WriteLine(certifiedYear);
                
                CertificationPageObj.DeleteCertification(deleteInput);
                string deletedLanguage = CertificationPageObj.getDeletedCertificate();
                Assert.That(deletedLanguage != deleteInput.certificateorAward, "Expected language has not been deleted");

                if (deleteInput.certificateorAward != "Database")
                {
                    test.Log(Status.Fail, "Test Failed, Element to delete does not found");
                }
                else
                {
                    test.Log(Status.Pass, "Test Passed");
                }

            }

        }

        [Test, Order(8)]
        public void CancelCertification_Test()
        {
            test = extent.CreateTest("InvalidCertificationDetails1_Test").Info("Test8 Started- Cancel Certification ");
            CertificationPageObj.CancelFunction();
            test.Pass("Test passed");
            CertificationPageObj.AssertionCancel();
                   
        }

       [TearDown]
        public void TearDown()
            
        {
            driver.Quit();
            // Flush the ExtentReports instance
            extent.Flush();
        }
    }
    
}