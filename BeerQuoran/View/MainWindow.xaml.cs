﻿using BeerQuoran.ViewModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Xaml.Behaviors;
using System.Windows.Media.Animation;

namespace BeerQuoran
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (DataContext is WindowCommands windowCommand)
            {
                windowCommand.StartFilterAnimationRequested += OnStartAnimationRequested;
                windowCommand.StartSearchBoxAnimationRequested += OnStartSearchBoxAnimRequest;
            }
        }

        private void OnStartSearchBoxAnimRequest(object? sender, EventArgs e)
        {
            switch (tbx_search.Width)
            {
                case 0:
                    tbx_search.Visibility = Visibility.Visible;
                    tbl_search.Visibility = Visibility.Collapsed;
                    var storyboard = Resources["SearchBoxExpand"] as Storyboard;
                    storyboard?.Begin();
                    break;
                default:
                    storyboard = Resources["SearchBoxCollpase"] as Storyboard;
                    if (storyboard != null)
                    {
                        storyboard.Completed += (sender, e) =>
                        {
                            tbx_search.Visibility = Visibility.Collapsed;
                            tbl_search.Visibility = Visibility.Visible;
                        };
                    }
                    storyboard?.Begin();
                    break;
            }
        }

        private void OnStartAnimationRequested(object sender, EventArgs e)
        {          
            switch (br_filterHolder.Height)
            {
                case 45:
                    var storyboard = Resources["FilterHeightExpand"] as Storyboard;
                    storyboard?.Begin();
                    break;

                default:
                    storyboard = Resources["FilterHeightCollapse"] as Storyboard;
                    storyboard?.Begin();
                    break;
            }
        }
    }
}
