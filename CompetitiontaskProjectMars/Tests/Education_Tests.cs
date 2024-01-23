using CompetitiontaskProjectMars.Pages;
using CompetitiontaskProjectMars.TestModel;
using CompetitiontaskProjectMars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitiontaskProjectMars.Tests
{
    [TestFixture]
    public class Education_Tests : CommonDriver
    {
        Login LoginPageObj;
        Educations EducationPageObj;
        public Education_Tests()
        {
            LoginPageObj = new Login();
            EducationPageObj = new Educations();
        }
        [SetUp]
        public void CertficationSetUp()
        {
            //Open Chrome browser
            driver = new ChromeDriver();
            // Login page object initialization and definition
            LoginPageObj.LoginSteps();
        }
        [Test, Order(1)]
        public void DeleteExistingRecords_Test()

        {
            EducationPageObj.DeleteExistingRecords();
        }

        [Test, Order(2)]
        public void AddNewEducation_Test()

        {
            EducationPageObj.AddNewEducation();
            string expectedMessge = "Education has been added";
            string actualMessage = EducationPageObj.getMessage();
            Assert.That(actualMessage == expectedMessge, "Actual message and expected message do not match");
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();

        }
    }
}