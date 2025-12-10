Feature:Skills
@SkillsTests

Scenario:01 Verify whether user with valid credentials is redirected to Profile page
	Given the Mars Project url is opened
	When the user clicks logs in with valid credentials <Email_address> and <Password>
	Then the user should be redirected to the Profile page with Profile name <Profile_Name>
	And click on Skill tab

Examples:
| Email_address | Password | Profile_Name |
| "lija2512@gmail.com" | "123456" | "Hi Lija" |


Scenario:02 Verify whether the user on clicking Add New button in Skills tab is able to create a record
   Given the Mars Project url is opened
    When the user clicks logs in with valid credentials <Email_address> and <Password>
	Then the user should be redirected to the Profile page
	Then click on Skill tab
	When the user clicks on AddNew button enters <Skill> and <SkillLevel> and clicks on Add button in the skills section
	Then the <Skill> skill record should be displayed in the table

Examples:
| Email_address        | Password | Skill               | SkillLevel |
| "lija2512@gmail.com" | "123456" | "Automated testing" | "Expert"   |

Scenario:03 Verify whether the user is able to update the skills record created
	Given the Mars Project url is opened
   When the user clicks logs in with valid credentials <Email_address> and <Password>
	Then the user should be redirected to the Profile page
	Then click on Skill tab
	And the <Skill> skill record should be displayed in the table
	Then the user clicks on the edit icon and updates the skill level<UpdatedSkill_Level> and clicks on update button
	And the <UpdatedSkillLevel> skill level should get updated successfully
Examples:
| Email_address        | Password | Skill               | UpdatedSkill_Level |
| "lija2512@gmail.com" | "123456" | "Automated testing" | "Intermediate"     |

Scenario:04 Verify whether the validations during add skills are working as expected.
	Given the Mars Project url is opened
	When  the user clicks logs in with valid credentials <Email_address> and <Password>
	Then the user should be redirected to the Profile page
	And click on Skill tab
	And verify the Add skill validations and also when entering  <Existing_Skill> and <Existing_skilllevel> are working

	Examples: 
	| Email_address        | Password | Existing_Skill | Existing_skilllevel |
	| "lija2512@gmail.com" | "123456" | "Automated testing"| "Intermediate"  |

	Scenario:05 Verify whether the validations during edit skills are working as expected.
	Given the Mars Project url is opened
	When  the user clicks logs in with valid credentials <Email_address> and <Password>
	Then the user should be redirected to the Profile page
	And click on Skill tab
	And verify the Edit skill validations are working  
    Examples:
	| Email_address        | Password |
	| "lija2512@gmail.com" | "123456" |

	Scenario:06 Verify whether the existing skill record is deleted on clicking the cross (X) icon and a message is displayed
	Given the Mars Project url is opened
	When  the user clicks logs in with valid credentials <Email_address> and <Password>
	Then the user should be redirected to the Profile page
	And click on Skill tab
	When the user clicks on the cross icon against the <skill> skill record
	Then the <Skill> skill record should be deleted
	 Examples:
	| Email_address        | Password | Skill               |
	| "lija2512@gmail.com" | "123456" | "Automated testing" |
