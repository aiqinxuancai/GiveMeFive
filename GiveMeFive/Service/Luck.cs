using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GiveMeFive.Service
{
    /// <summary>
    /// 奖项设置
    /// </summary>
    public class LuckSetting
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
        /// 允许中奖的等级 level
        /// </summary>
        public int level { set; get; }

    }


    public class Luck
    {
        private List<LuckSetting> m_listLuckSetting;


        public Luck(string path)
        {
            m_listLuckSetting = new List<LuckSetting>();
            LoadLuck(path);
        }


        public List<LuckSetting> GetLuck()
        {
            return m_listLuckSetting;
        }


        public void LoadLuck(string filePath)
        {

            //奖项名称 抽取人数 等级（不填写默认为都可以抽到）
            var fullText = File.ReadAllText(filePath);


            fullText = fullText.Replace("\t", " "); //制表符转换为空格
            fullText = fullText.Replace("  ", " "); //所有多余的空格会变为一个

            string[] fullTextLines = fullText.Split("\r\n".ToCharArray());
            for (int i = 0; i < fullTextLines.Length; i++)
            {
                string line = fullTextLines[i];
                string[] lines = line.Split(" ".ToCharArray());

                if (lines.Length == 2) //级别默认为99级
                {
                    m_listLuckSetting.Add(new LuckSetting() { name = lines[0], level = 99, count = int.TryParse(lines[1], out int countInt) ? countInt : 1});
                }
                else if (lines.Length == 3) //自定义了等级
                {
                    int level = 99;
                    if (int.TryParse(lines[2], out int levelNew))
                    {
                        level = levelNew;
                    }
                    m_listLuckSetting.Add(new LuckSetting() { name = lines[0], level = level, count = int.TryParse(lines[1], out int countInt) ? countInt : 1 });
                }
            }
        }

    }
}
