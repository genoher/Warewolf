﻿using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Reflection;
using Warewolf.Test.Agent;
using Warewolf.UI.Tests.Explorer.ExplorerUIMapClasses;
using Warewolf.UI.Tests.Search.SearchUIMapClasses;
using Warewolf.UI.Tests.ServerSource.ServerSourceUIMapClasses;

namespace Warewolf.UI.Tests.Search
{
    [CodedUITest]
    public class SearchViewTests
    {
        [TestMethod]
        [DeploymentItem(@"lib\win32\x86\git2-6311e88.dll", @"lib\win32\x86")]
        [DeploymentItem(@"lib\win32\x64\git2-6311e88.dll", @"lib\win32\x64")]
        [TestCategory(nameof(Search))]
        public void Clicking_Search_Menu_Item_Opens_Search_View()
        {
            Mouse.Click(UIMap.MainStudioWindow.SideMenuBar.SearchButton, new Point(16, 11));
            Assert.IsTrue(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.Exists, "Search View Window did not Open after clicking Seacrch Menu Item.");
        }

        [TestMethod]
        [DeploymentItem(@"lib\win32\x86\git2-6311e88.dll", @"lib\win32\x86")]
        [DeploymentItem(@"lib\win32\x64\git2-6311e88.dll", @"lib\win32\x64")]
        [TestCategory(nameof(Search))]
        public void Clicking_New_Server_Button_Opens_Server_Source_Tab()
        {
            Mouse.Click(UIMap.MainStudioWindow.SideMenuBar.SearchButton, new Point(16, 11));
            Mouse.Click(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchConnectControlCustom.NewServerButton);
            Assert.IsTrue(ServerSourceUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.ServerSourceTab.Exists, "Server Source tab did not open after clicking New Server Source Button.");
        }

