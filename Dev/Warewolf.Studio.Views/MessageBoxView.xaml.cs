﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using Warewolf.Studio.Core;

namespace Warewolf.Studio.Views
{
    /// <summary>
    /// Interaction logic for MessageBoxView.xaml
    /// </summary>
    public partial class MessageBoxView
    {
        readonly Grid _blackoutGrid = new Grid();
        private bool _openDependencyGraph;
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

        private void Hyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            var resourcePath = sender as Hyperlink;
            if (resourcePath != null)
            {
                var listStrLineElements = resourcePath.NavigateUri.OriginalString.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                if (File.Exists(listStrLineElements[1]))
                {
                    var input = listStrLineElements[1].Remove(listStrLineElements[1].LastIndexOf(@"\", StringComparison.Ordinal) + 1);
                    Process.Start(input);
                }
                if (File.Exists(listStrLineElements[2]))
                {
                    var input = listStrLineElements[2].Remove(listStrLineElements[2].LastIndexOf(@"\", StringComparison.Ordinal) + 1);
                    Process.Start(input);
                }
            }
        }
    }
}
