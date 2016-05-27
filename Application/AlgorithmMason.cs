using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    /// <summary>
    /// Класс реализующий алгоритм мейсона для преобразования структурной схема в виде Орграфа.
    /// </summary>
    class AlgorithmMason
    {
        /// <summary>
        /// Функция, находящая количество путей в Оргафе.
        /// </summary>
        //public DirectedGraph GetNumWays(DirectedGraph OrGraph, int VertexNum = 0)
        //{
        //    DirectedGraph rez;
        //    string s = "";
        //    foreach (Vertex item in OrGraph)
        //    {
        //        if (item.GetNumAheadPath > 2)
        //        {
        //            //To Do

        //        }
        //        else
        //        {
        //            s += item.Index;
        //        }
        //    }
        //    return rez;
        //}

        public List<DirectedGraph> GetNumWays(DirectedGraph OrGraph, int VertexNum = 0)
        {
            List<DirectedGraph> rez = new List<DirectedGraph>();
            string s = "";
            if (OrGraph[VertexNum].GetNumAheadPath > 1)
            {
                foreach (Vertex item in OrGraph.BustPath(0))
                {
                    rez.Add(new DirectedGraph());
                }
            }
        }
    }
}
