﻿using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Warewolf.UI.Tests.DBSource.DBSourceUIMapClasses;
using Warewolf.UI.Tests.WorkflowTab.Tools.Database.DatabaseToolsUIMapClasses;
using Warewolf.UI.Tests.WorkflowTab.WorkflowTabUIMapClasses;

namespace Warewolf.UI.Tests.Tools
{
    [CodedUITest]
    public class MySQLTests
    {
        const string SourceName = "MySQLSourceFromTool";

        [TestMethod]
        [DeploymentItem(@"lib\win32\x86\git2-6311e88.dll", @"lib\win32\x86")]
        [DeploymentItem(@"lib\win32\x64\git2-6311e88.dll", @"lib\win32\x64")]
        [TestCategory("Database Tools")]
        public void MySQLDatabaseTool_Small_And_LargeView_Then_NewSource_UITest()
        {
            Assert.IsTrue(DatabaseToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.MySqlDatabase.Exists, "My SQL Connector tool does not exist on design surface.");
            //Small View
            DatabaseToolsUIMap.MySqlDatabaseTool_ChangeView_With_DoubleClick();
            Assert.IsTrue(DatabaseToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.MySqlDatabase.SmallView.Exists, "My SQL Connector tool small view does not exist after collapsing large view with a double click.");
            //Large View
            DatabaseToolsUIMap.MySqlDatabaseTool_ChangeView_With_DoubleClick();
            Assert.IsTrue(DatabaseToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.MySqlDatabase.LargeView.SourcesComboBox.Exists, "Sources combobox does not exist on My SQL database connector tool large view.");
            Assert.IsTrue(DatabaseToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.MySqlDatabase.LargeView.EditSourceButton.Exists, "Edit Source button does not exist on My SQL database connector tool large view.");
            Assert.IsTrue(DatabaseToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.MySqlDatabase.LargeView.NewSourceButton.Exists, "New Source button does not exist on My SQL database connector tool large view.");
            Assert.IsTrue(DatabaseToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.MySqlDatabase.LargeView.ActionsComboBox.Exists, "Actions combobox does not exist on My SQL database connector tool large view.");
            Assert.IsTrue(DatabaseToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.MySqlDatabase.LargeView.GenerateOutputsButton.Exists, "Generate Outputs button does not exist on My SQL database connector tool large view.");
            Assert.IsTrue(DatabaseToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.MySqlDatabase.LargeView.OutputsMappingDataGrTable.Exists, "Outputs Mapping table does not exist on My SQL database connector tool large view.");
            Assert.IsTrue(DatabaseToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.MySqlDatabase.LargeView.RecordSetTextBoxEdit.Exists, "Recordset textbox does not exist on My SQL database connector tool large view.");
            Assert.IsTrue(DatabaseToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.MySqlDatabase.LargeView.OnErrorCustom.Exists, "OnError panel does not exist on My SQL database connector tool large view.");
            Assert.IsTrue(DatabaseToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.MySqlDatabase.DoneButton.Exists, "Done button does not exist on My SQL database connector tool large view.");
            //New Source
            DatabaseToolsUIMap.Click_NewSourceButton_From_MySQLTool();
            Assert.IsTrue(DBSourceUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.DBSourceTab.Exists, "MySQL Source Tab does not exist.");
            Assert.IsTrue(DBSourceUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.DBSourceTab.WorkSurfaceContext.ManageDatabaseSourceControl.ServerComboBox.Enabled, "MySQL Server Address combobox is disabled new MySQL Source wizard tab");
            Assert.IsTrue(DBSourceUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.DBSourceTab.WorkSurfaceContext.UserRadioButton.Enabled, "User authentification rabio button is not enabled.");
            Assert.IsTrue(DBSourceUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.DBSourceTab.WorkSurfaceContext.WindowsRadioButton.Enabled, "Windows authentification type radio button not enabled.");
            Assert.IsFalse(DBSourceUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.DBSourceTab.WorkSurfaceContext.TestConnectionButton.Enabled, "Test Connection Button is enabled.");
            DBSourceUIMap.Click_UserButton_On_DatabaseSource();
            Assert.IsTrue(DBSourceUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.DBSourceTab.WorkSurfaceContext.UserNameTextBox.Exists);
            Assert.IsTrue(DBSourceUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.DBSourceTab.WorkSurfaceContext.PasswordTextBox.Exists);
            DBSourceUIMap.Enter_Text_Into_DatabaseServer_Tab("RSAKLFSVRDEV");
            DBSourceUIMap.IEnterRunAsUserRootOnDatabaseSource();
            Assert.IsTrue(DBSourceUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.DBSourceTab.WorkSurfaceContext.TestConnectionButton.Enabled, "Test Connection Button is not enabled.");
            DBSourceUIMap.Click_DB_Source_Wizard_Test_Connection_Button();
            DBSourceUIMap.Select_mysql_From_DB_Source_Wizard_Database_Combobox();
            UIMap.Save_With_Ribbon_Button_And_Dialog(SourceName);
            DBSourceUIMap.Click_Close_DB_Source_Wizard_Tab_Button();
            //Edit Source
            DatabaseToolsUIMap.MySqlDatabaseTool_ChangeView_With_DoubleClick();
            DatabaseToolsUIMap.Select_Source_From_MySQLTool();
            Assert.IsTrue(DatabaseToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.MySqlDatabase.LargeView.EditSourceButton.Enabled, "Edit Source Button is not enabled after selecting source.");
            DatabaseToolsUIMap.Click_EditSourceButton_On_MySQLTool();
            Assert.IsTrue(DBSourceUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.DBSourceTab.Exists, "MySql Source Tab does not exist");
            DBSourceUIMap.Select_test_From_DB_Source_Wizard_Database_Combobox();
            UIMap.Click_Save_Ribbon_Button_With_No_Save_Dialog();
            DBSourceUIMap.Click_Close_DB_Source_Wizard_Tab_Button();
            DatabaseToolsUIMap.MySqlDatabaseTool_ChangeView_With_DoubleClick();
            DatabaseToolsUIMap.Click_EditSourceButton_On_MySQLTool();
            Assert.AreEqual("test", DBSourceUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.DBSourceTab.WorkSurfaceContext.ManageDatabaseSourceControl.DatabaseComboxBox.testText.DisplayText);
        }

