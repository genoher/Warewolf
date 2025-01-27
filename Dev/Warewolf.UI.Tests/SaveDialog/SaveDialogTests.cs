﻿using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Warewolf.UI.Tests.DialogsUIMapClasses;
using Warewolf.UI.Tests.WorkflowTab.WorkflowTabUIMapClasses;
using Warewolf.UI.Tests.Explorer.ExplorerUIMapClasses;
using System.Drawing;

namespace Warewolf.UI.Tests.SaveDialog
{
    [CodedUITest]
    public class SaveDialogTests
    {
        const string HelloWorld = "Hello World";
        const string FolderToRename = "FolderToRename";
        const string FolderRenamed = "FolderToRename_Renamed";
        const string SaveDialogHiddenVersion = "SaveDialogHiddenVersion";

        [TestMethod]
        [DeploymentItem(@"lib\win32\x86\git2-6311e88.dll", @"lib\win32\x86")]
        [DeploymentItem(@"lib\win32\x64\git2-6311e88.dll", @"lib\win32\x64")]
        [TestCategory("Save Dialog")]
        public void Save_Dialog_Filter_Given_HelloWorld_Filters_Explorer_Tree()
        {
            DialogsUIMap.Filter_Save_Dialog_Explorer(HelloWorld);
            Assert.IsTrue(DialogsUIMap.SaveDialogWindow.ExplorerView.ExplorerTree.localhost.FirstItem.Exists, "No items in the explorer tree after filtering when there should be at exactly 1.");
            Assert.IsFalse(UIMap.ControlExistsNow(DialogsUIMap.SaveDialogWindow.ExplorerView.ExplorerTree.localhost.SecondItem), "Too many items in the explorer tree after filtering when there should be at exactly 1.");
            DialogsUIMap.Click_SaveDialog_CancelButton();
        }

        [TestMethod]
        [DeploymentItem(@"lib\win32\x86\git2-6311e88.dll", @"lib\win32\x86")]
        [DeploymentItem(@"lib\win32\x64\git2-6311e88.dll", @"lib\win32\x64")]
        [TestCategory("Save Dialog")]
        public void Save_Dialog_Resource_Version_Should_Be_Hidden()
        {
            DialogsUIMap.Click_SaveDialog_CancelButton();
            ExplorerUIMap.Filter_Explorer(SaveDialogHiddenVersion);
            ExplorerUIMap.Select_ShowVersionHistory_From_ExplorerContextMenu();
            ExplorerUIMap.Create_New_Workflow_In_LocalHost_With_Shortcut();
            WorkflowTabUIMap.Make_Workflow_Savable_By_Dragging_Start();
            WorkflowTabUIMap.Save_Workflow_Using_Shortcut();
            DialogsUIMap.Filter_Save_Dialog_Explorer(SaveDialogHiddenVersion);
            Assert.IsTrue(DialogsUIMap.SaveDialogWindow.ExplorerView.ExplorerTree.localhost.FirstItem.Exists, "No items in the explorer tree after filtering when there should be at exactly 1.");
            Assert.IsFalse(DialogsUIMap.SaveDialogWindow.ExplorerView.ExplorerTree.localhost.SecondItem.Exists, "The version should not be visible when the Save Dialog is open.");
            DialogsUIMap.Click_SaveDialog_CancelButton();
        }

        [TestMethod]
        [DeploymentItem(@"lib\win32\x86\git2-6311e88.dll", @"lib\win32\x86")]
        [DeploymentItem(@"lib\win32\x64\git2-6311e88.dll", @"lib\win32\x64")]
        [TestCategory("Save Dialog")]
        public void Server_Context_Menu_Has_New_Folder_Only()
        {
            DialogsUIMap.RightClick_Save_Dialog_Localhost();
            Assert.IsTrue(DialogsUIMap.SaveDialogWindow.SaveDialogContextMenu.NewFolderMenuItem.Exists);
            DialogsUIMap.Click_SaveDialog_CancelButton();
        }

