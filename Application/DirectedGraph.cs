using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    /// <summary>
    /// Искусственный класс реализующий в мышинном представлении ориентированный граф.
    /// </summary>
    class DirectedGraph
    {
        /// <summary>
        /// Набор вершин ориентированного графа.
        /// </summary>
        List<Vertex> DirGraph { get; set; }

        /// <summary>
        /// Конструктор, который инициализирует пустой граф с заданным количеством вершин.
        /// </summary>
        public DirectedGraph(int VertexNum)
        {
            for (int i = 0; i < VertexNum; i++)
            {
                DirGraph.Add(new Vertex());
            }
        }

        /// <summary>
        /// Функция, которая задает ориентированный граф, используя в качестве данных матрицу смежности.
        /// </summary>
        /// <param name="FdjacencyMatrix">Матрица смежности.</param>
        public static DirectedGraph GetDirGraph( int[,] AdjacencyMatrix)
        {
            DirectedGraph graph = new DirectedGraph(AdjacencyMatrix.Length); // Инициализируем пустой граф с заданным количеством вершин.

            /// Создаем пути между вершинами.
            for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < AdjacencyMatrix.GetLength(1); j++)
                {
                    if (AdjacencyMatrix[i,j] != 0) graph[i].pathway.Add(new Track(i, j));
                }
            }
            return graph;
        }

        /// <summary>
        /// Индексатор для доступа к вершине.
        /// </summary>
        public Vertex this[int index]
        {
            get { return DirGraph[index]; }
            set { DirGraph[index] = value; }
        }

        /// <summary>
        /// Количество вершин в Орграфе.
        /// </summary>
        public int Count { get { return DirGraph.Count; } }

        /// <summary>
        /// Итератор, реализующий перебор вершин.
        /// </summary>
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }

        /// <summary>
        /// Итератор, реализующий перебор путей у заданной вершины вершины.
        /// </summary>
        public IEnumerable BustPath(int VertexNumber)
        {
            foreach (var item in this[VertexNumber].pathway)
            {
                yield return item.end;
            }
        }
    }
}
