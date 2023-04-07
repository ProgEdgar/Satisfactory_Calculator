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
    /// Interaction logic for Other_Buildings.xaml
    /// </summary>
    public partial class Other_Buildings : Page
    {
        private MainWindow mainWindow = null;
        public Other_Buildings(MainWindow main)
        {
            InitializeComponent();
            this.mainWindow = main;
        }
    }
}
