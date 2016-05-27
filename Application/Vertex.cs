using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    /// <summary>
    /// Искусственный класс для инициализазции вершин.
    /// </summary>
    class Vertex
    {
        /// <summary>
        /// Номер вершины
        /// </summary>
        private static int index = 0;

        /// <summary>
        /// Реализует все пути связанные с конкретной вершиной.
        /// </summary>
        public List<Track> pathway { get; set; }

        /// <summary>
        /// Конструктор, создающий индексированную вершину.
        /// </summary>
        public Vertex()
        {
            index++;
        }

        /// <summary>
        /// Номер вершины.
        /// </summary>
        public int Index { get { return index; } }

        /// <summary>
        /// Количество прямых путей.
        /// </summary>
        public int GetNumAheadPath
        {
            get
            {
                int NumAheadPath = 0;
                foreach (var item in pathway)
                {
                    if (item.begin < item.end) NumAheadPath++;
                }
                return NumAheadPath;
            }
        }

        /// <summary>
        /// Количество обратных путей.
        /// </summary>
        public int GetNumBackPath
        {
            get
            {
                int NumBackPath = 0;
                foreach (var item in pathway)
                {
                    if (item.begin > item.end) NumBackPath++;
                }
                return NumBackPath;
            }
        }

        public override string ToString()
        {
            string data = Index + ": ";
            foreach (var item in pathway)
            {
                data += item.ToString();
            }
            return data;
        }
    }
}
