using LovingHermannBdd.Core;
using LovingHermannBdd.Core.Components;
using OpenQA.Selenium;
using System;
using Xunit;
using Xunit.Gherkin.Quick;

namespace LovingHermannBdd
{
    [FeatureFile("./Features/TIC-197.feature")]
    public class TIC197Steps : Feature
    {

        [Given(@"I launch Chrome browser")]
        public void I_launch_Chrome_browser()
        {
            Driver.Instance.Init();
        }

        [And(@"I open (.*) page")]
        public void I_open_page(string website)
        {
            Driver.Instance.Navigate(website);
        }

        [When(@"I press Add to Cart button")]
        public void I_press_Add_to_Cart_button()
        {
            SinglePage.GetAddToCartButton().Click();
        }

        [Then(@"A popup is shown")]
        public void Then_A_popup_is_shown()
        {
            var popupPresent = CartPopup.GetPopup().Displayed;
            Assert.True(popupPresent);
        }

        [And(@"I insert in 'Quantity' field value (.*)")]
        public void I_insert_in_field_value(string value)
        {
            var inputQuantity = CartPopup.GetQuantityInput();
            inputQuantity.Clear();
            inputQuantity.SendKeys(value);
        }

        [When(@"I press the 'Enter' button on keyboard")]
        public void I_press_the_button_on_keyboard()
        {
            var inputQuantity = CartPopup.GetQuantityInput();
            inputQuantity.SendKeys(Keys.Enter);
        }

        [Then(@"Warning message 'Please match the requested format' is displayed")]
        public void Warning_message_is_displayed()
        {
            var warningPopup = CartPopup.GetInvalidQuantityInput();
            Assert.True(warningPopup.Displayed);
        }

        [And(@"I close the browser")]
        public void I_close_the_browser()
        {
            Driver.Instance.WebDriver.Close();
        }
    }
}
