using AventStack.ExtentReports;

using CompetitiontaskProjectMars.Pages;
using CompetitiontaskProjectMars.TestModel;
using CompetitiontaskProjectMars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;


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
            CertificationPageObj.DeleteExistingRecords();
        }

        [Test, Order(2)]
        public void AddNewCertification_Test()

        {
            // Create an ExtentTest instance
            test = extent.CreateTest("AddNewCertification_Test").Info("Test Started");
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

                //if (input.certificateorAward==newRecordCertificateName)
                //{
                    test.Log(Status.Pass, "Test Passed, Added certifcation successfully");
                //    //CaptureScreenshot.SaveScreenshot(driver, "Certifications Record added");
                //    test.Info("Details", MediaEntityBuilder.CreateScreenCaptureFromPath("\\Screenshots\\" + "Certifications Record added" + ".png").Build());

                //}
               
                Assert.That(input.certificateorAward, Is.EqualTo(actualCertificateName), "Added Certifications and expected Certifications does not match.");
                
            }
        }
        [Test, Order(3)]
        public void InvalidCertificationDetails1_Test()
        {
            // Create an ExtentTest instance
            test = extent.CreateTest("InvalidCertificationDetails1_Test").Info("Test3 Started");
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
                    int s = certificateName.Length;
                    Assert.That(s <= 100, "Dont accept more than 100 chars");
                    //if (input.certificateorAward )
                    //{
                    //    test.Log(Status.Fail, "Test Failed, Not Added certifcation successfully");
                    //CaptureScreenshot.SaveScreenshot(driver, "Certifications Record added");
                //    if(s>=100)
                //{
                //    Assert.Fail("CertificateorAwardName field do not accept special characters");
                //    test.Info("Details", MediaEntityBuilder.CreateScreenCaptureFromPath("\\Screenshots\\" + "Certifications Record added" + ".png").Build()); }
                    

                    //    }
                    //}
                    //}
                    //catch (Exception e)
                    //{

                    //    test.Log(Status.Fail, e.ToString());
                    //}

                }
            }
        [Test, Order(4)]
        public void InvalidCertificationDetails2_Test()
        {

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
                string sub = "@%!&";

                if (input.certificateorAward.Contains(sub))
                {
                    Assert.Fail("CertificateorAwardName field do not accept special characters");
                }

            }
        }
        [Test, Order(5)]
        public void InvalidCertificationDetails3_Test()
        {

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
                string sub = "123";

                if (input.certificateorAward.Contains(sub))
                {
                    Assert.Fail("CertificateorAwardName field do not accept numerics");
                }


            }
        }
        [Test, Order(6)]

        public void UpdateCertification_Test()

        {
            List<Certification> item = CommonMethods.LoadJson.Read<Certification>("E:\\CompetitiontaskProjectMars\\CompetitiontaskProjectMars\\DataFiles\\UpdateCertificate.json");
            foreach (var updateInput in item)
            {
                string updatecertificateName = updateInput.certificateorAward;
                Console.WriteLine(updatecertificateName);
                string certifiedFrom = updateInput.certifiedFrom;
                Console.WriteLine(certifiedFrom);
                string certifiedYear = updateInput.certifiedYear;
                Console.WriteLine(certifiedYear);
                CertificationPageObj.EditCertification(updateInput);
            }
        }
        [Test, Order(7)]
        public void DeleteCertification_Test()
        {

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

            }
        
        }

        [Test, Order(8)]
        public void CancelCertification_Test()
        { 
              CertificationPageObj.CancelFunction();
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