        [TestMethod]
        [DeploymentItem(@"lib\win32\x86\git2-6311e88.dll", @"lib\win32\x86")]
        [DeploymentItem(@"lib\win32\x64\git2-6311e88.dll", @"lib\win32\x64")]
        [TestCategory(nameof(Search))]
        public void Clicking_Edit_Server_Button_Opens_Server_Source_Tab()
        {
            _containerOps = TestLauncher.StartLocalCIRemoteContainer(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TestResults"));
            Mouse.Click(UIMap.MainStudioWindow.SideMenuBar.SearchButton, new Point(16, 11));
            Mouse.Click(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchConnectControlCustom.ServerComboBox.ServersToggleButton);
            Mouse.Click(SearchUIMap.MainStudioWindow.ComboboxItemAsRemoteConnectionIntegration);
            Mouse.Click(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchConnectControlCustom.EditServerSource);
            Assert.IsTrue(ServerSourceUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.ServerSourceTab.Exists, "Server Source tab did not open after clicking Edit Server Source Button.");
        }

        [TestMethod]
        [DeploymentItem(@"lib\win32\x86\git2-6311e88.dll", @"lib\win32\x86")]
        [DeploymentItem(@"lib\win32\x64\git2-6311e88.dll", @"lib\win32\x64")]
        [TestCategory(nameof(Search))]
        public void Open_Search_Window_Has_All_Options_UnSelected()
        {
            Mouse.Click(UIMap.MainStudioWindow.SideMenuBar.SearchButton, new Point(16, 11));
            Assert.IsTrue(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.Exists, "Search View Window did not Open after clicking Seacrch Menu Item.");
            Assert.IsFalse(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.AllCheckBox.Checked);
            Assert.IsFalse(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.ServiceCheckBox.Checked);
            Assert.IsFalse(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.ScalarCheckBox.Checked);
            Assert.IsFalse(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.TestNameCheckBox.Checked);
            Assert.IsFalse(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.RecordsetCheckBox.Checked);
            Assert.IsFalse(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.ToolTitleCheckBox.Checked);
            Assert.IsFalse(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.ObjectCheckBox.Checked);
            Assert.IsFalse(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.InputVariableCheckBox.Checked);
            Assert.IsFalse(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.OutputVariableCheckBox.Checked);
        }

        [TestMethod]
        [DeploymentItem(@"lib\win32\x86\git2-6311e88.dll", @"lib\win32\x86")]
        [DeploymentItem(@"lib\win32\x64\git2-6311e88.dll", @"lib\win32\x64")]
        [TestCategory(nameof(Search))]
        public void Click_Search_Button_With_Nothing_Filtered()
        {
            Mouse.Click(UIMap.MainStudioWindow.SideMenuBar.SearchButton, new Point(16, 11));
            Assert.IsTrue(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.Exists, "Search View Window did not Open after clicking Seacrch Menu Item.");
            Mouse.Click(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchButton);
            Assert.IsFalse(UIMap.ControlExistsNow(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.WorkSurfaceContent.ContentDockManager.SearchViewUserControl.SearchResultsTable.ResultRow1));
        }

        [TestMethod]
        [DeploymentItem(@"lib\win32\x86\git2-6311e88.dll", @"lib\win32\x86")]
        [DeploymentItem(@"lib\win32\x64\git2-6311e88.dll", @"lib\win32\x64")]
        [TestCategory(nameof(Search))]
        public void UnChecking_Service_CheckBox_Then_AllCheckBox_Checkes_AllCheckBox()
        {
            Mouse.Click(UIMap.MainStudioWindow.SideMenuBar.SearchButton, new Point(16, 11));
            Mouse.Click(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.AllCheckBox);
            Assert.IsTrue(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.AllCheckBox.Checked);
            Assert.IsTrue(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.ServiceCheckBox.Checked);
            Assert.IsTrue(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.OutputVariableCheckBox.Checked);
            SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.ServiceCheckBox.Checked = false;
            Assert.IsFalse(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.AllCheckBox.Checked);
            Assert.IsFalse(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.ServiceCheckBox.Checked);
            Assert.IsTrue(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.OutputVariableCheckBox.Checked);
            Mouse.Click(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.AllCheckBox);
            Assert.IsTrue(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.AllCheckBox.Checked);
            Assert.IsTrue(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.ServiceCheckBox.Checked);
            Assert.IsTrue(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.OutputVariableCheckBox.Checked);
        }

        [TestMethod]
        [DeploymentItem(@"lib\win32\x86\git2-6311e88.dll", @"lib\win32\x86")]
        [DeploymentItem(@"lib\win32\x64\git2-6311e88.dll", @"lib\win32\x64")]
        [TestCategory(nameof(Search))]
        public void UnChecking_AllCheckBox_UnCheckesAll_Check_Boxes()
        {
            Mouse.Click(UIMap.MainStudioWindow.SideMenuBar.SearchButton, new Point(16, 11));
            Assert.IsFalse(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.AllCheckBox.Checked);
            Assert.IsFalse(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.ServiceCheckBox.Checked);
            Assert.IsFalse(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.ScalarCheckBox.Checked);
            Assert.IsFalse(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.TestNameCheckBox.Checked);
            Assert.IsFalse(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.RecordsetCheckBox.Checked);
            Assert.IsFalse(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.ToolTitleCheckBox.Checked);
            Assert.IsFalse(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.ObjectCheckBox.Checked);
            Assert.IsFalse(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.InputVariableCheckBox.Checked);
            Assert.IsFalse(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.OutputVariableCheckBox.Checked);
            Mouse.Click(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.AllCheckBox);
            Assert.IsTrue(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.ServiceCheckBox.Checked);
            Assert.IsTrue(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.ScalarCheckBox.Checked);
            Assert.IsTrue(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.TestNameCheckBox.Checked);
            Assert.IsTrue(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.RecordsetCheckBox.Checked);
            Assert.IsTrue(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.ToolTitleCheckBox.Checked);
            Assert.IsTrue(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.ObjectCheckBox.Checked);
            Assert.IsTrue(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.InputVariableCheckBox.Checked);
            Assert.IsTrue(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.OutputVariableCheckBox.Checked);
            Mouse.Click(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.AllCheckBox);
            Assert.IsFalse(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.AllCheckBox.Checked);
            Assert.IsFalse(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.ServiceCheckBox.Checked);
            Assert.IsFalse(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.ScalarCheckBox.Checked);
            Assert.IsFalse(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.TestNameCheckBox.Checked);
            Assert.IsFalse(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.RecordsetCheckBox.Checked);
            Assert.IsFalse(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.ToolTitleCheckBox.Checked);
            Assert.IsFalse(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.ObjectCheckBox.Checked);
            Assert.IsFalse(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.InputVariableCheckBox.Checked);
            Assert.IsFalse(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.OutputVariableCheckBox.Checked);
        }

        [TestMethod]
        [DeploymentItem(@"lib\win32\x86\git2-6311e88.dll", @"lib\win32\x86")]
        [DeploymentItem(@"lib\win32\x64\git2-6311e88.dll", @"lib\win32\x64")]
        [TestCategory(nameof(Search))]
        public void Checking_AllCheckBox_CheckesAll_Check_Boxes()
        {
            Mouse.Click(UIMap.MainStudioWindow.SideMenuBar.SearchButton, new Point(16, 11));
            Assert.IsTrue(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.Exists, "Search View Window did not Open after clicking Seacrch Menu Item.");
            Assert.IsFalse(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.AllCheckBox.Checked);
            Mouse.Click(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.AllCheckBox);
            Assert.IsTrue(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.ServiceCheckBox.Checked);
            Assert.IsTrue(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.ScalarCheckBox.Checked);
            Assert.IsTrue(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.TestNameCheckBox.Checked);
            Assert.IsTrue(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.RecordsetCheckBox.Checked);
            Assert.IsTrue(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.ToolTitleCheckBox.Checked);
            Assert.IsTrue(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.ObjectCheckBox.Checked);
            Assert.IsTrue(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.InputVariableCheckBox.Checked);
            Assert.IsTrue(SearchUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SearchTab.SearchOptionsExpander.OutputVariableCheckBox.Checked);
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            UIMap.SetPlaybackSettings();
            UIMap.AssertStudioIsRunning();
        }

        static ContainerLauncher _containerOps;

        [TestCleanup]
        public void CleanupContainer() => _containerOps?.Dispose();

        public ExplorerUIMap ExplorerUIMap
        {
            get
            {
                if (_explorerUIMap == null)
                {
                    _explorerUIMap = new ExplorerUIMap();
                }

                return _explorerUIMap;
            }
        }

        private ExplorerUIMap _explorerUIMap;
        public SearchUIMap SearchUIMap
        {
            get
            {
                if (_searchUIMap == null)
                {
                    _searchUIMap = new SearchUIMap();
                }

                return _searchUIMap;
            }
        }

        private SearchUIMap _searchUIMap;
        public UIMap UIMap
        {
            get
            {
                if (_uIMap == null)
                {
                    _uIMap = new UIMap();
                }

                return _uIMap;
            }
        }

        private UIMap _uIMap;

        public ServerSourceUIMap ServerSourceUIMap
        {
            get
            {
                if (_serverSourceUIMap == null)
                {
                    _serverSourceUIMap = new ServerSourceUIMap();
                }

                return _serverSourceUIMap;
            }
        }

        private ServerSourceUIMap _serverSourceUIMap;
    }
}
