﻿using CompetitiontaskProjectMars.TestModel;
using CompetitiontaskProjectMars.Tests;
using CompetitiontaskProjectMars.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace CompetitiontaskProjectMars.Pages
{
    public class Educations : CommonMethods.CommonDriver
    {
        private static IWebElement EducationTab => driver.FindElement(By.XPath("//a[text() = 'Education']"));
        private static IWebElement AddNewButton => driver.FindElement(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div"));
        private static IWebElement CollegeName => driver.FindElement(By.Name("instituteName"));
        private static IWebElement CountryOfCollege => driver.FindElement(By.Name("country"));
        private static IWebElement Title => driver.FindElement(By.Name("title"));
        private static IWebElement Degree => driver.FindElement(By.Name("degree"));
        private static IWebElement YearOfGraduation => driver.FindElement(By.Name("yearOfGraduation"));
        private static IWebElement AddButton => driver.FindElement(By.XPath("//input [contains (@class, 'ui teal button')]"));
        private static IWebElement getEditedUniversityName => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[2]"));
        private static IWebElement  deletedEducation => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[1]"));
        private static IWebElement PencilIcon => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[6]/span[1]/i"));
        private static IWebElement UpdateButton => driver.FindElement(By.XPath("//input[contains(@value, 'Update')]"));
        private static IWebElement ActualMessage => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        private static IWebElement newUniversityName => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
        private static IWebElement CancelButton => driver.FindElement(By.XPath("//input[@value= 'Cancel']"));
        private static IWebElement deleteIcon => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[2]/i"));
       

        public void DeleteExistingRecords()
        {
            CommonMethods.Wait.WaitToBeClickable(driver, "XPath", "//a[text() = 'Education']", 3);
            EducationTab.Click();

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                while (true)
                {
                    var deleteButtons = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[6]/span[2]/i"));

                    if (deleteButtons.Count == 0)
                    {
                        break;
                    }
                    foreach (var button in deleteButtons)
                    {
                        try
                        {
                            wait.Until(ExpectedConditions.ElementToBeClickable(button)).Click();
                            Thread.Sleep(5000);
                        }
                        catch (StaleElementReferenceException)
                        {
                            // Handle the exception by re-checking the element 
                        }
                    }
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("No items to delete");
            }

        }
        public void AddNewEducation(Education input)
        {
            //Click on Education tab
            CommonMethods.Wait.WaitToBeClickable(driver, "XPath", "//a[text() = 'Education']", 3);
            EducationTab.Click();

            //Click AddNew button on Education tab
            CommonMethods. Wait.WaitToBeClickable(driver, "XPath", "//div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div", 3);
            AddNewButton.Click();

            //Enter University/Institute Name
            CommonMethods. Wait.WaitToBeVisible(driver, "Name", "instituteName", 3);
            CollegeName.Clear();
            CollegeName.SendKeys(input.UniversityName);

            //Select the name of the Country
            CommonMethods.Wait.WaitToBeVisible(driver, "Name", "country", 3);
            CountryOfCollege.Click();
            CountryOfCollege.SendKeys(input.CountryOfCollege);

            //Select the Title
            CommonMethods. Wait.WaitToBeVisible(driver, "Name", "title", 3);
            Title.Click();
            Title.SendKeys(input.Title);

            //Enter the Degree
            CommonMethods. Wait.WaitToBeVisible(driver, "Name", "degree", 3);
            Degree.SendKeys(input.Degree);

            //Select the year of graduation
            CommonMethods.Wait.WaitToBeClickable(driver, "Name", "yearOfGraduation", 3);
            YearOfGraduation.Click();
            YearOfGraduation.SendKeys(input.YearOfGraduation);

            //Click on Add button
            CommonMethods.Wait.WaitToBeClickable(driver, "XPath", "//input [contains (@class, 'ui teal button')]", 3);
            AddButton.Click();
            Thread.Sleep(2000);

            //Wait for the popup message window to display
            CommonMethods. Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 3);
            Thread.Sleep(3000);

            string actualMessage = ActualMessage.Text;
            Console.WriteLine(actualMessage);
            
            //verify the expected message text
            string expectedMessage1 = "Education has been added";
            string expectedMessage2 = "This information is already exist.";
            string expectedMessage3 = "Education information was invalid";
            string expectedMessage4 = "Please enter all the fields";
            string expectedMessage5 = "Duplicated data";

            if (actualMessage == expectedMessage2 || actualMessage == expectedMessage3 || actualMessage == expectedMessage4 || actualMessage == expectedMessage5)
            {
                Thread.Sleep(9000);
                CancelButton.Click();
            }
            else if (actualMessage == expectedMessage1)
            {
                Thread.Sleep(9000);
                Console.WriteLine("Education record added successfully");
            }

        }
        public string GetUniversityName()
        {
            CommonMethods.Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[2]", 3);
            return newUniversityName.Text;
        }

        public void UpdateEducation(Education updateInput)

        {
            //Click on Education Icon
            CommonMethods.Wait.WaitToBeClickable(driver, "XPath", "//a[text() = 'Education']", 5);
            EducationTab.Click();
            Thread.Sleep(2000);

            PencilIcon.Click();
            Thread.Sleep(2000);

            CommonMethods.Wait.WaitToBeVisible(driver, "Name", "instituteName", 3);
            CollegeName.Click();
            CollegeName.Clear();
            CollegeName.SendKeys(updateInput.UniversityName);

            CommonMethods.Wait.WaitToBeVisible(driver, "Name", "country", 3);
            CountryOfCollege.Click();
            CountryOfCollege.SendKeys(updateInput.CountryOfCollege);

            CommonMethods. Wait.WaitToBeVisible(driver, "Name", "title", 3);
            Title.Click();
            Title.SendKeys(updateInput.Title);

            CommonMethods.Wait.WaitToBeVisible(driver, "Name", "degree", 3);
            Degree.Click();
            Degree.Clear();
            Degree.SendKeys(updateInput.Degree);

            CommonMethods.Wait.WaitToBeVisible(driver, "Name", "yearOfGraduation", 3);
            YearOfGraduation.Click();
            YearOfGraduation.SendKeys(updateInput.YearOfGraduation);

            //click on update button
            CommonMethods.Wait.WaitToBeClickable(driver, "XPath", "//input[contains(@value, 'Update')]", 3);
            UpdateButton.Click();
            Thread.Sleep(5000);

            //Wait for the popup message window to display
            CommonMethods.Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 3);
            //Get the POPup Message text
            string actualMessage = ActualMessage.Text;
            Console.WriteLine(actualMessage);

            string expectedMessage1 = "Education as been updated";
            string expectedMessage2 = "This information is already exist.";
            string expectedMessage3 = "Please enter all the fields";
            string expectedMessage4 = "Education information was invalid";

            if (actualMessage == expectedMessage1)
            {
                Thread.Sleep(3000);
                Console.WriteLine("Education record has been updated successfully");
            }
            else if (actualMessage == expectedMessage2 || actualMessage == expectedMessage3 || actualMessage == expectedMessage4)
            {

                CommonMethods.Wait.WaitToBeVisible(driver, "XPath", "//input[@value= 'Cancel']", 3);
                CancelButton.Click();
            }
           
        }
        public string GetEditedUniversityName()
        {
            Thread.Sleep(2000);
            return getEditedUniversityName.Text;
        }
        public void DeleteEducation(Education deleteInput)
        {

            CommonMethods. Wait.WaitToBeClickable(driver, "XPath", "//a[text() = 'Education']", 5);
            EducationTab.Click();
            Thread.Sleep(2000);

            if (getEditedUniversityName.Text == deleteInput.UniversityName)
            {
                // Find and click the delete icon in the row
                deleteIcon.Click();
                Thread.Sleep(4000);

                //Wait for the popup message window to display
                CommonMethods.Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 3);
                //Get the Popup Message text
                string actualMessage = ActualMessage.Text;
                Console.WriteLine(actualMessage);
                Thread.Sleep(3000);

            }
           else
           {
                Console.WriteLine($"Education to be deleted hasn't been found: {deleteInput.UniversityName}");
                
            }
        }

        public string getDeletedEducation()
        {
            Thread.Sleep(2000);
            return deletedEducation.Text;
        }
        
        public void CancelFunction()
        {
             CommonMethods.Wait.WaitToBeClickable(driver, "XPath", "//a[text() = 'Education']", 3);
             EducationTab.Click();
             //Click on UpdateIcon
             PencilIcon.Click();
             Thread.Sleep(5000);

             //Click on Cancel button
             CancelButton.Click();

        }
        public void AssertionCancel()
        {
            CommonMethods.Wait.WaitToBeClickable(driver, "XPath", "//a[text() = 'Education']", 5);
            //Click on Certification tab
            EducationTab.Click();

        }
    }
   
}