        [TestMethod]
        [DeploymentItem(@"lib\win32\x86\git2-6311e88.dll", @"lib\win32\x86")]
        [DeploymentItem(@"lib\win32\x64\git2-6311e88.dll", @"lib\win32\x64")]
        [TestCategory("Save Dialog")]
        public void Folder_Items_Context_Menu_Has_New_Folder_And_Rename()
        {
            DialogsUIMap.Filter_Save_Dialog_Explorer(FolderToRename);
            DialogsUIMap.RightClick_Save_Dialog_Localhost_First_Item();
            Assert.IsTrue(DialogsUIMap.SaveDialogWindow.SaveDialogContextMenu.RenameMenuItem.Exists);
            Assert.IsTrue(DialogsUIMap.SaveDialogWindow.SaveDialogContextMenu.UINewFolderMenuItem.Exists);
            DialogsUIMap.Click_SaveDialog_CancelButton();
        }

        [TestMethod]
        [DeploymentItem(@"lib\win32\x86\git2-6311e88.dll", @"lib\win32\x86")]
        [DeploymentItem(@"lib\win32\x64\git2-6311e88.dll", @"lib\win32\x64")]
        [TestCategory("Save Dialog")]
        public void Resources_Items_Context_Menu_Has_Delete_And_Rename()
        {
            DialogsUIMap.Filter_Save_Dialog_Explorer(HelloWorld);
            DialogsUIMap.RightClick_Save_Dialog_Localhost_First_Item();
            Assert.IsTrue(DialogsUIMap.SaveDialogWindow.SaveDialogContextMenu.DeleteMenuItem.Exists);
            Assert.IsTrue(DialogsUIMap.SaveDialogWindow.SaveDialogContextMenu.RenameMenuItem.Exists);
            DialogsUIMap.Click_SaveDialog_CancelButton();
        }

        [TestMethod]
        [DeploymentItem(@"lib\win32\x86\git2-6311e88.dll", @"lib\win32\x86")]
        [DeploymentItem(@"lib\win32\x64\git2-6311e88.dll", @"lib\win32\x64")]
        [TestCategory("Save Dialog")]
        public void SaveDialogServiceNameValidationInvalidChars()
        {
            DialogsUIMap.I_Enter_Invalid_Service_Name_Into_SaveDialog("Inv@lid N&m#");
            Assert.IsFalse(DialogsUIMap.SaveDialogWindow.SaveButton.Enabled, "Save dialog save button is ENABLED.");
        }

        [TestMethod]
        [DeploymentItem(@"lib\win32\x86\git2-6311e88.dll", @"lib\win32\x86")]
        [DeploymentItem(@"lib\win32\x64\git2-6311e88.dll", @"lib\win32\x64")]
        [TestCategory("Save Dialog")]
        public void SaveDialogServiceNameOnLoadedTextIsSelected()
        {
            Keyboard.SendKeys("{BACK}");
            Assert.AreEqual("", DialogsUIMap.SaveDialogWindow.ServiceNameTextBox.Text, "Error is not the same as expected");

            DialogsUIMap.SaveDialogWindow.ServiceNameTextBox.Text = "RandomResourceName";
            Assert.AreEqual("RandomResourceName", DialogsUIMap.SaveDialogWindow.ServiceNameTextBox.Text, "Error is not the same as expected");
        }

        [TestMethod]
        [DeploymentItem(@"lib\win32\x86\git2-6311e88.dll", @"lib\win32\x86")]
        [DeploymentItem(@"lib\win32\x64\git2-6311e88.dll", @"lib\win32\x64")]
        [TestCategory("Save Dialog")]
        public void SaveDialogServiceNameValidationNameEndsWithNumber()
        {
            DialogsUIMap.Enter_Valid_Service_Name_Into_Save_Dialog("TestingWF1");
            Assert.IsTrue(DialogsUIMap.SaveDialogWindow.SaveButton.Enabled, "Save dialog save button is not enabled. Check workflow name is valid and that another workflow by that name does not already exist.");
        }
        [TestMethod]
        [DeploymentItem(@"lib\win32\x86\git2-6311e88.dll", @"lib\win32\x86")]
        [DeploymentItem(@"lib\win32\x64\git2-6311e88.dll", @"lib\win32\x64")]
        [TestCategory("Save Dialog")]
        public void SaveDialogServiceNameValidationNameEndsWithEmptySpace()
        {
            DialogsUIMap.I_Enter_Invalid_Service_Name_With_Whitespace_Into_SaveDialog("Test ");
            Assert.IsFalse(DialogsUIMap.SaveDialogWindow.SaveButton.Enabled, "Save dialog save button is not enabled. Check workflow name is valid and that another workflow by that name does not already exist.");
        }

