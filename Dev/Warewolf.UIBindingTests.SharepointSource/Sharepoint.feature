﻿@SharepointSource
Feature: Sharepoint
	In order to connect with Sharepoint Online
	As a Warewolf User
	I want to be able to interact with a sharepoint server

@SharepointSource
@MSTest:DeploymentItem:InfragisticsWPF4.Controls.Interactions.XamDialogWindow.v15.1.dll
@MSTest:DeploymentItem:Warewolf_Studio.exe
@MSTest:DeploymentItem:Newtonsoft.Json.dll
@MSTest:DeploymentItem:Microsoft.Practices.Prism.SharedInterfaces.dll
@MSTest:DeploymentItem:System.Windows.Interactivity.dll
Scenario: Creating New Sharepoint Source 
   Given I open New Sharepoint Source 
   Then "New SharePoint Service Source" tab is opened
   And title is "New SharePoint Service Source"
   And I type Address as "http://rsaklfsvrdev"
   Then "New SharePoint Service Source *" tab is opened
   And "Save" is "Disabled"
   And "Test Connection" is "Enabled"
   And I Select Authentication Type as "Windows"
   And Username field is "Collapsed"
   And Password field is "Collapsed"
   When Test Connecton is "Successful"
   And "Save" is "Enabled"
   When I save as "Testing Sharepoint Resource Save"
   Then the save dialog is opened
   Then title is "Testing Sharepoint Resource Save"
   And "Testing Sharepoint Resource Save" tab is opened

@SharepointSource
@MSTest:DeploymentItem:InfragisticsWPF4.Controls.Interactions.XamDialogWindow.v15.1.dll
@MSTest:DeploymentItem:Warewolf_Studio.exe
@MSTest:DeploymentItem:Newtonsoft.Json.dll
@MSTest:DeploymentItem:Microsoft.Practices.Prism.SharedInterfaces.dll
@MSTest:DeploymentItem:System.Windows.Interactivity.dll
Scenario: Creating New Sharepoint Source under auth type as user
   Given I open New Sharepoint Source
   And I type Address as "http://rsaklfsvrdev"
   And "Save" is "Disabled"
   And "Test Connection" is "Enabled"
   And I Select Authentication Type as "User"
   And Username field is "Visible"
   And Password field is "Visible"
   And I type Username as "IntegrationTester"
   And I type Password
   When Test Connecton is "Successful"
   And "Save" is "Enabled"
   When I save the source
   Then the save dialog is opened

@SharepointSource
@MSTest:DeploymentItem:InfragisticsWPF4.Controls.Interactions.XamDialogWindow.v15.1.dll
@MSTest:DeploymentItem:Warewolf_Studio.exe
@MSTest:DeploymentItem:Newtonsoft.Json.dll
@MSTest:DeploymentItem:Microsoft.Practices.Prism.SharedInterfaces.dll
@MSTest:DeploymentItem:System.Windows.Interactivity.dll
Scenario: Incorrect address anonymous auth type not allowing save
   Given I open New Sharepoint Source
   And I type Address as "sdfsdfd"
   And "Save" is "Disabled"
   And "Test Connection" is "Enabled"
   And I Select Authentication Type as "Windows"
   When Test Connecton is "UnSuccessful"
   And Validation message is thrown
   And "Save" is "Disabled"

@SharepointSource
@MSTest:DeploymentItem:InfragisticsWPF4.Controls.Interactions.XamDialogWindow.v15.1.dll
@MSTest:DeploymentItem:Warewolf_Studio.exe
@MSTest:DeploymentItem:Newtonsoft.Json.dll
@MSTest:DeploymentItem:Microsoft.Practices.Prism.SharedInterfaces.dll
@MSTest:DeploymentItem:System.Windows.Interactivity.dll
Scenario: Incorrect address Shows correct error message
   Given I open New Sharepoint Source
   And I type Address as "sdfsdfd"
   And "Save" is "Disabled"
   And "Test Connection" is "Enabled"
   And I Select Authentication Type as "Windows"
   When Test Connecton is "UnSuccessful"
   And Validation message is thrown
   And "Save" is "Disabled"
   And the error message is "Unable to contact Server : Test Failed: Value does not fall within the expected range."

@SharepointSource
@MSTest:DeploymentItem:InfragisticsWPF4.Controls.Interactions.XamDialogWindow.v15.1.dll
@MSTest:DeploymentItem:Warewolf_Studio.exe
@MSTest:DeploymentItem:Newtonsoft.Json.dll
@MSTest:DeploymentItem:Microsoft.Practices.Prism.SharedInterfaces.dll
@MSTest:DeploymentItem:System.Windows.Interactivity.dll
Scenario: Incorrect address user auth type is not allowing to save
   Given I open New Sharepoint Source
   And I type Address as "sdfsdfd"
   And "Save" is "Disabled"
   And "Test Connection" is "Enabled"
   And I Select Authentication Type as "User"
   And I type Username as "test"
   And I type Password
   When Test Connecton is "UnSuccessful"
   And Validation message is thrown
   And "Save" is "Disabled"

