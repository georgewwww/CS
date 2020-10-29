Feature: CalculatorSearch
	In order to search posts
	As a regular human
	I want to search on Reddit the keyword Calculator

Scenario: Calculator Search
	Given I access reddit.com website
	And I insert calculator keyword in the search-box
	When I press enter on keyboard
	Then the page with posts about calculator is shown
	And I check the logo of the page