        [TestMethod]
        [DeploymentItem(@"lib\win32\x86\git2-6311e88.dll", @"lib\win32\x86")]
        [DeploymentItem(@"lib\win32\x64\git2-6311e88.dll", @"lib\win32\x64")]
        [TestCategory("Save Dialog")]
        public void CloseSaveDialogRemovesExplorerFilter()
        {
            DialogsUIMap.Filter_Save_Dialog_Explorer("Hello World");
            Assert.IsTrue(DialogsUIMap.SaveDialogWindow.ExplorerView.ExplorerTree.localhost.FirstItem.Exists);
            DialogsUIMap.Click_SaveDialog_CancelButton();
            Playback.Wait(2000);
            ExplorerUIMap.ExplorerItemsAppearOnTheExplorerTree();
        }

        [TestMethod]
        [DeploymentItem(@"lib\win32\x86\git2-6311e88.dll", @"lib\win32\x86")]
        [DeploymentItem(@"lib\win32\x64\git2-6311e88.dll", @"lib\win32\x64")]
        [TestCategory("Save Dialog")]
        public void RenameFolderFromSaveDialog()
        {
            DialogsUIMap.Filter_Save_Dialog_Explorer(FolderToRename);
            DialogsUIMap.RenameItemUsingShortcut();
            DialogsUIMap.Rename_Folder_From_Save_Dialog("FolderToRename_Renamed");
            DialogsUIMap.Click_SaveDialog_CancelButton();
            ExplorerUIMap.Filter_Explorer("FolderToRename_Renamed");
            ExplorerUIMap.ExplorerContainItem("FolderToRename_Renamed");
        }

        [TestMethod]
        [DeploymentItem(@"lib\win32\x86\git2-6311e88.dll", @"lib\win32\x86")]
        [DeploymentItem(@"lib\win32\x64\git2-6311e88.dll", @"lib\win32\x64")]
        [TestCategory("Save Dialog")]
        public void MoveFolderToSameLocationFromSaveDialog()
        {
            DialogsUIMap.Filter_Save_Dialog_Explorer(FolderToRename);
            DialogsUIMap.MoveFolderToRenameIntoLocalhost();
            DialogsUIMap.ResourceIsChildOfLocalhost(FolderToRename);
        }

        [TestMethod]
        [DeploymentItem(@"lib\win32\x86\git2-6311e88.dll", @"lib\win32\x86")]
        [DeploymentItem(@"lib\win32\x64\git2-6311e88.dll", @"lib\win32\x64")]
        [TestCategory("Save Dialog")]
        public void MoveFolderToFolderToRenameFromSaveDialog()
        {
            DialogsUIMap.Filter_Save_Dialog_Explorer("FolderTo");
            DialogsUIMap.MoveFolderToMoveIntoFolderToRename();
            DialogsUIMap.Filter_Save_Dialog_Explorer("FolderToMove");
            DialogsUIMap.FolderIsChildOfParentFolder("FolderToMove", FolderToRename);
        }

        [TestMethod]
        [DeploymentItem(@"lib\win32\x86\git2-6311e88.dll", @"lib\win32\x86")]
        [DeploymentItem(@"lib\win32\x64\git2-6311e88.dll", @"lib\win32\x64")]
        [TestCategory("Save Dialog")]
        public void MoveResourceToLocalhostFromSaveDialog()
        {
            DialogsUIMap.Filter_Save_Dialog_Explorer("ResourceToMove");
            DialogsUIMap.MoveResourceToLocalhost();
            DialogsUIMap.Filter_Save_Dialog_Explorer("FolderToMove");
            Assert.IsTrue(ExplorerUIMap.MainStudioWindow.DockManager.SplitPaneLeft.Explorer.ExplorerTree.localhost.FirstItem.Exists, "Explorer does not contain a first item after filter.");
            ExplorerUIMap.ExplorerDoesNotContainFirstItemFirstSubItem();
        }

