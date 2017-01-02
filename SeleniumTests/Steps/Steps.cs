using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumTests.Steps
{
    class Steps
    {
        IWebDriver driver;
        public void InitBrowser()
        {
            driver = DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            DriverInstance.CloseBrowser();
        }

        public void RegisterNewAccount(string email, string pass, string conf, string fname, string lname)
        {
            Pages.RegistrationPage registrationPage = new Pages.RegistrationPage(driver);
            registrationPage.OpenPage();
            registrationPage.Registrated(email, pass, conf, fname, lname);
        }

        public void IncorrectRegistered(string email, string pass, string conf, string fname, string lname)
        {
            Pages.RegistrationPage registrationPage = new Pages.RegistrationPage(driver);
            registrationPage.OpenPage();
            registrationPage.IncorrectRegistrated(email, pass, conf, fname, lname);
        }

        public bool IsIncorrectRegistered()
        {
            Pages.RegistrationPage registrationPage = new Pages.RegistrationPage(driver);
            return registrationPage.isIncorrectRegistered();
        }

        public bool IsAccountRegistered()
        {
            Pages.RegistrationPage registrationPage = new Pages.RegistrationPage(driver);
            return registrationPage.isRegistrated();
        }

        public void LoginTicketPro(string username, string password)
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            profilePage.OpenPage();
            profilePage.Login(username,password);
        }

        public bool IsLoggedIn()
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            return profilePage.isLoggedIn();
        }

        public void FindBySquare(string square)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.FindBySquare(square);
        }

        public void FindByEventType(string eventType)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.FindByEventType(eventType);
        }

        public bool IsFinded()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            return mainPage.isFinded();
        }

        public void FindEventByDate(string date)
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            profilePage.OpenPage();
            profilePage.FindByEventDate(date);
        }

        public void FindEventByGenre(string genre)
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            profilePage.OpenPage();
            profilePage.FindByEventGenre(genre);
        }

        public bool IsFindedBy()
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            return profilePage.isFindedBy();
        }

        public void EditDeliveryAddress(string city, string username, string password)
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            profilePage.OpenPage();
            profilePage.Login(username, password);
            profilePage.EditDeliveryAddress(city);
        }

        public bool IsEditedAddress(string city)
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            return profilePage.isEditedAddress(city);
        }

        public void EditPassword(string username, string password, string oldPaswword, string newPassword, string confirmPassword)
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            profilePage.OpenPage();
            profilePage.Login(username, password);
            profilePage.EditPassword(oldPaswword, newPassword, confirmPassword);
        }

        public bool IsPasswordEdited()
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            return profilePage.isPasswordEdited();
        }

        public void PasswordRestore(string email)
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            profilePage.OpenPage();
            profilePage.PasswordRestore(email);
        }

        public bool IsPasswordRestored()
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            return profilePage.isPasswordRestored();
        }

        public void TicketAddToCart(string username, string password, string numberOfTickets)
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            profilePage.OpenPage();
            profilePage.Login(username, password);
            profilePage.AddTicketToCart(numberOfTickets);
        }

        public bool IsTicketAdded()
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            return profilePage.isTicketAdded();
        }

        public void ExtendedSearch(string eventFrom, string eventTo, string category, string region)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.ExtendedSearch(eventFrom,eventTo, category, region);
        }

    }
}
