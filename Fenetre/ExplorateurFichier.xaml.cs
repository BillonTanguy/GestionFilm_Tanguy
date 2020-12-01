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
using System.Windows.Shapes;

namespace GestionFilm_Tanguy.Fenetre
{
    /// <summary>
    /// Logique d'interaction pour ExplorateurFichier.xaml
    /// </summary>
    public partial class ExplorateurFichier : Window
    {
        public string CheminFichier { get; set; }

        public ExplorateurFichier(string cheminFichier, bool btnOpen = true)
        {
            InitializeComponent();

            CheminFichier = cheminFichier;

            FileExplorer.Init(CheminFichier, btnOpen);
        }

        private void ExplorateurFichier_Open(object sender, RoutedEventArgs e)
        {
            Context.CONTEXT_XML = (string)sender;

            this.Close();
        }

        private void ExplorateurFichier_Save(object sender, RoutedEventArgs e)
        {
            Context.CONTEXT_XML = (string)sender;

            this.Close();
        }
    }
}
