﻿#pragma warning disable
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
using System.Windows.Media;
using Dev2;
using Dev2.Common.Interfaces.Help;
using Microsoft.Practices.Prism.Mvvm;
using Warewolf.Core;

namespace Warewolf.Studio.ViewModels.Help
{
    public class HelpWindowViewModel : BindableBase, IHelpWindowViewModel, IDisposable
    {
        IHelpDescriptorViewModel _currentHelpText;
        readonly IHelpDescriptorViewModel _defaultViewModel;
        bool _webPageVisible;

        public HelpWindowViewModel(IHelpDescriptorViewModel defaultViewModel, IHelpWindowModel model)
        {
            VerifyArgument.AreNotNull(new Dictionary<string, object> { { "defaultViewModel", defaultViewModel }, { "model", model } });
            _defaultViewModel = defaultViewModel;
            CurrentHelpText = _defaultViewModel;
            HelpModel = model;
            model.OnHelpTextReceived += OnHelpTextReceived;
        }

        public string HelpText => CurrentHelpText.Description;

        public string HelpName => CurrentHelpText.Name;

        public DrawingImage HelpImage => CurrentHelpText.Icon as DrawingImage;

        void OnHelpTextReceived(object sender, IHelpDescriptor desc)
        {
            try
            {
                CurrentHelpText = new HelpDescriptorViewModel(desc);
            }
            catch (Exception)
            {
                CurrentHelpText = _defaultViewModel;
                throw;
            }

        }

        public IHelpWindowModel HelpModel { get; private set; }

        #region Implementation of IHelpWindowViewModel

        /// <summary>
        /// Wpf component binds here
        /// </summary>
        public IHelpDescriptorViewModel CurrentHelpText
        {
            get
            {
                return _currentHelpText;
            }
            set
            {
                _currentHelpText = value;
                OnPropertyChanged(() => HelpName);
                OnPropertyChanged(() => HelpText);
                OnPropertyChanged(() => HelpImage);
            }
        }
        public bool WebPageVisible
        {
            get
            {
                return _webPageVisible;
            }
            set
            {
                _webPageVisible = value;
                OnPropertyChanged(() => WebPageVisible);
            }
        }

        public void UpdateHelpText(string helpText)
        {
            if (string.IsNullOrWhiteSpace(helpText))
            {
                var textToDisplay = Resources.Languages.Core.StandardStyling.Replace("\r\n", "") +
                                    Resources.Languages.HelpText.WarewolfDefaultHelpDescription +
                                    Resources.Languages.Core.StandardBodyParagraphClosing;
                CurrentHelpText = new HelpDescriptorViewModel(new HelpDescriptor("", textToDisplay, null));
                WebPageVisible = true;
            }
            else
            {
                WebPageVisible = false;
                var textToDisplay = Resources.Languages.Core.StandardStyling.Replace("\r\n", "") +
                                    helpText +
                                    Resources.Languages.Core.StandardBodyParagraphClosing;
                CurrentHelpText = new HelpDescriptorViewModel(new HelpDescriptor("", textToDisplay, null));
            }
            OnPropertyChanged(() => WebPageVisible);
        }

        #endregion

        #region Implementation of IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
        void Dispose(bool disposing)
        {
            if (disposing)
            {
                HelpModel.OnHelpTextReceived -= OnHelpTextReceived;
            }
        }

        #endregion
    }
}
