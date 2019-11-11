Feature: SpecFlowFeature1
	As a seller
	I want the feature to add my Profile Details
	So that
	The people seeking for some skills can look into my details

@mytag
Scenario: Check if user could able to add a language 
	Given I clicked on the Language tab under Profile page
	When I add a new language
	Then that language should be displayed on my listings

	Scenario: Check if user could cancel when adding language
	Given I clicked on the Language tab
	And I clicked on the add button
	When I click on the cancel button
	Then the application will NOT add the language

	Scenario: Check if user could edit the added language
	Given I clicked on the language tab under the profile page
	When I edit the chosen language
	Then the updated language should be displayed on my listings

	Scenario: Check if user could cancel when editing language
	Given I clicked on the Language tab
	And I clicked on the add button
	And I edit the language and language level
	When I click on the cancel button
	Then the application will NOT change the language

	Scenario: Check if user could delete the added language
	Given I clicked on the Language tab under Profile
	When I delete the chosen language
	Then the deleted language should NOT be displayed on my listings

	Scenario: Check if user could add language with empty language
	Given I clicked on the Language tab
	When I clicked on add button
	Then the application will show an error

	Scenario: Check if user could add language with empty language level
	Given I clicked on the Language tab
	When I clicked on add button
	Then the application will show an error

Scenario: Check if user could add skills to their profile
Given I clicked on the skills tab
When I add a skill
Then the skill i added should be displayed om my profile

	Scenario: Check if user could edit the added skills
	Given I clicked on the skills tab under the profile page
	When I edit the chosen skills
	Then the updated skills should be displayed on my listings

	Scenario: Check if user could delete the added skills
	Given I clicked on the skills tab under Profile
	When I delete the chosen skills
	Then the deleted skills should NOT be displayed on my listings

	Scenario: Check if user could add skills with empty skills
	Given I clicked on the skills tab under Profile
	When I clicked on add button
	Then the application will show an error

	Scenario: Check if user could add skills with empty experience level
	Given I clicked on the skills tab under Profile
	When I clicked on add button
	Then the application will show an error

	Scenario: Check if user could cancel when adding skills
	Given I clicked on the skills tab under Profile
	And I clicked on the add button
	When I click on the cancel button
	Then the application will NOT add the skills

	Scenario: Check if user could cancel when editing skills
	Given I clicked on the Skills tab
	And I clicked on the add button
	And I edit the skills and experience level
	When I click on the cancel button
	Then the application will NOT change the skills

Scenario: Check if user could add certification to their profile
Given I clicked on the certification tab
When I add a certification
Then the certification I added should be displayed on my profile

	Scenario: Check if user could edit the added certification
	Given I clicked on the certification tab under the profile page
	When I edit the chosen certification
	Then the updated certification should be displayed on my listings

	Scenario: Check if user could delete the added certification
	Given I clicked on the certification tab under profile page
	When I delete the chosen certification
	Then the deleted certification should NOT be displayed on my listings

	Scenario: Check if user could add certification with empty certification name
	Given I clicked on the certification tab under profile page
	When I clicked on add button
	Then the application will show an error

	Scenario: Check if user could add certification with empty certification year
	Given I clicked on the certification tab under profile page
	When I clicked on add button
	Then the application will show an error

	Scenario: Check if user could add certification with empty certification from
	Given I clicked on the certification tab under profile page
	When I clicked on add button
	Then the application will show an error

	Scenario: Check if user could cancel when adding Certification
	Given I clicked on the Certification tab under Profile
	And I clicked on the add button
	When I click on the cancel button
	Then the application will NOT add the Certification

	Scenario: Check if user could cancel when editing Certification
	Given I clicked on the Certification tab
	And I clicked on the add button
	And I edit the Certification name, from and year
	When I click on the cancel button
	Then the application will NOT change the Certification

Scenario: Check if user could add education to their profile
	Given I click on the education tab under the profile page
	When I add a education
	Then the education should be added to my listings

	Scenario: Check if user could edit the added education
	Given I clicked on the education tab under the profile page
	When I edit the chosen education
	Then the updated education should be displayed on my listings

	Scenario: Check if user could delete the added education
	Given I clicked on the education tab under profile page
	When I delete the chosen education
	Then the deleted education should NOT be displayed on my listings

	Scenario: Check if user could add education with empty College name 
	Given I clicked on the education tab under profile page
	When I clicked on add button
	Then the application will show an error

	Scenario: Check if user could add education with empty College country 
	Given I clicked on the education tab under profile page
	When I clicked on add button
	Then the application will show an error

	Scenario: Check if user could add education with empty Title or  Degree Year of Graduation
	Given I clicked on the education tab under profile page
	When I clicked on add button
	Then the application will show an error

	Scenario: Check if user could add education with empty Year of Graduation
	Given I clicked on the education tab under profile page
	When I clicked on add button
	Then the application will show an error

	Scenario: Check if user could cancel when adding education
	Given I clicked on the education tab under Profile
	And I clicked on the add button
	When I click on the cancel button
	Then the application will NOT add the education

	Scenario: Check if user could cancel when editing education
	Given I clicked on the education tab
	And I clicked on the add button
	And I edit the College name, country, title and year
	When I click on the cancel button
	Then the application will NOT change the Certification
	