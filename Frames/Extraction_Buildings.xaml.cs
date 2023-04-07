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

namespace Satisfactory_Calculator
{
    /// <summary>
    /// Interaction logic for Extraction_Buildings.xaml
    /// </summary>
    public partial class Extraction_Buildings : Page
    {
        private MainWindow mainWindow = null;
        public Extraction_Buildings(MainWindow main)
        {
            InitializeComponent();
            this.mainWindow = main;
        }
    }
}
