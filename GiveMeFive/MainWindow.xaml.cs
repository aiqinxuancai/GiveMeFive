using GiveMeFive.Service;
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

        private Luck m_luck;
        private MemberManager m_memberManager;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //this.Topmost = true;
            //this.WindowStyle = System.Windows.WindowStyle.None;
            //this.WindowState = System.Windows.WindowState.Maximized;

            //初始化奖项UI
            m_luck = new Luck(@".\Data\luck.txt");
            var luckList = m_luck.GetLuck();
            foreach (LuckSetting item in luckList)
            {
                Button button = new Button() { Content = item.name, FontSize = 36, Margin = new Thickness(0, 10, 0, 0), DataContext = item };
                button.Click += LuckButton_Click;
                pageMainPage.stackPanelLuckList.Children.Add(button);
            }

            //初始化玩家数据
            m_memberManager = new MemberManager(@".\Data\member.txt");

            ChangePage(PAGE_TYPE.PAGE_MAIN);
        }

        /// <summary>
        /// 点击主Page的Luck按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LuckButton_Click(object sender, RoutedEventArgs e)
        {
            LuckSetting item = (LuckSetting)((Button)sender).DataContext;
            //var result = m_memberManager.GetRandomMembers(item);

            //切换到对应的抽奖页面并且开始滚动
            if (item.count == 1)
            {
                ChangePage(PAGE_TYPE.PAGE_ONE);
                pageOneLuck.SetLuckData(m_luck);
                pageOneLuck.SetMemberData(m_memberManager);
                pageOneLuck.SetLuckSettingData(item);
                pageOneLuck.Start();
            }
            else
            {
                ChangePage(PAGE_TYPE.PAGE_MULTIPLE);
                pageMultipleLuck.SetLuckData(m_luck);
                pageMultipleLuck.SetMemberData(m_memberManager);
                pageMultipleLuck.SetLuckSettingData(item);
                pageMultipleLuck.Start();

            }
        }

        private void GetResult(PAGE_TYPE type)
        {
            switch (type)
            {
                case PAGE_TYPE.PAGE_ONE:
                    var listOne = m_memberManager.GetRandomMembers(pageOneLuck.m_luckSetting);
                    pageOneLuck.Stop(listOne);
                    break;
                case PAGE_TYPE.PAGE_MULTIPLE:
                    var list = m_memberManager.GetRandomMembers(pageMultipleLuck.m_luckSetting);
                    pageMultipleLuck.Stop(list);
                    break;
            }
        }




        private void MetroWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                GetResult(GetNowPageType());
            }
        }

       
        private enum PAGE_TYPE{ PAGE_MAIN, PAGE_ONE, PAGE_MULTIPLE };

        private void ChangePage (PAGE_TYPE type)
        {
            gridMainPage.Visibility = Visibility.Hidden;
            gridOneLuck.Visibility = Visibility.Hidden;
            gridMultipleLuck.Visibility = Visibility.Hidden;

            switch (type)
            {
                case PAGE_TYPE.PAGE_MAIN:
                    gridMainPage.Visibility = Visibility.Visible;
                    break;
                case PAGE_TYPE.PAGE_ONE:
                    gridOneLuck.Visibility = Visibility.Visible;
                    break;
                case PAGE_TYPE.PAGE_MULTIPLE:
                    gridMultipleLuck.Visibility = Visibility.Visible;
                    break;
            }
        }


        private PAGE_TYPE GetNowPageType()
        {
            if (gridMainPage.Visibility == Visibility.Visible)
            {
                return PAGE_TYPE.PAGE_MAIN;
            }
            else if (gridOneLuck.Visibility == Visibility.Visible)
            {
                return PAGE_TYPE.PAGE_ONE;
            } 
            else if (gridMultipleLuck.Visibility == Visibility.Visible)
            {
                return PAGE_TYPE.PAGE_MULTIPLE;
            }
            return PAGE_TYPE.PAGE_MAIN;
        }

    }





}
