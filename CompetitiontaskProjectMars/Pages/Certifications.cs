using CompetitiontaskProjectMars.TestModel;
using CompetitiontaskProjectMars.Utilities;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RazorEngine;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;

namespace CompetitiontaskProjectMars.Pages
{
    public class Certifications : CommonMethods.CommonDriver
    {
        private static IWebElement CertificationTab => driver.FindElement(By.XPath("//a[text() = 'Certifications']"));
        private static IWebElement AddNew => driver.FindElement(By.XPath("//div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div"));
        
        //private static IWebElement CertificateorAward => driver.FindElement(By.XPath("//div[3]/form/div[5]/div[1]/div[2]/div/div/div[1]/div/input"));
        private static IWebElement CertifiedFrom => driver.FindElement(By.Name("certificationFrom"));
        private static IWebElement CertifiedYear => driver.FindElement(By.Name("certificationYear"));
        private static IWebElement AddButton => driver.FindElement(By.XPath("//div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]"));
        private static IWebElement PencilIcon => driver.FindElement(By.XPath($" //*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[1]/i"));
        private static IWebElement UpdateButton => driver.FindElement(By.XPath("//input[contains(@value, 'Update')]"));
        private static IWebElement newCertificateName => driver.FindElement(By.XPath("(//*[@class= 'ui fixed table'])[4]/tbody/tr/td[1]"));
        private static IWebElement ActualMessage => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        private static IWebElement  editedCertificationName => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[1]"));
        private static IWebElement deletedCertificate => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[1]"));
        private static IWebElement DeleteButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td[4]/span[2]/i"));
        private static IWebElement CancelButton => driver.FindElement(By.XPath("//input[@value= 'Cancel']"));


        public void DeleteExistingRecords()
        {
            CertificationTab.Click();
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                while (true)
                {
                    var deleteButtons = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td[4]/span[2]/i"));

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

        public void AddNewCertification(Certification input)

        {
            Wait.WaitToBeVisible(driver, "XPath", "//a[text() = 'Certifications']", 5);
            CertificationTab.Click();
            Thread.Sleep(3000);

            Wait.WaitToBeVisible(driver, "XPath", "//div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div", 5);
            AddNew.Click();
            Thread.Sleep(3000);

            IWebElement CertificateorAward = driver.FindElement(By.XPath("//div[3]/form/div[5]/div[1]/div[2]/div/div/div[1]/div/input"));
            Wait.WaitToBeVisible(driver, "XPath", "//div[3]/form/div[5]/div[1]/div[2]/div/div/div[1]/div/input", 5);
            CertificateorAward.SendKeys(input.certificateorAward);
            Thread.Sleep(3000);

            Wait.WaitToBeVisible(driver, "Name", "certificationFrom", 5);
            CertifiedFrom.SendKeys(input.certifiedFrom);

            Wait.WaitToBeVisible(driver, "Name", "certificationYear", 5);
            CertifiedYear.Click();
            CertifiedYear.SendKeys(input.certifiedYear);

            Wait.WaitToBeClickable(driver, "XPath", "//div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]", 2);
            AddButton.Click();
            Thread.Sleep(5000);


            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 3);
            string actualMessage = ActualMessage.Text;
            Console.WriteLine(actualMessage);

            //verify the expected message 
            string expectedMessage1 = CertificateorAward + " has been added to your certification";
            string expectedMessage2 = "This information is already exist.";
            string expectedMessage3 = "Please enter Certification Name, Certification From and Certification Year";
            string expectedMessage4 = "Duplicated data";

            if (actualMessage == expectedMessage1)
            {
                Thread.Sleep(3000);
                Console.WriteLine(expectedMessage1);
            }
            else if (actualMessage == expectedMessage2 || actualMessage == expectedMessage3 || actualMessage == expectedMessage4)
            {

                Wait.WaitToBeClickable(driver, "XPath", "//input[@value= 'Cancel']", 10);
                CancelButton.Click();
            }


        }
        public string GetCertificateName()
        {
            Thread.Sleep(2000);
            return newCertificateName.Text;

        }


        public void EditCertification(Certification updateInput)

        {
            Wait.WaitToBeVisible(driver, "XPath", "//a[text() = 'Certifications']", 5);
            CertificationTab.Click();

            Wait.WaitToBeVisible(driver, "XPath", " //*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[1]/i", 5);
            PencilIcon.Click();
            Thread.Sleep(2000);

            IWebElement CertificateorAward = driver.FindElement(By.Name("certificationName"));
            CertificateorAward.Clear();
            CertificateorAward.SendKeys(updateInput.certificateorAward);
            Thread.Sleep(2000);

            Wait.WaitToBeVisible(driver, "Name", "certificationFrom", 3);
            CertifiedFrom.Clear();
            CertifiedFrom.SendKeys(updateInput.certifiedFrom);
            Thread.Sleep(2000);

            Wait.WaitToBeVisible(driver, "Name", "certificationYear", 3);
            CertifiedYear.Click();
            CertifiedYear.SendKeys(updateInput.certifiedYear);
            Thread.Sleep(2000);

            Wait.WaitToBeClickable(driver, "XPath", "//input[contains(@value, 'Update')]", 3);
            UpdateButton.Click();
            Thread.Sleep(2000);

            //Wait for the popup message window to display
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 3);
            string actualMessage = ActualMessage.Text;
            Console.WriteLine(actualMessage);

            //verify the expected message text
            string expectedMessage1 = CertificateorAward + " has been updated to your certification";
            string expectedMessage2 = "This information is already exist.";
            string expectedMessage3 = "Please enter Certification Name, Certification From and Certification Year";
            string expectedMessage4 = "Duplicated data";

            if (actualMessage == expectedMessage1)
            {
                Thread.Sleep(2000);
                Console.WriteLine(expectedMessage1);
            }
            else if (actualMessage == expectedMessage2 || actualMessage == expectedMessage3 || actualMessage == expectedMessage4)
            {
                Thread.Sleep(2000);
                CancelButton.Click();
            }
        }
        public string EditedCertificationName()
        {
            Thread.Sleep(2000);
            return editedCertificationName.Text;
        }
        public void DeleteCertification(Certification deleteInput)
        {

            Wait.WaitToBeClickable(driver, "XPath", "//a[text() = 'Certifications']", 5);
            CertificationTab.Click();

            if (editedCertificationName.Text == deleteInput.certificateorAward)
            {
                // Find and click the delete icon in the row
                DeleteButton.Click();
                Thread.Sleep(2000);

                //Wait for the popup message window to display
                Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 5);
                string actualMessage = ActualMessage.Text;
                Console.WriteLine(actualMessage);

            }

            else
            {
                Console.WriteLine("Certificate to be deleted hasn't been found");
            }
        }
        public string getDeletedCertificate()
        {
            Thread.Sleep(2000);
            return deletedCertificate.Text;
        }

        //Cancel while a record is updating
        public void CancelFunction()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//a[text() = 'Certifications']", 5);
            CertificationTab.Click();
            //Click on UpdateIcon
            Wait.WaitToBeVisible(driver, "XPath", " //*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[1]/i", 5);
            PencilIcon.Click();
            //Click on Cancel button
            Wait.WaitToBeClickable(driver, "XPath", "//input[@value= 'Cancel']", 10);
            CancelButton.Click();

        }
        public void AssertionCancel()
        {

            //Click on Certification tab
            Wait.WaitToBeVisible(driver, "XPath", "//a[text() = 'Certifications']", 5);
            CertificationTab.Click();

         }
    }
 } 