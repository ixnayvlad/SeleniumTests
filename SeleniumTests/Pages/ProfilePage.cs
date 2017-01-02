using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace SeleniumTests.Pages
{
    class ProfilePage : AbstractPage
    {
        private const string BASE_URL = "https://shop.ticketpro.by/RU/Account/LogOn";

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement inputUsername;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement inputPassword;

        [FindsBy(How = How.Id, Using = "agree")]
        private IWebElement checkboxAgree;

        [FindsBy(How = How.XPath, Using = "//input[@value='ВХОД']")]
        private IWebElement buttonEnter;
       
        [FindsBy(How = How.Id, Using = "srch_date")]
        private IWebElement inputDate;

        [FindsBy(How = How.Id, Using = "genre_input")]
        private IWebElement inputGenre;
        
        [FindsBy(How = How.Id, Using = "srchtab4")]
        private IWebElement buttonSearchGenre;

        [FindsBy(How = How.Id, Using = "srchtab5")]
        private IWebElement buttonSearchDate;

        [FindsBy(How = How.Id, Using = "search_button")]
        private IWebElement buttonSearch;

        [FindsBy(How = How.LinkText, Using = "Редактировать профиль")]
        private IWebElement linkProfileEdit;

        [FindsBy(How = How.LinkText, Using = "Редактировать")]
        private IWebElement linkEdit;

        [FindsBy(How = How.Id, Using = "city")]
        private IWebElement inputCity;

        [FindsBy(How = How.XPath, Using = "//input[@value='СОХРАНИТЬ']")]
        private IWebElement buttonSave;

        [FindsBy(How = How.XPath, Using = "//input[@value='OK']")]
        private IWebElement buttonOk;

        [FindsBy(How = How.LinkText, Using = "Изменить пароль")]
        private IWebElement linkEditPassword;

        [FindsBy(How = How.LinkText, Using = "Забыли пароль?")]
        private IWebElement linkPasswordRestore;

        [FindsBy(How = How.Id, Using = "oldPassword")]
        private IWebElement inputOldPassword;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement inputNewPassword;

        [FindsBy(How = How.Id, Using = "confirmed")]
        private IWebElement inputСonfirmedPassword;

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement inputEmail;

        [FindsBy(How = How.XPath, Using = "//input[@value='ОТПРАВИТЬ']")]
        private IWebElement buttonSend;

        [FindsBy(How = How.LinkText, Using = "Морозко")]
        private IWebElement linkEvent;

        [FindsBy(How = How.XPath, Using = "(//INPUT[@type='text'])[2]")]
        private IWebElement inputNumberOfTickets;

        [FindsBy(How = How.Id, Using = "basket_add_everything")]
        private IWebElement buttonBasket;
        

        public ProfilePage(IWebDriver driver)
            : base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            System.Threading.Thread.Sleep(2000);
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void Login(string username, string password)
        {
            inputUsername.SendKeys(username);
            inputPassword.SendKeys(password);
            checkboxAgree.Click();
            buttonEnter.Click();
            System.Threading.Thread.Sleep(3000);
        }



        public bool isLoggedIn()
        {

            IWebElement message = driver.FindElement(By.Id("div_info_message"));
            return message.Text.Equals("Вход в систему произошел успешно.");
        }

        public void FindByEventGenre(string eventGenre)
        {
            buttonSearchGenre.Click();
            inputGenre.SendKeys(eventGenre);
            buttonSearch.Click();
            System.Threading.Thread.Sleep(2000);
        }

        public bool isFindedBy()
        {
            IWebElement findInfo = driver.FindElement(By.XPath("//H4[text()='НАЙДЕННЫЕ МЕРОПРИЯТИЯ']"));
            if (findInfo.Displayed)
                return true;
            else
                return false;
        }

        public void FindByEventDate(string eventDate)
        {
            buttonSearchDate.Click();
            inputDate.SendKeys(eventDate);
            buttonSearch.Click();
            System.Threading.Thread.Sleep(2000);
        }


        public void EditDeliveryAddress(string city)
        {
            linkProfileEdit.Click();
            System.Threading.Thread.Sleep(2000);
            linkEdit.Click();
            System.Threading.Thread.Sleep(2000);
            inputCity.Clear();
            inputCity.SendKeys(city);
            buttonSave.Click();
            System.Threading.Thread.Sleep(2000);
        }

        public bool isEditedAddress(string city)
        {
            IWebElement message = driver.FindElement(By.XPath("//DIV[@class='city']"));
            return message.Text.Equals(city);
        }

        public void EditPassword(string oldPassword, string newPassword, string confPassword)
        {
            linkProfileEdit.Click();
            System.Threading.Thread.Sleep(5000);
            linkEditPassword.Click();
            inputOldPassword.SendKeys(oldPassword);
            inputNewPassword.SendKeys(newPassword);
            inputСonfirmedPassword.SendKeys(confPassword);
            buttonOk.Click();
            System.Threading.Thread.Sleep(2000);
        }

        public bool isPasswordEdited()
        {
            IWebElement message = driver.FindElement(By.XPath("//DIV[@class='info_message rounded_corners_5px']"));
            return message.Text.Equals("Пароль был успешно изменен.");
        }

        public void PasswordRestore(string email)
        {
            linkPasswordRestore.Click();
            System.Threading.Thread.Sleep(2000);
            inputEmail.SendKeys(email);
            buttonSend.Click();
            System.Threading.Thread.Sleep(2000);
        }

        public bool isPasswordRestored()
        {
            IWebElement message = driver.FindElement(By.XPath("//DIV[@class='info_message rounded_corners_5px']"));
            return message.Text.Equals("На ваш адрес электронной почты были высланы дальнейшие инструкции.");
        }

        public void AddTicketToCart(string numberOfTickets)
        {
            buttonSearch.Click();
            System.Threading.Thread.Sleep(2000);
            linkEvent.Click();
            System.Threading.Thread.Sleep(2000);
            inputNumberOfTickets.SendKeys(numberOfTickets);
            buttonBasket.Click();
            System.Threading.Thread.Sleep(2000);
        }

        public bool isTicketAdded()
        {
            IWebElement message = driver.FindElement(By.XPath("//DIV[@class='info_message rounded_corners_5px']"));
            return message.Text.Equals("Билет добавлен в корзину.");
        }
    }
}
