using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class LoginPage : WebDriver
    {
        IWebElement emailInput = Driver.FindElement(By.CssSelector("#email"));
        IWebElement password_txt = Driver.FindElement(By.CssSelector("#passwd"));
        IWebElement login_btn = Driver.FindElement(By.Id("SubmitLogin"));
        public void EnterCredentialsAndLogin(string email, string password)
        {
            emailInput.SendKeys(email);
            password_txt.SendKeys(password);
            login_btn.Click();
        }
    }
}