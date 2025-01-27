﻿/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using Dev2.Common.Interfaces.Diagnostics.Debug;
using Dev2.Common.Interfaces.Scheduler.Interfaces;
using System.Collections.Generic;

namespace Dev2.Core.Tests.Triggers
{
    public class ResourceHistoryForTest : IResourceHistory
    {
        public string WorkflowOutput { get; private set; }
        public IList<IDebugState> DebugOutput { get; private set; }
        public IEventInfo TaskHistoryOutput { get; private set; }
        public string UserName { get; set; }
    }
}
