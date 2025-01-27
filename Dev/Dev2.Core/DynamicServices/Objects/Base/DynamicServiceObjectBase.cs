#pragma warning disable
/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System.Collections.Generic;
using System.Text;
using Dev2.Common.Interfaces.Core.DynamicServices;

namespace Dev2.DynamicServices.Objects.Base
{
    public abstract class DynamicServiceObjectBase : IDynamicServiceObject
    {
        #region Constructors

        protected DynamicServiceObjectBase()
        {
            CompilerErrors = new List<string>();
        }

        protected DynamicServiceObjectBase(enDynamicServiceObjectType objectType)
            : this()
        {
            ObjectType = objectType;
        }

        #endregion

        #region Public Properties

        int _versionNo = 1;
        public string DisplayName { get; set; }
        public enApprovalState ApprovalState { get; set; }
        public string IconPath { get; set; }
        public string Tags { get; set; }
        public string OutputSpecification { get; set; }
        public StringBuilder DataListSpecification { get; set; }
        public string Name { get; set; }
        public ICollection<string> CompilerErrors { get; set; }
        public enDynamicServiceObjectType ObjectType { get; set; }
        public StringBuilder ResourceDefinition { get; set; }

        public int VersionNo
        {
            get { return _versionNo; }
            set { _versionNo = value; }
        }

        public string Comment { get; set; }
        public string Category { get; set; }
        public string HelpLink { get; set; }

        public bool IsCompiled => CompilerErrors?.Count <= 0;

        #endregion

        #region Public Methods

        public virtual bool Compile() => IsCompiled;

        #endregion
    }
}