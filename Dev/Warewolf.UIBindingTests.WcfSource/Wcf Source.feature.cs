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
namespace Warewolf.UIBindingTests.WcfSource
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class WcfSourceFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Wcf Source.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Wcf Source", "\tIn order to share settings\r\n\tI want to save my Wcf source Settings\r\n\tSo that I c" +
                    "an reuse them", ProgrammingLanguage.CSharp, new string[] {
                        "WcfSource"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Wcf Source")))
            {
                global::Warewolf.UIBindingTests.WcfSource.WcfSourceFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create New Wcf source")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Wcf Source")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("WcfSource")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("WcfSource")]
        public virtual void CreateNewWcfSource()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create New Wcf source", new string[] {
                        "WcfSource",
                        "MSTest:DeploymentItem:InfragisticsWPF4.Controls.Interactions.XamDialogWindow.v15." +
                            "1.dll",
                        "MSTest:DeploymentItem:Warewolf_Studio.exe",
                        "MSTest:DeploymentItem:Newtonsoft.Json.dll",
                        "MSTest:DeploymentItem:Microsoft.Practices.Prism.SharedInterfaces.dll",
                        "MSTest:DeploymentItem:System.Windows.Interactivity.dll"});
#line 13
this.ScenarioSetup(scenarioInfo);
#line 14
 testRunner.Given("I open New Wcf Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
 testRunner.Then("\"New WCF Service Source\" tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 16
 testRunner.And("the title is \"New WCF Service Source\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And("\"WCF Endpoint Url\" input is \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And("\"Test Connection\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Fail Send Shows correct error message")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Wcf Source")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("WcfSource")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("WcfSource")]
        public virtual void FailSendShowsCorrectErrorMessage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Fail Send Shows correct error message", new string[] {
                        "WcfSource",
                        "MSTest:DeploymentItem:InfragisticsWPF4.Controls.Interactions.XamDialogWindow.v15." +
                            "1.dll",
                        "MSTest:DeploymentItem:Warewolf_Studio.exe",
                        "MSTest:DeploymentItem:Newtonsoft.Json.dll",
                        "MSTest:DeploymentItem:Microsoft.Practices.Prism.SharedInterfaces.dll",
                        "MSTest:DeploymentItem:System.Windows.Interactivity.dll"});
#line 27
this.ScenarioSetup(scenarioInfo);
#line 28
 testRunner.Given("I open New Wcf Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 29
 testRunner.Then("\"New WCF Service Source\" tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 30
 testRunner.And("I type WCF Endpoint Url as \"test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.And("Send is \"Unsuccessful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.Then("Send is \"Invalid URI: The format of the URI could not be determined.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 35
 testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
