using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LovingHermannBdd.Core
{
    public class Driver
    {
        private Driver() { }

        private static Driver instance = null;
        public static Driver Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Driver();
                }
                return instance;
            }
        }

        public IWebDriver WebDriver { get; private set; }

        public void Init()
        {
            if (WebDriver == null)
            {
                var options = new ChromeOptions();
                options.AddArgument("--incognito");
                options.AddArgument("--start-maximized");

                WebDriver = new ChromeDriver(options);
            }
        }

        public void Close()
        {
            WebDriver.Close();
        }

        public void Navigate(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }
    }
}
