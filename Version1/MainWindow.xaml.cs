using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Version1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            if ((graph = SetGraph()) != null)
            {
                SetWaysValueText();
                SetCyclesValuesText();
                //OrGraph.GetDifrent(graph.getCycle, 2);
                //DataSet.JoinPath(graph.getWays, graph.getCycle);
                AlgorithmMason Maison = new AlgorithmMason(graph);

                foreach (var item in Maison.Maison())
                {
                    textBoxDeterminant.Text += item + Environment.NewLine;
                }
                //textBoxDeterminant.Text = Maison.Maison()[1] + Environment.NewLine;



            }
        }
    }
}
