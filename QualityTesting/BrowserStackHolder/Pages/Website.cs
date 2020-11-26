using BrowserStackHolder.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace BrowserStackHolder.Pages
{
    public class Website
    {
        private readonly IWebDriver WebDriver;
        private readonly Collection<TestPage> Pages;

        public Website()
        {
            WebDriver = InitializeWebDriver();
            Pages = InitializePages();
        }

        [Obsolete]
        private IWebDriver InitializeWebDriver()
        {
            DesiredCapabilities caps = new DesiredCapabilities();

            caps.SetCapability("os", "Windows");
            caps.SetCapability("os_version", "10");
            caps.SetCapability("browser", "Chrome");
            caps.SetCapability("browser_version", "latest");
            caps.SetCapability("browserstack.user", "USER");
            caps.SetCapability("browserstack.key", "KEY");
            caps.SetCapability("name", "georgec13's First Test");

            return new RemoteWebDriver(
              new Uri("https://hub-cloud.browserstack.com/wd/hub/"), caps
            );
        }

        private Collection<TestPage> InitializePages()
        {
            return new Collection<TestPage>
            {
                new HomePage(WebDriver),
                new ResultPage(WebDriver)
            };
        }

        public void GoTo(string link)
        {
            WebDriver.Navigate().GoToUrl(link);
        }

        public bool PageLoaded()
        {
            try
            {
                var waitForDocumentReady = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5));
                waitForDocumentReady.Until((wdriver) =>
                    (WebDriver as IJavaScriptExecutor).ExecuteScript("return document.readyState").Equals("complete"));
                return true;
            }
            catch (TimeoutException)
            {
                return false;
            }
        }

        public TestPage GetPage(PageName pageName)
        {
            return Pages.FirstOrDefault(page => page.Name.Equals(pageName));
        }

        public bool DoesElementExistOnPage(PageName pageName, Element element)
        {
            var locator = GetPage(pageName).GetLocator(element);
            try
            {
                WebDriver.FindElement(locator.FindBy);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public int GetElementsCountOnPage(PageName pageName, Element element)
        {
            var locator = GetPage(pageName).GetLocator(element);
            try
            {
                return WebDriver.FindElements(locator.FindBy).Count;
            }
            catch (NoSuchElementException)
            {
                return 0;
            }
        }

        public void ClickElementOnPage(PageName pageName, Element element)
        {
            var locator = GetPage(pageName).GetLocator(element);
            WebDriver.FindElement(locator.FindBy).Submit();
        }

        public void EnterTextIntoInputField(PageName pageName, Element element, string text)
        {
            var locator = GetPage(pageName).GetLocator(element);
            WebDriver.FindElement(locator.FindBy).SendKeys(text);
        }

        public void Dispose()
        {
            WebDriver.Dispose();
        }
    }
}
