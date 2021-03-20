Feature: YouTube REST API tests

@checkStatusCode
Scenario: Check status code
	Given the client setup
	And the request setup
	When send request
	Then the response status code should be OK