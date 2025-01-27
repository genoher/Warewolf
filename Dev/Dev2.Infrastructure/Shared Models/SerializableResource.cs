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

using System;
using System.Collections.Generic;
using Dev2.Common.Interfaces.Security;
using Dev2.Common.Interfaces.Versioning;
using Dev2.Providers.Errors;


namespace Dev2.Data.ServiceModel

{

    /// <summary>
    /// Light weight resource to ship to the studio ;)
    /// </summary>
    public class SerializableResource
    {
        /// <summary>
        /// The resource ID that uniquely identifies the resource.
        /// </summary>

        public Guid ResourceID { get; set; }


        /// <summary>
        /// The display name of the resource.
        /// </summary>
        public string ResourceName { get; set; }

        /// <summary>
        /// Gets or sets the type of the resource.
        /// </summary>
        public string ResourceType { get; set; }

        /// <summary>
        /// Gets or sets the category of the resource.
        /// </summary>   
        public string ResourceCategory { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is valid].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is valid]; otherwise, <c>false</c>.
        /// </value>
        public bool IsValid { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is new resource].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is new resource]; otherwise, <c>false</c>.
        /// </value>
        public bool IsNewResource { get; set; }

        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        public List<ErrorInfo> Errors { get; set; }

        /// <summary>
        /// Gets or sets the data list.
        /// </summary>
        /// <value>
        /// The data list.
        /// </value>
        public string DataList { get; set; }

        /// <summary>
        /// Gets or sets the inputs.
        /// </summary>
        /// <value>
        /// The inputs.
        /// </value>
        public string Inputs { get; set; }

        /// <summary>
        /// Gets or sets the outputs.
        /// </summary>
        /// <value>
        /// The outputs.
        /// </value>
        public string Outputs { get; set; }


        public IVersionInfo VersionInfo { get; set; }

        /// <summary>
        /// Gets or sets the permissions of the resource
        /// </summary>
        public Permissions Permissions { get; set; }

        public bool IsSource
        {
            get;
            set;
        }
        public bool IsService
        {
            get;
            set;
        }
        public bool IsFolder
        {
            get;
            set;
        }
        public bool IsReservedService
        {
            get;
            set;
        }
        public bool IsServer
        {
            get;
            set;
        }
        public bool IsResourceVersion
        {
            get;
            set;
        }
    }
}
