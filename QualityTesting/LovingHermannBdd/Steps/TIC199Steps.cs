using LovingHermannBdd.Core;
using LovingHermannBdd.Core.Components;
using Xunit;
using Xunit.Gherkin.Quick;

namespace LovingHermannBdd
{
    [FeatureFile("./Features/TIC-199.feature")]
    public class TIC199Steps : Feature
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

        [And(@"A checkout button is displayed")]
        public void A_checkout_button_is_displayed()
        {
            var checkoutButton = CartPopup.GetCheckoutButton();
            Assert.True(checkoutButton.Displayed);
        }

        [And(@"I close the browser")]
        public void I_close_the_browser()
        {
            Driver.Instance.WebDriver.Close();
        }
    }
}
