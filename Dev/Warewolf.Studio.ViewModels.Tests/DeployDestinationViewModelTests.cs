﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.ObjectModel;
using Dev2.Common.Interfaces;
using Dev2.Common.Interfaces.Explorer;
using Dev2.Studio.Interfaces;
using Microsoft.Practices.Prism.PubSubEvents;
using Moq;
using Dev2;
using Dev2.ConnectionHelpers;

namespace Warewolf.Studio.ViewModels.Tests
{
    [TestClass]
    public class DeployDestinationViewModelTests
    {
        #region Fields

        DeployDestinationViewModel _target;

        Mock<IShellViewModel> _shellViewModelMock;
        Mock<IServer> _serverMock;
        Mock<IEventAggregator> _eventAggregatorMock;
        Mock<IStudioUpdateManager> _studioUpdateManagerMock;
        Mock<IExplorerItem> _explorerItemMock;

        #endregion Fields

        #region Test initialize

        [TestInitialize]
        public void TestInitialize()
        {
            var explorerTooltips = new Mock<IExplorerTooltips>();
            CustomContainer.Register(explorerTooltips.Object);
            var serverRepository = new Mock<IServerRepository>();
            CustomContainer.Register(serverRepository.Object);
            var connectControlSingleton = new Mock<IConnectControlSingleton>();
            CustomContainer.Register(connectControlSingleton.Object);
            _shellViewModelMock = new Mock<IShellViewModel>();
            _shellViewModelMock.Setup(model => model.ExplorerViewModel).Returns(new Mock<IExplorerViewModel>().Object);
            _shellViewModelMock.Setup(model => model.ExplorerViewModel.ConnectControlViewModel).Returns(new Mock<IConnectControlViewModel>().Object);
            var env = new Mock<IEnvironmentViewModel>();
            _shellViewModelMock.SetupGet(model => model.ExplorerViewModel.Environments).Returns(new Caliburn.Micro.BindableCollection<IEnvironmentViewModel>()
            {
                env.Object
            });
            _serverMock = new Mock<IServer>();
            _studioUpdateManagerMock = new Mock<IStudioUpdateManager>();
            _explorerItemMock = new Mock<IExplorerItem>();
            _explorerItemMock.SetupGet(it => it.Children).Returns(new ObservableCollection<IExplorerItem>());
            _serverMock.Setup(it => it.LoadExplorer(false)).ReturnsAsync(_explorerItemMock.Object);
            _serverMock.SetupGet(it => it.UpdateRepository).Returns(_studioUpdateManagerMock.Object);
            _serverMock.SetupGet(it => it.DisplayName).Returns("someResName");
            var mockEnvironmentConnection = SetupMockConnection();
            _serverMock.SetupGet(it => it.Connection).Returns(mockEnvironmentConnection.Object);
            _serverMock.Setup(server => server.Connection).Returns(mockEnvironmentConnection.Object);
            _shellViewModelMock.SetupGet(it => it.LocalhostServer).Returns(_serverMock.Object);
            _eventAggregatorMock = new Mock<IEventAggregator>();
            _target = new DeployDestinationViewModel(_shellViewModelMock.Object, _eventAggregatorMock.Object);
        }

        private static Mock<IEnvironmentConnection> SetupMockConnection()
        {
            var uri = new Uri("http://bravo.com/");
            var mockEnvironmentConnection = new Mock<IEnvironmentConnection>();
            mockEnvironmentConnection.Setup(a => a.AppServerUri).Returns(uri);
            mockEnvironmentConnection.Setup(a => a.AuthenticationType).Returns(Dev2.Runtime.ServiceModel.Data.AuthenticationType.Public);
            mockEnvironmentConnection.Setup(a => a.WebServerUri).Returns(uri);
            mockEnvironmentConnection.Setup(a => a.ID).Returns(Guid.Empty);
            return mockEnvironmentConnection;
        }

        #endregion Test initialize

        #region Test properties

        [TestMethod,Timeout(60000)]
        public void TestMinSupportedVersion()
        {
            //arrange
            var selectedEnvironmentMock = new Mock<IEnvironmentViewModel>();
            var serverMock = new Mock<IServer>();
            var version = "4.0.3";
            serverMock.Setup(it => it.GetMinSupportedVersion()).Returns(version);
            selectedEnvironmentMock.SetupGet(it => it.Server).Returns(serverMock.Object);
            _target.SelectedEnvironment = selectedEnvironmentMock.Object;

            //act
            var actual = _target.MinSupportedVersion;

            //assert
            Assert.AreEqual(Version.Parse(version), actual);
        }

        [TestMethod,Timeout(60000)]
        public void TestServerVersion()
        {
            //arrange
            var selectedEnvironmentMock = new Mock<IEnvironmentViewModel>();
            var serverMock = new Mock<IServer>();
            var version = "4.0.3";
            serverMock.Setup(it => it.GetServerVersion()).Returns(version);
            selectedEnvironmentMock.SetupGet(it => it.Server).Returns(serverMock.Object);
            _target.SelectedEnvironment = selectedEnvironmentMock.Object;

            //act
            var actual = _target.ServerVersion;

            //assert
            Assert.AreEqual(Version.Parse(version), actual);
        }

        [TestMethod,Timeout(60000)]
        public void TestIsLoading()
        {
            //arrange
            var isIsLoadingChanged = false;
            _target.IsLoading = false;
            _target.PropertyChanged += (s, e) =>
            {
                isIsLoadingChanged = isIsLoadingChanged || e.PropertyName == "IsLoading";
            };

            //act
            _target.IsLoading = !_target.IsLoading;

            //assert
            Assert.IsTrue(_target.IsLoading);
            Assert.IsTrue(isIsLoadingChanged);
        }

        [TestMethod,Timeout(60000)]
        [Owner("Nkosinathi Sangweni")]
        public void DeployTests_GivenIsSet_ShouldFireOnPropertyChanged()
        {
            //---------------Set up test pack-------------------
            var wasCalled = false;
            _target.IsLoading = false;
            _target.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "DeployTests")
                {
                    wasCalled = true;
                }
            };
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            _target.DeployTests = true;
            //---------------Test Result -----------------------
            Assert.IsTrue(wasCalled);
        }
        #endregion Test properties
    }
}