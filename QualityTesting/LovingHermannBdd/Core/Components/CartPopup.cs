using OpenQA.Selenium;

namespace LovingHermannBdd.Core.Components
{
    public class CartPopup
    {
        private static readonly string popupId = "PPMiniCart";
        private static readonly string quantityInputName = "quantity_1";
        private static readonly string quantityErrorInputMessage = "input.minicart-quantity:invalid";
        private static readonly string checkoutButtonName = "checkout";

        public static IWebElement GetPopup()
        {
            return Driver.Instance.WebDriver.FindElement(By.Id(popupId));
        }

        public static IWebElement GetQuantityInput()
        {
            return Driver.Instance.WebDriver.FindElement(By.Name(quantityInputName));
        }

        public static IWebElement GetInvalidQuantityInput()
        {
            return Driver.Instance.WebDriver.FindElement(By.CssSelector(quantityErrorInputMessage));
        }

        public static IWebElement GetCheckoutButton()
        {
            return Driver.Instance.WebDriver.FindElement(By.Name(checkoutButtonName));
        }
    }
}
