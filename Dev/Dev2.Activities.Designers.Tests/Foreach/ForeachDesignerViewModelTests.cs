/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System.Activities.Presentation.Model;
using System.Collections.Generic;
using System.Windows;
using Dev2.Activities.Designers2.Foreach;
using Dev2.Common.Interfaces.Help;
using Dev2.Data.Interfaces.Enums;
using Dev2.Studio.Core.Activities.Utils;
using Dev2.Studio.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Unlimited.Applications.BusinessDesignStudio.Activities;


namespace Dev2.Activities.Designers.Tests.Foreach
{
    [TestClass]
    public class ForeachDesignerViewModelTests
    {
        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("ForeachDesignerViewModel_Constructor")]
        public void ForeachDesignerViewModel_Constructor_ModelItemIsValid_SelectedForeachTypeIsInitialized()
        {
            var modelItem = CreateModelItem();
            var viewModel = new TestForeachDesignerViewModel(modelItem);
            viewModel.Validate();
            Assert.AreEqual(enForEachType.InRange, viewModel.ForEachType);
            Assert.AreEqual("* in Range", viewModel.SelectedForeachType);
            Assert.AreEqual(viewModel.FromVisibility, Visibility.Visible);
            Assert.AreEqual(viewModel.ToVisibility, Visibility.Visible);
            Assert.AreEqual(viewModel.CsvIndexesVisibility, Visibility.Hidden);
            Assert.AreEqual(viewModel.NumberVisibility, Visibility.Hidden);
            Assert.AreEqual(viewModel.RecordsetVisibility, Visibility.Hidden);
            Assert.IsTrue(viewModel.HasLargeView);
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory("ForeachDesignerViewModel_Handle")]
        public void ForeachDesignerViewModel_UpdateHelp_ShouldCallToHelpViewMode()
        {
            //------------Setup for test--------------------------      
            var mockMainViewModel = new Mock<IShellViewModel>();
            var mockHelpViewModel = new Mock<IHelpWindowViewModel>();
            mockHelpViewModel.Setup(model => model.UpdateHelpText(It.IsAny<string>())).Verifiable();
            mockMainViewModel.Setup(model => model.HelpViewModel).Returns(mockHelpViewModel.Object);
            CustomContainer.Register(mockMainViewModel.Object);
            var viewModel = new TestForeachDesignerViewModel(CreateModelItem());
            //------------Execute Test---------------------------
            viewModel.UpdateHelpDescriptor("help");
            //------------Assert Results-------------------------
            mockHelpViewModel.Verify(model => model.UpdateHelpText(It.IsAny<string>()), Times.Once());
        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("ForeachDesignerViewModel_Constructor")]
        public void ForeachDesignerViewModel_Constructor_ModelItemIsValid_ForeachTypesHasThreeItems()
        {
            var modelItem = CreateModelItem();
            var viewModel = new TestForeachDesignerViewModel(modelItem);
            Assert.AreEqual(4, viewModel.ForeachTypes.Count);
        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("ForeachDesignerViewModel_SetSelectedForeachType")]
        public void ForeachDesignerViewModel_SetSelectedForeachTypeToinCsv_ValidForeachType_ForeachTypeOnModelItemIsAlsoSet()
        {
            var modelItem = CreateModelItem();
            var viewModel = new TestForeachDesignerViewModel(modelItem);
            const string ExpectedValue = "* in CSV";
            viewModel.SelectedForeachType = ExpectedValue;
            Assert.AreEqual(enForEachType.InCSV, viewModel.ForEachType);
            Assert.AreEqual(viewModel.FromVisibility, Visibility.Hidden);
            Assert.AreEqual(viewModel.ToVisibility, Visibility.Hidden);
            Assert.AreEqual(viewModel.CsvIndexesVisibility, Visibility.Visible);
            Assert.AreEqual(viewModel.NumberVisibility, Visibility.Hidden);
            Assert.AreEqual(viewModel.RecordsetVisibility, Visibility.Hidden);
        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("ForeachDesignerViewModel_SetSelectedForeachType")]
        public void ForeachDesignerViewModel_SetSelectedForeachTypeToinRecordset_ValidForeachType_ForeachTypeOnModelItemIsAlsoSet()
        {
            var modelItem = CreateModelItem();
            var viewModel = new TestForeachDesignerViewModel(modelItem);
            const string ExpectedValue = "* in Recordset";
            viewModel.SelectedForeachType = ExpectedValue;
            Assert.AreEqual(enForEachType.InRecordset, viewModel.ForEachType);
            Assert.AreEqual(viewModel.FromVisibility, Visibility.Hidden);
            Assert.AreEqual(viewModel.ToVisibility, Visibility.Hidden);
            Assert.AreEqual(viewModel.CsvIndexesVisibility, Visibility.Visible);
            Assert.AreEqual(viewModel.NumberVisibility, Visibility.Hidden);
            Assert.AreEqual(viewModel.RecordsetVisibility, Visibility.Visible);
        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("ForeachDesignerViewModel_SetSelectedForeachType")]
        public void ForeachDesignerViewModel_SetSelectedForeachTypeToNoOfExecution_ValidForeachType_ForeachTypeOnModelItemIsAlsoSet()
        {
            var modelItem = CreateModelItem();
            var viewModel = new TestForeachDesignerViewModel(modelItem);
            const string ExpectedValue = "No. of Executes";
            viewModel.SelectedForeachType = ExpectedValue;
            Assert.AreEqual(enForEachType.NumOfExecution, viewModel.ForEachType);
            Assert.AreEqual(viewModel.FromVisibility, Visibility.Hidden);
            Assert.AreEqual(viewModel.ToVisibility, Visibility.Hidden);
            Assert.AreEqual(viewModel.CsvIndexesVisibility, Visibility.Hidden);
            Assert.AreEqual(viewModel.NumberVisibility, Visibility.Visible);
            Assert.AreEqual(viewModel.RecordsetVisibility, Visibility.Hidden);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("ForEachDesignerViewModel_MultipleItems")]
        public void ForEachDesignerViewModel_MultipleItems_NoFormats_Null()
        {
            //------------Setup for test--------------------------
            var modelItem = CreateModelItem();
            var viewModel = new ForeachDesignerViewModel(modelItem);
            var dataObject = new DataObject();
            //------------Execute Test---------------------------
            var multipleItemsToSequence = ForeachDesignerViewModel.MultipleItemsToSequence(dataObject);
            //------------Assert Results-------------------------
            Assert.IsFalse(multipleItemsToSequence);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("ForEachDesignerViewModel_MultipleItems")]
        public void ForEachDesignerViewModel_MultipleItems_NoDataObject_Null()
        {
            //------------Setup for test--------------------------
            var modelItem = CreateModelItem();
            var viewModel = new ForeachDesignerViewModel(modelItem);
            //------------Execute Test---------------------------
            var multipleItemsToSequence = ForeachDesignerViewModel.MultipleItemsToSequence(null);
            //------------Assert Results-------------------------
            Assert.IsFalse(multipleItemsToSequence);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("ForEachDesignerViewModel_MultipleItems")]
        public void ForEachDesignerViewModel_MultipleItems_NoModelItemsFormat_Null()
        {
            //------------Setup for test--------------------------
            var modelItem = CreateModelItem();
            var viewModel = new ForeachDesignerViewModel(modelItem);
            var dataObject = new DataObject("Some format", new object());
            //------------Execute Test---------------------------
            var multipleItemsToSequence = ForeachDesignerViewModel.MultipleItemsToSequence(dataObject);
            //------------Assert Results-------------------------
            Assert.IsFalse(multipleItemsToSequence);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("ForEachDesignerViewModel_MultipleItems")]
        public void ForEachDesignerViewModel_MultipleItems_ModelItemsFormatNotList_Null()
        {
            //------------Setup for test--------------------------
            var modelItem = CreateModelItem();
            var viewModel = new ForeachDesignerViewModel(modelItem);
            var dataObject = new DataObject("ModelItemsFormat", new object());
            //------------Execute Test---------------------------
            var multipleItemsToSequence = ForeachDesignerViewModel.MultipleItemsToSequence(dataObject);
            //------------Assert Results-------------------------
            Assert.IsFalse(multipleItemsToSequence);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("ForEachDesignerViewModel_MultipleItems")]
        public void ForEachDesignerViewModel_MultipleItems_ModelItemsFormatNotListOfModelItem_Null()
        {
            //------------Setup for test--------------------------
            var modelItem = CreateModelItem();
            var viewModel = new ForeachDesignerViewModel(modelItem);
            var dataObject = new DataObject("ModelItemsFormat", new List<string> { "some string", "some string 2" });
            //------------Execute Test---------------------------
            var multipleItemsToSequence = ForeachDesignerViewModel.MultipleItemsToSequence(dataObject);
            //------------Assert Results-------------------------
            Assert.IsFalse(multipleItemsToSequence);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("ForEachDesignerViewModel_MultipleItems")]
        public void ForEachDesignerViewModel_MultipleItems_ModelItemsFormatListOfModelItemContainsNonActivity_NotAddedToSequence()
        {
            //------------Setup for test--------------------------
            var modelItem = CreateModelItem();
            var viewModel = new ForeachDesignerViewModel(modelItem);
            var assignActivity = new DsfMultiAssignActivity();
            var gatherSystemInformationActivity = new DsfGatherSystemInformationActivity();
            var dataObject = new DataObject("ModelItemsFormat", new List<ModelItem> { ModelItemUtils.CreateModelItem("a string model item"), ModelItemUtils.CreateModelItem(gatherSystemInformationActivity), ModelItemUtils.CreateModelItem(assignActivity) });
            //------------Execute Test---------------------------
            var multipleItemsToSequence = ForeachDesignerViewModel.MultipleItemsToSequence(dataObject);
            //------------Assert Results-------------------------
            Assert.IsTrue(multipleItemsToSequence);
            //            var dsfSequenceActivity = multipleItemsToSequence.GetCurrentValue() as DsfSequenceActivity;
            //            Assert.IsNotNull(dsfSequenceActivity);
            //            Assert.AreEqual(2, dsfSequenceActivity.Activities.Count);
            //            Assert.AreEqual(gatherSystemInformationActivity, dsfSequenceActivity.Activities[0]);
            //            Assert.AreEqual(assignActivity, dsfSequenceActivity.Activities[1]);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("ForEachDesignerViewModel_MultipleItems")]
        public void ForEachDesignerViewModel_MultipleItems_ModelItemsFormatListOfModelItemContainsOneActivity_NotAddedToSequence()
        {
            //------------Setup for test--------------------------
            var modelItem = CreateModelItem();
            var viewModel = new ForeachDesignerViewModel(modelItem);
            var assignActivity = new DsfMultiAssignActivity();
            var dataObject = new DataObject("ModelItemsFormat", new List<ModelItem> { ModelItemUtils.CreateModelItem(assignActivity) });
            //------------Execute Test---------------------------
            var multipleItemsToSequence = ForeachDesignerViewModel.MultipleItemsToSequence(dataObject);
            //------------Assert Results-------------------------
            Assert.IsFalse(multipleItemsToSequence);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("ForEachDesignerViewModel_MultipleItems")]
        public void ForEachDesignerViewModel_MultipleItems_ModelItemsFormatListOfModelItemActivities_AddedToSequence()
        {
            //------------Setup for test--------------------------
            var modelItem = CreateModelItem();
            var viewModel = new ForeachDesignerViewModel(modelItem);
            var assignActivity = new DsfMultiAssignActivity();
            var gatherSystemInformationActivity = new DsfGatherSystemInformationActivity();
            var numberFormatActivity = new DsfNumberFormatActivity();
            var dataObject = new DataObject("ModelItemsFormat", new List<ModelItem> { ModelItemUtils.CreateModelItem(gatherSystemInformationActivity), ModelItemUtils.CreateModelItem(assignActivity), ModelItemUtils.CreateModelItem(numberFormatActivity) });
            //------------Execute Test---------------------------
            var multipleItemsToSequence = ForeachDesignerViewModel.MultipleItemsToSequence(dataObject);
            //------------Assert Results-------------------------
            Assert.IsTrue(multipleItemsToSequence);
            //            var dsfSequenceActivity = multipleItemsToSequence.GetCurrentValue() as DsfSequenceActivity;
            //            Assert.IsNotNull(dsfSequenceActivity);
            //            Assert.AreEqual(3, dsfSequenceActivity.Activities.Count);
            //            Assert.AreEqual(gatherSystemInformationActivity, dsfSequenceActivity.Activities[0]);
            //            Assert.AreEqual(assignActivity, dsfSequenceActivity.Activities[1]);
            //            Assert.AreEqual(numberFormatActivity, dsfSequenceActivity.Activities[2]);
        }

        static ModelItem CreateModelItem()
        {
            return ModelItemUtils.CreateModelItem(new DsfForEachActivity());
        }
    }
}
