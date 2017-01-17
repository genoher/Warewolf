using System;
using System.Collections.Generic;
using Dev2.Common;
using Dev2.Common.Interfaces;
using Dev2.Common.Interfaces.Toolbox;
using Dev2.Data.TO;
using Dev2.Interfaces;
using Dev2.Runtime.ServiceModel.Esb.Brokers.Plugin;
using Warewolf.Core;
using Warewolf.Resource.Errors;
using Warewolf.Storage;

namespace Dev2.Activities
{
    [ToolDescriptorInfo("DotNetDll", "DotNet DLL", ToolType.Native, "6AEB1038-6332-46F9-8BDD-641DE4EA038D", "Dev2.Acitivities", "1.0.0.0", "Legacy", "Resources", "/Warewolf.Studio.Themes.Luna;component/Images.xaml", "Tool_Resources_Dot_net_DLL")]
    public class DsfEnhancedDotNetDllActivity : DsfMethodBasedActivity
    {
        public INamespaceItem Namespace { get; set; }
        public IPluginConstructor Constructor { get; set; }
        public List<Dev2MethodInfo> MethodsToRun { get; set; }
        public List<IConstructorParameter> ConstructorInputs { get; set; }

        public DsfEnhancedDotNetDllActivity()
        {
            Type = "DotNet DLL Connector";
            DisplayName = "DotNet DLL";
            MethodsToRun = new List<Dev2MethodInfo>();
            ConstructorInputs = new List<IConstructorParameter>();
        }


        protected override void ExecutionImpl(IEsbChannel esbChannel, IDSFDataObject dataObject, string inputs, string outputs, out ErrorResultTO errors, int update)
        {
            errors = new ErrorResultTO();
            if (Namespace == null)
            {
                errors.AddError(ErrorResource.NoNamespaceSelected);
                return;
            }

            if (Constructor == null)
            {
                Constructor = new PluginConstructor();
            }


            ExecuteService(update, out errors, Constructor, Namespace, dataObject);
        }

        protected void ExecuteService(int update, out ErrorResultTO errors, IPluginConstructor constructor, INamespaceItem namespaceItem, IDSFDataObject dataObject)
        {
            errors = new ErrorResultTO();
            PluginExecutionDto pluginExecutionDto;
            if (Constructor.IsExistingObject)
            {
                var warewolfEvalResult = dataObject.Environment.Eval(Constructor.ConstructorName, update);
                var existingObject = ExecutionEnvironment.WarewolfEvalResultToString(warewolfEvalResult);
                pluginExecutionDto = new PluginExecutionDto(existingObject);
            }
            else
            {
                pluginExecutionDto = new PluginExecutionDto(string.Empty);
            }
         
            foreach (var parameter in constructor.Inputs)
            {
                var paramIterator = dataObject.Environment.Eval(parameter.Value, update);
                var resultToString = ExecutionEnvironment.WarewolfEvalResultToString(paramIterator);
                parameter.Value = resultToString;
            }
            var args = new PluginInvokeArgs
            {
                AssemblyLocation = Namespace.AssemblyLocation,
                AssemblyName = Namespace.AssemblyName,
                Fullname = namespaceItem.FullName,
                PluginConstructor = constructor,
                MethodsToRun = MethodsToRun
            };

            pluginExecutionDto.Args = args;
            try
            {
                if (!Constructor.IsExistingObject)
                {
                    pluginExecutionDto = PluginServiceExecutionFactory.CreateInstance(args);
                }

                var result = PluginServiceExecutionFactory.InvokePlugin(pluginExecutionDto);
                MethodsToRun = result.Args.MethodsToRun;// assign return values returned from the seperate AppDomain
               
            }
            catch (Exception e)
            {
                errors.AddError(e.Message);
            }
        }

        public override enFindMissingType GetFindMissingType()
        {
            return enFindMissingType.DataGridActivity;
        }

    }
}