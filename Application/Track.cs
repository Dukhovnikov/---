using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    /// <summary>
    /// Искусственный класс для инициализазции путей.
    /// </summary>
    class Track
    {
        /// <summary>
        /// Номер начальной вершины.
        /// </summary>
        public readonly int begin;

        /// <summary>
        /// Номер конечной вершины.
        /// </summary>
        public readonly int end;

        /// <summary>
        /// Переменная показывающая, пройден ли данный путь или нет. True - пройден, false - не пройден.
        /// </summary>
        public bool passed { get; set; }

        /// <summary>
        /// Конструктор принимающий два параметра: номер начальной и конечной вершин.
        /// </summary>
        public Track(int begin, int end)
        {
            this.begin = begin;
            this.end = end;
            passed = false;
        }

        /// <summary>
        /// Индекс следующей вершины.
        /// </summary>
        public int Next { get { return end; } }

        public override string ToString()
        {
            return end.ToString(); 
        }
    }
}
