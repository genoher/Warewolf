/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Activities.Statements;
using System.Collections.Generic;
using Dev2.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using Unlimited.Applications.BusinessDesignStudio.Activities;
using Warewolf.Tools.Specs.BaseTypes;

namespace Dev2.Activities.Specs.Toolbox.Data.Replace
{
    [Binding]
    public class ReplaceSteps : RecordSetBases
    {
        readonly ScenarioContext scenarioContext;

        public ReplaceSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;
        }

        string _inFields = "[[sentence]]";

        protected override void BuildDataList()
        {
            scenarioContext.TryGetValue("variableList", out List<Tuple<string, string>> variableList);

            if (variableList == null)
            {
                variableList = new List<Tuple<string, string>>();
                scenarioContext.Add("variableList", variableList);
            }

            variableList.Add(new Tuple<string, string>(ResultVariable, ""));
            BuildShapeAndTestData();

            scenarioContext.TryGetValue("find", out string find);
            scenarioContext.TryGetValue("replaceWith", out string replaceWith);

            scenarioContext.TryGetValue("resultVar", out string resultVar);

            if (string.IsNullOrEmpty(resultVar))
            {
                resultVar = ResultVariable;
            }

            if (scenarioContext.TryGetValue("sentence", out string sentence))
            {
                _inFields = sentence;
            }

            var replace = new DsfReplaceActivity
                {
                    Result = resultVar,
                    FieldsToSearch = _inFields,
                    Find = find,
                    ReplaceWith = replaceWith
                };

            TestStartNode = new FlowStep
                {
                    Action = replace
                };
            scenarioContext.Add("activity", replace);
        }

        [Given(@"I have a sentence ""(.*)""")]
        public void GivenIHaveASentence(string sentence)
        {
            scenarioContext.Add("sentence", sentence);
        }

        [Given(@"replace result is ""(.*)""")]
        public void GivenReplaceResultIs(string resultVar)
        {
            scenarioContext.Add("resultVar", resultVar);
        }


        [Given(@"I have a replace variable ""(.*)"" equal to ""(.*)""")]
        public void GivenIHaveAReplaceVariableEqualTo(string variable, string value)
        {
            scenarioContext.TryGetValue("variableList", out List<Tuple<string, string>> variableList);

            if (variableList == null)
            {
                variableList = new List<Tuple<string, string>>();
                scenarioContext.Add("variableList", variableList);
            }
            variableList.Add(new Tuple<string, string>(variable, value));
        }

        [Given(@"I want to find the characters ""(.*)""")]
        public void GivenIWantToFindTheCharacters(string find)
        {
            scenarioContext.Add("find", find);
        }

        [Given(@"I want to replace them with ""(.*)""")]
        public void GivenIWantToReplaceThemWith(string replaceWith)
        {
            scenarioContext.Add("replaceWith", replaceWith);
        }

        [When(@"the replace tool is executed")]
        public void WhenTheReplaceToolIsExecuted()
        {
            BuildDataList();
            var result = ExecuteProcess(isDebug: true, throwException: false);
            scenarioContext.Add("result", result);
        }

        [Then(@"the replace result should be ""(.*)""")]
        public void ThenTheReplaceResultShouldBe(string expectedResult)
        {
            expectedResult = expectedResult.Replace('"', ' ').Trim();
            var result = scenarioContext.Get<IDSFDataObject>("result");
            GetScalarValueFromEnvironment(result.Environment, ResultVariable,
                                       out string actualValue, out string error);
            Assert.AreEqual(expectedResult, actualValue);
        }

        [Then(@"""(.*)"" should be ""(.*)""")]
        public void ThenShouldBe(string variable, string value)
        {
            value = value.Replace('"', ' ').Trim();
            var result = scenarioContext.Get<IDSFDataObject>("result");
            GetScalarValueFromEnvironment(result.Environment, variable,
                                       out string actualValue, out string error);
            Assert.AreEqual(value, actualValue);
        }
    }
}
