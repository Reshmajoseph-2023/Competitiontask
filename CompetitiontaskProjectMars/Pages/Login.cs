using CompetitiontaskProjectMars.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitiontaskProjectMars.Pages
{
    public class Login : CommonMethods.CommonDriver
    {
        private static IWebElement SignInButton => driver.FindElement(By.XPath("//a[text()='Sign In']"));
        private static IWebElement Email => driver.FindElement(By.Name("email"));
        private static IWebElement Password => driver.FindElement(By.Name("password"));
        private static IWebElement RememberMe => driver.FindElement(By.Name("rememberDetails"));
        private static IWebElement loginbutton => driver.FindElement(By.XPath("//button[text()='Login']"));

        public void LoginSteps()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/Home");
            SignInButton.Click();
            Thread.Sleep(1000);
            Email.SendKeys("reshmajoseph1201@gmail.com");
            Password.SendKeys("Docker2023");
            RememberMe.Click();
            loginbutton.Click();
            Thread.Sleep(3000);
        }

    }
}
