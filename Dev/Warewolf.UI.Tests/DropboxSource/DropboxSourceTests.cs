﻿using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Warewolf.UI.Tests.DropboxSource.DropboxSourceUIMapClasses;
using Warewolf.UI.Tests.Explorer.ExplorerUIMapClasses;

namespace Warewolf.UI.Tests
{
    [CodedUITest]
    public class DropboxSourceTests
    {
        [TestMethod]
        [DeploymentItem(@"lib\win32\x86\git2-6311e88.dll", @"lib\win32\x86")]
        [DeploymentItem(@"lib\win32\x64\git2-6311e88.dll", @"lib\win32\x64")]
        [TestCategory("Source Wizards")]
        // ReSharper disable once InconsistentNaming
        public void Create_DropboxSource_From_ExplorerContextMenu_UITests()
        {
            ExplorerUIMap.Select_NewDropboxSource_From_ExplorerContextMenu();
            Assert.IsTrue(DropboxSourceUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.OAuthSourceWizardTab.Exists, "OAuth Source Tab does not exist");
            Assert.IsFalse(DropboxSourceUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.OAuthSourceWizardTab.WorkSurfaceContext.AuthoriseButton.Enabled, "Authorise button is enabled");
            Assert.IsTrue(DropboxSourceUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.OAuthSourceWizardTab.WorkSurfaceContext.ServerTypeComboBox.Enabled, "Server Type Combobox is not enabled");
            Assert.IsTrue(DropboxSourceUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.OAuthSourceWizardTab.WorkSurfaceContext.OAuthKeyTextBox.Enabled, "OAuth Key Textbox is not enabled");
            DropboxSourceUIMap.Enter_TextIntoOAuthKey_On_OAuthSourceTab();
            DropboxSourceUIMap.Click_OAuthSource_AuthoriseButton();
        }

        #region Additional test attributes

        [TestInitialize()]
        public void MyTestInitialize()
        {
            UIMap.SetPlaybackSettings();
            UIMap.AssertStudioIsRunning();
        }
        
        public UIMap UIMap
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

        ExplorerUIMap ExplorerUIMap
        {
            get
            {
                if (_ExplorerUIMap == null)
                {
                    _ExplorerUIMap = new ExplorerUIMap();
                }

                return _ExplorerUIMap;
            }
        }

        private ExplorerUIMap _ExplorerUIMap;

        DropboxSourceUIMap DropboxSourceUIMap
        {
            get
            {
                if (_DropboxSourceUIMap == null)
                {
                    _DropboxSourceUIMap = new DropboxSourceUIMap();
                }

                return _DropboxSourceUIMap;
            }
        }

        private DropboxSourceUIMap _DropboxSourceUIMap;

        #endregion
    }
}