using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class HomePage : WebDriver
    {
        IWebElement login = Driver.FindElement(By.LinkText("Sign in"));        
        IWebElement createButton = Driver.FindElement(By.Id("SubmitCreate"));
        public void GoToLoginPage()
        {
            login.Click();
        }

        public void GoToReguistrationPage()
        {
            createButton.Click();
        }
    }
}
