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
using System.IO;
using System.Text;
using Dev2.Common;
using Dev2.Communication;
using Dev2.DynamicServices;
using Dev2.Workspaces;
using Warewolf.Resource.Errors;

namespace Dev2.Runtime.ESB.Management.Services
{
    public class ClearLog : DefaultEsbManagementEndpoint
    {
        public override StringBuilder Execute(Dictionary<string, StringBuilder> values, IWorkspace theWorkspace)
        {
            var result = new ExecuteMessage { HasError = false };
            var msg = new StringBuilder();
            string directory = null;

            values.TryGetValue("Directory", out StringBuilder tmp);
            if (tmp != null)
            {
                directory = tmp.ToString();
            }

            if(string.IsNullOrWhiteSpace(directory))
            {
                AppendError(msg, directory, ErrorResource.CannotDeleteFileWithoughtDirectory);
            }
            else if(!Directory.Exists(directory))
            {
                AppendError(msg, directory, string.Format(ErrorResource.DirectoryNotFound, directory));
            }
            else
            {
                try
                {
                    var files = Directory.GetFiles(directory);

                    foreach(var file in files)
                    {
                        File.Delete(file);
                    }

                    msg.Append("Success");
                }
                catch(Exception ex)
                {
                    AppendError(msg, directory, ex.Message);
                    Dev2Logger.Info(ex.StackTrace, GlobalConstants.WarewolfInfo);
                }
            }

            result.Message.Append(msg);

            var serializer = new Dev2JsonSerializer();

            return serializer.SerializeToBuilder(result);

        }

        static void AppendError(StringBuilder result, string directory, string msg)
        {
            result.AppendFormat("Error clearing '{0}'...", directory);
            result.AppendLine();
            result.Append($"Error: {msg}");
        }

        public override DynamicService CreateServiceEntry() => EsbManagementServiceEntry.CreateESBManagementServiceEntry(HandlesType(), "<DataList><Directory ColumnIODirection=\"Input\"/><Dev2System.ManagmentServicePayload ColumnIODirection=\"Both\"></Dev2System.ManagmentServicePayload></DataList>");

        public override string HandlesType() => "ClearLogService";
    }
}
