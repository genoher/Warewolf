#pragma warning disable
﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using Warewolf.Studio.Core;
using Warewolf.Studio.ViewModels;

namespace Warewolf.Studio.Views
{
    public partial class MessageBoxView
    {
        readonly Grid _blackoutGrid = new Grid();
        bool _openDependencyGraph;
        public bool OpenDependencyGraph => _openDependencyGraph;

        public MessageBoxView()
        {
            InitializeComponent();
            PopupViewManageEffects.AddBlackOutEffect(_blackoutGrid);
        }

        void MessageBoxView_OnClosing(object sender, CancelEventArgs e)
        {
            PopupViewManageEffects.RemoveBlackOutEffect(_blackoutGrid);
        }

        void BtnDependencies_OnClick(object sender, RoutedEventArgs e)
        {
            _openDependencyGraph = true;
            DialogResult = false;
        }

        void Hyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            if (sender is Hyperlink resourcePath)
            {
                var listStrLineElements = resourcePath.NavigateUri.OriginalString.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                for (int i = 1; i < listStrLineElements.Count; i++)
                {
                    Process.Start("explorer.exe", "/select," + listStrLineElements[i]);
                }
            }
        }

        void MessageBoxView_OnLoaded(object sender, RoutedEventArgs e)
        {
            var messageBoxViewModel = DataContext as MessageBoxViewModel;
            if (messageBoxViewModel != null && messageBoxViewModel.IsYesButtonVisible)
            {
                BtnYesCommand.Focusable = true;
                BtnYesCommand.Focus();
            }
            if (messageBoxViewModel != null && messageBoxViewModel.IsOkButtonVisible)
            {
                BtnOkCommand.Focusable = true;
                BtnOkCommand.Focus();
            }
        }

        void MessageBoxView_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }

#pragma warning disable S1541 // Methods and properties should not be too complex
        void MessageBoxView_OnPreviewKeyDown(object sender, KeyEventArgs e)
#pragma warning restore S1541 // Methods and properties should not be too complex
        {
            if ((Keyboard.Modifiers == (ModifierKeys.Alt | ModifierKeys.Control)) && (e.Key == Key.F4) && Application.Current != null)
            {
                CloseAllWindows();
            }

            if (e.Key == Key.Escape)
            {
                var messageBoxViewModel = DataContext as MessageBoxViewModel;
                if (messageBoxViewModel != null && messageBoxViewModel.IsYesButtonVisible)
                {
                    BtnYesCommand.Focusable = false;
                    BtnYesCommand.Focus();
                }
                if (messageBoxViewModel != null && messageBoxViewModel.IsOkButtonVisible)
                {
                    BtnOkCommand.Focusable = false;
                    BtnOkCommand.Focus();
                }
                if (messageBoxViewModel != null && messageBoxViewModel.IsCancelButtonVisible)
                {
                    BtnCancelCommand.Focusable = true;
                    BtnCancelCommand.Focus();
                }
                if (messageBoxViewModel != null && messageBoxViewModel.IsNoButtonVisible)
                {
                    BtnNoCommand.Focusable = true;
                    BtnNoCommand.Focus();
                }
            }
        }

        private static void CloseAllWindows()
        {
            var windowCollection = Application.Current.Windows;
            foreach (var window in windowCollection)
            {
                if (window is Window window1 && window1.Name != "MainViewWindow")
                {
                    window1.Close();
                }
            }
        }

        void BtnDeleteAll_OnClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is MessageBoxViewModel messageBoxViewModel)
            {
                messageBoxViewModel.IsDeleteAnywaySelected = true;
            }
            DialogResult = false;
        }
    }
}
