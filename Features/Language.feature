Feature: Language

@languageTests
Scenario:01 Verify whether user with valid credentials is redirected to Profile page
	Given the Mars Project url is opened
	When the user logs in with valid credentials <Email_address> and <Password>
	Then the user should be redirected to the Profile page
	And the text <Profile_Name> should be displayed.

Examples:
	| Email_address        | Password | Profile_Name |
	| "lija2512@gmail.com" | "123456" | "Hi Lija"    |


Scenario:02 Verify whether user with invalid credentials is able to login and access the profile page
	Given the Mars Project url is opened
	When the user logs in with invalid credentials <Email_address> and <Password>
	Then the user should not be redirected to the Profile Page

Examples:
	| Email_address    | Password |
	| "lija@gmail.com" | "1234"   |

Scenario:03 Verify whether the user on clicking Add New button under language tab is able to create a record
	Given the Mars Project url is opened
	When  the user logs in with valid credentials <Email_address> and <Password>
	Then the user should be redirected to the Profile page
	And the user clicks on AddNew button enters <Language> and <Languagelevel> and clicks on Add button
	And the <Language> record should be displayed in the table

Examples:
	| Email_address        | Password | Languagelevel | Language  |
	| "lija2512@gmail.com" | "123456" | "Fluent"      | "English" |

Scenario:04 Verify whether the user is able to update the language record created
	Given the Mars Project url is opened
	When  the user logs in with valid credentials <Email_address> and <Password>
	Then the user should be redirected to the Profile page
	And the user clicks on AddNew button enters <Language> and <LanguageLevel> and clicks on Add button
	And the <Language> record should be displayed in the table
	When the user clicks on edit icon and updates the field with <UpdatedLanguageLevel>
	Then the <UpdatedLanguageLevel> of the record should get updated successfully

Examples:
	| Email_address        | Password | Language  | LanguageLevel | UpdatedLanguageLevel |
	| "lija2512@gmail.com" | "123456" | "English" | "Basic"       | "Native/Bilingual"   |


	Scenario:05 Verify whether the validations during add language are working as expected.
	Given the Mars Project url is opened
	When  the user logs in with valid credentials <Email_address> and <Password>
	Then the user should be redirected to the Profile page
	And verify adding language <Language> validations are working 

Examples:
	| Email_address        | Password | Language  |
	| "lija2512@gmail.com" | "123456" | "English" |
	| "lija2512@gmail.com" | "123456" | "Hindi"   |

Scenario:06 Verify whether the validations during edit language are working as expected.
	Given the Mars Project url is opened
    When  the user logs in with valid credentials <Email_address> and <Password>
	Then the user should be redirected to the Profile page
	And the user clicks on AddNew button enters <Language1> and <LanguageLevel1> and clicks on Add button
	And the user clicks on AddNew button enters <Language2> and <LanguageLevel2> and clicks on Add button
	And verify editing language <Language1> and <LanguageLevel1> validations are working  

	Examples:
	| Email_address        | Password | Language1 | LanguageLevel1     | Language2 | LanguageLevel2     |
	| "lija2512@gmail.com" | "123456" | "English" | "Native/Bilingual" | "French"  | "Fluent"           |



	Scenario:07 Verify whether once all  the four languages added are displayed in the list the Add New button gets disabled
	Given the Mars Project url is opened
	When  the user logs in with valid credentials <Email_address> and <Password>
	Then the user should be redirected to the Profile page
	And the user clicks on AddNew button enters <Language1> and <LanguageLevel1> and clicks on Add button
	And the user clicks on AddNew button enters <Language2> and <LanguageLevel2> and clicks on Add button
	And the user clicks on AddNew button enters <Language3> and <LanguageLevel3> and clicks on Add button
	When the user clicks on Add New button and creates the last language record with <Language> and <LanguageLevel> after that the button is disabled

	Examples:
	| Email_address        | Password | Language     | LanguageLevel | Language1    | LanguageLevel1 | Language2 | LanguageLevel2 | Language3 | LanguageLevel3 |
	| "lija2512@gmail.com" | "123456" | "Java"       | "Basic"      | "Javascript" | "Fluent"       | "C#"      | "Fluent"     | "Python"  | "Basic"     |
	


	Scenario:08 Verify whether the existing record is deleted on clicking the cross (X) icon and a message is displayed
	Given the Mars Project url is opened
	When  the user logs in with valid credentials <Email_address> and <Password>
	Then the user should be redirected to the Profile page
	And the user clicks on AddNew button enters <Language> and <LanguageLevel> and clicks on Add button
	When the user clicks on the cross icon against the <Language1> record
	Then the <Language> record should be deleted

Examples:
	| Email_address        | Password | Language | LanguageLevel | Language1 |
	| "lija2512@gmail.com" | "123456" | "French" | "Beginner"     | "French"  |



