using CompetitiontaskProjectMars.Pages;
using CompetitiontaskProjectMars.TestModel;
using CompetitiontaskProjectMars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using AventStack.ExtentReports;

namespace CompetitiontaskProjectMars.Tests
{
    [TestFixture]
    public class Education_Tests : CommonMethods.CommonDriver
    {
        private ExtentReports extent;
        private ExtentTest test;

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
            extent = CommonMethods.ExtentReportsM.getReport();
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
            // Create an ExtentTest instance
            test = extent.CreateTest("AddNewCertification_Test").Info("Test Started");

            List<Education> item = CommonMethods.LoadJson.Read<Education>("E:\\CompetitiontaskProjectMars\\CompetitiontaskProjectMars\\DataFiles\\AddEducation.json");

            foreach (var input in item)
            {
                string UniversityName = input.UniversityName;
                Console.WriteLine(UniversityName);
                string CountryOfCollege = input.CountryOfCollege;
                Console.WriteLine(CountryOfCollege);
                string Title = input.Title;
                Console.WriteLine(Title);
                string Degree = input.Degree;
                Console.WriteLine(Degree);
                string YearOfGraduation = input.YearOfGraduation;
                Console.WriteLine(YearOfGraduation);
                EducationPageObj.AddNewEducation(input);
                string actualUniversityName = EducationPageObj.GetUniversityName();
            }
        }
        [Test, Order(3)]
        public void InvalidEducationDetails1_Test()

        {
            List<Education> item = CommonMethods.LoadJson.Read<Education>("E:\\CompetitiontaskProjectMars\\CompetitiontaskProjectMars\\DataFiles\\InvalidCertificationDetails1.json");

            foreach (var input in item)
            {
                string UniversityName = input.UniversityName;
                Console.WriteLine(UniversityName);
                string CountryOfCollege = input.CountryOfCollege;
                Console.WriteLine(CountryOfCollege);
                string Title = input.Title;
                Console.WriteLine(Title);
                string Degree = input.Degree;
                Console.WriteLine(Degree);
                string YearOfGraduation = input.YearOfGraduation;
                Console.WriteLine(YearOfGraduation);
                EducationPageObj.AddNewEducation(input);
              
                int s = UniversityName.Length;
                Assert.That(s <= 100, "Dont accept more than 100 chars");
            }
        }
        [Test, Order(4)]
        public void InvalidEducationDetails2_Test()

        {
            List<Education> item = CommonMethods.LoadJson.Read<Education>("E:\\CompetitiontaskProjectMars\\CompetitiontaskProjectMars\\DataFiles\\InvalidCertificationDetails2.json");

            foreach (var input in item)
            {
                string UniversityName = input.UniversityName;
                Console.WriteLine(UniversityName);
                string CountryOfCollege = input.CountryOfCollege;
                Console.WriteLine(CountryOfCollege);
                string Title = input.Title;
                Console.WriteLine(Title);
                string Degree = input.Degree;
                Console.WriteLine(Degree);
                string YearOfGraduation = input.YearOfGraduation;
                Console.WriteLine(YearOfGraduation);
                EducationPageObj.AddNewEducation(input);
                string sub = "@%!&";

                if (input.UniversityName.Contains(sub))
                {
                    Assert.Fail("CertificateorAwardName field do not accept special characters");
                }
            }
        }
        [Test, Order(5)]
        public void InvalidEducationDetails3_Test()

        {
            List<Education> item = CommonMethods.LoadJson.Read<Education>("E:\\CompetitiontaskProjectMars\\CompetitiontaskProjectMars\\DataFiles\\InvalidCertificationDetails3.json");

            foreach (var input in item)
            {
                string UniversityName = input.UniversityName;
                Console.WriteLine(UniversityName);
                string CountryOfCollege = input.CountryOfCollege;
                Console.WriteLine(CountryOfCollege);
                string Title = input.Title;
                Console.WriteLine(Title);
                string Degree = input.Degree;
                Console.WriteLine(Degree);
                string YearOfGraduation = input.YearOfGraduation;
                Console.WriteLine(YearOfGraduation);
                EducationPageObj.AddNewEducation(input);
                string sub = "123";

                if (input.UniversityName.Contains(sub))
                {
                    Assert.Fail("CertificateorAwardName field do not accept numerics");
                }


            }
        
        }
        [Test, Order(6)]
        public void InvalidEducationDetails4_Test()

        {
            List<Education> item = CommonMethods.LoadJson.Read<Education>("E:\\CompetitiontaskProjectMars\\CompetitiontaskProjectMars\\DataFiles\\InvalidCertificationDetails4.json");
            foreach (var input in item)
            {
                string UniversityName = input.UniversityName;
                Console.WriteLine(UniversityName);
                string CountryOfCollege = input.CountryOfCollege;
                Console.WriteLine(CountryOfCollege);
                string Title = input.Title;
                Console.WriteLine(Title);
                string Degree = input.Degree;
                Console.WriteLine(Degree);
                string YearOfGraduation = input.YearOfGraduation;
                Console.WriteLine(YearOfGraduation);
                EducationPageObj.AddNewEducation(input);
            }
        }

        [Test, Order(7)]

        public void UpdateEducation_Test()

        {


            List<Education> item = CommonMethods.LoadJson.Read<Education>("E:\\CompetitiontaskProjectMars\\CompetitiontaskProjectMars\\DataFiles\\UpdateEducation.json");

            foreach (var updateInput in item)
            {

                string UniversityName = updateInput.UniversityName;
                Console.WriteLine(UniversityName);
                string CountryOfCollege = updateInput.CountryOfCollege;
                Console.WriteLine(CountryOfCollege);
                string Title = updateInput.Title;
                Console.WriteLine(Title);
                string Degree = updateInput.Degree;
                Console.WriteLine(Degree);
                string YearOfGraduation = updateInput.YearOfGraduation;
                Console.WriteLine(YearOfGraduation);
                EducationPageObj.UpdateEducation(updateInput);
            }
        }

        [Test, Order(8)]
        public void DeleteEducation_Test()
        {

            List<Education> item = CommonMethods.LoadJson.Read<Education>("E:\\CompetitiontaskProjectMars\\CompetitiontaskProjectMars\\DataFiles\\DeleteEducation.json");
            foreach (var deleteInput in item)
            {

                string UniversityName = deleteInput.UniversityName;
                Console.WriteLine(UniversityName);
                string CountryOfCollege = deleteInput.CountryOfCollege;
                Console.WriteLine(CountryOfCollege);
                string Title = deleteInput.Title;
                Console.WriteLine(Title);
                string Degree = deleteInput.Degree;
                Console.WriteLine(Degree);
                string YearOfGraduation = deleteInput.YearOfGraduation;
                Console.WriteLine(YearOfGraduation);

                try
                {
                    EducationPageObj.DeleteEducation(deleteInput);

                }
                catch (NoSuchElementException)
                {

                    Console.WriteLine($"DeleteCertification element not found for certificateName: {deleteInput.UniversityName}");
                }
            }
        }
        [Test, Order(9)]
        public void CancelCertification_Test()
        {
            EducationPageObj.CancelFunction();
            EducationPageObj.AssertionCancel();

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