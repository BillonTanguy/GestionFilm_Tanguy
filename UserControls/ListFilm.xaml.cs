using GestionFilm_Tanguy.Models;
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

namespace GestionFilm_Tanguy.UserControls
{
    /// <summary>
    /// Logique d'interaction pour ListFilm.xaml
    /// </summary>
    public partial class ListFilm : UserControl
    {
        public ListFilm()
        {
            InitializeComponent();
        }

        public void Initialize(List<Film> films)
        {
            DataContext = films;
        }
    }
}
