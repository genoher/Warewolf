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
using System.Windows.Input;
using Dev2.Common.Interfaces.Data.TO;

namespace Dev2.Common.Interfaces.Queue
{
    public interface IQueueResource : IEquatable<IQueueResource>
    {
        /// <summary>
        ///     Property to check if the queue resouce is saved
        /// </summary>
        bool IsDirty { get; set; }

        /// <summary>
        ///     Queue Name
        /// </summary>
        string QueueName { get; set; }

        /// <summary>
        ///     Represents the old name of the task
        /// </summary>
        string OldName { get; set; }

        /// <summary>
        ///     Queue Status
        /// </summary>
        QueueStatus Status { get; set; }

        /// <summary>
        ///     The workflow that we will run
        /// </summary>
        string WorkflowName { get; set; }


        /// <summary>
        ///     The workflow that we will run
        /// </summary>
        Guid ResourceId { get; set; }

        /// <summary>
        ///     The task UserName
        /// </summary>
        string UserName { get; set; }

        //The task password
        string Password { get; set; }

        /// <summary>
        ///     validation errors
        /// </summary>
        IErrorResultTO Errors { get; set; }

        bool IsNew { get; set; }

        bool IsNewItem { get; }
        string NameForDisplay { get; }
        string Name { get; set; }
    }

    public interface INewQueuedResource
    {
        ICommand NewCommand { get; set; }
    }

   
}