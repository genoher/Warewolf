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
using Dev2.Common.ExtMethods;
using Dev2.Common.Interfaces.Enums.Enums;
using Dev2.Common.Lookups;
using Dev2.Studio.Interfaces;

namespace Dev2.Activities.Designers2.Zip
{
    public class ZipDesignerViewModel : FileActivityDesignerViewModel
    {
        public IList<string> CompressionRatioList { get; private set; }

        public ZipDesignerViewModel(ModelItem modelItem)
            : base(modelItem, "File or Folder", "Destination")
        {
            AddTitleBarLargeToggle();

            CompressionRatioList = Dev2EnumConverter.ConvertEnumsTypeToStringList<CompressionRatios>();

            var selectionRatio = string.IsNullOrEmpty(CompressionRatio)
                ? CompressionRatios.Default
                : (CompressionRatios)Enum.Parse(typeof(CompressionRatios), CompressionRatio);

            SelectedCompressionRatioDescription = selectionRatio.GetDescription();
            HelpText = Warewolf.Studio.Resources.Languages.HelpText.Tool_File_Zip;
        }

        public string SelectedCompressionRatioDescription
        {
            get { return (string)GetValue(SelectedCompressionRatioDescriptionProperty); }
            set { SetValue(SelectedCompressionRatioDescriptionProperty, value); }
        }

        public static readonly DependencyProperty SelectedCompressionRatioDescriptionProperty = DependencyProperty.Register("SelectedCompressionRatioDescription", typeof(string), typeof(ZipDesignerViewModel), new PropertyMetadata(default(string), OnSelectedCompressionRatioDescriptionPropertyChanged));

        static void OnSelectedCompressionRatioDescriptionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            var viewModel = (ZipDesignerViewModel)d;
            var description = args.NewValue as string;

            var enumValue = Dev2EnumConverter.GetEnumFromStringDiscription(description, typeof(CompressionRatios));
            if(enumValue != null)
            {
                viewModel.CompressionRatio = enumValue.ToString();
            }
        }
        
        string CompressionRatio
        {
            set { SetProperty(value); }
            get { return GetProperty<string>(); }
        }

        public override void Validate()
        {
            Errors = null;
            var password = ArchivePassword;
            ValidateUserNameAndPassword();
            ValidateDestinationUsernameAndPassword();
            ValidateInputAndOutputPaths();
            ValidateArchivePassword(password, "Archive Password");
        }

        string ArchivePassword => GetProperty<string>();

        public override void UpdateHelpDescriptor(string helpText)
        {
            var mainViewModel = CustomContainer.Get<IShellViewModel>();
            mainViewModel?.HelpViewModel.UpdateHelpText(helpText);
        }
    }
}

