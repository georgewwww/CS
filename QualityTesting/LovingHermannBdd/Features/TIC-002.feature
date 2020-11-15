Feature: TIC-002

Scenario: Verify that user can perform sign in action with valid data
	Given I launch Chrome browser
	And I open https://loving-hermann-e2094b.netlify.app page
	When I press Sign In button
	Then Sign In popup is displayed
	When I fill the name input with 'foo'
	And I fill the email input with 'foo@bar.co'
	And I press Submit button
	Then The main page with logged data is displayed
	And I close the browser