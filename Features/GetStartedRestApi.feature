Feature: Tutorial REST API tests
# https://www.ontestautomation.com/restful-api-testing-in-csharp-with-restsharp/
# many thanks to Bas Dijkstra - I really fast get started REST with blog

@checkStatusCode
Scenario: Check status code
	Given the client setup
	And the request setup
	When send request
	Then the response status code should be OK

@checkStatusResponseType
Scenario: Check response type
	Given the client setup
	And the request setup
	When send request
	Then the response type should be json

@checkJsonContent
Scenario: Check json content
	Given the client setup
	And the request setup
	When send request
	Then the response location should be US

@checkJsonContentPlaces
Scenario: Check json content places
	Given the client setup
	And the request setup
	When send request
	Then the response place should be "New York"