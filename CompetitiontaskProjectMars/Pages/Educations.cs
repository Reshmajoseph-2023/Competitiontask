using CompetitiontaskProjectMars.TestModel;
using CompetitiontaskProjectMars.Utilities;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitiontaskProjectMars.Pages
{
    public class Educations : CommonDriver
    {
        private static IWebElement EducationTab => driver.FindElement(By.XPath("//a[text() = 'Education']"));
        private static IWebElement AddNewButton => driver.FindElement(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div"));
        private static IWebElement CollegName => driver.FindElement(By.Name("instituteName"));
        private static IWebElement CountryOfCollege => driver.FindElement(By.Name("country"));
        private static IWebElement Title => driver.FindElement(By.Name("title"));
        private static IWebElement Degree => driver.FindElement(By.Name("degree"));
        private static IWebElement YearOfGraduation => driver.FindElement(By.Name("yearOfGraduation"));
        private static IWebElement AddButton => driver.FindElement(By.XPath("//input [contains (@class, 'ui teal button')]"));
        private static  IWebElement actualMessage => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        private static IWebElement pencilIcon => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[1]"));
        private static IWebElement messageBox => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        private static IWebElement newRecordInstituteName => driver.FindElement(By.XPath("(//*[@class= 'ui fixed table'])[3]/tbody[last()]/tr/td[2]"));
        private static IWebElement cancelIcon => driver.FindElement(By.XPath("//input[@value= 'Cancel']"));
        public void DeleteExistingRecords()
        {
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

        public void AddNewEducation()
        {
            EducationTab.Click();
            AddNewButton.Click();
            CollegName.SendKeys("Cusat");
            SelectElement chooseCountry = new SelectElement(CountryOfCollege);
            chooseCountry.SelectByValue("India");
            SelectElement chooseTitle = new SelectElement(Title);
            chooseTitle.SelectByValue("B.Tech");
            Degree.SendKeys("Computer Science");
            SelectElement chooseYearOfGraduation = new SelectElement(YearOfGraduation);
            chooseYearOfGraduation.SelectByValue("2015");
            AddButton.Click();
        }

        public string getMessage()
        {
            Thread.Sleep(4000);
            
            //Get the text message after entering education details
            return actualMessage.Text;
        }

        
    }
        
    
}
