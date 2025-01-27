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
using System.Globalization;
using System.Linq;
using ActivityUnitTests;
using Dev2.Activities;
using Dev2.Common;
using Dev2.Common.Interfaces.Enums;
using Dev2.Common.State;
using Dev2.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dev2.Tests.Activities.ActivityTests
{
    /// <summary>
    ///     Summary description for RandomActivityTests
    /// </summary>
    [TestClass]
    public class RandomActivityTests : BaseActivityUnitTest
    {
        /// <summary>
        ///     Gets or sets the test context which provides
        ///     information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        #region Numbers Tests

        [TestMethod]
        public void GenerateRandomNumberWithStaticInputsExpectedARandomNumberToBeOutput()
        {
            const int Start = 10;
            const int End = 20;
            SetupArguments(ActivityStrings.RandomActivityDataListWithData, ActivityStrings.RandomActivityDataListShape, enRandomType.Numbers, Start.ToString(CultureInfo.InvariantCulture), End.ToString(CultureInfo.InvariantCulture), string.Empty, "[[OutVar1]]");

            var result = ExecuteProcess();
            GetScalarValueFromEnvironment(result.Environment, "OutVar1", out string actual, out string error);
            int.TryParse(actual, out int actualNum);

            // remove test datalist ;)

            if (string.IsNullOrEmpty(error))
            {
                Assert.IsTrue(actualNum >= Start && actualNum <= End);
            }
            else
            {
                Assert.Fail("The following errors occurred while retrieving datalist items\r\nerrors:{0}", error);
            }
        }

        [TestMethod]
        public void GenerateRandomNumberWithRecordsetWithBlankInOutputExpectedRecordsetToHaveTenNumbers()
        {
            SetupArguments(ActivityStrings.RandomActivityDataListWithData, ActivityStrings.RandomActivityDataListShape, enRandomType.Numbers, "[[recset2(*).field2]]", "[[recset1(*).field1]]", string.Empty, "[[recset2().field2]]");

            var result = ExecuteProcess();
            GetRecordSetFieldValueFromDataList(result.Environment, "recset2", "field2", out IList<string> dataListItems, out string error);

            // remove test datalist ;)

            if (string.IsNullOrEmpty(error))
            {
                Assert.IsTrue(dataListItems.Count == 10);
                int.TryParse(dataListItems[5], out int firstRes);
                Assert.IsTrue(firstRes >= -10 && firstRes <= 10);
                int.TryParse(dataListItems[6], out int secondRes);
                Assert.IsTrue(secondRes >= -20 && secondRes <= 20);
                int.TryParse(dataListItems[7], out int thirdRes);
                Assert.IsTrue(thirdRes >= -30 && thirdRes <= 30);
                int.TryParse(dataListItems[8], out int forthRes);
                Assert.IsTrue(forthRes >= -40 && forthRes <= 40);
                int.TryParse(dataListItems[9], out int fithRes);
                Assert.IsTrue(fithRes >= -50 && fithRes <= 50);
            }
            else
            {
                Assert.Fail("The following errors occurred while retrieving datalist items\r\nerrors:{0}", error);
            }
        }

        [TestMethod]
        public void GenerateRandomNumberWithBlankStringInFromExpectedError()
        {
            SetupArguments(ActivityStrings.RandomActivityDataListWithData, ActivityStrings.RandomActivityDataListShape, enRandomType.Numbers, "", "[[recset1(1).field1]]", string.Empty, "[[recset2().field2]]");

            var result = ExecuteProcess();
            GetScalarValueFromEnvironment(result.Environment, GlobalConstants.ErrorPayload, out string actual, out string error);

            // remove test datalist ;)

            if (string.IsNullOrEmpty(error))
            {
                Assert.AreEqual(Warewolf.Resource.Errors.ErrorResource.RandomPositiveIntegerForStartErrorTest, actual);
            }
            else
            {
                Assert.Fail("The following errors occurred while retrieving datalist items\r\nerrors:{0}", error);
            }
        }

        [TestMethod]
        public void GenerateRandomNumberWithBlankStringInToExpectedError()
        {
            SetupArguments(ActivityStrings.RandomActivityDataListWithData, ActivityStrings.RandomActivityDataListShape, enRandomType.Numbers, "[[recset2(1).field2]]", "", string.Empty, "[[recset2().field2]]");

            var result = ExecuteProcess();
            GetScalarValueFromEnvironment(result.Environment, GlobalConstants.ErrorPayload, out string actual, out string error);

            // remove test datalist ;)

            if (string.IsNullOrEmpty(error))
            {
                Assert.AreEqual(Warewolf.Resource.Errors.ErrorResource.RandomPositiveIntegerForEndErrorTest, actual);
            }
            else
            {
                Assert.Fail("The following errors occurred while retrieving datalist items\r\nerrors:{0}", error);
            }
        }

        //Test ammended as this is required to work now BUG 9506.
        [TestMethod]
        public void GenerateRandomNumberWithFromHigherThenToExpectedANumberBetweenTheTwoNumbersIsGenerated()
        {
            SetupArguments(ActivityStrings.RandomActivityDataListWithData, ActivityStrings.RandomActivityDataListShape, enRandomType.Numbers, "[[recset1(1).field1]]", "[[recset2(1).field2]]", string.Empty, "[[OutVar1]]");

            var result = ExecuteProcess();
            GetScalarValueFromEnvironment(result.Environment, "OutVar1", out string actual, out string error);

            // remove test datalist ;)

            int.TryParse(actual, out int innerResult);

            if (string.IsNullOrEmpty(error))
            {
                Assert.IsTrue(innerResult >= -10 && innerResult <= 10);
            }
            else
            {
                Assert.Fail("The following errors occurred while retrieving datalist items\r\nerrors:{0}", error);
            }
        }

        [TestMethod]
        public void GenerateRandomNumberWithFromBlankExpectedError()
        {
            SetupArguments(ActivityStrings.RandomActivityDataListWithData, ActivityStrings.RandomActivityDataListShape, enRandomType.Numbers, "", "[[recset2(1).field2]]", string.Empty, "[[recset2().field2]]");

            var result = ExecuteProcess();
            GetScalarValueFromEnvironment(result.Environment, GlobalConstants.ErrorPayload, out string actual, out string error);

            // remove test datalist ;)

            if (string.IsNullOrEmpty(error))
            {
                Assert.AreEqual(Warewolf.Resource.Errors.ErrorResource.RandomPositiveIntegerForStartErrorTest, actual);
            }
            else
            {
                Assert.Fail("The following errors occurred while retrieving datalist items\r\nerrors:{0}", error);
            }
        }

        [TestMethod]
        public void GenerateRandomNumberWithToBlankExpectedError()
        {
            SetupArguments(ActivityStrings.RandomActivityDataListWithData, ActivityStrings.RandomActivityDataListShape, enRandomType.Numbers, "[[recset1(1).field1]]", "", string.Empty, "[[recset2().field2]]");

            var result = ExecuteProcess();
            GetScalarValueFromEnvironment(result.Environment, GlobalConstants.ErrorPayload, out string actual, out string error);

            // remove test datalist ;)

            if (string.IsNullOrEmpty(error))
            {
                Assert.AreEqual(Warewolf.Resource.Errors.ErrorResource.RandomPositiveIntegerForEndErrorTest, actual);
            }
            else
            {
                Assert.Fail("The following errors occurred while retrieving datalist items\r\nerrors:{0}", error);
            }
        }

        [TestMethod]
        public void GenerateRandomNumberWithToFieldWithLettersExpectedError()
        {
            SetupArguments(ActivityStrings.RandomActivityDataListWithData, ActivityStrings.RandomActivityDataListShape, enRandomType.Numbers, "[[recset1(1).field1]]", "letters", "", "[[recset2().field2]]");

            var result = ExecuteProcess();

            var expected = string.Format(Warewolf.Resource.Errors.ErrorResource.RandomIntegerForEndErrorTest, double.MinValue, double.MaxValue);
            GetScalarValueFromEnvironment(result.Environment, GlobalConstants.ErrorPayload, out string actual, out string error);

            // remove test datalist ;)

            if (string.IsNullOrEmpty(error))
            {
                Assert.AreEqual(expected, actual);
            }
            else
            {
                Assert.Fail("The following errors occurred while retrieving datalist items\r\nerrors:{0}", error);
            }
        }

        [TestMethod]
        public void GenerateRandomNumberWithFromFieldWithLettersExpectedError()
        {
            SetupArguments(ActivityStrings.RandomActivityDataListWithData, ActivityStrings.RandomActivityDataListShape, enRandomType.Numbers, "letters", "[[recset1(1).field1]]", string.Empty, "[[recset2().field2]]");

            var result = ExecuteProcess();

            var expected = string.Format(Warewolf.Resource.Errors.ErrorResource.RandomIntegerForStartErrorTest, double.MinValue, double.MaxValue);
            GetScalarValueFromEnvironment(result.Environment, GlobalConstants.ErrorPayload, out string actual, out string error);

            // remove test datalist ;)

            if (string.IsNullOrEmpty(error))
            {
                Assert.AreEqual(expected, actual);
            }
            else
            {
                Assert.Fail("The following errors occurred while retrieving datalist items\r\nerrors:{0}", error);
            }
        }

        #endregion

        #region Letters Tests

        [TestMethod]
        public void GenerateRandomLettersWithLengthOfTenStaticValueExpectedFiveRandomCharString()
        {
            const int Length = 10;
            SetupArguments(ActivityStrings.RandomActivityDataListWithData, ActivityStrings.RandomActivityDataListShape, enRandomType.Letters, string.Empty, string.Empty, Length.ToString(CultureInfo.InvariantCulture), "[[OutVar1]]");

            var result = ExecuteProcess();
            GetScalarValueFromEnvironment(result.Environment, "OutVar1", out string actual, out string error);

            // remove test datalist ;)

            if (string.IsNullOrEmpty(error))
            {
                Assert.AreEqual(Length, actual.Length);
            }
            else
            {
                Assert.Fail("The following errors occurred while retrieving datalist items\r\nerrors:{0}", error);
            }
        }

        [TestMethod]
        public void GenerateRandomLettersWithLengthOfTenRecordsetWithIndexValueExpectedFiveRandomCharString()
        {
            SetupArguments(ActivityStrings.RandomActivityDataListWithData, ActivityStrings.RandomActivityDataListShape, enRandomType.Letters, string.Empty, string.Empty, "[[recset1(1).field1]]", "[[OutVar1]]");

            var result = ExecuteProcess();
            GetScalarValueFromEnvironment(result.Environment, "OutVar1", out string actual, out string error);

            // remove test datalist ;)

            if (string.IsNullOrEmpty(error))
            {
                Assert.AreEqual(10, actual.Length);
            }
            else
            {
                Assert.Fail("The following errors occurred while retrieving datalist items\r\nerrors:{0}", error);
            }
        }

        [TestMethod]
        public void GenerateRandomLettersWithLengthOfNegativeTenExpectedError()
        {
            SetupArguments(ActivityStrings.RandomActivityDataListWithData, ActivityStrings.RandomActivityDataListShape, enRandomType.Letters, string.Empty, string.Empty, "[[recset2(1).field2]]", "[[OutVar1]]");

            var result = ExecuteProcess();

            const string Expected = "Please enter a positive integer for the Length.";
            GetScalarValueFromEnvironment(result.Environment, GlobalConstants.ErrorPayload, out string actual, out string error);

            // remove test datalist ;)

            if (string.IsNullOrEmpty(error))
            {
                Assert.AreEqual(Expected, actual);
            }
            else
            {
                Assert.Fail("The following errors occurred while retrieving datalist items\r\nerrors:{0}", error);
            }
        }

        [TestMethod]
        public void GenerateRandomLettersWithLengthOfLettersExpectedError()
        {
            SetupArguments(ActivityStrings.RandomActivityDataListWithData, ActivityStrings.RandomActivityDataListShape, enRandomType.Letters, string.Empty, string.Empty, "letters", "[[OutVar1]]");

            var result = ExecuteProcess();

            const string Expected = "Please ensure that the Length is an integer value.";
            GetScalarValueFromEnvironment(result.Environment, GlobalConstants.ErrorPayload, out string actual, out string error);

            // remove test datalist ;)

            if (string.IsNullOrEmpty(error))
            {
                Assert.AreEqual(Expected, actual);
            }
            else
            {
                Assert.Fail("The following errors occurred while retrieving datalist items\r\nerrors:{0}", error);
            }
        }

        [TestMethod]
        public void GenerateRandomLettersWithBlankLengthExpectedError()
        {
            SetupArguments(ActivityStrings.RandomActivityDataListWithData, ActivityStrings.RandomActivityDataListShape, enRandomType.Letters, string.Empty, string.Empty, "", "[[OutVar1]]");

            var result = ExecuteProcess();
            GetScalarValueFromEnvironment(result.Environment, GlobalConstants.ErrorPayload, out string actual, out string error);

            // remove test datalist ;)

            if (string.IsNullOrEmpty(error))
            {
                Assert.AreEqual(Warewolf.Resource.Errors.ErrorResource.RandomPositiveIntegerErrorTest, actual);
            }
            else
            {
                Assert.Fail("The following errors occurred while retrieving datalist items\r\nerrors:{0}", error);
            }
        }

        #endregion

        

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfRandomActivity_UpdateForEachInputs")]
        public void DsfRandomActivity_UpdateForEachInputs_NullUpdates_DoesNothing()
        {
            //------------Setup for test--------------------------
            const string From = "[[Numeric(1).num]]";
            const string To = "Up";
            const string Result = "[[res]]";
            const string Length = "2";
            var act = new DsfRandomActivity { From = From, To = To, Length = Length, Result = Result };

            //------------Execute Test---------------------------
            act.UpdateForEachInputs(null);
            //------------Assert Results-------------------------
            Assert.AreEqual(From, act.From);
            Assert.AreEqual(To, act.To);
            Assert.AreEqual(Length, act.Length);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfRandomActivity_GetOutputs")]
        public void DsfRandomActivity_GetOutputs_Called_ShouldReturnListWithResultValueInIt()
        {
            //------------Setup for test--------------------------
            const string From = "[[Numeric(1).num]]";
            const string To = "Up";
            const string Result = "[[res]]";
            const string Length = "2";
            var act = new DsfRandomActivity { From = From, To = To, Length = Length, Result = Result };
            //------------Execute Test---------------------------
            var outputs = act.GetOutputs();
            //------------Assert Results-------------------------
            Assert.AreEqual(1, outputs.Count);
            Assert.AreEqual("[[res]]", outputs[0]);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfRandomActivity_UpdateForEachInputs")]
        public void DsfRandomActivity_UpdateForEachInputs_MoreThan1Updates_Updates()
        {
            //------------Setup for test--------------------------
            const string From = "[[Numeric(1).num]]";
            const string To = "Up";
            const string Result = "[[res]]";
            const string Length = "2";
            var act = new DsfRandomActivity { From = From, To = To, Length = Length, Result = Result };

            var tuple1 = new Tuple<string, string>(From, "Test");
            var tuple2 = new Tuple<string, string>(To, "Test2");
            var tuple3 = new Tuple<string, string>(Length, "Test3");
            //------------Execute Test---------------------------
            act.UpdateForEachInputs(new List<Tuple<string, string>> { tuple1, tuple2, tuple3 });
            //------------Assert Results-------------------------
            Assert.AreEqual("Test2", act.To);
            Assert.AreEqual("Test", act.From);
            Assert.AreEqual("Test3", act.Length);
        }


        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfRandomActivity_UpdateForEachOutputs")]
        public void DsfRandomActivity_UpdateForEachOutputs_NullUpdates_DoesNothing()
        {
            //------------Setup for test--------------------------
            const string From = "[[Numeric(1).num]]";
            const string To = "Up";
            const string Result = "[[res]]";
            const string Length = "2";
            var act = new DsfRandomActivity { From = From, To = To, Length = Length, Result = Result };

            act.UpdateForEachOutputs(null);
            //------------Assert Results-------------------------
            Assert.AreEqual(Result, act.Result);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfRandomActivity_UpdateForEachOutputs")]
        public void DsfRandomActivity_UpdateForEachOutputs_MoreThan1Updates()
        {
            //------------Setup for test--------------------------
            const string From = "[[Numeric(1).num]]";
            const string To = "Up";
            const string Result = "[[res]]";
            const string Length = "2";
            var act = new DsfRandomActivity { From = From, To = To, Length = Length, Result = Result };

            var tuple1 = new Tuple<string, string>("Test", "Test");
            var tuple2 = new Tuple<string, string>("Test2", "Test2");
            //------------Execute Test---------------------------
            act.UpdateForEachOutputs(new List<Tuple<string, string>> { tuple1, tuple2 });
            //------------Assert Results-------------------------
            Assert.AreEqual(Result, act.Result);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfRandomActivity_UpdateForEachOutputs")]
        public void DsfRandomActivity_UpdateForEachOutputs_1Updates_UpdateCommandResult()
        {
            //------------Setup for test--------------------------
            const string From = "[[Numeric(1).num]]";
            const string To = "Up";
            const string Result = "[[res]]";
            const string Length = "2";
            var act = new DsfRandomActivity { From = From, To = To, Length = Length, Result = Result };

            var tuple1 = new Tuple<string, string>("[[res]]", "Test");
            //------------Execute Test---------------------------
            act.UpdateForEachOutputs(new List<Tuple<string, string>> { tuple1 });
            //------------Assert Results-------------------------
            Assert.AreEqual("Test", act.Result);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfRandomActivity_GetForEachInputs")]
        public void DsfRandomActivity_GetForEachInputs_WhenHasExpression_ReturnsInputList()
        {
            //------------Setup for test--------------------------
            const string From = "[[Numeric(1).num]]";
            const string To = "Up";
            const string Result = "[[res]]";
            const string Length = "2";
            var act = new DsfRandomActivity { From = From, To = To, Length = Length, Result = Result };

            //------------Execute Test---------------------------
            var dsfForEachItems = act.GetForEachInputs();
            //------------Assert Results-------------------------
            Assert.AreEqual(3, dsfForEachItems.Count);
            Assert.AreEqual(To, dsfForEachItems[0].Name);
            Assert.AreEqual(To, dsfForEachItems[0].Value);
            Assert.AreEqual(From, dsfForEachItems[1].Name);
            Assert.AreEqual(From, dsfForEachItems[1].Value);
            Assert.AreEqual(Length, dsfForEachItems[2].Name);
            Assert.AreEqual(Length, dsfForEachItems[2].Value);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfRandomActivity_GetForEachOutputs")]
        public void DsfRandomActivity_GetForEachOutputs_WhenHasResult_ReturnsOutputList()
        {
            //------------Setup for test--------------------------
            const string From = "[[Numeric(1).num]]";
            const string To = "Up";
            const string Result = "[[res]]";
            const string Length = "2";
            var act = new DsfRandomActivity { From = From, To = To, Length = Length, Result = Result };

            //------------Execute Test---------------------------
            var dsfForEachItems = act.GetForEachOutputs();
            //------------Assert Results-------------------------
            Assert.AreEqual(1, dsfForEachItems.Count);
            Assert.AreEqual(Result, dsfForEachItems[0].Name);
            Assert.AreEqual(Result, dsfForEachItems[0].Value);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfRandomActivity_GetState")]
        public void DsfRandomActivity_GetState_ReturnsStateVariable()
        {
            //---------------Set up test pack-------------------
            //------------Setup for test--------------------------
            var act = new DsfRandomActivity { RandomType=enRandomType.LetterAndNumbers,From="1",To="5",Length="2",Result="[[rand]]"};
            //------------Execute Test---------------------------
            var stateItems = act.GetState();
            Assert.AreEqual(5, stateItems.Count());

            var expectedResults = new[]
            {
                new StateVariable
                {
                    Name = "RandomType",
                    Type = StateVariable.StateType.Input,
                    Value = "LetterAndNumbers"
                },
                new StateVariable
                {
                    Name = "From",
                    Type = StateVariable.StateType.Input,
                    Value = "1"
                },
                new StateVariable
                {
                    Name = "To",
                    Type = StateVariable.StateType.Input,
                    Value = "5"
                },
                new StateVariable
                {
                    Name = "Length",
                    Type = StateVariable.StateType.Input,
                    Value = "2"
                },
                new StateVariable
                {
                    Name="Result",
                    Type = StateVariable.StateType.Output,
                    Value = "[[rand]]"
                }
            };

            var iter = act.GetState().Select(
                (item, index) => new
                {
                    value = item,
                    expectValue = expectedResults[index]
                }
                );

            //------------Assert Results-------------------------
            foreach (var entry in iter)
            {
                Assert.AreEqual(entry.expectValue.Name, entry.value.Name);
                Assert.AreEqual(entry.expectValue.Type, entry.value.Type);
                Assert.AreEqual(entry.expectValue.Value, entry.value.Value);
            }
        }

        #region Private Test Methods

        void SetupArguments(string currentDL, string testData, enRandomType randomType, string from, string to, string length, string result)
        {
            TestStartNode = new FlowStep
            {
                Action = new DsfRandomActivity { RandomType = randomType, From = from, To = to, Length = length, Result = result }
            };

            CurrentDl = testData;
            TestData = currentDL;
        }

        #endregion Private Test Methods
    }
}
