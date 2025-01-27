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
namespace Dev2.Activities.Specs.Composition
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class WorkflowResumeFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "WorkflowResume.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "WorkflowResume", "\tWhen a workflow execution fails\r\n\tI want to Resume", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "WorkflowResume")))
            {
                global::Dev2.Activities.Specs.Composition.WorkflowResumeFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Resuming a workflow that had failed to connect")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkflowResume")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ResumeWorkflowExecution")]
        public virtual void ResumingAWorkflowThatHadFailedToConnect()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Resuming a workflow that had failed to connect", new string[] {
                        "ResumeWorkflowExecution"});
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("I have a workflow \"WorkflowWithMysqlToolUsingContainer\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table589 = new TechTalk.SpecFlow.Table(new string[] {
                        "variable",
                        "value"});
            table589.AddRow(new string[] {
                        "[[number]]",
                        "1"});
#line 8
 testRunner.And("\"WorkflowWithMysqlToolUsingContainer\" contains an Assign \"AssignNumber\" as", ((string)(null)), table589, "And ");
#line 11
 testRunner.And("\"WorkflowWithMysqlToolUsingContainer\" contains a mysql database service \"ToolUsin" +
                    "gContainerAsTheSource\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table590 = new TechTalk.SpecFlow.Table(new string[] {
                        "variable",
                        "value"});
            table590.AddRow(new string[] {
                        "[[outnumber]]",
                        "=[[number]]+1"});
#line 12
 testRunner.And("\"WorkflowWithMysqlToolUsingContainer\" contains an Assign \"IncrementNumber\" as", ((string)(null)), table590, "And ");
#line 15
    testRunner.When("\"WorkflowWithMysqlToolUsingContainer\" is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
    testRunner.Then("the workflow execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 17
 testRunner.And("execution stopped on error and did not execute \"IncrementNumber\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And("the \"ToolUsingContainerAsTheSource\" in Workflow \"WorkflowWithMysqlToolUsingContai" +
                    "ner\" has an error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.When("I startup the mysql container", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
 testRunner.And("I select \"NewMySqlSource\" for \"ToolUsingContainerAsTheSource\" as Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.And("I select \"Pr_CitiesGetCountries\" Action for \"ToolUsingContainerAsTheSource\" tool", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.And("\"WorkflowWithMysqlToolUsingContainer\" is Saved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And("I resume workflow \"WorkflowWithMysqlToolUsingContainer\" at \"ToolUsingContainerAsT" +
                    "heSource\" tool", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.Then("Resume has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 25
 testRunner.And("Resume message is \"Execution Completed.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table591 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table591.AddRow(new string[] {
                        "1",
                        "[[outnumber]] = 2"});
#line 26
 testRunner.And("the \"IncrementNumber\" in Workflow \"WorkflowWithMysqlToolUsingContainer\" debug out" +
                    "puts as", ((string)(null)), table591, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Resuming a workflow Given No Name And Resume From SetTheOutputVariable tool")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkflowResume")]
        public virtual void ResumingAWorkflowGivenNoNameAndResumeFromSetTheOutputVariableTool()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Resuming a workflow Given No Name And Resume From SetTheOutputVariable tool", ((string[])(null)));
#line 31
this.ScenarioSetup(scenarioInfo);
#line 32
 testRunner.Given("I have a server at \"localhost\" with workflow \"Hello World\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 33
 testRunner.And("Workflow \"Hello World\" has \"Set the output variable (1)\" activity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.And("I resume workflow \"Hello World\" at \"Set the output variable (1)\" tool", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
 testRunner.Then("Resume has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 36
 testRunner.And("Resume message is \"Scalar value { Name } is NULL\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Resuming a workflow Given Resume From AssignValueToNameIfBlank Tool")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkflowResume")]
        public virtual void ResumingAWorkflowGivenResumeFromAssignValueToNameIfBlankTool()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Resuming a workflow Given Resume From AssignValueToNameIfBlank Tool", ((string[])(null)));
#line 39
this.ScenarioSetup(scenarioInfo);
#line 40
 testRunner.Given("I have a server at \"localhost\" with workflow \"Hello World\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 41
 testRunner.And("Workflow \"Hello World\" has \"Assign a value to Name if blank (1)\" activity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
 testRunner.And("I resume workflow \"Hello World\" at \"Assign a value to Name if blank (1)\" tool", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.Then("Resume has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 44
 testRunner.And("Resume message is \"Execution Completed.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Resuming Workflow From a specific Version")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkflowResume")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ResumeWorkflowExecution")]
        public virtual void ResumingWorkflowFromASpecificVersion()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Resuming Workflow From a specific Version", new string[] {
                        "ResumeWorkflowExecution"});
#line 47
this.ScenarioSetup(scenarioInfo);
#line 48
 testRunner.Given("I have a workflow \"ResumeWorkflowFromVersion\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table592 = new TechTalk.SpecFlow.Table(new string[] {
                        "variable",
                        "value"});
            table592.AddRow(new string[] {
                        "[[rec().a]]",
                        "New"});
            table592.AddRow(new string[] {
                        "[[rec().a]]",
                        "Test"});
#line 49
 testRunner.And("\"ResumeWorkflowFromVersion\" contains an Assign \"VarsAssign\" as", ((string)(null)), table592, "And ");
#line 53
 testRunner.When("workflow \"ResumeWorkflowFromVersion\" is saved \"1\" time", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 54
 testRunner.Then("workflow \"ResumeWorkflowFromVersion\" has \"0\" Versions in explorer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 55
 testRunner.When("\"WorkflowWithAssignAndCount\" is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 56
 testRunner.Then("the workflow execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table593 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table593.AddRow(new string[] {
                        "1",
                        "[[rec(1).a]] = New"});
            table593.AddRow(new string[] {
                        "2",
                        "[[rec(2).a]] = Test"});
#line 57
 testRunner.And("the \"VarsAssign\" in Workflow \"ResumeWorkflowFromVersion\" debug outputs as", ((string)(null)), table593, "And ");
#line hidden
            TechTalk.SpecFlow.Table table594 = new TechTalk.SpecFlow.Table(new string[] {
                        "variable",
                        "value"});
            table594.AddRow(new string[] {
                        "[[variable]]",
                        "NewlyAddedVariable"});
#line 61
 testRunner.Then("I update \"ResumeWorkflowFromVersion\" by adding \"AnotherVarsAssign\" as", ((string)(null)), table594, "Then ");
#line 64
 testRunner.When("workflow \"ResumeWorkflowFromVersion\" is saved \"1\" time", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table595 = new TechTalk.SpecFlow.Table(new string[] {
                        "variable",
                        "value"});
            table595.AddRow(new string[] {
                        "[[ThirdAssignVariable]]",
                        "ThirdAssignVariable"});
#line 65
 testRunner.Then("I update \"ResumeWorkflowFromVersion\" by adding \"ThirVarAssign\" as", ((string)(null)), table595, "Then ");
#line 68
 testRunner.When("workflow \"ResumeWorkflowFromVersion\" is saved \"1\" time", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 69
 testRunner.And("I reload Server resources", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
 testRunner.And("I resume the workflow \"ResumeWorkflowFromVersion\" at \"VarsAssign\" from version \"2" +
                    "\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
 testRunner.Then("the workflow execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table596 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table596.AddRow(new string[] {
                        "1",
                        "[[rec(1).a]] = New"});
            table596.AddRow(new string[] {
                        "2",
                        "[[rec(2).a]] = Test"});
#line 72
 testRunner.And("the \"VarsAssign\" in Workflow \"ResumeWorkflowFromVersion\" debug outputs as", ((string)(null)), table596, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
