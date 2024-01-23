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
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace CompetitiontaskProjectMars.Tests
{

    [TestFixture]
    public class Certification_Tests : CommonDriver
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
            extent = ReportsM.getReport();
            //Open Chrome browser
            driver = new ChromeDriver();
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
            test = extent.CreateTest("AddNewCertification_Test").Info("Test Started");
            test.Pass("Test passed");
            CertificationPageObj.AddNewCertification();
            string expectedmessage = "DB administration has been added to your certification";
            string actualMessage = CertificationPageObj.getMessage();
            Assert.That(actualMessage == expectedmessage, "Actual message and expected message do not match");
           
        }
        [Test, Order(3)]
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