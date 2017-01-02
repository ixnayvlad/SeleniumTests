using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace SeleniumTests.Pages
{
    class RegistrationPage : AbstractPage
    {
        private const string BASE_URL = "https://shop.ticketpro.by/RU/Account/Register";


        //[FindsBy(How = How.Id, Using = "login_screen_reg")]
        //private IWebElement buttonEnter;

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement inputEmail;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement inputPassword;

        [FindsBy(How = How.Id, Using = "confirmed")]
        private IWebElement inputConfirm;

        [FindsBy(How = How.Id, Using = "first")]
        private IWebElement inputFname;

        [FindsBy(How = How.Id, Using = "last")]
        private IWebElement inputLname;

        [FindsBy(How = How.XPath, Using = "//input[@value='СОХРАНИТЬ']")]
        private IWebElement buttonSubmit;

        public RegistrationPage(IWebDriver driver)
            : base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            System.Threading.Thread.Sleep(2000);
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void Registrated(string email, string pass, string conf, string fname, string lname)
        {
            inputEmail.SendKeys(email);
            inputPassword.SendKeys(pass);
            inputConfirm.SendKeys(conf);
            inputFname.SendKeys(fname);
            inputLname.SendKeys(lname);
            buttonSubmit.Click();
            System.Threading.Thread.Sleep(3000);
        }

       

        public bool isRegistrated()
        {
           
            IWebElement message = driver.FindElement(By.Id("div_info_message"));
            return message.Text.Equals("Регистрация прошла успешно.");
        }

        public void IncorrectRegistrated(string email, string pass, string conf, string fname, string lname)
        {
            inputEmail.SendKeys(email);
            inputPassword.SendKeys(pass);
            inputConfirm.SendKeys(conf);
            inputFname.SendKeys(fname);
            inputLname.SendKeys(lname);
            buttonSubmit.Click();
            System.Threading.Thread.Sleep(3000);
        }

        public bool isIncorrectRegistered()
        {
            IWebElement message = driver.FindElement(By.XPath("//DIV[@class='field_error register_error_email'][text()='Введен адрес электронной почты в неверном формате.']"));
            return true;
        }
    }
}
