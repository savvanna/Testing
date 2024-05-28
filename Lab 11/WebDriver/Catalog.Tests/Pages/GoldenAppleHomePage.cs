using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Catalog.Tests.Pages
{
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
