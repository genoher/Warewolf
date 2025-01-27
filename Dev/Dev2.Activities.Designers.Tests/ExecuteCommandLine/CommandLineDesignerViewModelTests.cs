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
using System.Diagnostics;
using Dev2.Activities.Designers2.CommandLine;
using Dev2.Common.Interfaces.Help;
using Dev2.Common.Interfaces.Infrastructure.Providers.Errors;
using Dev2.Providers.Errors;
using Dev2.Studio.Core.Activities.Utils;
using Dev2.Studio.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Dev2.Activities.Designers.Tests.ExecuteCommandLine
{
    [TestClass]
    
    public class CommandLineDesignerViewModelTests
    {
        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("CommandLineDesignerViewModel_Constructor")]
        public void CommandLineDesignerViewModel_Constructor_Properties_Initialized()
        {
            //------------Setup for test--------------------------

            //------------Execute Test---------------------------
            var viewModel = new CommandLineDesignerViewModel(CreateModelItem());

            //------------Assert Results-------------------------
            Assert.IsNotNull(viewModel.CommandPriorities);

            // Ensure order is correct
            Assert.AreEqual(ProcessPriorityClass.BelowNormal, viewModel.CommandPriorities[0].Key);
            Assert.AreEqual(ProcessPriorityClass.Normal, viewModel.CommandPriorities[1].Key);
            Assert.AreEqual(ProcessPriorityClass.AboveNormal, viewModel.CommandPriorities[2].Key);
            Assert.AreEqual(ProcessPriorityClass.Idle, viewModel.CommandPriorities[3].Key);
            Assert.AreEqual(ProcessPriorityClass.High, viewModel.CommandPriorities[4].Key);
            Assert.AreEqual(ProcessPriorityClass.RealTime, viewModel.CommandPriorities[5].Key);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("CommandLineDesignerViewModel_Validate")]
        public void CommandLineDesignerViewModel_Validate_CommandFileNameIsNull_HasErrors()
        {
            //------------Setup for test--------------------------
            const string CommandFileName = null;
            
            var viewModel = new CommandLineDesignerViewModel(CreateModelItem(CommandFileName));
            

            //------------Execute Test---------------------------
            viewModel.Validate();

            //------------Assert Results-------------------------
            Assert.IsNotNull(viewModel.Errors);
            Assert.AreEqual(1, viewModel.Errors.Count);

            var error = viewModel.Errors[0];
            Assert.AreEqual("Command must have a value", error.Message);
            Assert.AreEqual(ErrorType.Critical, error.ErrorType);

            Assert.IsFalse(viewModel.IsCommandFileNameFocused);
            error.Do();
            Assert.IsTrue(viewModel.IsCommandFileNameFocused);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("CommandLineDesignerViewModel_Validate")]
        public void CommandLineDesignerViewModel_Validate_CommandFileNameHasInvalidExpression_HasErrors()
        {
            //------------Setup for test--------------------------
            const string CommandFileName = "h]]";
            var viewModel = new CommandLineDesignerViewModel(CreateModelItem(CommandFileName));

            //------------Execute Test---------------------------
            viewModel.Validate();

            //------------Assert Results-------------------------
            Assert.IsNotNull(viewModel.Errors);
            Assert.AreEqual(1, viewModel.Errors.Count);

            var error = viewModel.Errors[0];
            Assert.AreEqual(Warewolf.Resource.Errors.ErrorResource.CommandLineInvalidExpressionErrorTest, error.Message);
            Assert.AreEqual(ErrorType.Critical, error.ErrorType);

            Assert.IsFalse(viewModel.IsCommandFileNameFocused);
            error.Do();
            Assert.IsTrue(viewModel.IsCommandFileNameFocused);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("CommandLineDesignerViewModel_Validate")]
        public void CommandLineDesignerViewModel_Validate_CommandFileNameHasValidExpression_HasNoErrors()
        {
            //------------Setup for test--------------------------
            const string CommandFileName = "[[h]]";
            var viewModel = new CommandLineDesignerViewModel(CreateModelItem(CommandFileName));

            //------------Execute Test---------------------------
            viewModel.Validate();

            //------------Assert Results-------------------------
            Assert.IsNotNull(viewModel.Errors);
            Assert.AreEqual(0, viewModel.Errors.Count);
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory("CommandLineDesignerViewModel_Handle")]
        public void CommandLineDesignerViewModel_UpdateHelp_ShouldCallToHelpViewMode()
        {
            //------------Setup for test--------------------------      
            var mockMainViewModel = new Mock<IShellViewModel>();
            var mockHelpViewModel = new Mock<IHelpWindowViewModel>();
            mockHelpViewModel.Setup(model => model.UpdateHelpText(It.IsAny<string>())).Verifiable();
            mockMainViewModel.Setup(model => model.HelpViewModel).Returns(mockHelpViewModel.Object);
            CustomContainer.Register(mockMainViewModel.Object);

            const string CommandFileName = "[[h]]";
            var viewModel = new CommandLineDesignerViewModel(CreateModelItem(CommandFileName));
            //------------Execute Test---------------------------
            viewModel.UpdateHelpDescriptor("help");
            //------------Assert Results-------------------------
            mockHelpViewModel.Verify(model => model.UpdateHelpText(It.IsAny<string>()), Times.Once());
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("CommandLineDesignerViewModel_Validate")]
        public void CommandLineDesignerViewModel_Validate_ClearsErrorsFirst()
        {
            //------------Setup for test--------------------------
            const string CommandFileName = "h]]";
            var viewModel = new CommandLineDesignerViewModel(CreateModelItem(CommandFileName))
            {
                Errors = new List<IActionableErrorInfo>
                {
                    new ActionableErrorInfo { Message = "Previous Error", ErrorType = ErrorType.Warning}
                }
            };

            //------------Execute Test---------------------------
            viewModel.Validate();

            //------------Assert Results-------------------------
            Assert.IsNotNull(viewModel.Errors);
            Assert.AreEqual(1, viewModel.Errors.Count);

            var error = viewModel.Errors[0];
            Assert.AreEqual(Warewolf.Resource.Errors.ErrorResource.CommandLineInvalidExpressionErrorTest, error.Message);
            Assert.AreEqual(ErrorType.Critical, error.ErrorType);
        }


        static ModelItem CreateModelItem(string commandFileName = null)
        {
            return ModelItemUtils.CreateModelItem(new DsfExecuteCommandLineActivity { CommandFileName = commandFileName });
        }
    }
}
