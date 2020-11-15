using LovingHermannBdd.Core;
using LovingHermannBdd.Core.Components;
using Xunit;
using Xunit.Gherkin.Quick;

namespace LovingHermannBdd
{
    [FeatureFile("./Features/TIC-200.feature")]
    public class TIC200Steps : Feature
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

        [When(@"I press first Flickr post")]
        public void I_press_first_Flickr_post()
        {
            var element = Footer.GetFirstFlickrPost();
            element.Click();
        }

        [Then(@"I am redirected to a page from (.*)")]
        public void I_am_redirected_to_a_page_from(string page)
        {
            Assert.Contains(page, Driver.Instance.WebDriver.Url);
        }

        [And(@"I close the browser")]
        public void I_close_the_browser()
        {
            Driver.Instance.WebDriver.Close();
        }
    }
}
