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
namespace Warewolf.Tools.Specs.Toolbox.Recordset.LengthNullHandler
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class LengthFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Length.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Length", "\tIn order to get the length of a records\r\n\tAs a Warewolf user\r\n\tI want a tool tha" +
                    "t takes a record set gives me its length", ProgrammingLanguage.CSharp, new string[] {
                        "Recordset"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Length")))
            {
                global::Warewolf.Tools.Specs.Toolbox.Recordset.LengthNullHandler.LengthFeature.FeatureSetup(null);
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
#line 7
#line 8
 testRunner.Given("this feature", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.Then("activity is DsfCountRecordsetNullHandlerActivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Length of a recordset with 3 rows")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        public virtual void LengthOfARecordsetWith3Rows()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Length of a recordset with 3 rows", ((string[])(null)));
#line 11
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table2153 = new TechTalk.SpecFlow.Table(new string[] {
                        "[[rs]]",
                        ""});
            table2153.AddRow(new string[] {
                        "rs(1).row",
                        "1"});
            table2153.AddRow(new string[] {
                        "rs(3).row",
                        "2"});
            table2153.AddRow(new string[] {
                        "rs(5).row",
                        "3"});
#line 12
 testRunner.Given("I get the length from a recordset that looks like with this shape", ((string)(null)), table2153, "Given ");
#line 17
 testRunner.And("get length on record \"[[rs()]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.When("the length tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
 testRunner.Then("the length result should be 5", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 20
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2154 = new TechTalk.SpecFlow.Table(new string[] {
                        "Recordset"});
            table2154.AddRow(new string[] {
                        "[[rs(1).row]] = 1"});
            table2154.AddRow(new string[] {
                        "[[rs(3).row]] = 2"});
            table2154.AddRow(new string[] {
                        "[[rs(5).row]] = 3"});
#line 21
 testRunner.And("the debug inputs as", ((string)(null)), table2154, "And ");
#line hidden
            TechTalk.SpecFlow.Table table2155 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table2155.AddRow(new string[] {
                        "[[result]] = 5"});
#line 26
 testRunner.And("the debug output as", ((string)(null)), table2155, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Length of a recordset with 8 rows")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        public virtual void LengthOfARecordsetWith8Rows()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Length of a recordset with 8 rows", ((string[])(null)));
#line 30
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table2156 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        ""});
            table2156.AddRow(new string[] {
                        "rs(1).row",
                        "1"});
            table2156.AddRow(new string[] {
                        "rs(2).row",
                        "2"});
            table2156.AddRow(new string[] {
                        "rs(3).row",
                        "3"});
            table2156.AddRow(new string[] {
                        "rs(4).row",
                        "4"});
            table2156.AddRow(new string[] {
                        "rs(5).row",
                        "5"});
            table2156.AddRow(new string[] {
                        "rs(6).row",
                        "6"});
            table2156.AddRow(new string[] {
                        "rs(7).row",
                        "7"});
            table2156.AddRow(new string[] {
                        "rs(8).row",
                        "8"});
#line 31
 testRunner.Given("I get the length from a recordset that looks like with this shape", ((string)(null)), table2156, "Given ");
#line 41
 testRunner.And("get length on record \"[[rs()]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
 testRunner.When("the length tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 43
 testRunner.Then("the length result should be 8", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 44
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2157 = new TechTalk.SpecFlow.Table(new string[] {
                        "Recordset"});
            table2157.AddRow(new string[] {
                        "[[rs(1).row]] =  1"});
            table2157.AddRow(new string[] {
                        "[[rs(2).row]] =  2"});
            table2157.AddRow(new string[] {
                        "[[rs(3).row]] =  3"});
            table2157.AddRow(new string[] {
                        "[[rs(4).row]] =  4"});
            table2157.AddRow(new string[] {
                        "[[rs(5).row]] =  5"});
            table2157.AddRow(new string[] {
                        "[[rs(6).row]] =  6"});
            table2157.AddRow(new string[] {
                        "[[rs(7).row]] =  7"});
            table2157.AddRow(new string[] {
                        "[[rs(8).row]] =  8"});
#line 45
 testRunner.And("the debug inputs as", ((string)(null)), table2157, "And ");
#line hidden
            TechTalk.SpecFlow.Table table2158 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table2158.AddRow(new string[] {
                        "[[result]] = 8"});
#line 55
 testRunner.And("the debug output as", ((string)(null)), table2158, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Recordset length for coloumn")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        public virtual void RecordsetLengthForColoumn()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Recordset length for coloumn", ((string[])(null)));
#line 59
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table2159 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        ""});
            table2159.AddRow(new string[] {
                        "rs(1).row",
                        "1"});
            table2159.AddRow(new string[] {
                        "rs(2).row",
                        "2"});
            table2159.AddRow(new string[] {
                        "rs(3).row",
                        "3"});
            table2159.AddRow(new string[] {
                        "rs(4).row",
                        "4"});
            table2159.AddRow(new string[] {
                        "rs(5).row",
                        "5"});
            table2159.AddRow(new string[] {
                        "rs(6).row",
                        "6"});
            table2159.AddRow(new string[] {
                        "rs(7).row",
                        "7"});
            table2159.AddRow(new string[] {
                        "rs(8).row",
                        "8"});
#line 60
 testRunner.Given("I get the length from a recordset that looks like with this shape", ((string)(null)), table2159, "Given ");
#line 70
 testRunner.And("get length on record \"[[rs().row]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
 testRunner.When("the length tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 72
 testRunner.Then("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2160 = new TechTalk.SpecFlow.Table(new string[] {
                        "Recordset"});
#line 73
 testRunner.And("the debug inputs as", ((string)(null)), table2160, "And ");
#line hidden
            TechTalk.SpecFlow.Table table2161 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
#line 75
 testRunner.And("the debug output as", ((string)(null)), table2161, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Recordset length for coloumns invalid")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        public virtual void RecordsetLengthForColoumnsInvalid()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Recordset length for coloumns invalid", ((string[])(null)));
#line 78
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table2162 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        ""});
            table2162.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table2162.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table2162.AddRow(new string[] {
                        "rs().row",
                        "3"});
            table2162.AddRow(new string[] {
                        "rs().row",
                        "4"});
            table2162.AddRow(new string[] {
                        "rs().row2",
                        "5"});
            table2162.AddRow(new string[] {
                        "rs().row2",
                        "6"});
            table2162.AddRow(new string[] {
                        "rs().row2",
                        "7"});
#line 79
 testRunner.Given("I get the length from a recordset that looks like with this shape", ((string)(null)), table2162, "Given ");
#line 88
 testRunner.And("get length on record \"[[rs().row]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
 testRunner.When("the length tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 90
 testRunner.Then("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2163 = new TechTalk.SpecFlow.Table(new string[] {
                        "Recordset"});
#line 91
 testRunner.And("the debug inputs as", ((string)(null)), table2163, "And ");
#line hidden
            TechTalk.SpecFlow.Table table2164 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
#line 93
 testRunner.And("the debug output as", ((string)(null)), table2164, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Recordset length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        public virtual void RecordsetLength()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Recordset length", ((string[])(null)));
#line 96
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table2165 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        ""});
            table2165.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table2165.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table2165.AddRow(new string[] {
                        "rs().row",
                        "3"});
            table2165.AddRow(new string[] {
                        "rs().row",
                        "4"});
            table2165.AddRow(new string[] {
                        "rs().row2",
                        "5"});
            table2165.AddRow(new string[] {
                        "rs().row2",
                        "6"});
            table2165.AddRow(new string[] {
                        "rs().row2",
                        "7"});
#line 97
 testRunner.Given("I get the length from a recordset that looks like with this shape", ((string)(null)), table2165, "Given ");
#line 106
 testRunner.And("get length on record \"[[rs()]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 107
 testRunner.When("the length tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 108
 testRunner.Then("the length result should be 6", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 109
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2166 = new TechTalk.SpecFlow.Table(new string[] {
                        "Recordset"});
            table2166.AddRow(new string[] {
                        "[[rs(1).row]] =  1"});
            table2166.AddRow(new string[] {
                        "[[rs(2).row]] =  2"});
            table2166.AddRow(new string[] {
                        "[[rs(3).row]] =  3"});
            table2166.AddRow(new string[] {
                        "[[rs(4).row]] =  4"});
            table2166.AddRow(new string[] {
                        "[[rs(4).row2]] =  5"});
            table2166.AddRow(new string[] {
                        "[[rs(5).row2]] =  6"});
            table2166.AddRow(new string[] {
                        "[[rs(6).row2]] =  7"});
#line 110
 testRunner.And("the debug inputs as", ((string)(null)), table2166, "And ");
#line hidden
            TechTalk.SpecFlow.Table table2167 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table2167.AddRow(new string[] {
                        "[[result]] = 6"});
#line 119
 testRunner.And("the debug output as", ((string)(null)), table2167, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Recordset length for invalid recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        public virtual void RecordsetLengthForInvalidRecordset()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Recordset length for invalid recordset", ((string[])(null)));
#line 123
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table2168 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        ""});
            table2168.AddRow(new string[] {
                        "rs(1).row",
                        "1"});
            table2168.AddRow(new string[] {
                        "rs(2).row",
                        "2"});
            table2168.AddRow(new string[] {
                        "rs(3).row",
                        "3"});
            table2168.AddRow(new string[] {
                        "rs(4).row",
                        "4"});
            table2168.AddRow(new string[] {
                        "rs(5).row",
                        "5"});
            table2168.AddRow(new string[] {
                        "rs(6).row",
                        "6"});
            table2168.AddRow(new string[] {
                        "rs(7).row",
                        "7"});
            table2168.AddRow(new string[] {
                        "rs(8).row",
                        "8"});
#line 124
 testRunner.Given("I get the length from a recordset that looks like with this shape", ((string)(null)), table2168, "Given ");
#line 134
 testRunner.And("get length on record \"[[rs().&^]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 135
 testRunner.When("the length tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 136
 testRunner.Then("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2169 = new TechTalk.SpecFlow.Table(new string[] {
                        "Recordset"});
#line 137
 testRunner.And("the debug inputs as", ((string)(null)), table2169, "And ");
#line hidden
            TechTalk.SpecFlow.Table table2170 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
#line 139
 testRunner.And("the debug output as", ((string)(null)), table2170, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        public virtual void EnsureRecordsetLengthInputsWorkAsExpected(string variable, string val, string error, string message, string result, string value, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Ensure Recordset length inputs work as expected", exampleTags);
#line 142
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table2171 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        ""});
            table2171.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table2171.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table2171.AddRow(new string[] {
                        "rs().row",
                        "3"});
            table2171.AddRow(new string[] {
                        "rs().row",
                        "4"});
            table2171.AddRow(new string[] {
                        "rs().row2",
                        "5"});
            table2171.AddRow(new string[] {
                        "rs().row2",
                        "6"});
            table2171.AddRow(new string[] {
                        "rs().row2",
                        "7"});
#line 143
 testRunner.Given("I get the length from a recordset that looks like with this shape", ((string)(null)), table2171, "Given ");
#line 152
 testRunner.And(string.Format("get length on record \"{0}\"", variable), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 153
 testRunner.When("the length tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 154
 testRunner.Then(string.Format("the execution has \"{0}\" error", error), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Ensure Recordset length inputs work as expected: [[a]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "[[a]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:variable", "[[a]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:val", "The")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Error", "AN")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:message", "Scalar not allowed")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:result", "[[b]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:value", "[[b]] = failure")]
        public virtual void EnsureRecordsetLengthInputsWorkAsExpected_A()
        {
#line 142
this.EnsureRecordsetLengthInputsWorkAsExpected("[[a]]", "The", "AN", "Scalar not allowed", "[[b]]", "[[b]] = failure", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Ensure Recordset length inputs work as expected: \"\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "\"\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:variable", "\"\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:val", "\"\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Error", "AN")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:message", "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:result", "[[rec(1).a]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:value", "0")]
        public virtual void EnsureRecordsetLengthInputsWorkAsExpected_()
        {
#line 142
this.EnsureRecordsetLengthInputsWorkAsExpected("\"\"", "\"\"", "AN", "", "[[rec(1).a]]", "0", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Ensure Recordset length inputs work as expected: dfsd")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "dfsd")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:variable", "dfsd")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:val", "dfsd")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Error", "AN")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:message", "Invalid characters have been entered as Recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:result", "[[rec(*).a]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:value", "Failure")]
        public virtual void EnsureRecordsetLengthInputsWorkAsExpected_Dfsd()
        {
#line 142
this.EnsureRecordsetLengthInputsWorkAsExpected("dfsd", "dfsd", "AN", "Invalid characters have been entered as Recordset", "[[rec(*).a]]", "Failure", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Ensure Recordset length inputs work as expected: 12")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "12")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:variable", "12")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:val", "12")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Error", "AN")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:message", "Invalid characters have been entered as Recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:result", "[[rec([[int]]).a]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:value", "Failure")]
        public virtual void EnsureRecordsetLengthInputsWorkAsExpected_12()
        {
#line 142
this.EnsureRecordsetLengthInputsWorkAsExpected("12", "12", "AN", "Invalid characters have been entered as Recordset", "[[rec([[int]]).a]]", "Failure", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Ensure Recordset length inputs work as expected: [[rec(1)]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "[[rec(1)]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:variable", "[[rec(1)]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:val", "\"\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Error", "AN")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:message", "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:result", "[[rs().a]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:value", "[[rs(1).a]] = 3")]
        public virtual void EnsureRecordsetLengthInputsWorkAsExpected_Rec1()
        {
#line 142
this.EnsureRecordsetLengthInputsWorkAsExpected("[[rec(1)]]", "\"\"", "AN", "", "[[rs().a]]", "[[rs(1).a]] = 3", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Ensure Recordset length inputs work as expected: [[rec(*)]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "[[rec(*)]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:variable", "[[rec(*)]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:val", "\"\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Error", "AN")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:message", "Blank result variable")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:result", "\"\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:value", "\"\"")]
        public virtual void EnsureRecordsetLengthInputsWorkAsExpected_Rec()
        {
#line 142
this.EnsureRecordsetLengthInputsWorkAsExpected("[[rec(*)]]", "\"\"", "AN", "Blank result variable", "\"\"", "\"\"", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Ensure Recordset length inputs work as expected: [[rec([[int]])]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "[[rec([[int]])]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:variable", "[[rec([[int]])]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:val", "\"\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Error", "AN")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:message", "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:result", "[[sdasd]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:value", "3")]
        public virtual void EnsureRecordsetLengthInputsWorkAsExpected_RecInt()
        {
#line 142
this.EnsureRecordsetLengthInputsWorkAsExpected("[[rec([[int]])]]", "\"\"", "AN", "", "[[sdasd]]", "3", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Ensure Recordset length inputs work as expected: [[c]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "[[c]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:variable", "[[c]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:val", "\"\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Error", "AN")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:message", "Scalar not allowed")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:result", "[[d]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:value", "Failure")]
        public virtual void EnsureRecordsetLengthInputsWorkAsExpected_C()
        {
#line 142
this.EnsureRecordsetLengthInputsWorkAsExpected("[[c]]", "\"\"", "AN", "Scalar not allowed", "[[d]]", "Failure", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Length of an null recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        public virtual void LengthOfAnNullRecordset()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Length of an null recordset", ((string[])(null)));
#line 166
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table2172 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        ""});
            table2172.AddRow(new string[] {
                        "[[rs().row]]",
                        "NULL"});
#line 167
 testRunner.Given("I get the length from a recordset that looks like with this shape", ((string)(null)), table2172, "Given ");
#line 170
 testRunner.And("get length on record \"[[rs()]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 171
 testRunner.When("the length tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 172
 testRunner.Then("the length result should be 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 173
 testRunner.And("the execution has \"No\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Length Of An Unassigned Recordset With Null Check Not Selected")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        public virtual void LengthOfAnUnassignedRecordsetWithNullCheckNotSelected()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Length Of An Unassigned Recordset With Null Check Not Selected", ((string[])(null)));
#line 175
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 176
 testRunner.Given("get length on record \"[[rs()]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 177
 testRunner.And("Length Treat Null as Empty Recordset is not selected", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 178
 testRunner.When("the length tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 179
 testRunner.Then("the execution has \"An\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Length Of An Unassigned Recordset With Null Check Selected")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Length")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Recordset")]
        public virtual void LengthOfAnUnassignedRecordsetWithNullCheckSelected()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Length Of An Unassigned Recordset With Null Check Selected", ((string[])(null)));
#line 181
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 182
 testRunner.Given("get length on record \"[[rs()]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 183
 testRunner.And("Length Treat Null as Empty Recordset is selected", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 184
 testRunner.When("the length tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 185
 testRunner.Then("the execution has \"No\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

