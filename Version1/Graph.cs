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
            foreach (var a in begin.OutWay) Ways.AddRange(this.Ways(new List<Track> { a }, a.end));

            return Ways;
        }
        List<List<Track>> Ways(List<Track> CurentWay, Vertex CurPoint)
        {
            ///Если пришли в ту точку в которой были, то дальше не идем.
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
                    if (Way != null) wayFromPoint.AddRange(Way);
                }
                return wayFromPoint;
            }
        }

        /// <summary>
        /// Получить пути графа.
        /// </summary>
        /// <returns></returns>
        public List<List<Track>> getCycle()
        {
            List<List<Track>> Cycles = new List<List<Track>>();
            foreach (var a in Points)
            {
                foreach (var b in a.OutWay)
                {
                    Cycles.AddRange(Cycle(a, new List<Track>() { b }, b.end));
                }

            }
            return RemoveEqiul(Cycles);
        }

        /// <summary>
        /// Удаление дублированных циклов.
        /// </summary>
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

        List<List<Track>> Cycle(Vertex Start, List<Track> Curent_way, Vertex Curent_point)
        {
            ///Если пришли в стартавую точку отдаем путь.
            if (Curent_point == Start) return new List<List<Track>>() { Curent_way };
            ///Если пришли в ту точку в которой были, то дальше не продолжаем.
            if (Curent_way.Any((a) => a.begin == Curent_point)) return null;
            else
            {
                ///Тут храним пути из этой точки.
                var wayFromPoint = new List<List<Track>>();
                ///Запускаем рекурсию на все пути из вершины.
                foreach (var a in Curent_point.OutWay)
                {
                    var newWay = Curent_way.ToList();
                    newWay.Add(a);
                    var Way = Cycle(Start, newWay, a.end);
                    if (Way != null) wayFromPoint.AddRange(Way);
                }
                return wayFromPoint;
            }
        }

        /// <summary>
        /// Сравнение двух путей (циклов) на эквивалентность.
        /// </summary>
        bool eqiul(List<Track> T1, List<Track> T2)
        {
            foreach (var a in T1)
            {
                if (!T2.Any(b => b == a)) return false;
            }
            return true;
        }

        bool newEqiulas(List<Track> T1, List<Track> T2)
        {
            foreach (var a in T1)
            {
                if (T2.Any(b => b.PF == a.PF)) return false;
            }
            
            return true;
        }

        public List<List<Track>> getDisjointCycle(List<List<Track>> trackCycles)
        {
            List<List<Track>> DisjointCyce = new List<List<Track>>();
            for (int i = 0; i < trackCycles.Count; i++)
            {
                for (var j = i + 1; j < trackCycles.Count; j++)
                {
                    if (newEqiulas(trackCycles[i], trackCycles[j]))
                    {
                        DisjointCyce.Add(trackCycles[i]);
                        DisjointCyce.Add(trackCycles[j]);
                    }
                }
            }
            return DisjointCyce;
        }

        

        /// <summary>
        /// 
        /// </summary>
        public Graph()
        {
            //var P = new Vertex[6];
            //for (int i = 0; i < 6; i++) P[i] = new Vertex(i.ToString());

            //Points = new List<Vertex>(3) { P[0], P[1], P[2], P[3], P[4], P[5] };

            //new Track(Points[0], Points[1], "1");
            //new Track(Points[1], Points[2], "W1");
            //new Track(Points[2], Points[3], "W2");
            //new Track(Points[2], Points[5], "1");
            //new Track(Points[2], Points[1], "-W4");
            //new Track(Points[3], Points[4], "W3");
            //new Track(Points[4], Points[5], "1");
            //new Track(Points[4], Points[1], "-W6");
            //new Track(Points[4], Points[3], "-W5");
            //begin = P[0];
            //end = P[5];
        }




    }
}
