Feature: TIC-001

Scenario: Verify that user can't perform sign in action with invalid data
	Given I launch Chrome browser
	And I open https://loving-hermann-e2094b.netlify.app page
	When I press Sign In button
	Then Sign In popup is displayed
	When I fill the name input with 'foo'
	And I fill the email input with 'bar'
	And I press Submit button
	Then A warning message is displayed under email input
	And I close the browser