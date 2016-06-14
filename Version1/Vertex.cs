using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version1
{
    /// <summary>
    /// Класс, представляющий вершину графа.
    /// </summary>
    class Vertex
    {
        /// <summary>
        /// Пути из вершины.
        /// </summary>
        public List<Track> myWay;

        /// <summary>
        /// Возвращает все пути, входящие в вершину.
        /// </summary>
        public List<Track> inWay => myWay.Where((a) => a.end == this).ToList();

        /// <summary>
        /// Возвращает все пути, исходящие из данной вершины.
        /// </summary>
        public List<Track> OutWay => myWay.Where((a) => a.begin == this).ToList();

        /// <summary>
        /// Название верины.
        /// </summary>
        string Name;

        public Vertex(string Name)
        {
            this.Name = Name;
            myWay = new List<Track>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
