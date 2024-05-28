using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Catalog.Tests.Driver;

public class DriverManager
{
    private IWebDriver _driver;

    public IWebDriver GetInstance()
    {
        if (_driver is null)
        {
            _driver = new ChromeDriver();
        }

        return _driver;
    }

    public WebDriverWait GetWaitInstance(int waitTime)
    {
        var driver = GetInstance();

        return new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
    }

    public void MaximizeWindow()
    {
        _driver?.Manage().Window.Maximize();
    }

    public void Cleanup()
    {
        _driver?.Quit();
        _driver = null;
    }
}
