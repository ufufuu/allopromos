Feature: Create Store Category
	In order to improve Store services
	as a site administrator
	I want to be able to Create, View and manage Store Categories
Scenario: Create Store Category
	Given I am logged into the Site as an Administrator
	When I click the Create Store Category link
	And Enter the following information
		| Field         | Value     |
		| Category name | Boutiques |
	And When i click the Create button
	Then I see a Succeded Creation Window