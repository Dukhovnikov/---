using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version1
{
    /// <summary>
    /// Класс предназначенный, для отображения в памяти отдельного пути или контура.
    /// </summary>
    class DataSet
    {
        /// <summary>
        /// Цепочка вершин графа.
        /// </summary>
        public List<Track> data { get; set; } = new List<Track>();

        /// <summary>
        /// Строковое представление яцейки ОрГрафа.
        /// </summary>
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

        /// <summary>
        /// Математическое представление отдельного пути или контура, учитывающее знак.
        /// </summary>
        public string ConvertToString()
        {
            string line = ToString().Replace(" -> ", "*");
            int Sign = Convert.ToInt32(Math.Pow(-1, line.ToCharArray().Where(a => a == '-').Count()));
            if (Sign < 0) line = "-" + line.Replace("-", "");
            else line = line.Replace("-", "");
            return line;
        }

        /// <summary>
        /// Математическое представление отдельного пути или контура, не учитывающее знак.
        /// </summary>
        public string Abs()
        {
            string line = ConvertToString();
            if (line.Contains("-")) line = line.Replace("-", "");
            return line;
        }

        /// <summary>
        /// Последний элемент последовательности.
        /// </summary>
        public Track Last { get { return data.Last(); } }

        /// <summary>
        /// Коструктор класса.
        public DataSet(List<Track> data)
        {
            this.data = new List<Track>(data);
        }

        /// <summary>
        /// Количество путей в контуре или прямом путе.
        /// </summary>
        public int Count { get { return data.Count; } }

        /// <summary>
        /// Знак последовательности.
        /// </summary>
        public int Sign
        {
            get
            {
                if (ConvertToString().Contains("-")) return -1;
                else return 1;
            }
        }

        /// <summary>
        /// Сравнивает некоторое множество путей или циклов, и возвращает те, которые не содержаться во втором объекте.
        /// </summary>
        public static DataSet WayWithoutCycles (List<DataSet> Cycles, DataSet Way)
        {
            List<DataSet> result = Cycles.ToList();
            foreach (var item in result)
            {
                if (!Equals(item, Way)) return item;
            }
            return null;
        }

        /// <summary>
        /// Сравнение двух последовательностей. Вернет true, если сравнивые элементы имеют хотя бы одну общую вершину.
        /// </summary>
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
    }
}
