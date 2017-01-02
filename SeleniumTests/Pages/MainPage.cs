using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumTests.Pages
{
    class MainPage : AbstractPage
    {
        private const string BASE_URL = "http://www.ticketpro.by/jnp/home/index.html";

        [FindsBy(How = How.Id, Using = "queryANDWords")]
        private IWebElement inputQuery;

        [FindsBy(How = How.Id, Using = "sB1")]
        private IWebElement buttonSearch;

        [FindsBy(How = How.Id, Using = "popClose")]
        private IWebElement buttonPop;

        [FindsBy(How = How.LinkText, Using = "Расширенный поиск")]
        private IWebElement linkExtendSearch;


        [FindsBy(How = How.Id, Using = "category")]
        private IWebElement buttonCategory;

        [FindsBy(How = How.Id, Using = "region")]
        private IWebElement buttonRegion;


        [FindsBy(How = How.Id, Using = "eventFrom")]
        private IWebElement inputEventFrom;


        [FindsBy(How = How.Id, Using = "eventTo")]
        private IWebElement inputEventTo;









        public void FindBySquare(string square)
        {
            System.Threading.Thread.Sleep(2000);
            buttonPop.Click();
            System.Threading.Thread.Sleep(2000);
            inputQuery.SendKeys(square);
            buttonSearch.Click();
            System.Threading.Thread.Sleep(2000);
        }

        public bool isFinded()
        {

            IWebElement findstring = driver.FindElement(By.Id("article"));
            if (findstring.Displayed)
                return true;
            else
                return false;
        }

        public void FindByEventType(string eventType)
        {
            System.Threading.Thread.Sleep(2000);
            buttonPop.Click();
            System.Threading.Thread.Sleep(2000);
            inputQuery.SendKeys(eventType);
            buttonSearch.Click();
            System.Threading.Thread.Sleep(2000);

        }

        public void ExtendedSearch(string eventFrom, string eventTo, string category, string region)
        {
            System.Threading.Thread.Sleep(2000);
            buttonPop.Click();
            System.Threading.Thread.Sleep(2000);
            linkExtendSearch.Click();
            System.Threading.Thread.Sleep(2000);
            buttonCategory.Click();
            System.Threading.Thread.Sleep(2000);
            buttonCategory.SendKeys(category);
            buttonRegion.Click();
            System.Threading.Thread.Sleep(2000);
            buttonRegion.SendKeys(region);
            System.Threading.Thread.Sleep(2000);
            inputEventFrom.SendKeys(eventFrom);
            inputEventTo.SendKeys(eventTo);
            buttonSearch.Click();


        }

        public MainPage(IWebDriver driver)
            : base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            System.Threading.Thread.Sleep(2000);
            driver.Navigate().GoToUrl(BASE_URL);
        }

    }
}
