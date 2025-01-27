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
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;
using Dev2.Common;
using Dev2.Common.State;
using Dev2.Interfaces;

namespace Dev2.Core.Tests.Workflows
{
    public class TestActivity : Activity, IDev2Activity
    {
        public string UniqueID { get; set; }

        public enFindMissingType GetFindMissingType()
        {
            return enFindMissingType.StaticActivity;
        }

        public IDev2Activity Execute(IDSFDataObject data,int update)
        {
            return null;
        }

        public IEnumerable<IDev2Activity> NextNodes { get; set; }
        public Guid ActivityId { get; set; }
        public List<string> GetOutputs()
        {
            return new List<string>();
        }

        public string GetDisplayName()
        {
            return "";
        }
        public FlowNode GetFlowNode() => throw new NotImplementedException();
        IEnumerable<IDev2Activity> IDev2Activity.GetChildrenNodes() => throw new NotImplementedException();
        public IEnumerable<IDev2Activity> GetNextNodes() => throw new NotImplementedException();
        public List<(string Description, string Key, string SourceUniqueId, string DestinationUniqueId)> ArmConnectors() => throw new NotImplementedException();
        public IEnumerable<StateVariable> GetState() => throw new NotImplementedException();
        T IDev2Activity.As<T>() => this as T;
    }

    public class TestDecisionActivity : Activity<bool>, IDev2Activity
    {
        public string UniqueID { get; set; }

        public enFindMissingType GetFindMissingType()
        {
            return enFindMissingType.StaticActivity;
        }

        public IDev2Activity Execute(IDSFDataObject data, int update)
        {
            return null;
        }
        public string GetDisplayName()
        {
            return "";
        }
        public IEnumerable<IDev2Activity> NextNodes { get; set; }
        public Guid ActivityId { get; set; }
        public List<string> GetOutputs()
        {
            return new List<string>();
        }

        public FlowNode GetFlowNode() => throw new NotImplementedException();
        IEnumerable<IDev2Activity> IDev2Activity.GetChildrenNodes() => throw new NotImplementedException();
        public IEnumerable<IDev2Activity> GetNextNodes() => throw new NotImplementedException();
        public List<(string Description, string Key, string SourceUniqueId, string DestinationUniqueId)> ArmConnectors() => throw new NotImplementedException();
        public IEnumerable<StateVariable> GetState() => throw new NotImplementedException();
        T IDev2Activity.As<T>() => this as T;
    }
}
