﻿using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Warewolf.UI.Tests.WorkflowTab.Tools.Recordset.RecordsetToolsUIMapClasses;
using Warewolf.UI.Tests.WorkflowTab.WorkflowTabUIMapClasses;

namespace Warewolf.UI.Tests.WorkflowTab.Tools.Recordset
{
    [CodedUITest]
    public class SortTest
    {
        [TestMethod]
        [DeploymentItem(@"lib\win32\x86\git2-6311e88.dll", @"lib\win32\x86")]
        [DeploymentItem(@"lib\win32\x64\git2-6311e88.dll", @"lib\win32\x64")]
        [TestCategory("Recordset Tools")]
        public void SortTool_Small_And_LargeView_UITest()
        {
            Assert.IsTrue(RecordsetToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.SortRecords.Exists, "SortRecords tool on the design surface does not exist");
            //Small View
            Assert.IsTrue(RecordsetToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.SortRecords.SmallViewContentCustom.SortFieldComboBox.Exists, "SortField Combobox does not exist on design surface.");
            Assert.IsTrue(RecordsetToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.SortRecords.SmallViewContentCustom.SortOrderComboBox.Exists, "SortOrder Combobox does not exist on design surface.");
            //Large View              
            RecordsetToolsUIMap.Open_SortRecords_LargeView();
            Assert.IsTrue(RecordsetToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.SortRecords.LargeViewContentCustom.SortFieldComboBox.Exists, "SortField Combobox does not exist on design surface.");
            Assert.IsTrue(RecordsetToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.SortRecords.LargeViewContentCustom.SortOrderComboBox.Exists, "SortOrder Combobox does not exist on design surface.");
            Assert.IsTrue(RecordsetToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.SortRecords.LargeViewContentCustom.OnErrorCustom.Exists, "OnError Pane does not exist on design surface.");
            Assert.IsTrue(RecordsetToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.SortRecords.DoneButton.Exists, "Done Button does not exist on design surface.");
        }

        #region Additional test attributes

        [TestInitialize()]
        public void MyTestInitialize()
        {
            UIMap.SetPlaybackSettings();
            UIMap.AssertStudioIsRunning();
            UIMap.Click_NewWorkflow_RibbonButton();
            WorkflowTabUIMap.Drag_Toolbox_Sort_Record_Onto_DesignSurface();
        }

        UIMap UIMap
        {
            get
            {
                if (_UIMap == null)
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

        RecordsetToolsUIMap RecordsetToolsUIMap
        {
            get
            {
                if (_RecordsetToolsUIMap == null)
                {
                    _RecordsetToolsUIMap = new RecordsetToolsUIMap();
                }

                return _RecordsetToolsUIMap;
            }
        }

        private RecordsetToolsUIMap _RecordsetToolsUIMap;

        #endregion
    }
}
