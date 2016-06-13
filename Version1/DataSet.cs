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
        public DataSet(List<Track> data)
        {
            this.data = new List<Track>(data);
        }


        #region Try
        public static List<DataSet> JoinPath(List<DataSet> Ways ,List<DataSet> Cycle)
        {
            List<DataSet> DisjoinWays = new List<DataSet>();
            foreach (DataSet item in Ways)
            {
                if (EqulasPath(Cycle, item)) DisjoinWays.Add(item);
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
        static bool Equals(DataSet ValueOne, DataSet ValueTwo)
        {
            foreach (Track item in ValueOne.data)
            {
                foreach (Track temp in ValueTwo.data)
                {
                    if (item == temp) return true;
                }
            }
            return false;
        }
        static bool EqulasPath(List<DataSet> Now, DataSet obj)
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
