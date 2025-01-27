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
    public partial class StudioTestFrameworkkWithDropboxToolsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "StudioTestFrameworkWithDropboxTools.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "StudioTestFrameworkkWithDropboxTools", "\tIn order to test workflows that contain dropbox tools in warewolf \r\n\tAs a user\r\n" +
                    "\tI want to create, edit, delete and update tests in a test window", ProgrammingLanguage.CSharp, new string[] {
                        "StudioTestFrameworkWithDropboxTools"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "StudioTestFrameworkkWithDropboxTools")))
            {
                global::Dev2.Activities.Specs.StudioTestFramework.StudioTestFrameworkkWithDropboxToolsFeature.FeatureSetup(null);
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
        
        public virtual void FeatureBackground()
        {
#line 8
#line 9
  testRunner.Given("test folder is cleaned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1101 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input Var Name"});
            table1101.AddRow(new string[] {
                        "[[a]]"});
#line 10
  testRunner.And("I have \"Workflow 1\" with inputs as", ((string)(null)), table1101, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1102 = new TechTalk.SpecFlow.Table(new string[] {
                        "Ouput Var Name"});
            table1102.AddRow(new string[] {
                        "[[outputValue]]"});
#line 13
  testRunner.And("\"Workflow 1\" has outputs as", ((string)(null)), table1102, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1103 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input Var Name"});
            table1103.AddRow(new string[] {
                        "[[rec().a]]"});
            table1103.AddRow(new string[] {
                        "[[rec().b]]"});
#line 16
  testRunner.Given("I have \"Workflow 2\" with inputs as", ((string)(null)), table1103, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1104 = new TechTalk.SpecFlow.Table(new string[] {
                        "Ouput Var Name"});
            table1104.AddRow(new string[] {
                        "[[returnVal]]"});
#line 20
  testRunner.And("\"Workflow 2\" has outputs as", ((string)(null)), table1104, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1105 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input Var Name"});
            table1105.AddRow(new string[] {
                        "[[A]]"});
            table1105.AddRow(new string[] {
                        "[[B]]"});
            table1105.AddRow(new string[] {
                        "[[C]]"});
#line 23
  testRunner.Given("I have \"Workflow 3\" with inputs as", ((string)(null)), table1105, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1106 = new TechTalk.SpecFlow.Table(new string[] {
                        "Ouput Var Name"});
            table1106.AddRow(new string[] {
                        "[[message]]"});
#line 28
  testRunner.And("\"Workflow 3\" has outputs as", ((string)(null)), table1106, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1107 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input Var Name"});
            table1107.AddRow(new string[] {
                        "[[input]]"});
#line 31
  testRunner.Given("I have \"WorkflowWithTests\" with inputs as", ((string)(null)), table1107, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1108 = new TechTalk.SpecFlow.Table(new string[] {
                        "Ouput Var Name"});
            table1108.AddRow(new string[] {
                        "[[outputValue]]"});
#line 34
  testRunner.And("\"WorkflowWithTests\" has outputs as", ((string)(null)), table1108, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1109 = new TechTalk.SpecFlow.Table(new string[] {
                        "TestName",
                        "AuthenticationType",
                        "Error",
                        "TestFailing",
                        "TestPending",
                        "TestInvalid",
                        "TestPassed"});
            table1109.AddRow(new string[] {
                        "Test1",
                        "Windows",
                        "false",
                        "false",
                        "false",
                        "false",
                        "true"});
            table1109.AddRow(new string[] {
                        "Test2",
                        "Windows",
                        "false",
                        "true",
                        "false",
                        "false",
                        "false"});
            table1109.AddRow(new string[] {
                        "Test3",
                        "Windows",
                        "false",
                        "false",
                        "false",
                        "true",
                        "false"});
            table1109.AddRow(new string[] {
                        "Test4",
                        "Windows",
                        "false",
                        "false",
                        "true",
                        "false",
                        "false"});
#line 37
  testRunner.And("\"WorkflowWithTests\" Tests as", ((string)(null)), table1109, "And ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Test Wf With Dropbox Upload Tool")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "StudioTestFrameworkkWithDropboxTools")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("StudioTestFrameworkWithDropboxTools")]
        public virtual void TestWfWithDropboxUploadTool()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test Wf With Dropbox Upload Tool", ((string[])(null)));
#line 45
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 46
 testRunner.Given("I have a workflow \"TestWFWithDropBoxUpload\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1110 = new TechTalk.SpecFlow.Table(new string[] {
                        "Local File",
                        "OverwriteOrAdd",
                        "DropboxFile",
                        "Result"});
            table1110.AddRow(new string[] {
                        "C:\\Home.Delete",
                        "Overwrite",
                        "source.xml",
                        "[[res]]"});
#line 47
 testRunner.And("\"TestWFWithDropBoxUpload\" contains a DropboxUpload \"UploadTool\" Setup as", ((string)(null)), table1110, "And ");
#line 50
 testRunner.And("I save workflow \"TestWFWithDropBoxUpload\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.Then("the test builder is open with \"TestWFWithDropBoxUpload\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 52
 testRunner.And("I click New Test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.And("I Add \"UploadTool\" as TestStep", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.When("I save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
 testRunner.And("I run the test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.Then("test result is Passed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 57
 testRunner.When("I delete \"Test 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Test Wf With Dropbox Delete Tool")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "StudioTestFrameworkkWithDropboxTools")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("StudioTestFrameworkWithDropboxTools")]
        public virtual void TestWfWithDropboxDeleteTool()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test Wf With Dropbox Delete Tool", ((string[])(null)));
#line 59
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 60
 testRunner.Given("I have a workflow \"TestWFWithDropBoxDelete\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1111 = new TechTalk.SpecFlow.Table(new string[] {
                        "Local File",
                        "OverwriteOrAdd",
                        "DropboxFile",
                        "Result"});
            table1111.AddRow(new string[] {
                        "C:\\Home.Delete",
                        "Overwrite",
                        "ToDelete.xml",
                        "[[res]]"});
#line 61
 testRunner.And("\"TestWFWithDropBoxDelete\" contains a DropboxUpload \"UploadTool\" Setup as", ((string)(null)), table1111, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1112 = new TechTalk.SpecFlow.Table(new string[] {
                        "DropboxFile",
                        "Result"});
            table1112.AddRow(new string[] {
                        "ToDelete.xml",
                        "[[res]]"});
#line 64
 testRunner.And("\"TestWFWithDropBoxDelete\" contains a DropboxDelete \"DeleteTool\" Setup as", ((string)(null)), table1112, "And ");
#line 67
 testRunner.And("I save workflow \"TestWFWithDropBoxDelete\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
 testRunner.Then("the test builder is open with \"TestWFWithDropBoxDelete\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 69
 testRunner.And("I click New Test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
 testRunner.And("I Add \"UploadTool\" as TestStep", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
 testRunner.And("I Add \"DeleteTool\" as TestStep", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
 testRunner.When("I save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 73
 testRunner.And("I run the test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
 testRunner.Then("test result is Passed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 75
 testRunner.When("I delete \"Test 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Test Wf With Dropbox Download Tool")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "StudioTestFrameworkkWithDropboxTools")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("StudioTestFrameworkWithDropboxTools")]
        public virtual void TestWfWithDropboxDownloadTool()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test Wf With Dropbox Download Tool", ((string[])(null)));
#line 77
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 78
 testRunner.Given("I have a workflow \"TestWFWithDropBoxDowload\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1113 = new TechTalk.SpecFlow.Table(new string[] {
                        "Local File",
                        "OverwriteOrAdd",
                        "DropboxFile",
                        "Result"});
            table1113.AddRow(new string[] {
                        "C:\\Home.Delete",
                        "Overwrite",
                        "Download.xml",
                        "[[res]]"});
#line 79
 testRunner.And("\"TestWFWithDropBoxDowload\" contains a DropboxUpload \"UploadTool\" Setup as", ((string)(null)), table1113, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1114 = new TechTalk.SpecFlow.Table(new string[] {
                        "Local File",
                        "OverwriteOrAdd",
                        "DropboxFile",
                        "Result"});
            table1114.AddRow(new string[] {
                        "C:\\Home.Delete",
                        "Overwrite",
                        "Download.xml",
                        "[[res]]"});
#line 82
 testRunner.And("\"TestWFWithDropBoxDowload\" contains a DropboxDownLoad \"DownloadTool\" Setup as", ((string)(null)), table1114, "And ");
#line 85
 testRunner.And("I save workflow \"TestWFWithDropBoxDowload\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
 testRunner.Then("the test builder is open with \"TestWFWithDropBoxDowload\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 87
 testRunner.And("I click New Test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 88
 testRunner.And("I Add \"UploadTool\" as TestStep", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
 testRunner.And("I Add \"DownloadTool\" as TestStep", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
 testRunner.When("I save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 91
 testRunner.And("I run the test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
 testRunner.Then("test result is Passed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 93
 testRunner.When("I delete \"Test 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Test Wf With Dropbox List Tool")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "StudioTestFrameworkkWithDropboxTools")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("StudioTestFrameworkWithDropboxTools")]
        public virtual void TestWfWithDropboxListTool()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test Wf With Dropbox List Tool", ((string[])(null)));
#line 95
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 96
 testRunner.Given("I have a workflow \"TestWFWithDropBoxList\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1115 = new TechTalk.SpecFlow.Table(new string[] {
                        "Local File",
                        "OverwriteOrAdd",
                        "DropboxFile",
                        "Result"});
            table1115.AddRow(new string[] {
                        "C:\\Home.Delete",
                        "Overwrite",
                        "Home/Download.xml",
                        "[[res]]"});
#line 97
 testRunner.And("\"TestWFWithDropBoxList\" contains a DropboxUpload \"UploadTool\" Setup as", ((string)(null)), table1115, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1116 = new TechTalk.SpecFlow.Table(new string[] {
                        "Read",
                        "LoadSubFolders",
                        "DropboxFile",
                        "Result"});
            table1116.AddRow(new string[] {
                        "Files",
                        "true",
                        "Home",
                        "[[res().Files]]"});
#line 100
 testRunner.And("\"TestWFWithDropBoxList\" contains a DropboxList \"ListTool\" Setup as", ((string)(null)), table1116, "And ");
#line 103
 testRunner.And("I save workflow \"TestWFWithDropBoxList\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 104
 testRunner.Then("the test builder is open with \"TestWFWithDropBoxList\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 105
 testRunner.And("I click New Test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 106
 testRunner.And("I Add \"UploadTool\" as TestStep", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 107
 testRunner.And("I Add \"ListTool\" as TestStep", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 108
 testRunner.When("I save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 109
 testRunner.And("I run the test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 110
 testRunner.Then("test result is Passed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 111
 testRunner.When("I delete \"Test 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Test Workflow which contains COM DLL")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "StudioTestFrameworkkWithDropboxTools")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("StudioTestFrameworkWithDropboxTools")]
        public virtual void TestWorkflowWhichContainsCOMDLL()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test Workflow which contains COM DLL", ((string[])(null)));
#line 113
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 114
  testRunner.Given("I have a workflow \"TestWFCOMDLL\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1117 = new TechTalk.SpecFlow.Table(new string[] {
                        "Source",
                        "Namespace",
                        "Action"});
            table1117.AddRow(new string[] {
                        "RandomSource",
                        "System.Random",
                        "Next"});
#line 115
  testRunner.And("\"TestWFCOMDLL\" contains an COM DLL \"COMService\" as", ((string)(null)), table1117, "And ");
#line 118
    testRunner.And("I save workflow \"TestWFCOMDLL\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 119
   testRunner.Then("the test builder is open with \"TestWFCOMDLL\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 120
   testRunner.And("I click New Test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 121
   testRunner.And("I Add \"COMService\" as TestStep", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1118 = new TechTalk.SpecFlow.Table(new string[] {
                        "Variable Name",
                        "Condition",
                        "Value"});
            table1118.AddRow(new string[] {
                        "[[PrimitiveReturnValue]]",
                        "Not Date",
                        ""});
#line 122
   testRunner.And("I add StepOutputs as", ((string)(null)), table1118, "And ");
#line 125
   testRunner.When("I save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 126
   testRunner.And("I run the test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 127
   testRunner.Then("test result is Passed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 128
   testRunner.When("I delete \"Test 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
