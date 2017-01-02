using NUnit.Framework;

namespace SeleniumTests.Tests
{
    [TestFixture]
    class Tests
    {
        private Steps.Steps steps = new Steps.Steps();
        private const string INCORRECT_EMAIL = "testuse12@";
        private const string EMAIL = "testuse112@gmail.com";
        private const string PASSWORD = "qazWSX1996";
        private const string CONFIRM_PASSWORD = "qazWSX1996";
        private const string FNAME = "VTEST";
        private const string LNAME = "LTEST";
        private const string USERNAME = "ixnayvlad@gmail.com";
        private const string SQUARE = "ре паблик";
        private const string EVENT_TYPE = "концерт";
        private const string EVENT_DATE = "13.01.2017";
        private const string EDIT_CITY = "Минск";
        private const string GENRE_EVENT = "Sport";
        private const string OLD_PASSWORD = "qazWSX1996";
        private const string NEW_PASSWORD = "qazWSX1996";
        private const string NUMBER_OF_TICKETS = "1";
        private const string EVENT_FROM = "13.01.2017";
        private const string EVENT_TO = "18.01.2017";
        private const string CATEGORY = "Спорт";
        private const string REGION = "Минск";


        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
        }

        [TearDown]

        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        [Test]
        public void Registration()
        {
            steps.RegisterNewAccount(EMAIL, PASSWORD, CONFIRM_PASSWORD, FNAME, LNAME);
            Assert.True(steps.IsAccountRegistered());
        }

        [Test]
        public void IncorrectRegistered()
        {
            steps.IncorrectRegistered(INCORRECT_EMAIL, PASSWORD, CONFIRM_PASSWORD, FNAME, LNAME);
            Assert.True(steps.IsIncorrectRegistered());
        }

        [Test]
        public void LoggIn()
        {
            steps.LoginTicketPro(USERNAME, PASSWORD);
            Assert.True(steps.IsLoggedIn());
        }

        [Test]
        public void FindBySquare()
        {
            steps.FindBySquare(SQUARE);
            Assert.True(steps.IsFinded());
        }

        [Test]
        public void FindByEventType()
        {
            steps.FindBySquare(EVENT_TYPE);
            Assert.True(steps.IsFinded());
        }

        [Test]
        public void FindByEventDate()
        {
            steps.FindEventByDate(EVENT_DATE);
            Assert.True(steps.IsFindedBy());
        }

        [Test]
        public void EditDeliveryAddress()
        {
            steps.EditDeliveryAddress(EDIT_CITY, USERNAME, PASSWORD);
            Assert.True(steps.IsEditedAddress(EDIT_CITY));
        }

        [Test]
        public void FindByEventGenre()
        {
            steps.FindEventByGenre(GENRE_EVENT);
            Assert.True(steps.IsFindedBy());
        }

        [Test]
        public void EditPassword()
        {
            steps.EditPassword(USERNAME, PASSWORD, OLD_PASSWORD, NEW_PASSWORD, CONFIRM_PASSWORD);
            Assert.True(steps.IsPasswordEdited());
        }


        [Test]
        public void RestorePassword()
        {
            steps.PasswordRestore(USERNAME);
            Assert.True(steps.IsPasswordRestored());
        }

        [Test]
        public void AddTicketToCart()
        {
            steps.TicketAddToCart(USERNAME, PASSWORD, NUMBER_OF_TICKETS);
            Assert.True(steps.IsTicketAdded());
        }

        [Test]
        public void ExtendedSearch()
        {
            steps.ExtendedSearch(EVENT_FROM, EVENT_TO, CATEGORY, REGION);
            Assert.True(steps.IsFinded());
        }

    }
}
