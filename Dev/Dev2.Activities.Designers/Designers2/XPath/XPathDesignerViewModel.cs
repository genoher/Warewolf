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
using System.Activities.Presentation.Model;
using System.Collections.Generic;
using System.Windows;
using Dev2.Activities.Designers2.Core;
using Dev2.Common.Interfaces.Infrastructure.Providers.Errors;
using Dev2.Common.Interfaces.Infrastructure.Providers.Validation;
using Dev2.Data.Util;
using Dev2.Providers.Validation.Rules;
using Dev2.Studio.Core;
using Dev2.Studio.Core.Activities.Utils;
using Dev2.Studio.Interfaces;
using Dev2.Validation;
using Unlimited.Applications.BusinessDesignStudio.Activities;

namespace Dev2.Activities.Designers2.XPath
{
    public class XPathDesignerViewModel : ActivityCollectionDesignerViewModel<XPathDTO>
    {
        internal Func<string> GetDatalistString = () => DataListSingleton.ActiveDataList.Resource.DataList;
        public XPathDesignerViewModel(ModelItem modelItem)
            : base(modelItem)
        {
            AddTitleBarLargeToggle();
            AddTitleBarQuickVariableInputToggle();
            dynamic mi = ModelItem;
            InitializeItems(mi.ResultsCollection);
            HelpText = Warewolf.Studio.Resources.Languages.HelpText.Tool_Utility_Xpath;
        }
        public override string CollectionName => "ResultsCollection";


        public bool IsSourceStringFocused { get => (bool)GetValue(IsSourceStringFocusedProperty); set => SetValue(IsSourceStringFocusedProperty, value); }
        public static readonly DependencyProperty IsSourceStringFocusedProperty = DependencyProperty.Register("IsSourceStringFocused", typeof(bool), typeof(XPathDesignerViewModel), new PropertyMetadata(default(bool)));

        string SourceString => GetProperty<string>();

        protected override IEnumerable<IActionableErrorInfo> ValidateThis()
        {            
            foreach(var error in GetRuleSet("SourceString").ValidateRules("'XML'", () => IsSourceStringFocused = true))            
            {
                yield return error;
            }
        }

        IRuleSet GetRuleSet(string propertyName)
        {
            var ruleSet = new RuleSet();

            switch (propertyName)
            {
                case "SourceString":
                    ruleSet.Add(new IsStringEmptyOrWhiteSpaceRule(() => SourceString));

                    if (!string.IsNullOrEmpty(SourceString) && !DataListUtil.IsEvaluated(SourceString))
                    {
                        ruleSet.Add(new IsValidXmlRule(() => SourceString));
                    }

                    var outputExprRule = new IsValidExpressionRule(() => SourceString, GetDatalistString?.Invoke(), "1", new VariableUtils());
                    ruleSet.Add(outputExprRule);

                    break;
                default:
                    break;
            }
            return ruleSet;
        }

        protected override IEnumerable<IActionableErrorInfo> ValidateCollectionItem(ModelItem mi)
        {
            var dto = mi.GetCurrentValue() as XPathDTO;
            if(dto == null)
            {
                yield break;
            }

            foreach(var error in dto.GetRuleSet("OutputVariable", GetDatalistString?.Invoke()).ValidateRules("'Results'", () => mi.SetProperty("IsOutputVariableFocused", true)))
            {
                yield return error;
            }
            foreach(var error in dto.GetRuleSet("XPath", GetDatalistString?.Invoke()).ValidateRules("'XPath'", () => mi.SetProperty("IsXpathVariableFocused", true)))
            {
                yield return error;
            }
        }

        public override void UpdateHelpDescriptor(string helpText)
        {
            var mainViewModel = CustomContainer.Get<IShellViewModel>();
            mainViewModel?.HelpViewModel.UpdateHelpText(helpText);
        }
    }
}
