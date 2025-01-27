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
using System.Activities;
using System.Activities.Presentation;
using System.Activities.Presentation.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using Caliburn.Micro;
using Dev2.Common.Interfaces;
using Dev2.Common.Interfaces.Diagnostics.Debug;
using Dev2.Common.Interfaces.Enums;
using Dev2.Common.Interfaces.Infrastructure;
using Dev2.Common.Interfaces.Infrastructure.Events;
using Dev2.Common.Interfaces.Infrastructure.SharedModels;
using Dev2.Common.Interfaces.Security;
using Dev2.Common.Interfaces.Studio.Controller;
using Dev2.Communication;
using Dev2.Core.Tests.Environments;
using Dev2.Core.Tests.Workflows;
using Dev2.Data.ServiceModel.Messages;
using Dev2.Messages;
using Dev2.Runtime.ServiceModel.Data;
using Dev2.Services.Security;
using Dev2.Studio.AppResources.Comparers;
using Dev2.Studio.Core.Messages;
using Dev2.Studio.Core.Models;
using Dev2.Studio.Core.Utils;
using Dev2.Studio.Interfaces;
using Dev2.Studio.Interfaces.DataList;
using Dev2.Studio.Interfaces.Enums;
using Dev2.Studio.ViewModels.DataList;
using Dev2.Studio.ViewModels.Diagnostics;
using Dev2.Studio.ViewModels.WorkSurface;
using Dev2.Util;
using Dev2.Utilities;
using Dev2.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace Dev2.Core.Tests
{
    [TestClass]
    [TestCategory("Studio Worksurfaces Core")]
    public class WorkSurfaceContextViewModelTests
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            AppUsageStats.LocalHost = "http://localhost:3142";
            CustomContainer.Register<IServerRepository>(new Mock<IServerRepository>().Object);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("WorkSurfaceContextViewModel_Constructor")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WorkSurfaceContextViewModel_Constructor_NullWorkSurfaceKey_ExpectException()
        {
            //------------Setup for test--------------------------

            //------------Execute Test---------------------------

            new WorkSurfaceContextViewModel(new Mock<IEventAggregator>().Object, null, new Mock<IWorkSurfaceViewModel>().Object, new Mock<IPopupController>().Object, (a, b, c) => { });

            //------------Assert Results-------------------------
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("WorkSurfaceContextViewModel_Constructor")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WorkSurfaceContextViewModel_Constructor_NullWorkSurfaceViewModel_ExpectException()
        {
            //------------Setup for test--------------------------

            //------------Execute Test---------------------------

            new WorkSurfaceContextViewModel(new Mock<IEventAggregator>().Object, new WorkSurfaceKey(), null, new Mock<IPopupController>().Object, (a, b, c) => { });

            //------------Assert Results-------------------------
        }


        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("WorkSurfaceContextViewModel_Constructor")]
        public void WorkSurfaceContextViewModel_Constructor_ValidArguments_DebugOutputViewModelIsNull()
        {
            //------------Setup for test--------------------------
            var workSurfaceKey = new WorkSurfaceKey();
            var mockWorkSurfaceViewModel = new Mock<IWorkflowDesignerViewModel>();
            var mockedConn = new Mock<IEnvironmentConnection>();
            mockedConn.Setup(conn => conn.ServerEvents).Returns(new Mock<IEventPublisher>().Object);
            var mockEnvironmentModel = new Mock<IServer>();
            mockEnvironmentModel.Setup(model => model.Connection).Returns(mockedConn.Object);
            var environmentModel = mockEnvironmentModel.Object;
            mockWorkSurfaceViewModel.Setup(model => model.Server).Returns(environmentModel);

            var workSurfaceViewModel = mockWorkSurfaceViewModel.As<IWorkSurfaceViewModel>().Object;
            //------------Execute Test---------------------------
            var workSurfaceContextViewModel = new WorkSurfaceContextViewModel(new Mock<IEventAggregator>().Object, workSurfaceKey, workSurfaceViewModel, new Mock<IPopupController>().Object, (a, b, c) => { });
            //------------Assert Results-------------------------
            Assert.IsNotNull(workSurfaceContextViewModel);
            Assert.IsNull(workSurfaceContextViewModel.DebugOutputViewModel);
        }


        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("WorkSurfaceContextViewModel_EnvironmentModelIsConnectedChanged")]
        public void WorkSurfaceContextViewModel_EnvironmentModelIsConnectedChanged_False_DebugStatusFinished()
        {
            //------------Setup for test--------------------------
            var workSurfaceKey = new WorkSurfaceKey();
            var mockEnvironmentModel = new Mock<IServer>();
            var mockResourceModel = new Mock<IContextualResourceModel>();


            var workflow = new ActivityBuilder();
            var resourceRep = new Mock<IResourceRepository>();
            resourceRep.Setup(r => r.All()).Returns(new List<IResourceModel>());

            resourceRep.Setup(r => r.FetchResourceDefinition(It.IsAny<IServer>(), It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<bool>())).Returns((ExecuteMessage)null);

            var resourceModel = mockResourceModel;
            mockEnvironmentModel.Setup(m => m.ResourceRepository).Returns(resourceRep.Object);
            var envConn = new Mock<IEnvironmentConnection>();
            var serverEvents = new Mock<IEventPublisher>();
            envConn.Setup(m => m.ServerEvents).Returns(serverEvents.Object);
            mockEnvironmentModel.Setup(m => m.Connection).Returns(envConn.Object);
            mockEnvironmentModel.Setup(m => m.IsConnected).Returns(true);
            resourceModel.Setup(r => r.ResourceName).Returns("Test");
            var xamlBuilder = new StringBuilder("abc");

            var workflowHelper = new Mock<IWorkflowHelper>();

            workflowHelper.Setup(h => h.CreateWorkflow(It.IsAny<string>())).Returns(() => workflow);
            workflowHelper.Setup(h => h.SanitizeXaml(It.IsAny<StringBuilder>())).Returns(xamlBuilder);
            mockResourceModel.Setup(model => model.Environment).Returns(mockEnvironmentModel.Object);
            var viewModel = new WorkflowDesignerViewModelMock(resourceModel.Object, workflowHelper.Object);
            var connectedEventArgs = new ConnectedEventArgs { IsConnected = false };
            var workSurfaceContextViewModel = new WorkSurfaceContextViewModel(new Mock<IEventAggregator>().Object, workSurfaceKey, viewModel, new Mock<IPopupController>().Object, (a, b, c) => { }) { DebugOutputViewModel = { DebugStatus = DebugStatus.Executing } };
            //------------Execute Test---------------------------
            mockEnvironmentModel.Raise(model => model.IsConnectedChanged += null, connectedEventArgs);
            //------------Assert Results-------------------------
            Assert.AreEqual(DebugStatus.Finished, workSurfaceContextViewModel.DebugOutputViewModel.DebugStatus);
        }

        static WorkflowDesignerViewModelMock WorkflowDesignerViewModelMock(bool isConnected, Mock<IContextualResourceModel> ResourceModel = null)
        {
            var workflow = new ActivityBuilder();
            var resourceRep = new Mock<IResourceRepository>();
            resourceRep.Setup(r => r.All()).Returns(new List<IResourceModel>());

            ExecuteMessage exeMsg = null;

            resourceRep.Setup(r => r.FetchResourceDefinition(It.IsAny<IServer>(), It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<bool>())).Returns(exeMsg);

            var resourceModel = ResourceModel ?? new Mock<IContextualResourceModel>();
            resourceModel.Setup(m => m.Environment.ResourceRepository).Returns(resourceRep.Object);
            var envConn = new Mock<IEnvironmentConnection>();
            var serverEvents = new Mock<IEventPublisher>();
            envConn.Setup(m => m.ServerEvents).Returns(serverEvents.Object);
            resourceModel.Setup(m => m.Environment.Connection).Returns(envConn.Object);
            resourceModel.Setup(m => m.Environment.IsConnected).Returns(isConnected);
            resourceModel.Setup(r => r.ResourceName).Returns("Test");
            resourceRep.Setup(r => r.All()).Returns(new List<IResourceModel> { resourceModel.Object });
            var xamlBuilder = new StringBuilder("abc");

            var workflowHelper = new Mock<IWorkflowHelper>();
            
            workflowHelper.Setup(h => h.CreateWorkflow(It.IsAny<string>())).Returns(() =>
            {
                return workflow;
            });
            workflowHelper.Setup(h => h.SanitizeXaml(It.IsAny<StringBuilder>())).Returns(xamlBuilder);
            var viewModel = new WorkflowDesignerViewModelMock(resourceModel.Object, workflowHelper.Object);
            return viewModel;
        }

        static WorkflowDesignerViewModelMock WorkflowDesignerViewModelWithServerPermissionsMock(bool isConnected, Mock<IContextualResourceModel> ResourceModel = null)
        {
            var workflow = new ActivityBuilder();
            var resourceRep = new Mock<IResourceRepository>();
            resourceRep.Setup(r => r.All()).Returns(new List<IResourceModel>());

            ExecuteMessage exeMsg = null;

            resourceRep.Setup(r => r.FetchResourceDefinition(It.IsAny<IServer>(), It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<bool>())).Returns(exeMsg);

            var env = new Mock<IServer>();
            env.Setup(e => e.IsAuthorized).Returns(true);
            env.Setup(e => e.Permissions).Returns(new List<IWindowsGroupPermission> { WindowsGroupPermission.CreateAdministrators() });
            var mockAuthorizationService = new Mock<IAuthorizationService>();
            mockAuthorizationService.Setup(service => service.IsAuthorized(AuthorizationContext.DeployFrom, null)).Returns(true);
            mockAuthorizationService.Setup(service => service.IsAuthorized(AuthorizationContext.DeployTo, null)).Returns(true);
            env.Setup(model => model.AuthorizationService).Returns(mockAuthorizationService.Object);

            var resourceModel = ResourceModel ?? new Mock<IContextualResourceModel>();
            resourceModel.Setup(m => m.Environment).Returns(env.Object);
            resourceModel.Setup(m => m.Environment.ResourceRepository).Returns(resourceRep.Object);
            var envConn = new Mock<IEnvironmentConnection>();
            var serverEvents = new Mock<IEventPublisher>();
            envConn.Setup(m => m.ServerEvents).Returns(serverEvents.Object);
            resourceModel.Setup(m => m.Environment.Connection).Returns(envConn.Object);
            resourceModel.Setup(m => m.Environment.IsConnected).Returns(isConnected);
            resourceModel.Setup(r => r.ResourceName).Returns("Test");
            resourceModel.Setup(r => r.Category).Returns("Test");
            resourceRep.Setup(r => r.All()).Returns(new List<IResourceModel> { resourceModel.Object });
            var xamlBuilder = new StringBuilder("abc");

            var workflowHelper = new Mock<IWorkflowHelper>();

            workflowHelper.Setup(h => h.CreateWorkflow(It.IsAny<string>())).Returns(() =>
            {
                return workflow;
            });
            workflowHelper.Setup(h => h.SanitizeXaml(It.IsAny<StringBuilder>())).Returns(xamlBuilder);
            var viewModel = new WorkflowDesignerViewModelMock(resourceModel.Object, workflowHelper.Object);
            return viewModel;
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("WorkSurfaceContextViewModel_EnvironmentModelIsConnectedChanged")]
        public void WorkSurfaceContextViewModel_EnvironmentModelIsConnectedChanged_True_DebugStatusNotChanged()
        {
            //------------Setup for test--------------------------
            var mockedConn = new Mock<IEnvironmentConnection>();
            mockedConn.Setup(conn => conn.ServerEvents).Returns(new Mock<IEventPublisher>().Object);
            var mockEnvironmentModel = new Mock<IServer>();
            mockEnvironmentModel.Setup(model => model.Connection).Returns(mockedConn.Object);
            var environmentModel = mockEnvironmentModel.Object;
            var workSurfaceContextViewModel = CreateWorkSurfaceContextViewModel(environmentModel, true);
            var connectedEventArgs = new ConnectedEventArgs { IsConnected = true };
            workSurfaceContextViewModel.DebugOutputViewModel.DebugStatus = DebugStatus.Executing;
            //------------Execute Test---------------------------
            mockEnvironmentModel.Raise(model => model.IsConnectedChanged += null, connectedEventArgs);
            //------------Assert Results-------------------------
            Assert.AreEqual(DebugStatus.Executing, workSurfaceContextViewModel.DebugOutputViewModel.DebugStatus);
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory("WorkSurfaceContextViewModel_Debug")]
        public void WorkSurfaceContextViewModel_Debug_ExpectReturn()
        {
            //------------Setup for test--------------------------
            var workSurfaceContextViewModel = CreateWorkSurfaceContextViewModel();
            var mockDebugState = new Mock<IDebugState>();
            mockDebugState.Setup(state => state.StateType).Returns(StateType.All);
            mockDebugState.Setup(m => m.SessionID).Returns(workSurfaceContextViewModel.DebugOutputViewModel.SessionID);
            workSurfaceContextViewModel.DebugOutputViewModel.Append(mockDebugState.Object);
            //------------Precondition----------------------------
            //------------Execute Test---------------------------
            workSurfaceContextViewModel.Debug(null, false);
            //------------Assert Results-------------------------
            // NOTE: No Assert, purely for coverage
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory("WorkSurfaceContextViewModel_Debug")]
        public void WorkSurfaceContextViewModel_Debug_StopExecution()
        {
            //------------Setup for test--------------------------
            var workSurfaceContextViewModel = CreateWorkSurfaceContextViewModel();
            var mockDebugState = new Mock<IDebugState>();
            mockDebugState.Setup(state => state.StateType).Returns(StateType.All);
            mockDebugState.Setup(m => m.SessionID).Returns(workSurfaceContextViewModel.DebugOutputViewModel.SessionID);
            workSurfaceContextViewModel.DebugOutputViewModel.Append(mockDebugState.Object);
            //------------Precondition----------------------------
            //------------Execute Test---------------------------
            workSurfaceContextViewModel.StopExecution();
            //------------Assert Results-------------------------
            Assert.AreEqual(DebugStatus.Finished, workSurfaceContextViewModel.DebugOutputViewModel.DebugStatus);
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory("WorkSurfaceContextViewModel_Debug")]
        public void WorkSurfaceContextViewModel_Debug_ViewInBrowser_NullExpected()
        {
            //------------Setup for test--------------------------
            //var workSurfaceContextViewModel = CreateWorkSurfaceContextViewModel()
            var surfaceViewModel = new Mock<IWorkSurfaceViewModel>();
            var workSurfaceKey = new WorkSurfaceKey
            {
                WorkSurfaceContext = WorkSurfaceContext.Workflow
            };
            var surfaceContext = new Mock<WorkSurfaceContextViewModel>(workSurfaceKey, surfaceViewModel.Object);
            var mockEventAggregator = new Mock<IEventAggregator>();
            var workSurfaceContextViewModel = new WorkSurfaceContextViewModel(mockEventAggregator.Object, new WorkSurfaceKey(), surfaceViewModel.Object, new Mock<IPopupController>().Object, (a, b, c) => { });

            //------------Precondition----------------------------
            //------------Execute Test---------------------------
            workSurfaceContextViewModel.ViewInBrowser();
            //------------Assert Results-------------------------
            Assert.IsNull(workSurfaceContextViewModel.DebugOutputViewModel);
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory("WorkSurfaceContextViewModel_Debug")]
        public void WorkSurfaceContextViewModel_Debug_ViewInBrowser()
        {
            //------------Setup for test--------------------------
            //var workSurfaceContextViewModel = CreateWorkSurfaceContextViewModel()
            var surfaceViewModel = new Mock<IWorkSurfaceViewModel>();
            CustomContainer.Register(new Mock<IServerRepository>().Object);
            var workSurfaceKey = new WorkSurfaceKey
            {
                WorkSurfaceContext = WorkSurfaceContext.Workflow
            };
            var surfaceContext = new Mock<WorkSurfaceContextViewModel>(workSurfaceKey, surfaceViewModel.Object);
            var mockEventAggregator = new Mock<IEventAggregator>();
            var workSurfaceContextViewModel = new WorkSurfaceContextViewModel(mockEventAggregator.Object, new WorkSurfaceKey(), surfaceViewModel.Object, new Mock<IPopupController>().Object, (a, b, c) => { });
            workSurfaceContextViewModel.WorkSurfaceViewModel = WorkflowDesignerViewModelMock(true);
            //------------Precondition---------------------------
            //------------Execute Test---------------------------
            workSurfaceContextViewModel.ViewInBrowser();
            //------------Assert Results-------------------------
            // NOTE: No Assert, purely for coverage
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory("WorkSurfaceContextViewModel_Debug")]
        public void WorkSurfaceContextViewModel_Debug_QuickViewInBrowser()
        {
            //------------Setup for test--------------------------
            //var workSurfaceContextViewModel = CreateWorkSurfaceContextViewModel()
            var surfaceViewModel = new Mock<IWorkSurfaceViewModel>();
            CustomContainer.Register(new Mock<IServerRepository>().Object);
            var workSurfaceKey = new WorkSurfaceKey
            {
                WorkSurfaceContext = WorkSurfaceContext.Workflow
            };
            var surfaceContext = new Mock<WorkSurfaceContextViewModel>(workSurfaceKey, surfaceViewModel.Object);
            var mockEventAggregator = new Mock<IEventAggregator>();
            var workSurfaceContextViewModel = new WorkSurfaceContextViewModel(mockEventAggregator.Object, new WorkSurfaceKey(), surfaceViewModel.Object, new Mock<IPopupController>().Object, (a, b, c) => { });
            workSurfaceContextViewModel.WorkSurfaceViewModel = WorkflowDesignerViewModelMock(true);
            //------------Precondition---------------------------
            //------------Execute Test---------------------------
            workSurfaceContextViewModel.QuickViewInBrowser();
            //------------Assert Results-------------------------
            // NOTE: No Assert, purely for coverage
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory("WorkSurfaceContextViewModel_Debug")]
        public void WorkSurfaceContextViewModel_Debug_QuickDebug()
        {
            //------------Setup for test--------------------------
            //var workSurfaceContextViewModel = CreateWorkSurfaceContextViewModel()
            var surfaceViewModel = new Mock<IWorkSurfaceViewModel>();
            CustomContainer.Register(new Mock<IServerRepository>().Object);
            var workSurfaceKey = new WorkSurfaceKey
            {
                WorkSurfaceContext = WorkSurfaceContext.Workflow
            };
            var surfaceContext = new Mock<WorkSurfaceContextViewModel>(workSurfaceKey, surfaceViewModel.Object);
            var mockEventAggregator = new Mock<IEventAggregator>();
            var workSurfaceContextViewModel = new WorkSurfaceContextViewModel(mockEventAggregator.Object, new WorkSurfaceKey(), surfaceViewModel.Object, new Mock<IPopupController>().Object, (a, b, c) => { });
            workSurfaceContextViewModel.WorkSurfaceViewModel = WorkflowDesignerViewModelMock(true);
            workSurfaceContextViewModel.DebugOutputViewModel.DebugStatus = DebugStatus.Executing;
            //------------Precondition---------------------------
            //------------Execute Test---------------------------
            workSurfaceContextViewModel.QuickDebug();
            //------------Assert Results-------------------------
            Assert.AreEqual(DebugStatus.Finished, workSurfaceContextViewModel.DebugOutputViewModel.DebugStatus);
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory("WorkSurfaceContextViewModel_Debug")]
        public void WorkSurfaceContextViewModel_ShowSaveDialog()
        {
            //------------Setup for test--------------------------
            var surfaceViewModel = new Mock<IWorkSurfaceViewModel>();
            CustomContainer.Register(new Mock<IServerRepository>().Object);
            var workSurfaceKey = new WorkSurfaceKey
            {
                WorkSurfaceContext = WorkSurfaceContext.Workflow
            };
            var surfaceContext = new Mock<WorkSurfaceContextViewModel>(workSurfaceKey, surfaceViewModel.Object);
            var mockEventAggregator = new Mock<IEventAggregator>();
            var workSurfaceContextViewModel = new WorkSurfaceContextViewModel(mockEventAggregator.Object, new WorkSurfaceKey(), surfaceViewModel.Object, new Mock<IPopupController>().Object, (a, b, c) => { });
            workSurfaceContextViewModel.WorkSurfaceViewModel = WorkflowDesignerViewModelWithServerPermissionsMock(true);
            workSurfaceContextViewModel.DebugOutputViewModel.DebugStatus = DebugStatus.Executing;
            //------------Precondition---------------------------
            workSurfaceContextViewModel.ContextualResourceModel.Environment.Permissions = new List<IWindowsGroupPermission> { WindowsGroupPermission.CreateAdministrators() };

            //------------Execute Test---------------------------
            workSurfaceContextViewModel.ShowSaveDialog(workSurfaceContextViewModel.ContextualResourceModel, false);
            //------------Assert Results-------------------------
            // NOTE: No Assert, purely for coverage
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("WorkSurfaceContextViewModel_SetDebugStatus")]
        public void WorkSurfaceContextViewModel_SetDebugStatus_StatusConfigure_ClearsDebugOutputViewModel()
        {
            //------------Setup for test--------------------------
            var workSurfaceContextViewModel = CreateWorkSurfaceContextViewModel();
            var mockDebugState = new Mock<IDebugState>();
            mockDebugState.Setup(state => state.StateType).Returns(StateType.All);
            mockDebugState.Setup(m => m.SessionID).Returns(workSurfaceContextViewModel.DebugOutputViewModel.SessionID);
            workSurfaceContextViewModel.DebugOutputViewModel.Append(mockDebugState.Object);
            //------------Precondition----------------------------
            Assert.AreEqual(1, workSurfaceContextViewModel.DebugOutputViewModel.ContentItemCount);
            //------------Execute Test---------------------------
            workSurfaceContextViewModel.SetDebugStatus(DebugStatus.Configure);
            //------------Assert Results-------------------------
            Assert.AreEqual(1, workSurfaceContextViewModel.DebugOutputViewModel.ContentItemCount);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("WorkSurfaceContextViewModel_SetDebugStatus")]
        public void WorkSurfaceContextViewModel_SetDebugStatus_StatusFinished_DebugStatusFinished()
        {
            //------------Setup for test--------------------------
            var workSurfaceContextViewModel = CreateWorkSurfaceContextViewModel();
            workSurfaceContextViewModel.DebugOutputViewModel.DebugStatus = DebugStatus.Executing;
            //------------Execute Test---------------------------
            workSurfaceContextViewModel.SetDebugStatus(DebugStatus.Finished);
            //------------Assert Results-------------------------
            Assert.AreEqual(DebugStatus.Finished, workSurfaceContextViewModel.DebugOutputViewModel.DebugStatus);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("WorkSurfaceContextViewModel_IsEnvironmentConnected")]
        public void WorkSurfaceContextViewModel_IsEnvironmentConnected_WhenEnvironmentConnected_ReturnsTrue()
        {
            //------------Setup for test--------------------------
            var mockedConn = new Mock<IEnvironmentConnection>();
            mockedConn.Setup(conn => conn.ServerEvents).Returns(new Mock<IEventPublisher>().Object);

            var serverRepository = new Mock<IServerRepository>();
            CustomContainer.Register(serverRepository.Object);

            var mockEnvironmentModel = new Mock<IServer>();
            mockEnvironmentModel.Setup(model => model.Connection).Returns(mockedConn.Object);
            mockEnvironmentModel.Setup(model => model.IsConnected).Returns(true);
            var environmentModel = mockEnvironmentModel.Object;
            var workSurfaceContextViewModel = CreateWorkSurfaceContextViewModel(environmentModel, true);

            //------------Execute Test---------------------------
            var isEnvironmentConnected = workSurfaceContextViewModel.IsEnvironmentConnected();
            //------------Assert Results-------------------------
            Assert.IsTrue(isEnvironmentConnected);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("WorkSurfaceContextViewModel_IsEnvironmentConnected")]
        public void WorkSurfaceContextViewModel_IsEnvironmentConnected_WhenEnvironmentNotConnected_ReturnsFalse()
        {
            //------------Setup for test--------------------------
            var mockedConn = new Mock<IEnvironmentConnection>();
            mockedConn.Setup(conn => conn.ServerEvents).Returns(new Mock<IEventPublisher>().Object);

            var mockEnvironmentModel = new Mock<IServer>();
            mockEnvironmentModel.Setup(model => model.Connection).Returns(mockedConn.Object);
            mockEnvironmentModel.Setup(model => model.IsConnected).Returns(false);
            var environmentModel = mockEnvironmentModel.Object;
            var workSurfaceContextViewModel = CreateWorkSurfaceContextViewModel(environmentModel, false);

            //------------Execute Test---------------------------
            var isEnvironmentConnected = workSurfaceContextViewModel.IsEnvironmentConnected();
            //------------Assert Results-------------------------
            Assert.IsFalse(isEnvironmentConnected);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("WorkSurfaceContextViewModel_IsEnvironmentConnected")]
        public void WorkSurfaceContextViewModel_IsEnvironmentConnected_WhenEnvironmentNull_ReturnsFalse()
        {
            //------------Setup for test--------------------------
            var workSurfaceContextViewModel = CreateWorkSurfaceContextViewModel(null, false);

            //------------Execute Test---------------------------
            var isEnvironmentConnected = workSurfaceContextViewModel.IsEnvironmentConnected();
            //------------Assert Results-------------------------
            Assert.IsFalse(isEnvironmentConnected);
        }

        [TestMethod]
        [Owner("Ashley Lewis")]
        [TestCategory("WorkSurfaceContextViewModel_HandleUpdateDisplayName")]
        public void WorkSurfaceContextViewModel_HandleUpdateDisplayName_NewName_ContextualResourceModelNameChanged()
        {
            var WorksurfaceResourceID = Guid.NewGuid();
            const string newName = "RenamedResource";
            string actualNewName = null;
            var mockResourceModel = new Mock<IContextualResourceModel>();
            mockResourceModel.Setup(model => model.ID).Returns(WorksurfaceResourceID);
            mockResourceModel.SetupSet(model => model.ResourceName = It.IsAny<string>()).Callback<string>(value => { actualNewName = value; });
            var workSurfaceContextViewModel = CreateWorkSurfaceContextViewModel(null, true, mockResourceModel);
            workSurfaceContextViewModel.ContextualResourceModel.ID = WorksurfaceResourceID;
            //------------Execute Test---------------------------
            workSurfaceContextViewModel.Handle(new UpdateWorksurfaceDisplayName(WorksurfaceResourceID, "Worksurface Resource Name", newName));

            // Assert ContextualResourceModel Name Changed
            Assert.IsNotNull(actualNewName);
            Assert.AreEqual(actualNewName, newName, "Tab title not updated");
        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("WorkSurfaceContextViewModel_BindToModel")]
        public void WorkSurfaceContextViewModel_BindToModel_CallsBindToModelOnWorkSurfaceViewModel()
        {
            //------------Setup for test--------------------------
            var workSurfaceKey = new WorkSurfaceKey();
            var mockWorkSurfaceViewModel = new Mock<IWorkflowDesignerViewModel>();
            var mockedConn = new Mock<IEnvironmentConnection>();
            mockedConn.Setup(conn => conn.ServerEvents).Returns(new Mock<IEventPublisher>().Object);
            var mockEnvironmentModel = new Mock<IServer>();
            mockEnvironmentModel.Setup(model => model.Connection).Returns(mockedConn.Object);
            var environmentModel = mockEnvironmentModel.Object;
            mockWorkSurfaceViewModel.Setup(model => model.Server).Returns(environmentModel);
            mockWorkSurfaceViewModel.Setup(m => m.BindToModel()).Verifiable();
            var workSurfaceViewModel = mockWorkSurfaceViewModel.As<IWorkSurfaceViewModel>();
            var workSurfaceContextViewModel = new WorkSurfaceContextViewModel(new Mock<IEventAggregator>().Object, workSurfaceKey, workSurfaceViewModel.Object, new Mock<IPopupController>().Object, (a, b, c) => { });
            //------------Execute Test---------------------------
            workSurfaceContextViewModel.BindToModel();
            //------------Assert---------------------------------
            mockWorkSurfaceViewModel.Verify(m => m.BindToModel(), Times.Once());
        }


        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("WorkSurfaceContextViewModel_CanDebug")]
        public void WorkSurfaceContextViewModel_CanDebug_ExpectTrue()
        {
            var explorerTooltips = new Mock<IExplorerTooltips>();
            CustomContainer.Register(explorerTooltips.Object);
            var serverRepository = new Mock<IServerRepository>();
            CustomContainer.Register(serverRepository.Object);
            //------------Setup for test--------------------------
            var workSurfaceKey = new WorkSurfaceKey();
            var mockWorkSurfaceViewModel = new Mock<IWorkflowDesignerViewModel>();
            var mockedConn = new Mock<IEnvironmentConnection>();
            mockedConn.Setup(conn => conn.ServerEvents).Returns(new Mock<IEventPublisher>().Object);
            var mockEnvironmentModel = new Mock<IServer>();
            mockEnvironmentModel.Setup(model => model.Connection).Returns(mockedConn.Object);
            var environmentModel = mockEnvironmentModel.Object;
            mockWorkSurfaceViewModel.Setup(model => model.Server).Returns(environmentModel);
            mockWorkSurfaceViewModel.Setup(m => m.BindToModel()).Verifiable();

            var viewModel = WorkflowDesignerViewModelMock(true);

            var workSurfaceContextViewModel = new WorkSurfaceContextViewModel(new Mock<IEventAggregator>().Object, workSurfaceKey, viewModel, new Mock<IPopupController>().Object, (a, b, c) => { });

            workSurfaceContextViewModel.WorkSurfaceViewModel = new WorkSurfaceViewModelTest();
            workSurfaceContextViewModel.DebugOutputViewModel = viewModel.DebugOutputViewModel;
            //------------Execute Test---------------------------
            Assert.IsTrue(workSurfaceContextViewModel.CanDebug());
        }


        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("WorkSurfaceContextViewModel_CanDebug")]
        public void WorkSurfaceContextViewModel_CanSave_ExpectTrue()
        {
            //------------Setup for test--------------------------
            var workSurfaceKey = new WorkSurfaceKey();
            var mockWorkSurfaceViewModel = new Mock<IWorkflowDesignerViewModel>();
            var mockedConn = new Mock<IEnvironmentConnection>();
            mockedConn.Setup(conn => conn.ServerEvents).Returns(new Mock<IEventPublisher>().Object);
            var mockEnvironmentModel = new Mock<IServer>();
            mockEnvironmentModel.Setup(model => model.Connection).Returns(mockedConn.Object);
            var environmentModel = mockEnvironmentModel.Object;
            mockWorkSurfaceViewModel.Setup(model => model.Server).Returns(environmentModel);
            mockWorkSurfaceViewModel.Setup(m => m.BindToModel()).Verifiable();

            var viewModel = WorkflowDesignerViewModelMock(true);

            var workSurfaceContextViewModel = new WorkSurfaceContextViewModel(new Mock<IEventAggregator>().Object, workSurfaceKey, viewModel, new Mock<IPopupController>().Object, (a, b, c) => { });

            workSurfaceContextViewModel.WorkSurfaceViewModel = new WorkSurfaceViewModelTest();
            workSurfaceContextViewModel.DebugOutputViewModel = viewModel.DebugOutputViewModel;
            //------------Execute Test---------------------------
            Assert.IsTrue(workSurfaceContextViewModel.CanSave());
        }



        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("WorkSurfaceContextViewModel_CanDebug")]
        public void WorkSurfaceContextViewModel_CanExecute_ExpectTrue()
        {
            //------------Setup for test--------------------------
            var workSurfaceKey = new WorkSurfaceKey();
            var mockWorkSurfaceViewModel = new Mock<IWorkflowDesignerViewModel>();
            var mockedConn = new Mock<IEnvironmentConnection>();
            mockedConn.Setup(conn => conn.ServerEvents).Returns(new Mock<IEventPublisher>().Object);
            var mockEnvironmentModel = new Mock<IServer>();
            mockEnvironmentModel.Setup(model => model.Connection).Returns(mockedConn.Object);
            var environmentModel = mockEnvironmentModel.Object;
            mockWorkSurfaceViewModel.Setup(model => model.Server).Returns(environmentModel);
            mockWorkSurfaceViewModel.Setup(m => m.BindToModel()).Verifiable();
            var viewModel = WorkflowDesignerViewModelMock(true);
            var workSurfaceContextViewModel = new WorkSurfaceContextViewModel(new Mock<IEventAggregator>().Object, workSurfaceKey, viewModel, new Mock<IPopupController>().Object, (a, b, c) => { }) { WorkSurfaceViewModel = new WorkSurfaceViewModelTest() };
            workSurfaceContextViewModel.DebugOutputViewModel = viewModel.DebugOutputViewModel;
            //------------Execute Test---------------------------
            Assert.IsTrue(workSurfaceContextViewModel.CanExecute());
        }


        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("WorkSurfaceContextViewModel_CanDebug")]
        public void WorkSurfaceContextViewModel_CanViewInBrowser_ExpectTrue()
        {
            //------------Setup for test--------------------------
            var workSurfaceKey = new WorkSurfaceKey();
            var mockWorkSurfaceViewModel = new Mock<IWorkflowDesignerViewModel>();
            var mockedConn = new Mock<IEnvironmentConnection>();
            mockedConn.Setup(conn => conn.ServerEvents).Returns(new Mock<IEventPublisher>().Object);
            var mockEnvironmentModel = new Mock<IServer>();
            mockEnvironmentModel.Setup(model => model.Connection).Returns(mockedConn.Object);
            var environmentModel = mockEnvironmentModel.Object;
            mockWorkSurfaceViewModel.Setup(model => model.Server).Returns(environmentModel);
            mockWorkSurfaceViewModel.Setup(m => m.BindToModel()).Verifiable();
            var serverRepository = new Mock<IServerRepository>();
            CustomContainer.Register(serverRepository.Object);
            var viewModel = WorkflowDesignerViewModelMock(true);
            var workSurfaceContextViewModel = new WorkSurfaceContextViewModel(new Mock<IEventAggregator>().Object, workSurfaceKey, viewModel, new Mock<IPopupController>().Object, (a, b, c) => { }) { WorkSurfaceViewModel = new WorkSurfaceViewModelTest() };
            workSurfaceContextViewModel.DebugOutputViewModel = viewModel.DebugOutputViewModel;
            //------------Execute Test---------------------------
            Assert.IsTrue(workSurfaceContextViewModel.CanViewInBrowser());
        }


        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("WorkSurfaceContextViewModel_Save")]
        public void WorkSurfaceContextViewModel_SaveCallsCheckForServerMessages()
        {
            //------------Setup for test--------------------------
            var workSurfaceKey = new WorkSurfaceKey();
            var mockWorkSurfaceViewModel = new Mock<IWorkflowDesignerViewModel>();
            var mockedConn = new Mock<IEnvironmentConnection>();
            mockedConn.Setup(conn => conn.ServerEvents).Returns(new Mock<IEventPublisher>().Object);
            var mockEnvironmentModel = new Mock<IServer>();
            mockEnvironmentModel.Setup(model => model.Connection).Returns(mockedConn.Object);
            mockEnvironmentModel.SetupGet(p => p.IsConnected).Returns(true);
            var mockRepository = new Mock<IResourceRepository>();
            mockRepository.Setup(c => c.FetchResourceDefinition(It.IsAny<IServer>(), It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<bool>())).Returns(new ExecuteMessage());
            mockRepository.Setup(m => m.Save(It.IsAny<IResourceModel>())).Verifiable();
            mockRepository.Setup(c => c.SaveToServer(It.IsAny<IResourceModel>(), It.IsAny<string>())).Returns(new ExecuteMessage());
            mockEnvironmentModel.SetupGet(p => p.ResourceRepository).Returns(mockRepository.Object);
            var environmentModel = mockEnvironmentModel.Object;
            mockWorkSurfaceViewModel.Setup(model => model.Server).Returns(environmentModel);
            mockWorkSurfaceViewModel.Setup(m => m.BindToModel()).Verifiable();
            var workSurfaceViewModel = mockWorkSurfaceViewModel.As<IWorkSurfaceViewModel>();
            var workSurfaceContextViewModel = new WorkSurfaceContextViewModel(new Mock<IEventAggregator>().Object, workSurfaceKey, workSurfaceViewModel.Object, new Mock<IPopupController>().Object, (a, b, c) => { });
            var mockResourceModel = new Mock<IContextualResourceModel>();
            mockResourceModel.SetupGet(p => p.Environment).Returns(environmentModel);
            mockResourceModel.Setup(m => m.UserPermissions).Returns(Permissions.Contribute);
            //------------Execute Test---------------------------
            var mockShellViewModel = new Mock<IShellViewModel>();
            mockShellViewModel.Setup(shellViewModel => shellViewModel.ActiveServer).Returns(mockEnvironmentModel.Object);
            CustomContainer.Register(mockShellViewModel.Object);
            workSurfaceContextViewModel.Handle(new SaveResourceMessage(mockResourceModel.Object, false, false));
        }



        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("WorkSurfaceContextViewModel_Save")]
        public void WorkSurfaceContextViewModel_SaveCallsCheckForServerMessages_NoMessagesAvailable_NothingHappen()
        {
            //------------Setup for test--------------------------
            var workSurfaceKey = new WorkSurfaceKey();
            var mockWorkSurfaceViewModel = new Mock<IWorkflowDesignerViewModel>();
            var mockedConn = new Mock<IEnvironmentConnection>();
            mockedConn.Setup(conn => conn.ServerEvents).Returns(new Mock<IEventPublisher>().Object);
            var mockEnvironmentModel = new Mock<IServer>();
            mockEnvironmentModel.Setup(model => model.Connection).Returns(mockedConn.Object);
            mockEnvironmentModel.SetupGet(p => p.IsConnected).Returns(true);
            var mockRepository = new Mock<IResourceRepository>();
            mockRepository.Setup(c => c.FetchResourceDefinition(It.IsAny<IServer>(), It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<bool>())).Returns(new ExecuteMessage());
            mockRepository.Setup(m => m.Save(It.IsAny<IResourceModel>())).Verifiable();
            mockRepository.Setup(c => c.SaveToServer(It.IsAny<IResourceModel>(), It.IsAny<string>())).Returns(new ExecuteMessage());
            mockEnvironmentModel.SetupGet(p => p.ResourceRepository).Returns(mockRepository.Object);
            var environmentModel = mockEnvironmentModel.Object;
            mockWorkSurfaceViewModel.Setup(model => model.Server).Returns(environmentModel);
            mockWorkSurfaceViewModel.Setup(m => m.BindToModel()).Verifiable();
            var workSurfaceViewModel = mockWorkSurfaceViewModel.As<IWorkSurfaceViewModel>();

            // object to work on 
            var workSurfaceContextViewModel = new WorkSurfaceContextViewModel(new Mock<IEventAggregator>().Object, workSurfaceKey, workSurfaceViewModel.Object, new Mock<IPopupController>().Object, (a, b, c) => { });

            var mr = new Mock<IStudioCompileMessageRepo>();
            mr.Setup(a => a.GetCompileMessagesFromServer(It.IsAny<IContextualResourceModel>())).Returns(new CompileMessageList());
            var resourceChangedFactory = new Mock<IResourceChangeHandlerFactory>();
            var rsHandler = new Mock<IResourceChangeHandler>();
            resourceChangedFactory.Setup(a => a.Create(new Mock<IEventAggregator>().Object)).Returns(rsHandler.Object);
            workSurfaceContextViewModel.ResourceChangeHandlerFactory = resourceChangedFactory.Object;

            var mockResourceModel = new Mock<IContextualResourceModel>();
            mockResourceModel.SetupGet(p => p.Environment).Returns(environmentModel);
            mockResourceModel.Setup(m => m.UserPermissions).Returns(Permissions.Contribute);
            var mockShellViewModel = new Mock<IShellViewModel>();
            mockShellViewModel.Setup(shellViewModel => shellViewModel.ActiveServer).Returns(mockEnvironmentModel.Object);
            CustomContainer.Register(mockShellViewModel.Object);
            //------------Execute Test---------------------------

            workSurfaceContextViewModel.Handle(new SaveResourceMessage(mockResourceModel.Object, false, false));
            rsHandler.Verify(a => a.ShowResourceChanged(It.IsAny<IContextualResourceModel>(), It.IsAny<IList<string>>(), null), Times.Never());
        }

        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("WorkSurfaceContextViewModel_Save")]
        public void WorkSurfaceContextViewModel_SaveCallsCheckForServerMessages_MessagesAvailable_SuffHappens()
        {
            //------------Setup for test--------------------------
            var workSurfaceKey = new WorkSurfaceKey();
            var mockWorkSurfaceViewModel = new Mock<IWorkflowDesignerViewModel>();
            var mockedConn = new Mock<IEnvironmentConnection>();
            mockedConn.Setup(conn => conn.ServerEvents).Returns(new Mock<IEventPublisher>().Object);
            var mockEnvironmentModel = new Mock<IServer>();
            mockEnvironmentModel.Setup(model => model.Connection).Returns(mockedConn.Object);
            mockEnvironmentModel.SetupGet(p => p.IsConnected).Returns(true);
            var mockRepository = new Mock<IResourceRepository>();
            mockRepository.Setup(c => c.FetchResourceDefinition(It.IsAny<IServer>(), It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<bool>())).Returns(new ExecuteMessage());
            mockRepository.Setup(m => m.Save(It.IsAny<IResourceModel>())).Verifiable();
            mockRepository.Setup(c => c.SaveToServer(It.IsAny<IResourceModel>(), It.IsAny<string>())).Returns(new ExecuteMessage());
            mockEnvironmentModel.SetupGet(p => p.ResourceRepository).Returns(mockRepository.Object);
            var environmentModel = mockEnvironmentModel.Object;
            mockWorkSurfaceViewModel.Setup(model => model.Server).Returns(environmentModel);
            mockWorkSurfaceViewModel.Setup(m => m.BindToModel()).Verifiable();
            var workSurfaceViewModel = mockWorkSurfaceViewModel.As<IWorkSurfaceViewModel>();

            // object to work on 
            var workSurfaceContextViewModel = new WorkSurfaceContextViewModel(new Mock<IEventAggregator>().Object, workSurfaceKey, workSurfaceViewModel.Object, new Mock<IPopupController>().Object, (a, b, c) => { });

            var lst = new CompileMessageList { MessageList = new List<ICompileMessageTO> { new CompileMessageTO() } };
            var mr = new Mock<IStudioCompileMessageRepo>();
            mr.Setup(a => a.GetCompileMessagesFromServer(It.IsAny<IContextualResourceModel>())).Returns(lst);
            var resourceChangedFactory = new Mock<IResourceChangeHandlerFactory>();
            var rsHandler = new Mock<IResourceChangeHandler>();
            resourceChangedFactory.Setup(a => a.Create(It.IsAny<IEventAggregator>())).Returns(rsHandler.Object);
            workSurfaceContextViewModel.ResourceChangeHandlerFactory = resourceChangedFactory.Object;

            var mockResourceModel = new Mock<IContextualResourceModel>();
            mockResourceModel.SetupGet(p => p.Environment).Returns(environmentModel);
            mockResourceModel.Setup(m => m.UserPermissions).Returns(Permissions.Contribute);
            var mockShellViewModel = new Mock<IShellViewModel>();
            mockShellViewModel.Setup(shellViewModel => shellViewModel.ActiveServer).Returns(mockEnvironmentModel.Object);
            CustomContainer.Register(mockShellViewModel.Object);
            //------------Execute Test---------------------------

            workSurfaceContextViewModel.Handle(new SaveResourceMessage(mockResourceModel.Object, false, false));
        }
        
        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("WorkSurfaceContextViewModel_GetServiceInputDataFromUser")]
        public void WorkSurfaceContextViewModel_GetServiceInputDataFromUser()
        {
            //------------Setup for test--------------------------
            var mockWorkSurfaceViewModel = new Mock<IWorkflowDesignerViewModel>();
            var mockedConn = new Mock<IEnvironmentConnection>();
            mockedConn.Setup(conn => conn.ServerEvents).Returns(new Mock<IEventPublisher>().Object);
            var mockEnvironmentModel = new Mock<IServer>();
            mockEnvironmentModel.Setup(model => model.Connection).Returns(mockedConn.Object);
            var environmentModel = mockEnvironmentModel.Object;
            mockWorkSurfaceViewModel.Setup(model => model.Server).Returns(environmentModel);
            mockWorkSurfaceViewModel.Setup(m => m.BindToModel()).Verifiable();
            //------------Execute Test---------------------------
            var mockServiceDebugInfoModel = new Mock<IServiceDebugInfoModel>();
            mockServiceDebugInfoModel.SetupGet(p => p.ServiceInputData).Returns(It.IsAny<string>);
            mockServiceDebugInfoModel.SetupGet(p => p.RememberInputs).Returns(It.IsAny<bool>);
            var mockResourceModel = new Mock<IContextualResourceModel>();
            mockResourceModel.SetupGet(p => p.DataList).Returns(It.IsAny<string>);
            mockResourceModel.SetupGet(p => p.ResourceName).Returns(It.IsAny<string>);
            mockResourceModel.SetupGet(p => p.WorkflowXaml).Returns(It.IsAny<StringBuilder>);
            mockResourceModel.SetupGet(p => p.ID).Returns(It.IsAny<Guid>);
            mockResourceModel.SetupGet(p => p.ServerID).Returns(It.IsAny<Guid>);
            mockServiceDebugInfoModel.SetupGet(p => p.ResourceModel).Returns(mockResourceModel.Object);
        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("WorkSurfaceContextViewModel_Handle")]
        public void WorkSurfaceContextViewModel_Handle_SaveResourceMessage_CallsBindModelAndSave()
        {
            //------------Setup for test--------------------------
            var workSurfaceKey = new WorkSurfaceKey();
            var mockWorkSurfaceViewModel = new Mock<IWorkflowDesignerViewModel>();
            var mockedConn = new Mock<IEnvironmentConnection>();
            mockedConn.Setup(conn => conn.ServerEvents).Returns(new Mock<IEventPublisher>().Object);
            var mockEnvironmentModel = new Mock<IServer>();
            mockEnvironmentModel.Setup(model => model.Connection).Returns(mockedConn.Object);
            mockEnvironmentModel.SetupGet(p => p.IsConnected).Returns(true);
            var mockRepository = new Mock<IResourceRepository>();
            mockRepository.Setup(c => c.FetchResourceDefinition(It.IsAny<IServer>(), It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<bool>())).Returns(new ExecuteMessage());
            mockRepository.Setup(m => m.Save(It.IsAny<IResourceModel>())).Verifiable();
            mockRepository.Setup(c => c.SaveToServer(It.IsAny<IResourceModel>(), It.IsAny<string>())).Returns(new ExecuteMessage());
            mockEnvironmentModel.SetupGet(p => p.ResourceRepository).Returns(mockRepository.Object);
            var environmentModel = mockEnvironmentModel.Object;
            mockWorkSurfaceViewModel.Setup(model => model.Server).Returns(environmentModel);
            mockWorkSurfaceViewModel.Setup(m => m.BindToModel()).Verifiable();
            var workSurfaceViewModel = mockWorkSurfaceViewModel.As<IWorkSurfaceViewModel>();
            var workSurfaceContextViewModel = new WorkSurfaceContextViewModel(new Mock<IEventAggregator>().Object, workSurfaceKey, workSurfaceViewModel.Object, new Mock<IPopupController>().Object, (a, b, c) => { });
            var mockResourceModel = new Mock<IContextualResourceModel>();
            mockResourceModel.SetupGet(p => p.Environment).Returns(environmentModel);
            mockResourceModel.Setup(m => m.UserPermissions).Returns(Permissions.Contribute);
            var mockShellViewModel = new Mock<IShellViewModel>();
            mockShellViewModel.Setup(shellViewModel => shellViewModel.ActiveServer).Returns(mockEnvironmentModel.Object);
            CustomContainer.Register(mockShellViewModel.Object);
            //------------Execute Test---------------------------
            workSurfaceContextViewModel.Handle(new SaveResourceMessage(mockResourceModel.Object, false, false));
            //------------Assert---------------------------------
            mockWorkSurfaceViewModel.Verify(m => m.BindToModel(), Times.Once());
            mockRepository.Verify(m => m.SaveToServer(It.IsAny<IResourceModel>()), Times.Once());
        }
        
        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("WorkSurfaceContextViewModel_Handle")]
        public void WorkSurfaceContextViewModel_Handle_Save_InvalidXml_CausesPopup()
        {
            //------------Setup for test--------------------------
            var workSurfaceKey = new WorkSurfaceKey();
            var mockWorkSurfaceViewModel = new Mock<IWorkflowDesignerViewModel>();
            var mockedConn = new Mock<IEnvironmentConnection>();
            mockedConn.Setup(conn => conn.ServerEvents).Returns(new Mock<IEventPublisher>().Object);
            var mockEnvironmentModel = new Mock<IServer>();
            mockEnvironmentModel.Setup(model => model.Connection).Returns(mockedConn.Object);
            mockEnvironmentModel.SetupGet(p => p.IsConnected).Returns(true);
            var mockRepository = new Mock<IResourceRepository>();
            mockRepository.Setup(c => c.FetchResourceDefinition(It.IsAny<IServer>(), It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<bool>())).Returns(new ExecuteMessage());
            mockRepository.Setup(m => m.Save(It.IsAny<IResourceModel>())).Verifiable();
            mockRepository.Setup(c => c.SaveToServer(It.IsAny<IResourceModel>(), It.IsAny<string>())).Returns(new ExecuteMessage());
            mockEnvironmentModel.SetupGet(p => p.ResourceRepository).Returns(mockRepository.Object);
            var environmentModel = mockEnvironmentModel.Object;
            mockWorkSurfaceViewModel.Setup(model => model.Server).Returns(environmentModel);
            mockWorkSurfaceViewModel.Setup(m => m.BindToModel()).Verifiable();
            var workSurfaceViewModel = mockWorkSurfaceViewModel.As<IWorkSurfaceViewModel>();
            var popup = new Mock<IPopupController>();
            var workSurfaceContextViewModel = new WorkSurfaceContextViewModel(new Mock<IEventAggregator>().Object, workSurfaceKey, workSurfaceViewModel.Object, popup.Object, (a, b, c) => { });
            var mockResourceModel = new Mock<IContextualResourceModel>();
            mockResourceModel.SetupGet(p => p.Environment).Returns(environmentModel);
            mockResourceModel.Setup(m => m.UserPermissions).Returns(Permissions.Contribute);
            var dlvm = new Mock<IDataListViewModel>();
            dlvm.Setup(a => a.HasErrors).Returns(true);
            workSurfaceContextViewModel.DataListViewModel = dlvm.Object;
            //------------Execute Test---------------------------
            workSurfaceContextViewModel.Handle(new SaveResourceMessage(mockResourceModel.Object, false, false));
            //------------Assert---------------------------------
            popup.Verify(a => a.Show(It.IsAny<string>(), "Error Saving", MessageBoxButton.OK, MessageBoxImage.Error, "", false, true, false, false, false, false));
        }



        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("WorkSurfaceContextViewModel_Handle")]
        public void WorkSurfaceContextViewModel_Handle_Save_IsNewWF_CausesWebPopup()
        {
            //------------Setup for test--------------------------
            var workSurfaceKey = new WorkSurfaceKey();
            var mockWorkSurfaceViewModel = new Mock<IWorkflowDesignerViewModel>();
            var mockedConn = new Mock<IEnvironmentConnection>();
            mockedConn.Setup(conn => conn.ServerEvents).Returns(new Mock<IEventPublisher>().Object);
            var mockEnvironmentModel = new Mock<IServer>();
            mockEnvironmentModel.Setup(model => model.Connection).Returns(mockedConn.Object);
            mockEnvironmentModel.SetupGet(p => p.IsConnected).Returns(true);
            var mockRepository = new Mock<IResourceRepository>();
            mockRepository.Setup(c => c.FetchResourceDefinition(It.IsAny<IServer>(), It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<bool>())).Returns(new ExecuteMessage());
            mockRepository.Setup(m => m.Save(It.IsAny<IResourceModel>())).Verifiable();
            mockRepository.Setup(c => c.SaveToServer(It.IsAny<IResourceModel>(), It.IsAny<string>())).Returns(new ExecuteMessage());
            mockEnvironmentModel.SetupGet(p => p.ResourceRepository).Returns(mockRepository.Object);
            var environmentModel = mockEnvironmentModel.Object;
            mockWorkSurfaceViewModel.Setup(model => model.Server).Returns(environmentModel);
            mockWorkSurfaceViewModel.Setup(m => m.BindToModel()).Verifiable();
            var workSurfaceViewModel = mockWorkSurfaceViewModel.As<IWorkSurfaceViewModel>();
            var popup = new Mock<IPopupController>();
            var called = false;

            var workSurfaceContextViewModel = new WorkSurfaceContextViewModel(new Mock<IEventAggregator>().Object, workSurfaceKey, workSurfaceViewModel.Object, popup.Object, (a, b, c) => { called = true; });
            var mockResourceModel = new Mock<IContextualResourceModel>();
            mockResourceModel.SetupGet(p => p.Environment).Returns(environmentModel);
            mockResourceModel.Setup(m => m.UserPermissions).Returns(Permissions.Contribute);
            var dlvm = new Mock<IDataListViewModel>();
            dlvm.Setup(a => a.HasErrors).Returns(false);
            workSurfaceContextViewModel.DataListViewModel = dlvm.Object;
            mockResourceModel.Setup(a => a.IsNewWorkflow).Returns(true);
            //------------Execute Test---------------------------
            workSurfaceContextViewModel.Handle(new SaveResourceMessage(mockResourceModel.Object, false, false));
            //------------Assert---------------------------------
            Assert.IsTrue(called);
        }
        
        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("WorkSurfaceContextViewModel_Handle")]
        public void WorkSurfaceContextViewModel_Handle_Save_WhenContextualResourceModelIsNotNull()
        {
            //------------Setup for test--------------------------
            var workSurfaceKey = new WorkSurfaceKey();
            var mockWorkSurfaceViewModel = new Mock<IWorkflowDesignerViewModel>();
            var mockedConn = new Mock<IEnvironmentConnection>();
            mockedConn.Setup(conn => conn.ServerEvents).Returns(new Mock<IEventPublisher>().Object);
            var mockEnvironmentModel = new Mock<IServer>();
            mockEnvironmentModel.Setup(model => model.Connection).Returns(mockedConn.Object);
            mockEnvironmentModel.SetupGet(p => p.IsConnected).Returns(true);
            var mockRepository = new Mock<IResourceRepository>();
            mockRepository.Setup(c => c.FetchResourceDefinition(It.IsAny<IServer>(), It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<bool>())).Returns(new ExecuteMessage());
            mockRepository.Setup(m => m.Save(It.IsAny<IResourceModel>())).Verifiable();
            mockRepository.Setup(c => c.SaveToServer(It.IsAny<IResourceModel>(), It.IsAny<string>())).Returns(new ExecuteMessage());
            mockEnvironmentModel.SetupGet(p => p.ResourceRepository).Returns(mockRepository.Object);
            var environmentModel = mockEnvironmentModel.Object;
            mockWorkSurfaceViewModel.Setup(model => model.Server).Returns(environmentModel);
            mockWorkSurfaceViewModel.Setup(m => m.BindToModel()).Verifiable();
            var workSurfaceViewModel = mockWorkSurfaceViewModel.As<IWorkSurfaceViewModel>();
            var popup = new Mock<IPopupController>();
            var called = false;
            var mockResourceModel = new Mock<IContextualResourceModel>();
            mockResourceModel.SetupGet(p => p.Environment).Returns(environmentModel);
            mockResourceModel.Setup(m => m.UserPermissions).Returns(Permissions.Contribute);
            var workSurfaceContextViewModel = new WorkSurfaceContextViewModel(new Mock<IEventAggregator>().Object, workSurfaceKey, workSurfaceViewModel.Object, popup.Object, (a, b, c) => { called = true; });

            mockWorkSurfaceViewModel.Setup(a => a.ResourceModel).Returns(mockResourceModel.Object);
            workSurfaceContextViewModel.WorkSurfaceViewModel = new WorkSurfaceViewModelTest();

            var dlvm = new Mock<IDataListViewModel>();
            dlvm.Setup(a => a.HasErrors).Returns(false);
            workSurfaceContextViewModel.DataListViewModel = dlvm.Object;
            mockResourceModel.Setup(a => a.IsNewWorkflow).Returns(true);
            //------------Execute Test---------------------------
            workSurfaceContextViewModel.Handle(new SaveResourceMessage(mockResourceModel.Object, false, false));
            //------------Assert---------------------------------
            Assert.IsTrue(called);
        }
        
        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("WorkSurfaceContextViewModel_Dispose")]
        public void WorkSurfaceContextViewModel_Dispose_ExpectObjectsCleanedUp()
        {
            //------------Setup for test--------------------------
            var workSurfaceKey = new WorkSurfaceKey();
            var mockWorkSurfaceViewModel = new Mock<IWorkflowDesignerViewModel>();
            var mockedConn = new Mock<IEnvironmentConnection>();
            mockedConn.Setup(conn => conn.ServerEvents).Returns(new Mock<IEventPublisher>().Object);
            var mockEnvironmentModel = new Mock<IServer>();
            mockEnvironmentModel.Setup(model => model.Connection).Returns(mockedConn.Object);
            mockEnvironmentModel.SetupGet(p => p.IsConnected).Returns(true);
            var mockRepository = new Mock<IResourceRepository>();
            mockRepository.Setup(c => c.FetchResourceDefinition(It.IsAny<IServer>(), It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<bool>())).Returns(new ExecuteMessage());
            mockRepository.Setup(m => m.Save(It.IsAny<IResourceModel>())).Verifiable();
            mockRepository.Setup(c => c.SaveToServer(It.IsAny<IResourceModel>(), It.IsAny<string>())).Returns(new ExecuteMessage());
            mockEnvironmentModel.SetupGet(p => p.ResourceRepository).Returns(mockRepository.Object);
            var environmentModel = mockEnvironmentModel.Object;
            mockWorkSurfaceViewModel.Setup(model => model.Server).Returns(environmentModel);
            mockWorkSurfaceViewModel.Setup(m => m.BindToModel()).Verifiable();
            var workSurfaceViewModel = mockWorkSurfaceViewModel.As<IWorkSurfaceViewModel>();
            var popup = new Mock<IPopupController>();

            var workSurfaceContextViewModel = new WorkSurfaceContextViewModel(new Mock<IEventAggregator>().Object, workSurfaceKey, workSurfaceViewModel.Object, popup.Object, (a, b, c) => { });
            var mockResourceModel = new Mock<IContextualResourceModel>();
            mockResourceModel.SetupGet(p => p.Environment).Returns(environmentModel);
            mockResourceModel.Setup(m => m.UserPermissions).Returns(Permissions.Contribute);
            var dlvm = new Mock<IDataListViewModel>();
            dlvm.Setup(a => a.HasErrors).Returns(false);
            workSurfaceContextViewModel.DataListViewModel = dlvm.Object;
            mockResourceModel.Setup(a => a.IsNewWorkflow).Returns(true);
            //------------Execute Test---------------------------
            workSurfaceContextViewModel.Dispose();
            Assert.IsTrue(workSurfaceContextViewModel.IsDisposed);
        }

        static WorkSurfaceContextViewModel CreateWorkSurfaceContextViewModel(IServer server, bool isConnected, Mock<IContextualResourceModel> ResourceModel = null)
        {
            var workSurfaceKey = new WorkSurfaceKey();
            var mockResourceModel = ResourceModel ?? new Mock<IContextualResourceModel>();
            mockResourceModel.Setup(model => model.Environment).Returns(server);

            var viewModel = WorkflowDesignerViewModelMock(isConnected, mockResourceModel);

            var workSurfaceContextViewModel = new WorkSurfaceContextViewModel(new Mock<IEventAggregator>().Object, workSurfaceKey, viewModel, new Mock<IPopupController>().Object, (a, b, c) => { });
            return workSurfaceContextViewModel;
        }

        static WorkSurfaceContextViewModel CreateWorkSurfaceContextViewModel()
        {
            var mockedConn = new Mock<IEnvironmentConnection>();
            mockedConn.Setup(conn => conn.ServerEvents).Returns(new Mock<IEventPublisher>().Object);

            CommonSetupHelper.RegisterServerRepository();

            var mockEnvironmentModel = new Mock<IServer>();
            mockEnvironmentModel.Setup(model => model.Connection).Returns(mockedConn.Object);

            var environmentModel = mockEnvironmentModel.Object;
            return CreateWorkSurfaceContextViewModel(environmentModel, true);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("WorkSurfaceContextViewModel_DebugCommand")]
        public void WorkSurfaceContextViewModel_DebugCommand_UserHasAdministratorPermissions_CanExecuteIsTrue()
        {
            Verify_DebugCommand_CanExecute(Permissions.Administrator, true);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("WorkSurfaceContextViewModel_DebugCommand")]
        public void WorkSurfaceContextViewModel_DebugCommand_UserHasContributePermissions_CanExecuteIsTrue()
        {
            Verify_DebugCommand_CanExecute(Permissions.Contribute, true);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("WorkSurfaceContextViewModel_DebugCommand")]
        public void WorkSurfaceContextViewModel_DebugCommand_UserHasViewAndExecutePermissions_CanExecuteIsTrue()
        {
            Verify_DebugCommand_CanExecute(Permissions.View | Permissions.Execute, true);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("WorkSurfaceContextViewModel_DebugCommand")]
        public void WorkSurfaceContextViewModel_DebugCommand_UserHasViewPermissions_CanExecuteIsFalse()
        {
            Verify_DebugCommand_CanExecute(Permissions.View, false);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("WorkSurfaceContextViewModel_DebugCommand")]
        public void WorkSurfaceContextViewModel_DebugCommand_UserHasExecutePermissions_CanExecuteIsFalse()
        {
            Verify_DebugCommand_CanExecute(Permissions.Execute, false);
        }

        void Verify_DebugCommand_CanExecute(Permissions userPermissions, bool expected)
        {
            //------------Setup for test--------------------------
            var workSurfaceContextViewModel = CreateWorkSurfaceContextViewModel(userPermissions);

            //------------Execute Test---------------------------
            var actualDebug = workSurfaceContextViewModel.DebugCommand.CanExecute(null);
            var actualQuickDebug = workSurfaceContextViewModel.QuickDebugCommand.CanExecute(null);

            //------------Assert Results-------------------------
            Assert.AreEqual(expected, actualDebug);
            Assert.AreEqual(expected, actualQuickDebug);
        }

        static WorkSurfaceContextViewModel CreateWorkSurfaceContextViewModel(Permissions userPermissions)
        {

            var mockedConn = new Mock<IEnvironmentConnection>();
            mockedConn.Setup(conn => conn.ServerEvents).Returns(new Mock<IEventPublisher>().Object);

            var authService = new Mock<IAuthorizationService>();
            authService.Setup(s => s.IsAuthorized(It.IsAny<AuthorizationContext>(), It.IsAny<string>())).Returns(true);

            var serverRepository = new Mock<IServerRepository>();
            CustomContainer.Register(serverRepository.Object);

            var mockEnvironmentModel = new Mock<IServer>();
            mockEnvironmentModel.Setup(model => model.Connection).Returns(mockedConn.Object);
            mockEnvironmentModel.Setup(model => model.IsConnected).Returns(true);
            mockEnvironmentModel.Setup(model => model.AuthorizationService).Returns(authService.Object);

            var environmentModel = mockEnvironmentModel.Object;

            var resourceModel = new ResourceModel(environmentModel)
            {
                ID = Guid.NewGuid(),
                ResourceName = "TestResource" + Guid.NewGuid(),
                UserPermissions = userPermissions
            };

            var mockWorkSurfaceViewModel = new Mock<IWorkflowDesignerViewModel>();
            mockWorkSurfaceViewModel.Setup(model => model.Server).Returns(environmentModel);
            mockWorkSurfaceViewModel.Setup(model => model.ResourceModel).Returns(resourceModel);

            var mockResourceModel = new Mock<IContextualResourceModel>();
            mockResourceModel.Setup(model => model.ID).Returns(resourceModel.ID);
            mockResourceModel.Setup(model => model.ResourceName).Returns(resourceModel.ResourceName);
            mockResourceModel.Setup(model => model.UserPermissions).Returns(resourceModel.UserPermissions);
            var viewModel = WorkflowDesignerViewModelMock(true, mockResourceModel);

            var workSurfaceContextViewModel = new WorkSurfaceContextViewModel(new Mock<IEventAggregator>().Object, new WorkSurfaceKey(), viewModel, new Mock<IPopupController>().Object, (a, b, c) => { })
            {
                DebugOutputViewModel = { DebugStatus = DebugStatus.Ready }
            };

            workSurfaceContextViewModel.DebugCommand.UpdateContext(environmentModel, resourceModel);
            workSurfaceContextViewModel.QuickDebugCommand.UpdateContext(environmentModel, resourceModel);

            return workSurfaceContextViewModel;
        }
        
        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("WorkSurfaceContextViewModel_DebugCommand")]
        public void WorkSurfaceContextViewModel_DebugCommand_UserHasNoContributePermissions_SaveIsNotInvoked()
        {
            //------------Setup for test--------------------------
            CustomContainer.Register(new Mock<IWindowManager>().Object);
            var expected = 0;
            var workSurfaceContextViewModel = CreateWorkSurfaceContextViewModel(Permissions.Execute);

            var resourceRepo = new Mock<IResourceRepository>();
            resourceRepo.Setup(r => r.Save(It.IsAny<IResourceModel>())).Verifiable();

            var environmentModel = Mock.Get(workSurfaceContextViewModel.ContextualResourceModel.Environment);
            var mockConnection = new Mock<IEnvironmentConnection>();
            mockConnection.Setup(connection => connection.IsConnected).Returns(true);
            environmentModel.Setup(model => model.Connection).Returns(mockConnection.Object);
            environmentModel.Setup(model => model.ResourceRepository).Returns(resourceRepo.Object);


            //------------Execute Test---------------------------
            //------------Assert Results-------------------------
            workSurfaceContextViewModel.DebugCommand.Execute(null);
            resourceRepo.Verify(r => r.Save(It.IsAny<IResourceModel>()), Times.Exactly(expected));

            expected += 0;

            workSurfaceContextViewModel.QuickDebugCommand.Execute(null);
            resourceRepo.Verify(r => r.Save(It.IsAny<IResourceModel>()), Times.Exactly(expected));
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("WorkSurfaceContextViewModel_DebugCommand")]
        public void WorkSurfaceContextViewModel_DebugCommand_UserHasContributePermissions_SaveIsInvoked()
        {
            //------------Setup for test--------------------------
            CustomContainer.Register(new Mock<IWindowManager>().Object);
            var expected = 1;
            var workSurfaceContextViewModel = CreateWorkSurfaceContextViewModel(Permissions.Contribute);

            var resourceRepo = new Mock<IResourceRepository>();
            resourceRepo.Setup(r => r.Save(It.IsAny<IResourceModel>())).Verifiable();

            var environmentModel = Mock.Get(workSurfaceContextViewModel.ContextualResourceModel.Environment);
            var mockConnection = new Mock<IEnvironmentConnection>();
            mockConnection.Setup(connection => connection.IsConnected).Returns(true);
            environmentModel.Setup(model => model.Connection).Returns(mockConnection.Object);
            environmentModel.Setup(model => model.ResourceRepository).Returns(resourceRepo.Object);
            
            //------------Execute Test---------------------------
            //------------Assert Results-------------------------
            workSurfaceContextViewModel.DebugCommand.Execute(null);
            resourceRepo.Verify(r => r.Save(It.IsAny<IResourceModel>()), Times.Exactly(expected));
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("WorkSurfaceContextViewModel_DebugCommand")]
        public void WorkSurfaceContextViewModel_DebugCommand_UserHasContributePermissions_WfChanged_SaveIsInvokedAgain()
        {
            //------------Setup for test--------------------------
            CustomContainer.Register(new Mock<IWindowManager>().Object);
            var expected = 1;
            var workSurfaceContextViewModel = CreateWorkSurfaceContextViewModel(Permissions.Contribute);

            var resourceRepo = new Mock<IResourceRepository>();
            resourceRepo.Setup(r => r.Save(It.IsAny<IResourceModel>())).Verifiable();

            var environmentModel = Mock.Get(workSurfaceContextViewModel.ContextualResourceModel.Environment);
            var mockConnection = new Mock<IEnvironmentConnection>();
            mockConnection.Setup(connection => connection.IsConnected).Returns(true);
            environmentModel.Setup(model => model.Connection).Returns(mockConnection.Object);
            environmentModel.Setup(model => model.ResourceRepository).Returns(resourceRepo.Object);
            
            //------------Execute Test---------------------------
            //------------Assert Results-------------------------
            workSurfaceContextViewModel.DebugCommand.Execute(null);
            resourceRepo.Verify(r => r.Save(It.IsAny<IResourceModel>()), Times.Exactly(expected));

            expected += 1;
            workSurfaceContextViewModel.ContextualResourceModel.IsWorkflowSaved = false;
            var designSurface = workSurfaceContextViewModel.WorkSurfaceViewModel as WorkflowDesignerViewModelMock;
            Assert.IsNotNull(designSurface);
            designSurface.FireWorkflowChanged();
            workSurfaceContextViewModel.QuickDebugCommand.Execute(null);
            resourceRepo.Verify(r => r.Save(It.IsAny<IResourceModel>()), Times.Exactly(expected));
        }

        [TestMethod]
        [Owner("Leon Rajindrapersadh")]
        [TestCategory("WorkSurfaceContextViewModel_Debug")]
        public void WorkSurfaceContextViewModel_Debug_ValidateDataList()
        {
            const Permissions userPermissions = Permissions.Administrator;
            var workSurfaceContextViewModel = CreateWorkSurfaceContextViewModel(userPermissions);

            var resourceRepo = new Mock<IResourceRepository>();
            resourceRepo.Setup(r => r.Save(It.IsAny<IResourceModel>())).Verifiable();
            var ctx = new Mock<IContextualResourceModel>();

            var environmentModel = new Mock<IServer>();
            var serverRepository = new Mock<IServerRepository>();
            CustomContainer.Register(serverRepository.Object);

            var mockConnection = new Mock<IEnvironmentConnection>();
            mockConnection.Setup(connection => connection.IsConnected).Returns(true);
            environmentModel.Setup(model => model.Connection).Returns(mockConnection.Object);
            environmentModel.Setup(model => model.ResourceRepository).Returns(resourceRepo.Object);
            var popup = new Mock<IPopupController>();
            ctx.Setup(a => a.DataList).Returns("asdasda$%^");
            var pvt = new PrivateObject(workSurfaceContextViewModel);
            pvt.SetField("_contextualResourceModel", ctx.Object);
            pvt.SetField("_popupController", popup.Object);
            ctx.Setup(a => a.Environment).Returns(environmentModel.Object);
            pvt.SetField("_dataListViewModel", new DataListViewModel());
            
            //------------Execute Test---------------------------
            //------------Assert Results-------------------------
            workSurfaceContextViewModel.QuickDebug();

            popup.Verify(a => a.Show(It.IsAny<string>(), "Error Debugging", MessageBoxButton.OK, MessageBoxImage.Error, "", false, true, false, false, false, false));
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory(nameof(WorkSurfaceContextViewModel))]
        public void WorkSurfaceContextViewModel_Save_Expected_HasTrigger_Popup()
        {
            var workSurfaceContextViewModel = CreateWorkSurfaceContextViewModel(Permissions.Contribute);

            var mockPopupController = new Mock<IPopupController>();
            mockPopupController.Setup(popup => popup.Show(It.IsAny<string>(), It.IsAny<string>(), MessageBoxButton.YesNo, MessageBoxImage.Warning, "", false, false, false, true, false, false)).Returns(MessageBoxResult.No);
            var pvt = new PrivateObject(workSurfaceContextViewModel);
            pvt.SetField("_popupController", mockPopupController.Object);

            var mockTriggerQueue = new Mock<Warewolf.Triggers.ITriggerQueue>();
            mockTriggerQueue.Setup(triggerQueue => triggerQueue.ResourceId).Returns(workSurfaceContextViewModel.ContextualResourceModel.ID);

            Runtime.Hosting.TriggersCatalog.Instance.Queues.Add(mockTriggerQueue.Object);

            var isSaved = workSurfaceContextViewModel.Save(false, false);
            Assert.IsFalse(isSaved);

            Runtime.Hosting.TriggersCatalog.Instance.Queues.Clear();

            mockPopupController.Verify(a => a.Show(It.IsAny<string>(), It.IsAny<string>(), MessageBoxButton.YesNo, MessageBoxImage.Warning, "", false, false, false, true, false, false));
        }
    }

    public class WorkSurfaceViewModelTest : IWorkSurfaceViewModel, IWorkflowDesignerViewModel
    {
        bool _workspaceSave;

        #region Implementation of IHaveDisplayName

        public string DisplayName { get; set; }

        #endregion

        #region Implementation of IActivate

        public void Activate()
        {
            IsActive = true;
        }

        public bool IsActive { get; private set; }
        public event EventHandler<ActivationEventArgs> Activated;

        #endregion

        #region Implementation of IDeactivate

        public void Deactivate(bool close)
        {
            Activated?.Invoke(this, null);
            AttemptingDeactivation?.Invoke(null, null);
            Deactivated?.Invoke(null, null);
            PropertyChanged?.Invoke(null, null);
        }

        public event EventHandler<DeactivationEventArgs> AttemptingDeactivation;
        public event EventHandler<DeactivationEventArgs> Deactivated;

        #endregion

        #region Implementation of IClose

        public void TryClose()
        {
        }

        public void CanClose(Action<bool> callback)
        {
        }

        #endregion

        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Implementation of INotifyPropertyChangedEx

        public void NotifyOfPropertyChange(string propertyName)
        {
        }

        public void Refresh()
        {
        }

        public bool IsNotifying { get; set; }

        #endregion

        #region Implementation of IWorkSurfaceViewModel

        public WorkSurfaceContext WorkSurfaceContext { get; set; }
        public bool PreventSelection { get; set; }
        public string IconPath { get; set; }

        public void UpdateModelItem(ModelItem modelItem) => throw new NotImplementedException();
        public object SelectedModelItem => throw new NotImplementedException();
        public string WorkflowName => throw new NotImplementedException();
        public bool RequiredSignOff => throw new NotImplementedException();
        public WorkflowDesigner Designer => throw new NotImplementedException();
        public UIElement DesignerView => throw new NotImplementedException();
        public StringBuilder DesignerText => throw new NotImplementedException();
        public Action<ModelItem> ItemSelectedAction { get; set; }
        public bool IsTestView { get; set; }
        public ModelItem SelectedItem { get; set; }
        public bool CanViewWorkflowLink { get; set; }

        public void Dispose() => throw new NotImplementedException();
        public bool NotifyItemSelected(object primarySelection) => throw new NotImplementedException();
        public void BindToModel() => throw new NotImplementedException();
        public void AddMissingWithNoPopUpAndFindUnusedDataListItems() => throw new NotImplementedException();
        public ModelItem GetModelItem(Guid workSurfaceMappingId, Guid parentID) => throw new NotImplementedException();
        public string GetWorkflowInputs(string field) => throw new NotImplementedException();
        public void CreateBlankWorkflow() => throw new NotImplementedException();
        public void RemoveItem(IToolConflictItem model) => throw new NotImplementedException();
        public void AddItem(IToolConflictItem model) => throw new NotImplementedException();
        public void LinkActivities(Guid sourceUniqueId, Guid destinationUniqueId, string key) => throw new NotImplementedException();
        public void RemoveStartNodeConnection() => throw new NotImplementedException();
        public void LinkStartNode(IToolConflictItem model) => throw new NotImplementedException();
        public void UpdateModelItem(ModelItem modelItem, IToolConflictItem modelTool) => throw new NotImplementedException();
        public void UpdateWorkflowInputDataViewModel(IContextualResourceModel resourceModel) => throw new NotImplementedException();
        public void DeLinkActivities(Guid sourceUniqueId, Guid destinationUniqueId, string key) => throw new NotImplementedException();
        public IServer Server => throw new NotImplementedException();
        public StringBuilder ServiceDefinition
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
        public IContextualResourceModel ResourceModel
        {
            get
            {
                var ax = new Mock<IContextualResourceModel>();
                var env = new Mock<IServer>();
                _workspaceSave = true;
                env.Setup(a => a.IsConnected).Returns(true);
                ax.Setup(a => a.Environment).Returns(env.Object);
                ax.Setup(a => a.UserPermissions).Returns(Permissions.Administrator);
                return ax.Object;
            }
            set => throw new NotImplementedException();
        }
        public bool WorkspaceSave => _workspaceSave;
        public System.Action WorkflowChanged { get; set; }
        public bool CanMerge { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IServiceTestViewModel ViewModel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        #endregion

        public string GetAndUpdateWorkflowLinkWithWorkspaceID()
        {
            return "";
        }
    }
}