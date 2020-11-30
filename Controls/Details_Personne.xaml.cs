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

namespace GestionFilm_Tanguy.Controls
{
    /// <summary>
    /// Logique d'interaction pour Details_Personne.xaml
    /// </summary>
    public partial class Details_Personne : Window
    {
        Personne Personne { get; set; }

        public Details_Personne(Personne personne)
        {
            Personne = personne;

            InitializeComponent();

            Personne_TB_Nom.DataContext = Personne;
            Personne_TB_Prenom.DataContext = Personne;
            Personne_TB_Age.DataContext = Personne;
        }

        private void Personne_BTN_Save_Click(object sender, RoutedEventArgs e)
        {
            Personne.Nom = Personne_TB_Nom.Text;
            Personne.Prenom = Personne_TB_Prenom.Text;
            Personne.Age = Personne_TB_Age.Text;

            this.Close();
        }
    }
}
