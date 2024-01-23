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
    public class Certifications : CommonDriver
    {
        private static IWebElement CertificationTab => driver.FindElement(By.XPath("//a[text() = 'Certifications']"));
        private static IWebElement AddNew => driver.FindElement(By.XPath("//div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div"));
        
        private static IWebElement CertificateorAward => driver.FindElement(By.XPath("//div[3]/form/div[5]/div[1]/div[2]/div/div/div[1]/div/input"));
        private static IWebElement CertifiedFrom => driver.FindElement(By.Name("certificationFrom"));
        private static IWebElement CertifiedYear => driver.FindElement(By.Name("certificationYear"));
        private static IWebElement AddButton => driver.FindElement(By.XPath("//div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]"));
        private static IWebElement PencilIcon => driver.FindElement(By.XPath($" //*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[1]/i"));
        private static IWebElement UpdateButton => driver.FindElement(By.XPath("//input[contains(@value, 'Update')]"));
        private static IWebElement newCertificateName => driver.FindElement(By.XPath("(//*[@class= 'ui fixed table'])[4]/tbody/tr/td[1]"));
        private static IWebElement actualMessage => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        private static IWebElement UpdatedCertificate => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[1]"));
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

        public void AddNewCertification()

        {
            CertificationTab.Click();
            AddNew.Click();
            CertificateorAward.SendKeys("DB administration");
            CertifiedFrom.SendKeys("TechnoValley");
            SelectElement chooseYear = new SelectElement(CertifiedYear);
            chooseYear.SelectByValue("2023");
            AddButton.Click();

        }
        public string getMessage()
        {
            Thread.Sleep(4000);

            //Get the text message after entering education details
            return actualMessage.Text;
        }

        //Cancel while a record is updating
        public void CancelFunction()
        {
                CertificationTab.Click();
                Thread.Sleep(5000);
                //Click on UpdateIcon
                PencilIcon.Click();
                Thread.Sleep(5000);
                //Click on Cancel button
                CancelButton.Click();

        }
        public void AssertionCancel()
        {
                Thread.Sleep(5000);
                //Click on Certification tab
                CertificationTab.Click();

         }
    }
 } 