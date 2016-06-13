using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version1
{
    public partial class MainWindow
    {
        //Graph gr = new Graph();

        //private void getValueWays()
        //{
        //    List<List<Track>> myWays = gr.getWays().ToList();
        //    foreach (List<Track> item in myWays)
        //    {
        //        foreach (Track temp in item)
        //        {
        //            if (temp == item.Last()) textBoxWays.Text += temp.PF;
        //            else textBoxWays.Text += temp.PF + " ->";
        //        }
        //        textBoxWays.Text += Environment.NewLine;
        //    }
        //}

        //private void getValueCycle()
        //{
        //    List<List<Track>> myCycle = gr.getCycle().ToList();
        //    foreach (List<Track> item in myCycle)
        //    {
        //        foreach (Track temp in item)
        //        {
        //            if (temp == item.Last()) textBoxCycles.Text += temp.PF;
        //            else textBoxCycles.Text += temp.PF + " ->";
        //        }
        //        textBoxCycles.Text += Environment.NewLine;
        //    }
        //}

        //private void getDisjoinCycle()
        //{
        //    List<List<Track>> DisjoinCycle = gr.getDisjointCycle(gr.getCycle());

        //    foreach (List<Track> item in DisjoinCycle)
        //    {
        //        foreach (Track temp in item)
        //        {
        //            if (temp == item.Last()) textBoxDisjointCycle.Text += temp.PF;
        //            else textBoxDisjointCycle.Text += temp.PF + " ->";
        //        }
        //        textBoxDisjointCycle.Text += Environment.NewLine;
        //    }
        //}

        //private void getValueDeterminatn()
        //{
        //    textBoxDeterminant.Text = gr.getDeterminantGraph();
        //}
        OrGraph graph;

        private OrGraph SetGraph()
        {
            switch (tabControlGraphData.SelectedIndex)
            {
                case 0: return DataGraph.setTestGraphFirst();
                case 1: return DataGraph.setTestGraphSecond();
                case 2: return DataGraph.setTestGraphThird();
                case 3: return DataGraph.setTestGraphForth();
                case 4: return DataGraph.setTestGraphFifth();

                default: return null;
            }
        }

        private void SetWaysValueText()
        {
            textBoxWays.Text = "";
            foreach (var item in graph.getWays)
            {
                textBoxWays.Text += item.ToString() + Environment.NewLine;
            }
        }

        private void SetCyclesValuesText()
        {
            textBoxCycles.Text = "";
            foreach (var item in graph.getCycle)
            {
                textBoxCycles.Text += item.ToString() + Environment.NewLine;
            }
        }
    }
}
