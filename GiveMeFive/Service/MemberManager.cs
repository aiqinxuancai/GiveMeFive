using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiveMeFive.Service
{
    class CompanyMember
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
        /// level
        /// </summary>
        public int level { set; get; }

        /// <summary>
        /// 已中奖
        /// </summary>
        public bool isLuck { set; get; }


        public string luckName { set; get; }
    }
    


    /// <summary>
    /// 成员管理类
    /// </summary>
    class MemberManager
    {
        //载入所有player

        private List<CompanyMember> m_listMember;


        public MemberManager(string filePath)
        {
            LoadMember(filePath);
        }


        public void LoadMember(string filePath)
        {
            m_listMember = new List<CompanyMember>();

            for (int i = 1000; i < 1300; i++)
            {
                m_listMember.Add(new CompanyMember() { id = i, name = i.ToString(), level = 0, department = "团队" });
            }

        }



        public void Count(string filePath)
        {
            m_listMember.Count();
        }

        /// <summary>
        /// 获取N个没有中过奖的成员
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<CompanyMember> GetRandomMembers(int count)
        {
            List<CompanyMember> listMember = new List<CompanyMember>();
            for (int i = 0; i < count; i++)
            {
                CompanyMember member = GetRandomMember();
                member.isLuck = true;
                listMember.Add(member);
            }
            return listMember;
        }

        /// <summary>
        /// 获取一个没有中过奖的成员
        /// </summary>
        /// <returns></returns>
        public CompanyMember GetRandomMember()
        {
            //获取随机index
            byte[] guidBytes = Guid.NewGuid().ToByteArray();
            int theSeed = BitConverter.ToInt32(guidBytes, 0);
            Random rd = new Random(theSeed);
            int index = rd.Next(0, m_listMember.Count - 1);

            CompanyMember member = m_listMember[index];

            if (member.isLuck == false)
            {
                return member;
            }

            return GetRandomMember();
        }

        

    }
}
