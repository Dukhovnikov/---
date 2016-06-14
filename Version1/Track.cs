using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version1
{
    /// <summary>
    /// Класс, представляющий собой отдельный путь в графе.
    /// </summary>
    class Track
    {
        /// <summary>
        /// Вершины, которые начинаются из данного пути.
        /// </summary>
        public Vertex begin { get; set; }

        /// <summary>
        /// Вершины, которые заканчиваются из данного пути.
        /// </summary>
        public Vertex end { get; set; }

        /// <summary>
        /// Передатояная функция пути.
        /// </summary>
        public string PF { get; set; }

        /// <summary>
        /// Конструктор, который инициализирует начальную, конечную вершину, соединяющюю путь и ПФ пути.
        /// </summary>
        public Track(Vertex begin, Vertex end, string PF)
        {
            this.begin = begin;
            this.end = end;
            this.PF = PF;
            begin.myWay.Add(this);
            end.myWay.Add(this);
        }

        public override string ToString()
        {
            return begin.ToString() + " -> " + PF + " -> " + end.ToString();
        }
    }
}
