Feature: TIC-198

Scenario: Verify that user can access social button links
	Given I launch Chrome browser
	And I open https://loving-hermann-e2094b.netlify.app page
	When I press Facebook button
	Then I am redirected to a page from facebook.com
	And I close the browser