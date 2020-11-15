Feature: TIC-196

Scenario: Verify that user can change cart items with positive quantity
	Given I launch Chrome browser
	And I open https://loving-hermann-e2094b.netlify.app/single.html page
	When I press Add to Cart button
	Then A popup is shown
	And I insert in 'Quantity' field value 2
	When I press the 'Enter' button on keyboard
	Then Input with quantity is changed to 2
	And I close the browser