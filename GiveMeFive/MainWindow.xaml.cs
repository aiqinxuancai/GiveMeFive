﻿using GiveMeFive.Service;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace GiveMeFive
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //this.Topmost = true;
            //this.WindowStyle = System.Windows.WindowStyle.None;
            //this.WindowState = System.Windows.WindowState.Maximized;


            //Task task = new Task(() =>
            //{
            //    for (int i = 1000; i < 999999; i++)
            //    {
            //        this.Dispatcher.BeginInvoke(DispatcherPriority.Loaded,
            //                                new Action(() =>
            //                                {
            //                                    labelName.Content = i;
            //                                }));
            //        Thread.Sleep(1);
            //    }
            //});
            //task.Start();


            //MemberManager manager = new MemberManager("");

            //var members = manager.GetRandomMembers(20);


        }



    }





}
