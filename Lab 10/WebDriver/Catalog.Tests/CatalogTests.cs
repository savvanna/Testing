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
        public void WhenUsingPriceFilter_PriceFilterTagShouldAppear_WithCorrectPrice()
        {
            _driver.Manage().Window.Maximize();
            _homePage.NavigateTo();

            _homePage.OpenPriceFilter();
            _homePage.SelectPriceRange(2);

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
        public void WhenUsingPriceFilter_PriceFilterTagShouldAppear_WithCorrectPrice_New()
        {
            _driver.Manage().Window.Maximize();

            _driver.Navigate().GoToUrl("https://goldapple.by/");

            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/div/div/header/div[2]/div[2]/button[2]"))).Click();
            var inputField = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/div/div/aside[1]/div[2]/div/div/div/div/div/div[1]/div/div/div/form/div[1]/input[1]")));
            inputField.SendKeys("pfffhfbyv");
            inputField.SendKeys(Keys.Enter);
            var notificationXPath = "/html/body/div/div/div/main/header/div/div[2]";
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(notificationXPath)));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }

    public class GoldAppleHomePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public GoldAppleHomePage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl("https://goldapple.by/");
        }

        public void OpenPriceFilter()
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/div/div/header/div[2]/div[1]/div/button"))).Click();
        }

        public void SelectPriceRange(int rangeIndex)
        {
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"/html/body/div/div/div/aside[4]/div[2]/div/div/div/div/div/div[3]/div[2]/ul/li[{rangeIndex}]/div"))).Click();
        }

        // Add methods to interact with elements related to the price filter tag and error message

        public bool IsPriceFilterTagDisplayed()
        {
            return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//your-xpath-to-price-filter-tag"))).Displayed;
        }

        public string GetPriceFilterTagText()
        {
            return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//your-xpath-to-price-filter-tag"))).Text;
        }

        public bool IsErrorMessageDisplayed()
        {
            return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//your-xpath-to-error-message"))).Displayed;
        }

        public string GetErrorMessageText()
        {
            return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//your-xpath-to-error-message"))).Text;
        }

        public void SearchForProduct(string productName)
        {
            var inputField = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/div/div/header/div[2]/div[2]/button[2]")));
            inputField.SendKeys(productName);
            inputField.SendKeys(Keys.Enter);
        }
    }
}


/*namespace WebDriver;

public class CatalogTests
{
    private IWebDriver _driver;
    private WebDriverWait _wait;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    [Test]
    public void WhenUsingPriceFilter_PriceFilterTagShouldAppear_WithCorrectPrice()
    {
        _driver.Manage().Window.Maximize();

        _driver.Navigate().GoToUrl("https://goldapple.by/");

        _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/div/div/header/div[2]/div[2]/button[2]"))).Click();
        var inputField = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/div/div/aside[1]/div[2]/div/div/div/div/div/div[1]/div/div/div/form/div[1]/input[1]")));
        inputField.SendKeys("pfffhfbyv");
        inputField.SendKeys(Keys.Enter);
        var notificationXPath = "/html/body/div/div/div/main/header/div/div[2]"; 
        _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(notificationXPath)));
    }
  

   


    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}*/
