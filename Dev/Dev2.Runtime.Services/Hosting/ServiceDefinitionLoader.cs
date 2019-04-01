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
using System.Text;
using System.Xml.Linq;
using Dev2.Common;
using Dev2.Common.Common;
using Dev2.Common.Interfaces.Core.DynamicServices;
using Dev2.DynamicServices;
using Dev2.DynamicServices.Objects;
using Dev2.DynamicServices.Objects.Base;

namespace Dev2.Runtime.Hosting
{
    #region Service MetaData

    public class ServiceMetaData
    {
        public static ServiceMetaData ExtractMetaData(XElement xe, ref DynamicServiceObjectBase obj)
        {
            var result = new ServiceMetaData();

            var tmp = ExtractValue(xe, "Category");
            obj.Category = tmp;

            tmp = ExtractValue(xe, "DisplayName");
            obj.DisplayName = tmp;

            tmp = ExtractValue(xe, "Comment");
            obj.Comment = tmp;

            tmp = ExtractValue(xe, "IconPath");
            obj.IconPath = tmp;

            tmp = ExtractValue(xe, "HelpLink");
            obj.HelpLink = tmp;

            tmp = ExtractValue(xe, "DataList", true);
            obj.DataListSpecification = new StringBuilder(tmp);

            obj.Name = xe.AttributeSafe("Name");

            return result;
        }

        public static string ExtractValue(XElement xe, string elementName) => ExtractValue(xe, elementName, false);
        
        public static string ExtractValue(XElement xe, string elementName,bool useElementSafe)
        {
            var tmp = xe.Element(elementName);

            if(tmp != null)
            {
                var extractValue = tmp.Value;
                if (useElementSafe)
                {
                    extractValue = xe.ElementStringSafe(elementName);
                }

                return extractValue;
            }

            return string.Empty;
        }

        public static Guid SetID(ref XElement xe)
        {
            var id = new Guid();

            var tmpId = xe.AttributeSafe("ID");

            if(!string.IsNullOrEmpty(tmpId))
            {
                Guid.TryParse(tmpId, out id);
            }
            else
            {
                xe.Add(new XAttribute("ID", id.ToString()));
            }

            return id;

        }
    }

    #endregion

    public class ServiceDefinitionLoader
    {
        public List<DynamicServiceObjectBase> GenerateServiceGraph(StringBuilder serviceData)
        {
            if(serviceData == null || serviceData.Length == 0)
            {
                throw new ArgumentException("serviceData");
            }
            var result = new List<DynamicServiceObjectBase>();
            var xe = serviceData.ToXElement();

            if(IsSource(serviceData))
            {
                var src = new Source();
                var tmp = src as DynamicServiceObjectBase;
                ServiceMetaData.ExtractMetaData(xe, ref tmp);

                var typeOf = xe.AttributeSafe("ResourceType");

                src.Type = !Enum.TryParse(typeOf, out enSourceType sourceType) ? enSourceType.Unknown : sourceType;

                src.ConnectionString = xe.AttributeSafe("ConnectionString");
                src.AssemblyName = xe.AttributeSafe("AssemblyName");
                src.AssemblyLocation = xe.AttributeSafe("AssemblyLocation");

                // PBI 6597: TWR - added source ID check
                var id = ServiceMetaData.SetID(ref xe);
                src.ID = id;
                src.ResourceDefinition = serviceData;

                result.Add(src);

            }
            else
            {
                var ds = new DynamicService();
                var tmp = ds as DynamicServiceObjectBase;
                ServiceMetaData.ExtractMetaData(xe, ref tmp);

                // set the resource def ;)
                ds.ResourceDefinition = serviceData;

                var actions = xe.Element("Actions");
                var action = actions != null ? actions.Element("Action") : xe.Element("Action");

                if (action != null)
                {
                    xe = AddServiceAction(serviceData, result, xe, ds, action);
                }

            }
            return result;
        }

        private XElement AddServiceAction(StringBuilder serviceData, List<DynamicServiceObjectBase> result, XElement xe, DynamicService ds, XElement action)
        {
            var sa = new ServiceAction { Name = action.AttributeSafe("Name"), ResourceDefinition = serviceData };

            // Set service action ;)
            var typeOf = action.AttributeSafe("Type");
            if (Enum.TryParse(typeOf, out enActionType actionType))
            {
                sa.ActionType = actionType;
            }

            var element = action.Element("Outputs");
            if (element != null)
            {
                sa.OutputSpecification = element.Value;
            }

            // set name and id ;)
            sa.ServiceName = ds.Name;
            var id = ServiceMetaData.SetID(ref xe);
            ds.ID = id;

            if (IsWorkflow(serviceData))
            {
                // Convert to StringBuilder
                var xElement = action.Element("XamlDefinition");
                if (xElement != null)
                {
                    var def = xElement.ToStringBuilder();
                    def = def.Replace("<XamlDefinition>", "").Replace("</XamlDefinition>", "");
                    sa.XamlDefinition = def.Unescape();
                }

                var dataList = xe.Element("DataList");
                if (dataList != null)
                {
                    ds.DataListSpecification = dataList.ToStringBuilder();
                }
            }
            else
            {
                sa = AddServiceAction(sa, action);
            }

            // add the action
            ds.Actions.Add(sa);
            result.Add(ds);
            return xe;
        }

        static ServiceAction AddServiceAction(ServiceAction sa, XElement action)
        {
            if (sa.ActionType == enActionType.InvokeStoredProc)
            {
                Int32.TryParse(action.AttributeSafe("CommandTimeout"), out int timeout);
                sa.CommandTimeout = timeout;
            }

            var xElement = action.Element("OutputDescription");
            if (xElement != null)
            {
                sa.OutputDescription = xElement.Value;
            }

            // process inputs and outputs ;)
            var inputs = action.Element("Inputs");

            if (inputs != null)
            {
                var inputCollection = inputs.Elements("Input");

                foreach (var inputItem in inputCollection)
                {
                    bool.TryParse(inputItem.AttributeSafe("EmptyToNull"), out bool emptyToNull);

                    var sai = new ServiceActionInput
                    {
                        Name = inputItem.AttributeSafe("Name"),
                        Source = inputItem.AttributeSafe("Source"),
                        DefaultValue = inputItem.AttributeSafe("DefaultValue"),
                        EmptyToNull = emptyToNull,
                        NativeType = inputItem.AttributeSafe("NativeType")
                    };

                    if (string.IsNullOrEmpty(sai.NativeType))
                    {
                        sai.NativeType = "object";
                    }

                    // handle validators ;)
                    var validators = inputItem.Elements("Validator");
                    foreach (var validator in validators)
                    {
                        var v = new Validator
                        {
                            ValidatorType = !Enum.TryParse(validator.AttributeSafe("Type"), out enValidationType validatorType) ? enValidationType.Required : validatorType
                        };

                        sai.Validators.Add(v);
                    }

                    sa.ServiceActionInputs.Add(sai);
                }
            }
            return sa;
        }

        bool IsSource(StringBuilder serviceData) => serviceData.IndexOf("<Source ", 0, false) == 0;

        bool IsWorkflow(StringBuilder serviceData)
        {

            var startIdx = serviceData.IndexOf("<XamlDefinition>", 0, false);
            if(startIdx >= 0)
            {
                var endIdx = serviceData.IndexOf("</XamlDefinition>", startIdx, false);
                var dif = endIdx - startIdx;

                // we know a blank wf is larger then our max string size ;)
                return startIdx > 0 && dif > GlobalConstants.MAX_SIZE_FOR_STRING - 1024;
            }

            return false;
        }
    }
}
