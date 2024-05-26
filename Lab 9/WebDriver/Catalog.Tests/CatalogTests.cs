using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebDriver;

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
}