@SharepointSource
@MSTest:DeploymentItem:InfragisticsWPF4.Controls.Interactions.XamDialogWindow.v15.1.dll
@MSTest:DeploymentItem:Warewolf_Studio.exe
@MSTest:DeploymentItem:Newtonsoft.Json.dll
@MSTest:DeploymentItem:Microsoft.Practices.Prism.SharedInterfaces.dll
@MSTest:DeploymentItem:System.Windows.Interactivity.dll
Scenario: Testing Auth type as Anonymous and swaping it resets the test connection 
   Given I open New Sharepoint Source
   And "Save" is "Disabled"
   And I type Address as "http://rsaklfsvrdev" 
   And "Save" is "Disabled"
   And "Test Connection" is "Enabled"
   And I Select Authentication Type as "User"
   And I type Username as "test"
   And I type Password
   When Test Connecton is "Successful"
   And Validation message is Not thrown
   And "Save" is "Enabled"
   And I Select Authentication Type as "Windows"
   And Username field is "Collapsed"
   And Password field is "Collapsed"
   And "Save" is "Disabled"
   When Test Connecton is "Successful"
   And Validation message is Not thrown
   And "Save" is "Enabled"	 
   And I Select Authentication Type as "User"
   And Username field is "Visible"
   And Password field is "Visible"
   And "Save" is "Disabled" 

@SharepointSource
@MSTest:DeploymentItem:InfragisticsWPF4.Controls.Interactions.XamDialogWindow.v15.1.dll
@MSTest:DeploymentItem:Warewolf_Studio.exe
@MSTest:DeploymentItem:Newtonsoft.Json.dll
@MSTest:DeploymentItem:Microsoft.Practices.Prism.SharedInterfaces.dll
@MSTest:DeploymentItem:System.Windows.Interactivity.dll
Scenario: Editing saved Sharepoint Source 
   Given I open "Test" Sharepoint source
   Then "Test" tab is opened
   And title is "Test"
   And Address is "http://rsaklfsvrdev"
   And "Save" is "Disabled"
   And "Test Connection" is "Enabled"
   And Authentication Type is "Windows"
   And Username field is "Collapsed"
   And Password field is "Collapsed"
   And "Save" is "Disabled"
   When I type Address as "http://rsaklfsvrdevs"
   Then "Test *" tab is opened
   And "Save" is "Disabled"
   And "Test Connection" is "Enabled"
   And "Save" is "Disabled"
   When Test Connecton is "Successfull"
   Then "Save" is "Enabled" 
   When I save the source

@SharepointSource
@MSTest:DeploymentItem:InfragisticsWPF4.Controls.Interactions.XamDialogWindow.v15.1.dll
@MSTest:DeploymentItem:Warewolf_Studio.exe
@MSTest:DeploymentItem:Newtonsoft.Json.dll
@MSTest:DeploymentItem:Microsoft.Practices.Prism.SharedInterfaces.dll
@MSTest:DeploymentItem:System.Windows.Interactivity.dll
 Scenario: Editing saved Sharepoint Source auth type
   Given I open "Test" Sharepoint source
   Then "Test" tab is opened
   And Address is "http://rsaklfsvrdev"
   And "Save" is "Disabled"
   And "Test Connection" is "Enabled"
   And Authentication Type is "Windows"
   And Username field is "Collapsed"
   And Password field is "Collapsed"
   When I Select Authentication Type as "User"
   And Username field is "Visible"
   And Password field is "Visible"
   And Username field as "IntegrationTester"
   And Password field as "I73573r0"
   And "Save" is "Disabled"
   When Test Connecton is "Successfull"
   Then "Save" is "Enabled" 

@SharepointSource
@MSTest:DeploymentItem:InfragisticsWPF4.Controls.Interactions.XamDialogWindow.v15.1.dll
@MSTest:DeploymentItem:Warewolf_Studio.exe
@MSTest:DeploymentItem:Newtonsoft.Json.dll
@MSTest:DeploymentItem:Microsoft.Practices.Prism.SharedInterfaces.dll
@MSTest:DeploymentItem:System.Windows.Interactivity.dll
Scenario: Cancel Test
   Given I open New Sharepoint Source 
   Then "New SharePoint Service Source" tab is opened
   And title is "New SharePoint Service Source"
   And I type Address as "http://rsaklfsvrdev"
   When Test Connecton is "Long Running"
   And I Cancel the Test
   Then "Cancel Test" is "Disabled"
   And Validation message is thrown
   And Validation message is "Test Cancelled"