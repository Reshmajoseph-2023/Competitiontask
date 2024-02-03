using CompetitiontaskProjectMars.Pages;
using CompetitiontaskProjectMars.TestModel;
using CompetitiontaskProjectMars.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using Microsoft.VisualBasic;
using System.Security.Cryptography.X509Certificates;
using System.Drawing.Imaging;
using static CompetitiontaskProjectMars.Utilities.CommonMethods;

namespace CompetitiontaskProjectMars.Tests
{
    
    [TestFixture]
    public class Education_Tests : CommonDriver
    {
        Login LoginPageObj;
        Educations EducationPageObj;
        
        private ExtentTest test;
        private ExtentReports extent = ExtentReportsManager.getReport();

        public Education_Tests()
        {
            LoginPageObj = new Login();
            EducationPageObj = new Educations();
        }

        [SetUp]
        public void EducationSetUp()
        {
            driver = new ChromeDriver();
            LoginPageObj.LoginSteps();
        }

        [Test, Order(1), Description("This test is deleting existing education records")]
        public void DeleteExistingRecords_Test()

        {
            test = extent.CreateTest("DeleteExistingRecords_Test").Info("Test1 Started- Deleting existing education records ");
            EducationPageObj.DeleteExistingRecords();
            Console.WriteLine("Existing educational records are deleted successfully");
            test.Pass("Test passed");
        }

        [Test, Order(2), Description("This test is creating a new education record")]
        public void AddNewEducation_Test()

        {
            // Create an ExtentTest instance
            test = extent.CreateTest("AddNewEducation_Test").Info("Test2- Add New Education record Started");

            List<Education> item = LoadJson.Read<Education>("E:\\CompetitiontaskProjectMars\\CompetitiontaskProjectMars\\DataFiles\\AddEducation.json");

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
                test.Log(Status.Pass, "Test Passed");
                Assert.That(input.UniversityName, Is.EqualTo(actualUniversityName), "Actual Education and expected education does not match.");
            }
        }

        [Test, Order(3), Description("This test is checking more than 100 characters are allowed or not")]
        public void InvalidEducationDetails1_Test()

        { // Create an ExtentTest instance
            test = extent.CreateTest("InvalidEducationDetails1_Test").Info("Test3 Started- InvalidEducationDetails-Acceptance of more than 100 characters ");
            List <Education> item = LoadJson.Read<Education>("E:\\CompetitiontaskProjectMars\\CompetitiontaskProjectMars\\DataFiles\\InvalidEducationDetails1.json"); 
            try
            {
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

                    int l = UniversityName.Length;
                    if (l >= 100)
                    {
                        Assert.Fail("More than 100 chars are not allowed");
                    }
                }
            }

            catch (Exception e)

