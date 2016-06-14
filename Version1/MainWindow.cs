using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version1
{
    public partial class MainWindow
    {
        /// <summary>
        /// Граф, заданный пользователем, в данной программе задается статически.
        /// </summary>
        OrGraph graph;

        /// <summary>
        /// Инициализация графа, в зависимости от выбора пользователя.
        /// </summary>
        private OrGraph SetGraph()
        {
            switch (tabControlGraphData.SelectedIndex)
            {
                case 0: return DataGraph.setTestGraphFirst();
                case 1: return DataGraph.setTestGraphSixth();
                case 2: return DataGraph.setTestGraphThird();
                case 3: return DataGraph.setTestGraphForth();
                case 4: return DataGraph.setTestGraphFifth();

                default: return null;
            }
        }

        /// <summary>
        /// Устанавливием значения всех путей в визуализированное окошко.
        /// </summary>
        private void SetWaysValueText()
        {
            textBoxWays.Text = "";
            foreach (var item in graph.getWays)
            {
                textBoxWays.Text += item.ToString() + Environment.NewLine;
            }
        }

        /// <summary>
        /// Устанавливием значения всех контуров в визуализированное окошко.
        /// </summary>
        private void SetCyclesValuesText()
        {
            textBoxCycles.Text = "";
            foreach (var item in graph.getCycle)
            {
                textBoxCycles.Text += item.ToString() + Environment.NewLine;
            }
        }

        /// <summary>
        /// Получение у установка передаточной функции графа.
        /// </summary>
        private void SetMaisonValue()
        {
            AlgorithmMason Maison = new AlgorithmMason(graph);
            textBoxNumerator.Text = Maison.getNumerator();
            textBoxDenominator.Text = Maison.getDenominator();

        }
    }
}
