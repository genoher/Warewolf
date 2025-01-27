﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.3.2.0
//      SpecFlow Generator Version:2.3.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Dev2.Activities.Specs.StudioTestFramework
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class StudioTestFrameworkAdvancedRecordsetFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "StudioTestFrameworkAdvancedRecordset.feature"
#line hidden
        
        public virtual Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
        {
            get
            {
                return this._testContext;
            }
            set
            {
                this._testContext = value;
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "StudioTestFrameworkAdvancedRecordset", "\tIn order to validate sql executing over a recordset\r\n\tAs a Warewolf developer\r\n\t" +
                    "I want to be what sql is supported", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "StudioTestFrameworkAdvancedRecordset")))
            {
                global::Dev2.Activities.Specs.StudioTestFramework.StudioTestFrameworkAdvancedRecordsetFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>(TestContext);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Test WF with Advanced Recordset Select All")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "StudioTestFrameworkAdvancedRecordset")]
        public virtual void TestWFWithAdvancedRecordsetSelectAll()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test WF with Advanced Recordset Select All", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("I have a workflow \"AdvancedRecsetTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table930 = new TechTalk.SpecFlow.Table(new string[] {
                        "variable",
                        "value"});
            table930.AddRow(new string[] {
                        "[[person(1).name]]",
                        "Bob"});
            table930.AddRow(new string[] {
                        "[[person(2).name]]",
                        "Alice"});
            table930.AddRow(new string[] {
                        "[[person(1).surname]]",
                        "Smith"});
            table930.AddRow(new string[] {
                        "[[person(2).surname]]",
                        "Jones"});
#line 8
 testRunner.And("\"AdvancedRecsetTestWF\" contains an Assign \"assignrecordset\" as", ((string)(null)), table930, "And ");
#line hidden
            TechTalk.SpecFlow.Table table931 = new TechTalk.SpecFlow.Table(new string[] {
                        "MappedTo",
                        "MappedFrom"});
            table931.AddRow(new string[] {
                        "name",
                        "[[TableCopy().name]]"});
            table931.AddRow(new string[] {
                        "surname",
                        "[[TableCopy().surname]]"});
#line 14
 testRunner.And("\"AdvancedRecsetTestWF\" contains Advanced Recordset \"selectall\" with Query \"Select" +
                    " * from person\"", ((string)(null)), table931, "And ");
#line 18
 testRunner.And("I save workflow \"AdvancedRecsetTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.Then("the test builder is open with \"AdvancedRecsetTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 20
 testRunner.And("I click New Test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.And("a new test is added", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
    testRunner.And("test name starts with \"Test 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table932 = new TechTalk.SpecFlow.Table(new string[] {
                        "Variable Name",
                        "Condition",
                        "Value"});
            table932.AddRow(new string[] {
                        "[[person(1).name]]",
                        "=",
                        "Bob"});
            table932.AddRow(new string[] {
                        "[[person(2).name]]",
                        "=",
                        "Alice"});
            table932.AddRow(new string[] {
                        "[[person(1).surname]]",
                        "=",
                        "Smith"});
            table932.AddRow(new string[] {
                        "[[person(2).surname]]",
                        "=",
                        "Jones"});
#line 23
 testRunner.And("I Add \"assignrecordset\" as TestStep with", ((string)(null)), table932, "And ");
#line hidden
            TechTalk.SpecFlow.Table table933 = new TechTalk.SpecFlow.Table(new string[] {
                        "Variable Name",
                        "Condition",
                        "Value"});
            table933.AddRow(new string[] {
                        "[[TableCopy(2).name]]",
                        "=",
                        "Alice"});
            table933.AddRow(new string[] {
                        "[[TableCopy(2).surname]]",
                        "=",
                        "Jones"});
#line 29
 testRunner.And("I Add \"selectall\" as TestStep with", ((string)(null)), table933, "And ");
#line 33
 testRunner.When("I save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
 testRunner.And("I run the test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
 testRunner.Then("test result is Passed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 36
 testRunner.When("I delete \"Test 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
 testRunner.Then("The \"DeleteConfirmation\" popup is shown I click Ok", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 38
 testRunner.Then("workflow \"AdvancedRecsetTestWF\" is deleted as cleanup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Test WF with Advanced Recordset Select Names")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "StudioTestFrameworkAdvancedRecordset")]
        public virtual void TestWFWithAdvancedRecordsetSelectNames()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test WF with Advanced Recordset Select Names", ((string[])(null)));
#line 41
this.ScenarioSetup(scenarioInfo);
#line 42
 testRunner.Given("I have a workflow \"AdvancedRecsetTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table934 = new TechTalk.SpecFlow.Table(new string[] {
                        "variable",
                        "value"});
            table934.AddRow(new string[] {
                        "[[person(1).name]]",
                        "Bob"});
            table934.AddRow(new string[] {
                        "[[person(2).name]]",
                        "Alice"});
            table934.AddRow(new string[] {
                        "[[person(1).surname]]",
                        "Smith"});
            table934.AddRow(new string[] {
                        "[[person(2).surname]]",
                        "Jones"});
#line 43
 testRunner.And("\"AdvancedRecsetTestWF\" contains an Assign \"assignrecordset\" as", ((string)(null)), table934, "And ");
#line hidden
            TechTalk.SpecFlow.Table table935 = new TechTalk.SpecFlow.Table(new string[] {
                        "MappedTo",
                        "MappedFrom"});
            table935.AddRow(new string[] {
                        "name",
                        "[[TableCopy().name]]"});
            table935.AddRow(new string[] {
                        "surname",
                        "[[TableCopy().surname]]"});
#line 49
 testRunner.And("\"AdvancedRecsetTestWF\" contains Advanced Recordset \"selectall\" with Query \"Select" +
                    " name from person\"", ((string)(null)), table935, "And ");
#line 53
 testRunner.And("I save workflow \"AdvancedRecsetTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.Then("the test builder is open with \"AdvancedRecsetTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 55
 testRunner.And("I click New Test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.And("a new test is added", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
    testRunner.And("test name starts with \"Test 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table936 = new TechTalk.SpecFlow.Table(new string[] {
                        "Variable Name",
                        "Condition",
                        "Value"});
            table936.AddRow(new string[] {
                        "[[person(1).name]]",
                        "=",
                        "Bob"});
            table936.AddRow(new string[] {
                        "[[person(2).name]]",
                        "=",
                        "Alice"});
            table936.AddRow(new string[] {
                        "[[person(1).surname]]",
                        "=",
                        "Smith"});
            table936.AddRow(new string[] {
                        "[[person(2).surname]]",
                        "=",
                        "Jones"});
#line 58
 testRunner.And("I Add \"assignrecordset\" as TestStep with", ((string)(null)), table936, "And ");
#line hidden
            TechTalk.SpecFlow.Table table937 = new TechTalk.SpecFlow.Table(new string[] {
                        "Variable Name",
                        "Condition",
                        "Value"});
            table937.AddRow(new string[] {
                        "[[TableCopy(2).name]]",
                        "=",
                        "Alice"});
#line 64
 testRunner.And("I Add \"selectall\" as TestStep with", ((string)(null)), table937, "And ");
#line 67
 testRunner.When("I save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 68
 testRunner.And("I run the test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
 testRunner.Then("test result is Passed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 70
 testRunner.When("I delete \"Test 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 71
 testRunner.Then("The \"DeleteConfirmation\" popup is shown I click Ok", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 72
 testRunner.Then("workflow \"AdvancedRecsetTestWF\" is deleted as cleanup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
