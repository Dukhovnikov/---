using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version1
{
    public partial class MainWindow
    {
        Graph gr = new Graph();
        
        private void getValueWays()
        {
            List<List<Track>> myWays = gr.getWays().ToList();
            foreach (List<Track> item in myWays)
            {
                foreach (Track temp in item)
                {
                    if (temp == item.Last()) textBoxWays.Text += temp.PF;
                    else textBoxWays.Text += temp.PF + " ->";
                }
                textBoxWays.Text += Environment.NewLine;
            }
        }

        private void getValueCycle()
        {
            List<List<Track>> myCycle = gr.getCycle().ToList();
            foreach (List<Track> item in myCycle)
            {
                foreach (Track temp in item)
                {
                    if (temp == item.Last()) textBoxCycles.Text += temp.PF;
                    else textBoxCycles.Text += temp.PF + " ->";
                }
                textBoxCycles.Text += Environment.NewLine;
            }
        }
    }
}
