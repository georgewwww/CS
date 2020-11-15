Feature: TIC-199

Scenario: Verify that user can check-out the cart items
	Given I launch Chrome browser
	And I open https://loving-hermann-e2094b.netlify.app/single.html page
	When I press Add to Cart button
	Then A popup is shown
	And A checkout button is displayed
	And I close the browser