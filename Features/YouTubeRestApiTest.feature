Feature: YouTube rest api test

@statusCode
Scenario: Check status code
	Given Launch Rest client "https://youtube.googleapis.com"
	And Build request select endpoint "/youtube/v3/videos" and auth
	And Build request add param "id" with value "stX4SSzUQDA"
	And Build get request from steps above
	When I send request
	Then Response status code should be OK



@statusCode @json
Scenario: Check status code and json videos
	Given Launch Rest client "https://youtube.googleapis.com"
	And Build request select endpoint "/youtube/v3/videos" and auth
	And Build request add param "part" with value "snippet"
	#And Build request add param "part" with value "statistics"
	And Build request add param "id" with value "stX4SSzUQDA"
	And Build get request from steps above
	When I send request
	Then Response status code should be OK
	And Check if response contains "web cucumber jenkins"




@statusCode @json
Scenario: Check status code and json channels
	Given Launch Rest client "https://youtube.googleapis.com"
	And Build request select endpoint "/youtube/v3/channels" and auth
	And Build request add param "part" with value "snippet"
	And Build request add param "part" with value "statistics"
	And Build request add param "id" with value "UCHMiUerOCwT7tMR2wRaSeoA"
	And Build get request from steps above
	When I send request
	Then Response status code should be OK
	And Check if response contains "Fantom"
