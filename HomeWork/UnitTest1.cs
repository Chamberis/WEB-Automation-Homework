using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace HomeWork 
{
     class Tests : WebDriver
    {
        private string URL = "http://automationpractice.com/index.php";

        //login data
        string email = "test3@test.lt";
        string password = "test123";


        //registration data
        string reg_firstname = "Testas";
        string reg_lastname = "Testauskas";
        string reg_password = "test123";
        string reg_email = "test3@test.lt";
        string reg_address = "street";
        string reg_city = "Testaviskes";
        string reg_state = "Alaska";
        string reg_zip = "01201";
        string reg_country = "United States";
        string reg_phone = "123456789";



        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl(URL);
        }

       
        [Test]

        public void TestRegistration()
        {
            IWebElement login = Driver.FindElement(By.LinkText("Sign in"));
            login.Click();
            IWebElement emailInput = Driver.FindElement(By.CssSelector("[id='email_create']"));
            emailInput.SendKeys(reg_email);
            IWebElement createButton = Driver.FindElement(By.Id("SubmitCreate"));
            createButton.Click();
            Task.Delay(4000).Wait();
            IWebElement firstname_txt = Driver.FindElement(By.Id("customer_firstname"));
            firstname_txt.SendKeys(reg_firstname);
            IWebElement lastname_txt = Driver.FindElement(By.Id("customer_lastname"));
            lastname_txt.SendKeys(reg_lastname);
            IWebElement password_txt = Driver.FindElement(By.Id("passwd"));
            password_txt.SendKeys(reg_password);
            IWebElement adress_txt = Driver.FindElement(By.Id("address1"));
            adress_txt.SendKeys(reg_address);
            IWebElement city_txt = Driver.FindElement(By.Id("city"));
            city_txt.SendKeys(reg_city);
            var state = new SelectElement(Driver.FindElement(By.Name("id_state")));
            state.SelectByText(reg_state);
            IWebElement zipCode = Driver.FindElement(By.Name("postcode"));
            zipCode.SendKeys(reg_zip);
            var country = new SelectElement(Driver.FindElement(By.Name("id_country")));
            country.SelectByText(reg_country);
            IWebElement phone_num = Driver.FindElement(By.Id("phone_mobile"));
            phone_num.SendKeys(reg_phone);
            IWebElement submitButton = Driver.FindElement(By.Id("submitAccount"));
            submitButton.Click();
            IWebElement registration_txt = Driver.FindElement(By.CssSelector("#center_column > p"));
            string ExpectedText = "Welcome to your account. Here you can manage all of your personal information and orders.";
            Assert.AreEqual(ExpectedText, registration_txt.Text.Trim());

        }

        [Test]

        public void Login()
        {
            EnterCredentialsAndlogin();
            Task.Delay(4000).Wait();
            IWebElement login_txt = Driver.FindElement(By.CssSelector("#center_column > p"));
            string ExpectedText = "Welcome to your account. Here you can manage all of your personal information and orders.";
            Assert.AreEqual(ExpectedText, login_txt.Text.Trim());
            
        }

        [Test]
        public void CheckSearch()
        {
            EnterCredentialsAndlogin();
            IWebElement search_txt = Driver.FindElement(By.CssSelector("#search_query_top"));
            search_txt.SendKeys("faded short sleeve t-shirt");
            IWebElement search_btn = Driver.FindElement(By.CssSelector("#searchbox > button"));
            search_btn.Click();
            IWebElement tshirt_txt = Driver.FindElement(By.CssSelector("#center_column > ul > li > div > div.right-block > h5 > a"));
            Assert.AreEqual(tshirt_txt.Text, "faded short sleeve t - shirt");
        }


        [Test]
        public void TestBuy()
        {
            EnterCredentialsAndlogin();
            IWebElement search_txt = Driver.FindElement(By.CssSelector("#search_query_top"));
            search_txt.SendKeys("faded short sleeve t-shirt");
            IWebElement search_btn = Driver.FindElement(By.CssSelector("#searchbox > button"));
            search_btn.Click();
            Task.Delay(4000).Wait();
            IWebElement add_btn = Driver.FindElement(By.CssSelector("#center_column > ul > li > div > div.right-block > div.button-container > a.button.ajax_add_to_cart_button.btn.btn-default"));
            add_btn.Click();
            Task.Delay(4000).Wait();
            IWebElement one_proceed_btn = Driver.FindElement(By.CssSelector("#layer_cart > div.clearfix > div.layer_cart_cart.col-xs-12.col-md-6 > div.button-container > a"));
            one_proceed_btn.Click();            
            IWebElement two_proceed_btn = Driver.FindElement(By.CssSelector("#center_column > p.cart_navigation.clearfix > a.button.btn.btn-default.standard-checkout.button-medium"));
            two_proceed_btn.Click();            
            IWebElement three_proceed_btn = Driver.FindElement(By.CssSelector("#center_column > form > p > button"));
            three_proceed_btn.Click();            
            IWebElement checked_btn = Driver.FindElement(By.CssSelector("#uniform-cgv"));
            checked_btn.Click();
            IWebElement four_proceed_btn = Driver.FindElement(By.CssSelector("#form > p > button"));
            four_proceed_btn.Click();            
            IWebElement pay_btn = Driver.FindElement(By.CssSelector("#HOOK_PAYMENT > div:nth-child(1) > div > p"));
            pay_btn.Click();        
            IWebElement comfirm_btn = Driver.FindElement(By.CssSelector("#cart_navigation > button"));
            comfirm_btn.Click();
            IWebElement comfirm_txt = Driver.FindElement(By.CssSelector("#center_column > div > p > strong"));
            string ExpectedText = "Your order on My Store is complete.";
            Assert.AreEqual(ExpectedText, comfirm_txt.Text.Trim());

        }

        public void EnterCredentialsAndlogin()
        {
            Task.Delay(4000).Wait();
            IWebElement loginButton = Driver.FindElement(By.LinkText("Sign in"));
            loginButton.Click();
            IWebElement emailInput = Driver.FindElement(By.CssSelector("#email"));
            emailInput.SendKeys(email);
            IWebElement password_txt = Driver.FindElement(By.CssSelector("#passwd"));
            password_txt.SendKeys(password);
            IWebElement login_btn = Driver.FindElement(By.Id("SubmitLogin"));
            login_btn.Click();
        }

        public void EnterCredentialsAndLoginPO()
        {
            HomePage homePage = new HomePage();
            homePage.GoToLoginPage();
            LoginPage loginPage = new LoginPage();
            loginPage.EnterCredentialsAndLogin(email, password);
        }

        [TearDown]
        public void Close()
        {
            Driver.Close();
        }

    }
}
