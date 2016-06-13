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

        public static List<List<DataSet>> getDisjointPath(List<DataSet> Cycle, List<List<DataSet>> outDisjoinPath)
        {
            List<List<DataSet>> DisjoinPath = outDisjoinPath.ToList();
            List<DataSet> CycleCopy = Cycle.ToList();
            if (DisjoinPath.Count == 0) DisjoinPath.Add(new List<DataSet>() { Cycle[0] });
            for (int i = 0; i < CycleCopy.Count; i++)
            {
                for (int j = i + 1 ; j < CycleCopy.Count; j++)
                {
                    if (Equals(CycleCopy[i], CycleCopy[j]))
                    {

                    }
                        
                }
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
    }
}
