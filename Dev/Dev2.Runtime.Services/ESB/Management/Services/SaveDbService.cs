#pragma warning disable
﻿/*
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
using System.Linq;
using System.Text;
using Dev2.Common;
using Dev2.Common.Interfaces.DB;
using Dev2.Common.Interfaces.Enums;
using Dev2.Common.Interfaces.Infrastructure;
using Dev2.Communication;
using Dev2.Converters.Graph.DataTable;
using Dev2.DynamicServices;
using Dev2.Runtime.Hosting;
using Dev2.Runtime.ServiceModel.Data;
using Dev2.Workspaces;
using Warewolf.Core;


namespace Dev2.Runtime.ESB.Management.Services
{
    public class SaveDbService : IEsbManagementEndpoint
    {
        public Guid GetResourceID(Dictionary<string, StringBuilder> requestArgs) => Guid.Empty;

        public AuthorizationContext GetAuthorizationContextForService() => AuthorizationContext.Contribute;

        IExplorerServerResourceRepository _serverExplorerRepository;       
        
        public StringBuilder Execute(Dictionary<string, StringBuilder> values, IWorkspace theWorkspace)
        {
            var msg = new ExecuteMessage();
            var serializer = new Dev2JsonSerializer();
            try
            {
                Dev2Logger.Info("Save Resource Service", GlobalConstants.WarewolfInfo);
                values.TryGetValue("DbService", out StringBuilder resourceDefinition);
                IDatabaseService service = serializer.Deserialize<DatabaseService>(resourceDefinition);                
                var parameters = service.Inputs?.Select(a => new MethodParameter() { EmptyToNull = a.EmptyIsNull, IsRequired = a.RequiredField, Name = a.Name, Value = a.Value }).ToList() ?? new List<MethodParameter>();                
                var source = ResourceCatalog.Instance.GetResource<DbSource>(GlobalConstants.ServerWorkspaceID, service.Source.Id);
                var output = new List<MethodOutput>(service.OutputMappings.Select(a => new MethodOutput(a.MappedFrom, a.MappedTo, "", false, a.RecordSetName, false, "", false, "", false)));
                var recset = new Recordset();
                recset.Fields.AddRange(new List<RecordsetField>(service.OutputMappings.Select(a => new RecordsetField { Name = a.MappedFrom, Alias = a.MappedTo, RecordsetAlias = a.RecordSetName, Path = new DataTablePath(a.RecordSetName, a.MappedFrom) })));
                recset.Name = service.Name;
                var res = new DbService
                {
                    Method = new ServiceMethod(service.Action.Name, service.Name, parameters, null, output, service.Action.Name),
                    ResourceName = service.Name,
                    ResourceID = service.Id,
                    Source = source,
                    Recordset = recset
                };
                ResourceCatalog.Instance.SaveResource(GlobalConstants.ServerWorkspaceID, res, service.Path);
                ServerExplorerRepo.UpdateItem(res);
                msg.HasError = false;
            }

            catch (Exception err)
            {
                msg.HasError = true;
                msg.Message = new StringBuilder(err.Message);
                Dev2Logger.Error(err, GlobalConstants.WarewolfError);
            }

            return serializer.SerializeToBuilder(msg);
        }

        public IExplorerServerResourceRepository ServerExplorerRepo
        {
            get => _serverExplorerRepository ?? ServerExplorerRepository.Instance;
            set => _serverExplorerRepository = value;
        }

        public DynamicService CreateServiceEntry() => EsbManagementServiceEntry.CreateESBManagementServiceEntry(HandlesType(), "<DataList><Roles ColumnIODirection=\"Input\"/><DbService ColumnIODirection=\"Input\"/><WorkspaceID ColumnIODirection=\"Input\"/><Dev2System.ManagmentServicePayload ColumnIODirection=\"Both\"></Dev2System.ManagmentServicePayload></DataList>");

        public string HandlesType() => "SaveDbService";
    }
}
