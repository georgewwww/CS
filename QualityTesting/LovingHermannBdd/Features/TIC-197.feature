Feature: TIC-197

Scenario: Verify that user can change cart items with negative quantity
	Given I launch Chrome browser
	And I open https://loving-hermann-e2094b.netlify.app/single.html page
	When I press Add to Cart button
	Then A popup is shown
	And I insert in 'Quantity' field value -2
	When I press the 'Enter' button on keyboard
	Then Warning message 'Please match the requested format' is displayed
	And I close the browser