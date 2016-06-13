using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version1
{
    static class DataGraph
    {
        public static OrGraph setTestGraphFirst()
        {
            List<Vertex> Points = new List<Vertex>();
            for (int i = 0; i < 6; i++) Points.Add(new Vertex(i.ToString()));

            new Track(Points[0], Points[1], "1");
            new Track(Points[1], Points[2], "W1");
            new Track(Points[2], Points[3], "W2");
            new Track(Points[3], Points[4], "W3");
            new Track(Points[4], Points[5], "W4");
            new Track(Points[0], Points[3], "W5");
            new Track(Points[1], Points[3], "W6");
            new Track(Points[4], Points[1], "-W7");
            new Track(Points[3], Points[2], "-W8");
            new Track(Points[4], Points[3], "-W9");

            return new OrGraph(Points, Points[0], Points[5]);
        }
        public static OrGraph setTestGraphSecond()
        {
            List<Vertex> Points = new List<Vertex>();
            for (int i = 0; i < 4; i++) Points.Add(new Vertex(i.ToString()));

            new Track(Points[0], Points[1], "1");
            new Track(Points[1], Points[2], "W1");
            new Track(Points[2], Points[3], "W2");
            new Track(Points[1], Points[2], "W3");
            new Track(Points[3], Points[2], "-W4");
            new Track(Points[3], Points[1], "-1");

            return new OrGraph(Points, Points[0], Points[3]);
        }
        public static OrGraph setTestGraphThird()
        {
            List<Vertex> Points = new List<Vertex>();
            for (int i = 0; i < 6; i++) Points.Add(new Vertex(i.ToString()));

            new Track(Points[0], Points[1], "1");
            new Track(Points[1], Points[2], "W1");
            new Track(Points[2], Points[3], "W2");
            new Track(Points[2], Points[5], "1");
            new Track(Points[2], Points[1], "-W4");
            new Track(Points[3], Points[4], "W3");
            new Track(Points[4], Points[5], "1");
            new Track(Points[4], Points[1], "-W6");
            new Track(Points[4], Points[3], "-W5");

            return new OrGraph(Points, Points[0], Points[5]);
        }
        public static OrGraph setTestGraphForth()
        {
            List<Vertex> Points = new List<Vertex>();
            for (int i = 0; i < 8; i++) Points.Add(new Vertex(i.ToString()));

            new Track(Points[0], Points[1], "1");
            new Track(Points[1], Points[2], "1");
            new Track(Points[2], Points[3], "W2");
            new Track(Points[3], Points[4], "1");
            new Track(Points[4], Points[5], "W4");
            new Track(Points[5], Points[6], "1");
            new Track(Points[6], Points[7], "W7");
            new Track(Points[0], Points[3], "W1");
            new Track(Points[4], Points[6], "W5");
            new Track(Points[4], Points[1], "-W3");
            new Track(Points[5], Points[4], "-W6");
            new Track(Points[7], Points[1], "-1");

            return new OrGraph(Points, Points[0], Points[7]);
        }
        public static OrGraph setTestGraphFifth()
        {
            List<Vertex> Points = new List<Vertex>();
            for (int i = 0; i < 8; i++) Points.Add(new Vertex(i.ToString()));

            new Track(Points[0], Points[1], "1");
            new Track(Points[1], Points[2], "W1");
            new Track(Points[2], Points[3], "1");
            new Track(Points[3], Points[4], "1");
            new Track(Points[4], Points[5], "W2");
            new Track(Points[5], Points[6], "1");
            new Track(Points[6], Points[7], "W3");
            new Track(Points[0], Points[2], "W4");
            new Track(Points[4], Points[7], "W5");
            new Track(Points[2], Points[1], "-1");
            new Track(Points[4], Points[1], "-W6");
            new Track(Points[4], Points[3], "-W7");
            new Track(Points[7], Points[5], "-1");

            return new OrGraph(Points, Points[0], Points[7]);
        }
        public static OrGraph setTestGraphSixth()
        {
            List<Vertex> Points = new List<Vertex>();
            for (int i = 0; i < 7; i++) Points.Add(new Vertex(i.ToString()));

            new Track(Points[0], Points[1], "1");
            new Track(Points[1], Points[2], "W1");
            new Track(Points[2], Points[3], "W4");
            new Track(Points[2], Points[1], "W2");
            new Track(Points[3], Points[2], "W3");
            new Track(Points[5], Points[2], "W5");
            new Track(Points[5], Points[6], "1");
            new Track(Points[2], Points[5], "W6");
            new Track(Points[4], Points[2], "W7");
            new Track(Points[2], Points[4], "W8");


            return new OrGraph(Points, Points[0], Points[6]);
        }
    }
}
