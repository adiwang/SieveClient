using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieveClient
{
    class LeafGrade
    {
        public int group;               // 组别
        public int rank;                // 级别

        public static Dictionary<int, string> group2Desc = new Dictionary<int, string>()
            {
                {1, "BL"},
                {2, "BF"},
                {3, "BR"},
                {4, "CL"},
                {5, "CF"},
                {6, "XL"},
                {7, "XF"},
                {8, "NOT"},
            };
        public static Dictionary<string, int> desc2group = new Dictionary<string, int>()
            {
                {"BL", 1},
                {"BF", 2},
                {"BR", 3},
                {"CL", 4},
                {"CF", 5},
                {"XL", 6},
                {"XF", 7},
                {"NOT", 8},
            };

        public LeafGrade()
        {
            group = 0;
            rank = 0;
        }

        public LeafGrade(int group, int rank)
        {
            this.group = group;
            this.rank = rank;
        }

        // 根据描述字符串构建LeafGrade实例，字符串应该是形如"B1L"的样式
        public static LeafGrade BuildLeafGrade(string desc)
        {
            if (desc.Length < 3)
                return null;
            string head = desc.Substring(0, 1);
            string tail = desc.Substring(desc.Length - 1, 1);
            string group_str = head + tail;
            if (!desc2group.ContainsKey(group_str))
                return null;
            int rank = Convert.ToInt32(desc.Substring(1, desc.Length - 2));
            return new LeafGrade(desc2group[group_str], rank);
        }

        // 将LeafGrade转换成string格式
        public override string ToString()
        {
            if (!group2Desc.ContainsKey(group))
                return "None";
            string group_str = group2Desc[group];
            char head = group_str[0];
            char tail = group_str[1];
            return string.Format("{0}{1}{2}", head, rank, tail);
        }
    }
}
