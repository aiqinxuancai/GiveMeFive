using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiveMeFive.Service
{

    class LuckSetting
    {
        /// <summary>
        /// 抽奖名称
        /// </summary>
        public string name { set; get; }

        /// <summary>
        /// 抽奖抽出的数量
        /// </summary>
        public int count { set; get; }

        /// <summary>
        /// 允许中奖的等级 0为不设置
        /// </summary>
        public int level { set; get; }

    }


    class Luck
    {
        private LuckSetting luckSetting;


        public Luck()
        {
            luckSetting = new LuckSetting();
        }

    }
}
