using AventStack.ExtentReports;
using CompetitiontaskProjectMars.Pages;
using CompetitiontaskProjectMars.TestModel;
using CompetitiontaskProjectMars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing.Imaging;



namespace CompetitiontaskProjectMars.Tests
{

    [TestFixture]
    public class Certification_Tests : CommonMethods.CommonDriver
    {
        private ExtentReports extent;
        private ExtentTest test;
        

        Login LoginPageObj;
        Certifications CertificationPageObj;
        public Certification_Tests()
        {
            LoginPageObj = new Login();
            CertificationPageObj = new Certifications();
        }
        [SetUp]
        public void CertficationSetUp()
        {
            extent = CommonMethods.ExtentReportsM.getReport();
            //Open Chrome browser
            driver = new ChromeDriver();
            //test.Log(Status.Info, "Chrome Browser Luanched");
            // Login page object initialization and definition
            LoginPageObj.LoginSteps();
        }
        [Test, Order(1)]
        public void DeleteExistingRecords_Test()

        {
            test = extent.CreateTest("DeleteExistingRecords_Test").Info("Test- Delete existing records Started");
            CertificationPageObj.DeleteExistingRecords();
            test.Pass("Test passed");
        }

        [Test, Order(2)]
        public void AddNewCertification_Test()

        {
            // Create an ExtentTest instance
            test = extent.CreateTest("AddNewCertification_Test").Info("Test- Add New Certification Started");
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

                
                    test.Log(Status.Pass, "Test Passed, Added certifcation successfully");
                
               
                Assert.That(input.certificateorAward, Is.EqualTo(actualCertificateName), "Actual Certifications and expected Certifications does not match.");
                
            }
        }
        [Test, Order(3)]
        public void InvalidCertificationDetails1_Test()
        {
            // Create an ExtentTest instance
            test = extent.CreateTest("InvalidCertificationDetails1_Test").Info("Test- InvalidCertificationDetails-Acceptance of more than 100 characters Started");
            List<Certification> item = CommonMethods.LoadJson.Read<Certification>("E:\\CompetitiontaskProjectMars\\CompetitiontaskProjectMars\\DataFiles\\InvalidCertificationDetails1.json");
            //try
            //{
                foreach (var input in item)
                {

                    string certificateName = input.certificateorAward;
                    Console.WriteLine(certificateName);

                    string certifiedFrom = input.certifiedFrom;
                    Console.WriteLine(certifiedFrom);
                    string certifiedYear = input.certifiedYear;
                    Console.WriteLine(certifiedYear);
                CertificationPageObj.AddNewCertification(input);
                //int l = certificateName.Length;
                //Assert.That(l <= 100, "Dont accept more than 100 chars");
                //Assert.Fail( "Dont accept more than 100 chars");
                string screenshotFolder = CommonMethods.CaptureScreenshot.SaveScreenshot(driver, "InvalidCertificationDetails1");
               
                   test.Log(Status.Fail, "ScreenshotInvalidCertificationDetails1", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotFolder).Build());
                
               
               
                //    test.Log(Status.Fail, e.ToString());
                //}

            }
            }
        [Test, Order(4)]
        public void InvalidCertificationDetails2_Test()
        {
            test = extent.CreateTest("InvalidCertificationDetails1_Test").Info("Test- InvalidCertificationDetails-special characters Started");
            List<Certification> item = CommonMethods.LoadJson.Read<Certification>("E:\\CompetitiontaskProjectMars\\CompetitiontaskProjectMars\\DataFiles\\InvalidCertificationDetails2.json");
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
        [Test, Order(5)]
        public void InvalidCertificationDetails3_Test()
        {
            test = extent.CreateTest("InvalidCertificationDetails1_Test").Info("Test- InvalidCertificationDetails-Numerics Started");
            List<Certification> item = CommonMethods.LoadJson.Read<Certification>("E:\\CompetitiontaskProjectMars\\CompetitiontaskProjectMars\\DataFiles\\InvalidCertificationDetails3.json");
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
        [Test, Order(6)]

        public void UpdateCertification_Test()

        {
            test = extent.CreateTest("InvalidCertificationDetails1_Test").Info("Test- Update Certification Started");
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
            test = extent.CreateTest("InvalidCertificationDetails1_Test").Info("Test- Delete Certification Started");
            List<Certification> item = CommonMethods.LoadJson.Read<Certification>("E:\\CompetitiontaskProjectMars\\CompetitiontaskProjectMars\\DataFiles\\DeleteCertificate.json");
            foreach (var deleteInput in item)
            {
                string certificateName = deleteInput.certificateorAward;
                Console.WriteLine(certificateName);
                string certifiedFrom = deleteInput.certifiedFrom;
                Console.WriteLine(certifiedFrom);
                string certifiedYear = deleteInput.certifiedYear;
                Console.WriteLine(certifiedYear);
                test.Pass("Test passed");
                CertificationPageObj.DeleteCertification(deleteInput);
                string deletedLanguage = CertificationPageObj.getDeletedCertificate();
                Assert.That(deletedLanguage != deleteInput.certificateorAward, "Expected language has not been deleted");

            }
        
        }

        [Test, Order(8)]
        public void CancelCertification_Test()
        {
            test = extent.CreateTest("InvalidCertificationDetails1_Test").Info("Test- Cancel Certification Started");
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