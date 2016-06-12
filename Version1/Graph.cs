using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version1
{
    /// <summary>
    /// Класс, реализующий Ориентированный граф.
    /// </summary>
    class Graph
    {
        /// <summary>
        /// Вершины графа.
        /// </summary>
        /// <remarks>Пути спрятаны в вершинах.</remarks>
        List<Vertex> Points;

        /// <summary>
        /// Начальная вершина графа.
        /// </summary>
        Vertex begin;
        /// <summary>
        /// Конечная вершина графа.
        /// </summary>
        Vertex end;

        /// <summary>
        /// Получить пути графа.
        /// </summary>
        /// <returns></returns>
        public List<List<Track>> getWays()
        {
            List<List<Track>> Ways = new List<List<Track>>();
            foreach (var a in begin.OutWay)
                Ways.AddRange(this.Ways(new List<Track> { a }, a.end));

            return Ways;
        }

        List<List<Track>> Ways(List<Track> CurentWay, Vertex CurPoint)
        {
            ///Если пришли в ту точку в которой были шлём всех нахер.
            if (CurentWay.Any((a) => a.begin == CurPoint)) return null;
            ///Если пришли в конец отдаем путь.
            if (CurPoint == end) return new List<List<Track>>() { CurentWay };
            else
            {
                ///Тут храним пути из этой точки.
                var wayFromPoint = new List<List<Track>>();
                ///Запускаем рекурсию на все пути из вершины.
                foreach (var a in CurPoint.OutWay)
                {
                    var newWay = CurentWay.ToList();
                    newWay.Add(a);
                    var Way = Ways(newWay, a.end);
                    if (Way != null)
                        wayFromPoint.AddRange(Way);
                }
                return wayFromPoint;
            }
        }

        public List<List<Track>> getCycle()
        {
            //List<List<Vertex>> Cycles = new List<List<Vertex>>();
            List<List<Track>> Cycles = new List<List<Track>>();
            foreach (var a in Points)
            {
                foreach (var b in a.OutWay)
                {
                    //Cycles.AddRange(РЕКУРСИЯ2(a, new List<Vertex>() { a }, b.end));
                    Cycles.AddRange(Cycle(a, new List<Track>() { b }, b.end));
                }

            }
            return RemoveEqiul(Cycles);
        }

        List<List<Track>> Cycle(Vertex Start, List<Track> Curent_way, Vertex Curent_point)
        {
            //если пришли в стартавую точку отдаем путь
            if (Curent_point == Start)
            {
                return new List<List<Track>>() { Curent_way };
            }
            //если пришли в ту точку в которой были шлём всех нахер
            if (Curent_way.Any((a) => a.begin == Curent_point))
                return null;
            else
            {
                //тут храним пути из этой точки
                var wayFromPoint = new List<List<Track>>();
                //запускаем рекурсию на все пути из вершины
                foreach (var a in Curent_point.OutWay)
                {
                    var newWay = Curent_way.ToList();
                    newWay.Add(a);
                    var Way = Cycle(Start, newWay, a.end);
                    if (Way != null)
                        wayFromPoint.AddRange(Way);
                }
                return wayFromPoint;
            }
        }

        /// <summary>
        /// Сравнение двух путей (циклов) на эквивалентность.
        /// </summary>
        /// <param name="T1"></param>
        /// <param name="T2"></param>
        /// <returns></returns>
        bool eqiul(List<Track> T1, List<Track> T2)
        {
            foreach (var a in T1)
            {
                if (!T2.Any(b => b == a))
                    return false;
            }
            return true;
        }
        
        List<List<Track>> RemoveEqiul(List<List<Track>> IN)
        {
            List<List<Track>> OUT = IN.ToList();
            for (int i = 0; i < IN.Count; i++)
            {
                for (var j = i + 1; j < IN.Count; j++)
                {
                    if (eqiul(IN[i], IN[j])) OUT.Remove(IN[j]);
                }
            }
            return OUT;
        }

        public Graph()
        {
            Vertex[] P = new Vertex[4];
            for (int i = 0; i < 4; i++)
            {
                P[i] = new Vertex(i.ToString());
            }

            Points = new List<Vertex>(4) { P[0], P[1], P[2], P[3] };

            begin = P[0];
            end = P[3];

            new Track(P[0], P[1], "1");
            new Track(P[1], P[2], "W1");
            new Track(P[1], P[2], "W3");
            new Track(P[2], P[3], "W2");
            new Track(P[3], P[2], "-W4");
            new Track(P[3], P[1], "-1");
        }

        /// <summary>
        /// простой граф для проверки
        /// </summary>
        public Graph(int x)
        {
            var P = new Vertex[3];
            for (int i = 0; i < 3; i++)
                P[i] = new Vertex(i.ToString());

            Points = new List<Vertex>(3) { P[0], P[1], P[2] };

            new Track(P[0], P[1], "1");
            new Track(P[1], P[2], "2");
            new Track(P[1], P[0], "3");
            new Track(P[1], P[2], "4");
            begin = P[0];
            end = P[2];
        }


    }
}
