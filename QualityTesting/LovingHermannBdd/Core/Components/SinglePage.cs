using OpenQA.Selenium;

namespace LovingHermannBdd.Core.Components
{
    public class SinglePage
    {
        private static readonly string addToCartButtonXPath = "/html/body/div[7]/div/div[2]/div[5]/div/form/fieldset/input[10]";

        public static IWebElement GetAddToCartButton()
        {
            return Driver.Instance.WebDriver.FindElement(By.XPath(addToCartButtonXPath));
        }
    }
}
