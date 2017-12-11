using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GiveMeFive.Service
{
    public class CompanyMember
    {
        /// <summary>
        /// 工号
        /// </summary>
        public int id { set; get; }

        /// <summary>
        /// 部门
        /// </summary>
        public string department { set; get; }

        /// <summary>
        /// 名字
        /// </summary>
        public string name { set; get; }

        /// <summary>
        /// level 0=正式 1=实习 2=劳务
        /// </summary>
        public int level { set; get; }

        /// <summary>
        /// 已中奖
        /// </summary>
        public bool isLuck { set; get; }

        /// <summary>
        /// 导出的时候用
        /// </summary>
        public string luckName { set; get; }
    }



    /// <summary>
    /// 成员管理类
    /// </summary>
    public class MemberManager
    {
        //载入所有player

        private List<CompanyMember> m_listMember;


        public MemberManager(string filePath)
        {
            LoadMember(filePath);
        }

        /// <summary>
        /// 导出中奖的成员
        /// </summary>
        public void OutLuckMember() 
        {
            string full = string.Empty;

            for (int i = 0; i < m_listMember.Count; i++)
            {
                if (m_listMember[i].isLuck)
                {
                    full += m_listMember[i].department + " " + m_listMember[i].name + " " + m_listMember[i].luckName + "\r\n";
                }
                
            }

            if (Directory.Exists(@".\Result") == false)
            {
                Directory.CreateDirectory(@".\Result");
            }
            File.WriteAllText(@".\Result\OutputLuckMember.txt", full);
        }

        /// <summary>
        /// 导出完整的成员列表
        /// </summary>
        public void OutFullMember()
        {
            string full = string.Empty;

            for (int i = 0; i < m_listMember.Count; i++)
            {
                full += m_listMember[i].department + " " + m_listMember[i].name + " " + m_listMember[i].luckName +  "\r\n";
            }

            if (Directory.Exists(@".\Result") == false)
            {
                Directory.CreateDirectory(@".\Result");
            }
            File.WriteAllText(@".\Result\OutputFullMember.txt", full);
        }

        public void LoadMember(string filePath)
        {
            m_listMember = new List<CompanyMember>();
            //File.ReadAllText();
            var fullText = "";
            fullText = fullText.Replace("\t", " "); //制表符转换为空格
            fullText = fullText.Replace("  ", " "); //所有多余的空格会变为一个

            string[] fullTextLines = fullText.Split("\r\n".ToCharArray());
            for (int i = 0; i < fullTextLines.Length; i++)
            {
                string line = fullTextLines[i];
                string[] lines = line.Split(" ".ToCharArray());

                if (lines.Length == 2) //级别默认为0级
                {
                    m_listMember.Add(new CompanyMember() { id = i, name = lines[1], level = 0, department = lines[0] });
                } 
                else if (lines.Length == 3) //自定义了等级
                {
                    int level = 0;
                    //判断第三级的值

                    if (int.TryParse(lines[2], out int levelNew))
                    {
                        level = levelNew;
                    }
                    m_listMember.Add(new CompanyMember() { id = i, name = lines[1], level = level, department = lines[0] });
                }

            }

            //以下为测试代码
            //for (int i = 1000; i < 1300; i++)
            //{
            //    m_listMember.Add(new CompanyMember() { id = i, name = i.ToString(), level = 0, department = "团队" });
            //}
            //OutFullMember();
        }



        public void Count(string filePath)
        {
            m_listMember.Count();
        }

        public List<CompanyMember> GetRandomMembersForShow(LuckSetting luckSetting)
        {
            List<CompanyMember> listMember = new List<CompanyMember>();

            if (luckSetting.count > m_listMember.Count)
            {
                luckSetting.count = m_listMember.Count;
            }

            while (listMember.Count < luckSetting.count)
            {
                CompanyMember member = GetRandomMember(luckSetting.level);
                if (member == null)
                {
                    continue;
                }
                //member.isLuck = true;
                //member.luckName = luckSetting.name;

                if (listMember.Contains(member) == false)
                {
                    listMember.Add(member);
                }
            }

 
            return listMember;
        }


        /// <summary>
        /// 获取N个没有中过奖的成员
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<CompanyMember> GetRandomMembers(LuckSetting luckSetting)
        {
            List<CompanyMember> listMember = new List<CompanyMember>();
            for (int i = 0; i < luckSetting.count; i++)
            {
                CompanyMember member = GetRandomMember(luckSetting.level);
                if (member == null)
                {
                    continue;
                }
                member.isLuck = true;
                member.luckName = luckSetting.name;
                listMember.Add(member);
            }
            return listMember;
        }

        /// <summary>
        /// 获取一个没有中过奖的成员
        /// </summary>
        /// <returns></returns>
        public CompanyMember GetRandomMember(int level)
        {
            //获取随机index

            for (int i = 0; i < 10000; i++) //这里避免出现调用卡住 所以设个次数
            {
                byte[] guidBytes = Guid.NewGuid().ToByteArray();
                int theSeed = BitConverter.ToInt32(guidBytes, 0);
                Random rd = new Random(theSeed);
                int index = rd.Next(0, m_listMember.Count - 1);

                CompanyMember member = m_listMember[index];

                if (member.isLuck == false && member.level <= level)
                {
                    return member;
                }
            }

            return null; // GetRandomMember(level)
        }

        

    }
}
