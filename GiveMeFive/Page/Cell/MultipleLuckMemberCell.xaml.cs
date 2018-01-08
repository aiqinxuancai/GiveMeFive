﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace GiveMeFive.Page.Cell
{

    public enum MultipleLuckMemberCellShowType
    {
        MAX = 0,
        MIN = 1
    }

    /// <summary>
    /// 上下排序的抽奖Cell
    /// </summary>
    public partial class MultipleLuckMemberCell : UserControl, INotifyPropertyChanged
    {
        public string _memberName;
        public string _memberDepartment;


        public string MemberName
        {
            get { return _memberName; }
            set
            {
                if (_memberName != value)
                {
                    _memberName = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("MemberName"));
                    
                }
            }
        }

        public string MemberDepartment
        {
            get { return _memberDepartment; }
            set
            {
                if (_memberDepartment != value)
                {
                    _memberDepartment = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("MemberDepartment"));
                }
            }
        }


        public MultipleLuckMemberCell(string memberName, string memberDepartment)
        {
            this.MemberName = memberName;
            this.MemberDepartment = memberDepartment;
            this.DataContext = this;
            InitializeComponent();
            

        }


        public MultipleLuckMemberCell()
        {
            this.DataContext = this;
            InitializeComponent();
            //ChangeShowType();
        }
        


        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