        [TestMethod]
        [DeploymentItem(@"lib\win32\x86\git2-6311e88.dll", @"lib\win32\x86")]
        [DeploymentItem(@"lib\win32\x64\git2-6311e88.dll", @"lib\win32\x64")]
        [TestCategory("Save Dialog")]
        public void DoubleClickItemInSaveDialogDoesNotOpenResource()
        {
            DialogsUIMap.Filter_Save_Dialog_Explorer("Hello World");
            DialogsUIMap.DoubleClickResourceOnTheSaveDialog();
            DialogsUIMap.Click_SaveDialog_CancelButton();
            UIMap.ResourceDidNotOpen();
        }

        [TestMethod]
        [DeploymentItem(@"lib\win32\x86\git2-6311e88.dll", @"lib\win32\x86")]
        [DeploymentItem(@"lib\win32\x64\git2-6311e88.dll", @"lib\win32\x64")]
        [TestCategory("Save Dialog")]
        public void PressEnterSavesResourceAndClosesSaveDialog()
        {
            const string resourceFolder = "EnterSavesResourceFolder";
            DialogsUIMap.RightClick_Save_Dialog_Localhost();
            DialogsUIMap.Select_NewFolder_From_SaveDialogContextMenu();
            DialogsUIMap.Name_New_Folder_From_Save_Dialog(resourceFolder);
            Assert.IsTrue(DialogsUIMap.SaveDialogWindow.Exists);
            DialogsUIMap.Enter_Valid_Service_Name_Into_Save_Dialog("EnterSavesResource");
            WorkflowTabUIMap.Enter_Using_Shortcut();
            DialogsUIMap.SaveDialogWindow.WaitForControlCondition(control => !control.TryGetClickablePoint(out Point point), 60000);
            Assert.IsFalse(DialogsUIMap.SaveDialogWindow.Exists);
        }


        [TestMethod]
        [DeploymentItem(@"lib\win32\x86\git2-6311e88.dll", @"lib\win32\x86")]
        [DeploymentItem(@"lib\win32\x64\git2-6311e88.dll", @"lib\win32\x64")]
        [TestCategory("Save Dialog")]
        public void ClickingSave_ThenPressEnter_SavesResource_AndClosesSaveDialog()
        {
            WorkflowTabUIMap.Escape_Using_Shortcut();
            Mouse.Click(UIMap.MainStudioWindow.SideMenuBar.SaveButton);

            const string resourceFolder = "ClickSaveEnterSavesResourceFolder";
            DialogsUIMap.RightClick_Save_Dialog_Localhost();
            DialogsUIMap.Select_NewFolder_From_SaveDialogContextMenu();
            DialogsUIMap.Name_New_Folder_From_Save_Dialog(resourceFolder);
            Assert.IsTrue(DialogsUIMap.SaveDialogWindow.Exists);
            DialogsUIMap.Enter_Valid_Service_Name_Into_Save_Dialog("ClickSaveEnterSavesResource");
            WorkflowTabUIMap.Enter_Using_Shortcut();
            DialogsUIMap.SaveDialogWindow.WaitForControlCondition(control => !control.TryGetClickablePoint(out Point point), 60000);
            Assert.IsFalse(DialogsUIMap.SaveDialogWindow.Exists);
        }

        #region Additional test attributes

        [TestInitialize]
        public void MyTestInitialize()
        {
            UIMap.SetPlaybackSettings();
            UIMap.AssertStudioIsRunning();
            ExplorerUIMap.Create_New_Workflow_In_LocalHost_With_Shortcut();
            WorkflowTabUIMap.Make_Workflow_Savable_By_Dragging_Start();
            WorkflowTabUIMap.Save_Workflow_Using_Shortcut();
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

        UIMap _UIMap;

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

        WorkflowTabUIMap _WorkflowTabUIMap;

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

        ExplorerUIMap _ExplorerUIMap;

        DialogsUIMap DialogsUIMap
        {
            get
            {
                if (_DialogsUIMap == null)
                {
                    _DialogsUIMap = new DialogsUIMap();
                }

                return _DialogsUIMap;
            }
        }

        DialogsUIMap _DialogsUIMap;

        #endregion
    }
}
