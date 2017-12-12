using GiveMeFive.Service;
using System;
using System.Collections.Generic;
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

namespace GiveMeFive.Page
{
    /// <summary>
    /// OneLuckPage.xaml 的交互逻辑
    /// </summary>
    public partial class OneLuckPage : UserControl
    {
        private Luck m_luck;
        public LuckSetting m_luckSetting;
        private MemberManager m_memberManager;
        private bool m_stop;
        private Task m_task;
        private object m_lock = new object();


        public OneLuckPage()
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
        }


        public void SetMemberData(MemberManager memberManager)
        {
            m_memberManager = memberManager;
        }

        public void UpdateName(string name)
        {
            lock(m_lock)
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                {
                    labelName.Content = name;
                }));
            }
        }

        public void Start()
        {
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
                    UpdateName(list[0]?.name);
                    Thread.Sleep(10);
                }
            });
            m_task.Start();
        }

        public void Stop(List<CompanyMember> list)
        {
            m_stop = true;
            m_task.Wait();
            Thread.Sleep(10);
            UpdateName(list[0]?.name);
        }



    }
}
