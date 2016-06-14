using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version1
{
    /// <summary>
    /// Класс, реализиующий алгоритм мейсона и создающий тестовое представление передаточной функции.
    /// </summary>
    class AlgorithmMason
    {
        /// <summary>
        /// Ориентированный граф структурной схемы.
        /// </summary>
        public OrGraph Graph { get; }

        /// <summary>
        /// Конструктор класс, которому для инициализации нужен ОрГраф.
        /// </summary>
        public AlgorithmMason(OrGraph Graph)
        {
            this.Graph = Graph;
        }

        /// <summary>
        /// Возвращает числитель передаточной функции.
        /// </summary>
        public string getNumerator()
        {
            return WayTransferFunction();
        }

        /// <summary>
        /// Возвращает знаменатель передаточной функции.
        /// </summary>
        public string getDenominator()
        {
            return Determinant();
        }

        /// <summary>
        /// Генерируует числитель передаточной функции, из передаточных функций путей ОрГрафа.
        /// </summary>
        private string WayTransferFunction()
        {
            string lineWay = ""; /// Тут будем хранить значение числителя.
            List<DataSet> Cycles = Graph.getCycle.ToList(); /// Заведем локальную переменную. Приссвоим ей все циклы ОрГрафа.
            List<DataSet> Ways = Graph.getWays.ToList(); /// Заведем локальную переменную. Приссвоим ей все пути ОрГрафа.
            DataSet temp; /// Переменная хранящее значение контура, который останется после удаления конкретного путя.
            bool check = true; /// Переменная для корректной расстановки знаков.
            foreach (DataSet item in Ways) /// Запускаем алгоритм.
            {
                if ((temp = DataSet.WayWithoutCycles(Cycles, item)) != null) /// Если удалить путь и циклы останутся.
                {
                    lineWay += (temp.Sign * -1 < 0 ? "-" : "+") + "(" + item.ConvertToString() + ") * " + "( 1 " + (temp.Sign * -1 < 0 ? "-":"+") + " " + temp.Abs() + " )";
                }
                else /// Иначе.
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

        /// <summary>
        /// Возвращает строковое представление определителя ОрГрафа.
        /// </summary>
        private string Determinant()
        {
            string determinant = "1"; /// Здась будем хранить текстовое представление определителя.
            foreach (DataSet item in Graph.getCycle) /// Перебираем все контура
            {
                if (item.Sign < 0) determinant += " + "; /// Учитывает общий знак
                else determinant += " - ";
                determinant += item.Abs();
            }
            /// До этого момента мы не учитывали несоприкасающиеся котура. Далее возвращаем полный определитель.
            return determinant + DisjoinCycles();
        }

        /// <summary>
        /// Возвращает строковое значение определителя ОрГрафа для всех несоприкасающихся контуров.
        /// </summary>
        private string DisjoinCycles()
        {
            string result = ""; /// Тут храним результат.
            foreach (DataSet[] item in Graph.DisjoinCycles) /// Перебираем все пары, тройки, ... , несоприкасающихся котуров.
            {
                int Sign = 1; /// Переменная хранящая общий знак отдельной связки несоприкасающихся котуров.
                string testValue = ""; /// Переменная, хранящая промежуточное значение отдельной связки несоприкасающихся контуров.
                foreach (DataSet temp in item) /// Перебираем отдельную связку.
                {
                    Sign *= Convert.ToInt32(Math.Pow(-1, item.Count())) * -1 * temp.Sign; /// Получаем конечный знак.
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
