using GiveMeFive.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using GiveMeFive.Page.Cell;


namespace GiveMeFive.Page
{
    /// <summary>
    /// MultipleLuckPage.xaml 的交互逻辑
    /// </summary>
    public partial class MultipleLuckPage : UserControl
    {
        private Luck m_luck;
        public LuckSetting m_luckSetting;
        private MemberManager m_memberManager;
        public bool m_stop;
        private Task m_task;
        private object m_lock = new object();

        public MultipleLuckPage()
        {
            InitializeComponent();
        }


        public void SetLuckData(Luck luck)
        {
            m_luck = luck;
        }

        public void SetLuckSettingData(LuckSetting luckSetting)
        {
            m_luckSetting = luckSetting;
            labelLuckName.Content = luckSetting.name;
        }


        public void SetMemberData(MemberManager memberManager)
        {
            m_memberManager = memberManager;
        }


        public void UpdateName(List<CompanyMember> list)
        {
            lock(m_lock)
            {

                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                {
                    double fontSize = 10d / 240d * this.ActualHeight;
                    for (int i = 0; i < list.Count; i++)
                    {
                        ((MultipleLuckMemberCellVersionTwo)stackPanelMultipleLuck.Children[i]).MemberName = list[i].name;
                        ((MultipleLuckMemberCellVersionTwo)stackPanelMultipleLuck.Children[i]).MemberDepartment = list[i].department;
                    }
                }));
            }

        }


        public void Start()
        {
            stackPanelMultipleLuck.Children.Clear();
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
            {
                for (int i = 0; i < m_luckSetting.count; i++)
                {
                    MultipleLuckMemberCellVersionTwo cell = new MultipleLuckMemberCellVersionTwo();
              
                    stackPanelMultipleLuck.Children.Add(cell);
                }
            }));


            //添加对应的数据
            m_task = new Task(() =>
            {
                m_stop = false;

                while (m_stop == false)
                {
                    var list = m_memberManager.GetRandomMembersForShow(m_luckSetting);
                    if (list.Count == 0)
                    {
                        m_stop = true;
                    }


                    //stackPanelMultipleLuck

                    UpdateName(list);
                    Thread.Sleep(10);
                }
            });
            m_task.Start();
        }

        public void Stop(List<CompanyMember> list)
        {
            m_stop = true;
            if (list != null )
            {
                m_task.Wait();
                Thread.Sleep(10);
                UpdateName(list);
            }
        }




    }
}
