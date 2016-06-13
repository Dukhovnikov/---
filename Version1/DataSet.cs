using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version1
{
    class DataSet
    {
        public List<Track> data { get; set; } = new List<Track>();
        public override string ToString()
        {
            string res = "";
            foreach (Track item in data)
            {
                if (item == data.Last()) res += item.PF;
                else res += item.PF + " -> ";
            }
            return res;
        }
        public string ConvertToString()
        {
            string line = ToString().Replace(" -> ", "*");
            int Sign = Convert.ToInt32(Math.Pow(-1, line.ToCharArray().Where(a => a == '-').Count()));
            if (Sign < 0) line = "-" + line.Replace("-", "");
            else line = line.Replace("-", "");
            return line;
        }
        public string Abs()
        {
            string line = ConvertToString();
            if (line.Contains("-")) line = line.Replace("-", "");
            return line;
        }
        public Track Last { get { return data.Last(); } }
        public DataSet(List<Track> data)
        {
            this.data = new List<Track>(data);
        }
        public int Count { get { return data.Count; } }
        public int Sign
        {
            get
            {
                if (ConvertToString().Contains("-")) return -1;
                else return 1;
            }
        }

        #region Try
        public static List<DataSet> JoinPath(List<DataSet> Ways, List<DataSet> Cycle)
        {
            List<DataSet> DisjoinWays = new List<DataSet>();
            foreach (DataSet item in Ways)
            {
                if (!EqulasPath(Cycle, item)) DisjoinWays.Add(item);
            }
            return DisjoinWays;
        }
        public static List<DataSet> getDisjointPath(List<DataSet> Cycle)
        {
            List<DataSet> DisjoinPath = new List<DataSet>();
            DisjoinPath.Add(Cycle[0]);
            for (int i = 1; i < Cycle.Count; i++)
            {
                if (!EqulasPath(DisjoinPath, Cycle[i])) DisjoinPath.Add(Cycle[i]);
            }
            return DisjoinPath;
        }
        public static DataSet WayWithoutCycles (List<DataSet> Cycles, DataSet Way)
        {
            List<DataSet> result = Cycles.ToList();
            foreach (var item in result)
            {
                if (!Equals(item, Way)) return item;
            }
            return null;
        }
        static bool Equals(DataSet ValueOne, DataSet ValueTwo)
        {
            foreach (Track item in ValueOne.data)
            {
                foreach (Track temp in ValueTwo.data)
                {
                    if (item.end == temp.end) return true;
                }
            }
            return false;
        }
        public static bool EqulasPath(List<DataSet> Now, DataSet obj)
        {
            foreach (DataSet item in Now)
            {
                if (Equals(item, obj)) { return true; }
            }
            return false;
        }
        #endregion
    }
}