        [TestMethod]
        [DeploymentItem(@"lib\win32\x86\git2-6311e88.dll", @"lib\win32\x86")]
        [DeploymentItem(@"lib\win32\x64\git2-6311e88.dll", @"lib\win32\x64")]
        [TestCategory("Database Tools")]
        public void MySQLDatabaseConnectorTool_Test_Connection_From_Design_Surface_UITest()
        {
            DatabaseToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.MySqlDatabase.LargeView.SourcesComboBox.Expanded = true;
            Mouse.Click(DatabaseToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.MySqlDatabase.LargeView.SourcesComboBox.Items[0]);
            DatabaseToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.MySqlDatabase.LargeView.ActionsComboBox.Expanded = true;
            Mouse.Click(DatabaseToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.MySqlDatabase.LargeView.ActionsComboBox.Items[1]);
            Mouse.Click(DatabaseToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.MySqlDatabase.LargeView.GenerateOutputsButton);
            DatabaseToolsUIMap.GetTestInputTextboxFromRow(DatabaseToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.MySqlDatabase.LargeView.InputLargeDataGridTable.Rows[0]).Text = "0";
            DatabaseToolsUIMap.GetTestInputTextboxFromRow(DatabaseToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.MySqlDatabase.LargeView.InputLargeDataGridTable.Rows[1]).Text = "a";
            Mouse.Click(DatabaseToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.MySqlDatabase.LargeView.TestButton);
            Mouse.Click(DatabaseToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.MySqlDatabase.LargeView.DoneButton);
            Mouse.Click(DatabaseToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.MySqlDatabase.DoneButton);
            Assert.IsTrue(DatabaseToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.MySqlDatabase.SmallView.Exists, "MySql database connector tool small view does not exist after entering valid data, testing it and clicking done.");
        }

        [TestMethod]
        [DeploymentItem(@"lib\win32\x86\git2-6311e88.dll", @"lib\win32\x86")]
        [DeploymentItem(@"lib\win32\x64\git2-6311e88.dll", @"lib\win32\x64")]
        [TestCategory("Database Tools")]
        public void MySQLDatabaseConnectorTool_Test_Command_Timeout_Empty_UITest()
        {
            Assert.AreEqual("", DatabaseToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.MySqlDatabase.LargeView.CommandTimeoutTextBoEdit.Text);
        }

        #region Additional test attributes

        [TestInitialize]
        public void MyTestInitialize()
        {
            UIMap.SetPlaybackSettings();
            UIMap.AssertStudioIsRunning();
            UIMap.Click_NewWorkflow_RibbonButton();
            WorkflowTabUIMap.Drag_Toolbox_MySql_Database_Onto_DesignSurface();
        }

        UIMap UIMap
        {
            get
            {
                if ((_UIMap == null))
                {
                    _UIMap = new UIMap();
                }

                return _UIMap;
            }
        }

        private UIMap _UIMap;

        WorkflowTabUIMap WorkflowTabUIMap
        {
            get
            {
                if (_WorkflowTabUIMap == null)
                {
                    _WorkflowTabUIMap = new WorkflowTabUIMap();
                }

                return _WorkflowTabUIMap;
            }
        }

        private WorkflowTabUIMap _WorkflowTabUIMap;

        DBSourceUIMap DBSourceUIMap
        {
            get
            {
                if (_DBSourceUIMap == null)
                {
                    _DBSourceUIMap = new DBSourceUIMap();
                }

                return _DBSourceUIMap;
            }
        }

        private DBSourceUIMap _DBSourceUIMap;

        DatabaseToolsUIMap DatabaseToolsUIMap
        {
            get
            {
                if (_DatabaseToolsUIMap == null)
                {
                    _DatabaseToolsUIMap = new DatabaseToolsUIMap();
                }

                return _DatabaseToolsUIMap;
            }
        }

        private DatabaseToolsUIMap _DatabaseToolsUIMap;

        #endregion
    }
}
