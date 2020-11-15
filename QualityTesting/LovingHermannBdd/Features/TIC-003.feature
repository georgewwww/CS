Feature: TIC-003

Scenario: Verify that the page has a 2020 copyright text
	Given I launch Chrome browser
	And I open https://loving-hermann-e2094b.netlify.app page
	When I scroll to the down of the page
	Then I see '2020' year in the text
	And I close the browser