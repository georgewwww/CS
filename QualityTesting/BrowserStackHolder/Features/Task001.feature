Feature: Task001

@Homepage
Scenario: Check page availability
	Given the link https://www.google.co.in
	When enter the link provided
	Then the google page is shown

@SearchResult
Scenario: Check how many results are shown
	Given the link https://google.com
	When fill the search input with calculator
	And press the search button
	Then count how many results are on page

@SearchNothing
Scenario: Search nothing
	Given the link https://google.com
	When leave the search input with empty string
	And press the search button
	Then page remains the same

@SearchIrrelevant
Scenario: Irrelevant search
	Given the link https://google.com
	When fill the search input with clculator
	And press the search button
	Then result page is shown
	And do you mean link is present