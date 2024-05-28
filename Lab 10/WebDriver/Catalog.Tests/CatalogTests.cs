using Catalog.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebDriver
{
    public class CatalogTests
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private GoldAppleHomePage _homePage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _homePage = new GoldAppleHomePage(_driver, _wait);
        }

        [Test]
        public void When_Change_City()
        {
            _driver.Manage().Window.Maximize();
            _homePage.NavigateTo();

            _homePage.OpenPriceFilter();
            _homePage.SelectPriceRange(2);

            Thread.Sleep(1500);

            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/div/div/header/div[2]/div[1]/div/button/div[2]/div/span")));
            var notificationText = _driver.FindElement(By.XPath("/html/body/div/div/div/header/div[2]/div[1]/div/button/div[2]/div/span")).Text;
            Assert.That(notificationText, Is.EqualTo("Гомель"));

            // You'll need to add assertions here to check if the price filter tag is displayed
            // and if it contains the correct price range.
            // Example:
            // Assert.IsTrue(_homePage.IsPriceFilterTagDisplayed(), "Price filter tag is not displayed.");
            // Assert.AreEqual(_homePage.GetPriceFilterTagText(), "Price range: 100-200", "Incorrect price range displayed."); 
        }

        [Test]
        public void WhenSearchingForInvalidProduct_ErrorMessageShouldAppear()
        {
            _driver.Manage().Window.Maximize();
            _homePage.NavigateTo();

            _homePage.SearchForProduct("pfffhfbyv");

            

            // You'll need to add assertions here to check if the error message is displayed.
            // Example:
            // Assert.IsTrue(_homePage.IsErrorMessageDisplayed(), "Error message is not displayed.");
            // Assert.AreEqual(_homePage.GetErrorMessageText(), "No results found for 'pfffhfbyv'.", "Incorrect error message displayed.");
        }

        [Test]
        public void When_chose_wrong_product()
        {
            _driver.Manage().Window.Maximize();

            _driver.Navigate().GoToUrl("https://goldapple.by/");

            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/div/div/header/div[2]/div[2]/button[2]"))).Click();
            var inputField = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/div/div/aside[1]/div[2]/div/div/div/div/div/div[1]/div/div/div/form/div[1]/input[1]")));
            inputField.SendKeys("pfffhfbyv");
            inputField.SendKeys(Keys.Enter);
            var notificationXPath = "/html/body/div/div/div/main/header/div/div[2]";
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(notificationXPath)));

            var notificationText = _driver.FindElement(By.XPath("/html/body/div/div/div/main/header/div/div[2]/p")).Text;
            Assert.That(notificationText, Is.EqualTo("Ничего не найдено. Попробуйте изменить запрос и мы поищем ещё раз."));


        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
