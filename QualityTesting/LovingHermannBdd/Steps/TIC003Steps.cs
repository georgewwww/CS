using LovingHermannBdd.Core;
using LovingHermannBdd.Core.Components;
using Xunit;
using Xunit.Gherkin.Quick;

namespace LovingHermannBdd
{
    [FeatureFile("./Features/TIC-003.feature")]
    public class TIC003Steps : Feature
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

        [When(@"I scroll to the down of the page")]
        public void I_scroll_to_the_down_of_the_page()
        {
            Footer.MoveTo();
        }

        [Then(@"I see '(.*)' year in the text")]
        public void I_see_year_in_the_text(string year)
        {
            var textElement = Footer.GetCopyrightText();
            Assert.Contains(year, textElement.Text);
        }

        [And(@"I close the browser")]
        public void I_close_the_browser()
        {
            Driver.Instance.WebDriver.Close();
        }
    }
}
