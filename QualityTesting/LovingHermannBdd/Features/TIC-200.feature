Feature: TIC-200

Scenario: Verify that user can access Flickr images links
	Given I launch Chrome browser
	And I open https://loving-hermann-e2094b.netlify.app page
	When I press first Flickr post
	Then I am redirected to a page from flickr.com
	And I close the browser