using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GiveMeFive.Page
{
    /// <summary>
    /// MultipleLuckMemberCell.xaml 的交互逻辑
    /// </summary>
    public partial class MultipleLuckMemberCell : UserControl
    {
        public string MemberName { set; get; }
        public string MemberDepartment { set; get; }

        public MultipleLuckMemberCell(string memberName, string memberDepartment)
        {
            this.MemberName = memberName;
            this.MemberDepartment = memberDepartment;

            this.DataContext = this;
            InitializeComponent();



        }


        public MultipleLuckMemberCell()
        {
            InitializeComponent();
        }
    }
}
