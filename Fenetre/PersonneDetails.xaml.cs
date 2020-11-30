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
    /// Logique d'interaction pour PersonneDetails.xaml
    /// </summary>
    public partial class PersonneDetails : Window
    {
        Personne Personne { get; set; }

        public PersonneDetails(Personne personne)
        {
            Personne = personne;

            InitializeComponent();

            PersonneControl.Init(Personne);
        }

        //Quand on a sauvegardé les changements, la fenêtre de ferme
        private void PersonneControl_SaveChanges(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
