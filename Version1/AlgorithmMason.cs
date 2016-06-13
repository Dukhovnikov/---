using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version1
{
    class AlgorithmMason
    {
        public OrGraph Graph { get; }
        public AlgorithmMason(OrGraph Graph)
        {
            this.Graph = Graph;
        }
        public string[] Maison()
        {
            string[] TransferFunction = new string[2];
            TransferFunction[0] = WayTransferFunction();
            TransferFunction[1] = Determinant();
            return TransferFunction;
        }
        private string WayTransferFunction()
        {
            string lineWay = "";
            List<DataSet> Cycles = Graph.getCycle.ToList();
            List<DataSet> Ways = Graph.getWays.ToList();
            DataSet temp;
            bool check = true;
            foreach (DataSet item in Ways)
            {
                if ((temp = DataSet.WayWithoutCycles(Cycles, item)) != null)
                {
                    lineWay += "(" + item.ConvertToString() + ") * " + "( 1 " + (temp.Sign * -1 < 0 ? "-":"+") + " " + temp.Abs() + " )";
                }
                else
                {
                    if (check)
                    {
                        lineWay += item.Abs();
                        check = false;
                    }
                    else
                    {
                        lineWay += (item.Sign < 0 ? " - " : " + ") + item.Abs();
                        
                    }
                }
            }
            return lineWay;
        }
        private string Determinant()
        {
            string determinant = "1";
            foreach (DataSet item in Graph.getCycle)
            {
                if (item.Sign < 0) determinant += " + ";
                else determinant += " - ";
                determinant += item.Abs();
            }

            return determinant + DisjoinCycles();
        }
        private string DisjoinCycles()
        {
            string result = "";
            foreach (DataSet[] item in Graph.DisjoinCycles)
            {
                int Sign = 1;
                string testValue = "";
                foreach (DataSet temp in item)
                {
                    Sign *= Convert.ToInt32(Math.Pow(-1, item.Count())) * -1 * temp.Sign;
                    if (temp == item.Last())
                    {
                        testValue += temp.Abs();
                    }
                    else
                    {
                        testValue += temp.Abs() + "*";
                    }
                }
                if (Sign < 0) result += " - " + testValue;
                else result += " + " + testValue;
            }
            return result;
        }
    }
}
