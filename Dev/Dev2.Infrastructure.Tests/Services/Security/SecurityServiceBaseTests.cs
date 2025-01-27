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
using System.Collections.Generic;
using Dev2.Common.Interfaces.Enums;
using Dev2.Services.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Dev2.Infrastructure.Tests.Services.Security
{
    [TestClass]
    public class SecurityServiceBaseTests
    {
        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("SecurityServiceBase_Constructor")]
        public void SecurityServiceBase_Constructor_PropertiesInitialized()
        {
            //------------Setup for test--------------------------

            //------------Execute Test---------------------------
            var securityServiceBase = new TestSecurityServiceBase();

            //------------Assert Results-------------------------
            Assert.IsNotNull(securityServiceBase.Permissions);
            Assert.AreEqual(0, securityServiceBase.Permissions.Count);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("SecurityServiceBase_Read")]
        public void SecurityServiceBase_Read_ReadPermissionsResultIsNotNull_PermissionsUpdated()
        {
            //------------Setup for test--------------------------
            var perms1 = new List<WindowsGroupPermission>
            {
                new WindowsGroupPermission(),
                new WindowsGroupPermission()
            };
            var perms2 = new List<WindowsGroupPermission>
            {
                new WindowsGroupPermission { ResourceName = "Permission1" },
                new WindowsGroupPermission { ResourceName = "Permission2" },
                new WindowsGroupPermission { ResourceName = "Permission3" },
            };
            var securityServiceBase = new TestSecurityServiceBase { ReadPermissionsResults = perms1 };
            securityServiceBase.Read();
            Assert.AreEqual(perms1.Count, securityServiceBase.Permissions.Count);

            securityServiceBase.ReadPermissionsResults = perms2;

            //------------Execute Test---------------------------
            securityServiceBase.Read();

            //------------Assert Results-------------------------
            Assert.AreEqual(perms2.Count, securityServiceBase.Permissions.Count);
            for(int i = 0; i < perms2.Count; i++)
            {
                Assert.AreEqual(perms2[i].ResourceName, securityServiceBase.Permissions[i].ResourceName);
            }
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("SecurityServiceBase_Read")]
        public void SecurityServiceBase_Read_FiresPermissionsUpdatedEvent_HasModifiedPermissionsAsEventArgsProperty()
        {
            //------------Setup for test--------------------------
            List<WindowsGroupPermission> changedPermissions = null;
            var perms1 = new List<WindowsGroupPermission>
            {
                new WindowsGroupPermission { ResourceName = "Permission1" },
            };
            var perms2 = new List<WindowsGroupPermission>
            {
                new WindowsGroupPermission { ResourceName = "Permission1" },
                new WindowsGroupPermission { ResourceName = "Permission2" },
                new WindowsGroupPermission { ResourceName = "Permission3" },
            };
            var securityServiceBase = new TestSecurityServiceBase { ReadPermissionsResults = perms1 };
            securityServiceBase.Read();
            securityServiceBase.PermissionsModified += (sender, args) =>
            {
                changedPermissions = args.ModifiedWindowsGroupPermissions;
            };

            //----------------Assert Preconditions--------------------------
            Assert.AreEqual(perms1.Count, securityServiceBase.Permissions.Count);
            Assert.IsNull(changedPermissions);
            securityServiceBase.ReadPermissionsResults = perms2;

            //------------Execute Test---------------------------
            securityServiceBase.Read();

            //------------Assert Results-------------------------
            Assert.IsNotNull(changedPermissions);
            Assert.AreEqual(3, changedPermissions.Count);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("SecurityServiceBase_Read")]
        public void SecurityServiceBase_Read_NoChanges_FiresPermissionsUpdatedEvent_HasModifiedPermissionsAsEventArgsProperty()
        {
            //------------Setup for test--------------------------
            List<WindowsGroupPermission> changedPermissions = null;
            var perms1 = new List<WindowsGroupPermission>
            {
                new WindowsGroupPermission { ResourceName = "Permission1" },
                new WindowsGroupPermission { ResourceName = "Permission2" },
                new WindowsGroupPermission { ResourceName = "Permission3" },
            };
            var perms2 = new List<WindowsGroupPermission>
            {
                new WindowsGroupPermission { ResourceName = "Permission1" },
                new WindowsGroupPermission { ResourceName = "Permission2" },
                new WindowsGroupPermission { ResourceName = "Permission3" },
            };
            var securityServiceBase = new TestSecurityServiceBase { ReadPermissionsResults = perms1 };
            securityServiceBase.Read();
            securityServiceBase.PermissionsModified += (sender, args) =>
            {
                changedPermissions = args.ModifiedWindowsGroupPermissions;
            };

            //----------------Assert Preconditions--------------------------
            Assert.AreEqual(perms1.Count, securityServiceBase.Permissions.Count);
            Assert.IsNull(changedPermissions);
            securityServiceBase.ReadPermissionsResults = perms2;

            //------------Execute Test---------------------------
            securityServiceBase.Read();

            //------------Assert Results-------------------------
            Assert.IsNotNull(changedPermissions);
            Assert.AreEqual(3, changedPermissions.Count);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("SecurityServiceBase_Read")]
        public void SecurityServiceBase_Read_ReadPermissionsResultIsNull_PermissionsCleared()
        {
            //------------Setup for test--------------------------
            var perms1 = new List<WindowsGroupPermission>
            {
                new WindowsGroupPermission(),
                new WindowsGroupPermission()
            };
            var securityServiceBase = new TestSecurityServiceBase { ReadPermissionsResults = perms1 };
            securityServiceBase.Read();
            Assert.AreEqual(perms1.Count, securityServiceBase.Permissions.Count);

            securityServiceBase.ReadPermissionsResults = null;

            //------------Execute Test---------------------------
            securityServiceBase.Read();

            //------------Assert Results-------------------------
            Assert.AreEqual(0, securityServiceBase.Permissions.Count);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("SecurityServiceBase_Read")]
        public void SecurityServiceBase_Read_ChangeEvent_Fired()
        {
            //------------Setup for test--------------------------
            var changedEventWasFired = false;
            var securityServiceBase = new TestSecurityServiceBase();
            securityServiceBase.PermissionsChanged += (sender, args) => changedEventWasFired = true;

            //------------Execute Test---------------------------
            securityServiceBase.Read();

            //------------Assert Results-------------------------
            Assert.IsTrue(changedEventWasFired);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("SecurityServiceBase_Remove")]
        public void SecurityServiceBase_Remove_ResourceIDDoesNotExist_PermissionNotRemoved()
        {
            //------------Setup for test--------------------------
            var toBeRemovedID = Guid.NewGuid();
            var resourceID = Guid.NewGuid();
            var permissions = new List<WindowsGroupPermission>
            {
                new WindowsGroupPermission { ResourceID = resourceID, Permissions = AuthorizationContext.View.ToPermissions() }
            };

            var securityService = new TestSecurityServiceBase { ReadPermissionsResults = permissions };
            securityService.Read();

            //------------Execute Test---------------------------
            securityService.Remove(toBeRemovedID);

            //------------Assert Results-------------------------
            Assert.AreEqual(1, securityService.Permissions.Count);
            Assert.IsTrue(WindowsGroupPermissionEquals(permissions[0], securityService.Permissions[0]));
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("ServerSecurityService_Remove")]
        public void SecurityServiceBase_Remove_ResourceIDDoesExist_PermissionsRemoved()
        {
            //------------Setup for test--------------------------
            var toBeRemovedID = Guid.NewGuid();
            var resourceID = toBeRemovedID;
            var permissions = new List<WindowsGroupPermission>
            {
                new WindowsGroupPermission { ResourceID = Guid.NewGuid(), Permissions = AuthorizationContext.View.ToPermissions() },
                new WindowsGroupPermission { ResourceID = resourceID, Permissions = AuthorizationContext.View.ToPermissions() },
                new WindowsGroupPermission { ResourceID = resourceID, Permissions = AuthorizationContext.Execute.ToPermissions() }
            };

            var securityService = new TestSecurityServiceBase { ReadPermissionsResults = permissions };
            securityService.Read();

            //------------Execute Test---------------------------
            securityService.Remove(toBeRemovedID);

            //------------Assert Results-------------------------
            Assert.AreEqual(1, securityService.Permissions.Count);
            Assert.IsTrue(WindowsGroupPermissionEquals(permissions[0], securityService.Permissions[0]));
        }

        public static bool WindowsGroupPermissionEquals(WindowsGroupPermission x, WindowsGroupPermission y) => x.Permissions.Equals(y.Permissions) && x.ResourceID.Equals(y.ResourceID) && ((x.WindowsGroup == null) || x.WindowsGroup.Equals(y.WindowsGroup));
    }
}