            {
                //Log screenshot
                string screenshotFolder = CaptureScreenshot.SaveScreenshot(driver, "100 chars-InvalidEducationDetails1");
                test.Log(Status.Fail, "Screenshot of accepting more than 100characters", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotFolder + ImageFormat.Png).Build());
                //Log error into extent reports
                test.Log(Status.Fail, e.ToString());


            }
        }

        [Test, Order(4), Description("This test is checking special characters are allowed or not")]
        public void InvalidEducationDetails2_Test()

        {
            test = extent.CreateTest("InvalidEducationDetails2_Test").Info("Test4 Started- InvalidEducationDetails2-Acceptance of special characters");
            List <Education> item = LoadJson.Read<Education>("E:\\CompetitiontaskProjectMars\\CompetitiontaskProjectMars\\DataFiles\\InvalidEducationDetails2.json");
            try
            {
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

                    bool containsSpecialCharacters = CharacterandNumericsTests.ContainsSpecialCharactersAndNumerics(UniversityName);
                    if (containsSpecialCharacters)
                    {
                       Assert.Fail("Special characters are not allowed");
                    }
                }

            }
            catch (Exception e)

            {
                //Log screenshot
                string screenshotFolder = CaptureScreenshot.SaveScreenshot(driver, "special characters-InvalidEducationDetails2");
                test.Log(Status.Fail, "Screenshot of accepting special characters", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotFolder + ImageFormat.Png).Build());
                //Log error into extent reports
                test.Log(Status.Fail, e.ToString());

            }
        }

        [Test, Order(5), Description("This test is checking numerics are allowed or not")]
        public void InvalidEducationDetails3_Test()

        {
            test = extent.CreateTest("InvalidEducationDetails3_Test").Info("Test5 Started- InvalidEducationDetails-Acceptance of numerics");
            List<Education> item = LoadJson.Read<Education>("E:\\CompetitiontaskProjectMars\\CompetitiontaskProjectMars\\DataFiles\\InvalidEducationDetails3.json");
            try
            {
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

                    bool containsNumerics = CharacterandNumericsTests.ContainsSpecialCharactersAndNumerics(UniversityName);
                    if (containsNumerics)
                    {
                        Assert.Fail("Numerics are not allowed");
                    }

                }
            }
            catch (Exception e)

            {
                //Log screenshot
                string screenshotFolder = CaptureScreenshot.SaveScreenshot(driver, "Numerics-InvalidEducationDetails3");
                test.Log(Status.Fail, "Screenshot of accepting numerics", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotFolder + ImageFormat.Png).Build());
                //Log error into extent reports
                test.Log(Status.Fail, e.ToString());

            }

        }

        [Test, Order(6), Description("This test is checking numerics are allowed or not for degree field")]
        public void InvalidEducationDetails4_Test()

        {
            test = extent.CreateTest("InvalidEducationDetails4_Test").Info("Test6 Started- InvalidEducationDetails-Acceptance of numerics");
            List<Education> item = LoadJson.Read<Education>("E:\\CompetitiontaskProjectMars\\CompetitiontaskProjectMars\\DataFiles\\InvalidEducationDetails4.json");
            try
            {
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

                    bool containsNumerics = CharacterandNumericsTests.ContainsSpecialCharactersAndNumerics(UniversityName);
                    if (containsNumerics)
                    {
                        Assert.Fail("Numerics are not allowed for degree field");
                    }
                }
            }
        
            catch (Exception e)

            {
                //Log screenshot
                string screenshotFolder = CaptureScreenshot.SaveScreenshot(driver, "Numerics-InvalidEducationDetails4");
                test.Log(Status.Fail, "Screenshot of accepting numerics", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotFolder + ImageFormat.Png).Build());
                //Log error into extent reports
                test.Log(Status.Fail, e.ToString());

            }
        }

        [Test, Order(7), Description("This test is editing an existing education record")]
        public void UpdateEducation_Test()

        {
            test = extent.CreateTest("UpdateEducation_Test").Info("Test7 Started-Update Education");
            List <Education> item = LoadJson.Read<Education>("E:\\CompetitiontaskProjectMars\\CompetitiontaskProjectMars\\DataFiles\\UpdateEducation.json"); 
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
                test.Pass("Test passed");
                EducationPageObj.UpdateEducation(updateInput);
                string updatedUniversityeName = EducationPageObj.GetEditedUniversityName();
                Assert.That(updatedUniversityeName == UniversityName, "Updated education and expected education does not match");

            }
        }

        [Test, Order(8), Description("This test is deleting an existing education record")]
        public void DeleteEducation_Test()
        {
            test = extent.CreateTest("DeleteEducation_Test").Info("Test8 Started- Delete Education ");
            List<Education> item = LoadJson.Read<Education>("E:\\CompetitiontaskProjectMars\\CompetitiontaskProjectMars\\DataFiles\\DeleteEducation.json");
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
                EducationPageObj.DeleteEducation(deleteInput);

                if(deleteInput.UniversityName != "Database")
                { 
                    test.Log(Status.Fail,"Test Failed, Element to delete does not found"); 
                }
                else
                {
                    test.Log(Status.Pass, "Test Passed");
                }
                
            }
        }
        
    
        [Test, Order(9), Description("This test cancel updating the existing record")]
        public void CancelEducation_Test()
        {
            test = extent.CreateTest("Cancel Education_Test").Info("Test9 Started- Cancel Education");
            test.Pass("Test passed");
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