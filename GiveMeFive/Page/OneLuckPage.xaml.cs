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
        private LuckSetting m_luckSetting;
        private MemberManager m_memberManager;
        private bool m_stop;

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

        public void Start()
        {

            Task task = new Task(() =>
            {

                m_stop = false;

                while (m_stop == false)
                {
                    this.Dispatcher.BeginInvoke(DispatcherPriority.Loaded,
                        new Action(() =>
                        {
                            labelName.Content = m_memberManager.GetRandomMembersForShow(m_luckSetting);
                        }));
                    Thread.Sleep(1);
                }
            });
            task.Start();



        }

        public void Stop()
        {
            m_stop = true;
        }
    }
}
