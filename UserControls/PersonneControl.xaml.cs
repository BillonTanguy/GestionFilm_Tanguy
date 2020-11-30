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
    /// Logique d'interaction pour PersonneControl.xaml
    /// </summary>
    public partial class PersonneControl : UserControl
    {
        public event RoutedEventHandler SaveChanges;
        public Personne Personne { get; set; }

        public PersonneControl()
        {
            InitializeComponent();
        }

        public void Init(Personne personne, int width = 420, int height = 150, bool btnVisible = true)
        {
            Personne = personne;

            UserControl.DataContext = new { Width = width, Height = height };
            TB_Nom.Text = Personne.Nom;
            TB_Prenom.Text = Personne.Prenom;
            TB_Age.Text = Personne.Age;

            //Pour cacher le bouton si besoin 
            if(!btnVisible) BTN_SaveChanges.Visibility = Visibility.Hidden;
        }

        private void SaveChanges_Personne_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveChanges_Personne_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Personne.Nom = TB_Nom.Text;
            Personne.Prenom = TB_Prenom.Text;
            Personne.Age = TB_Age.Text;

            SaveChanges?.Invoke(sender, e);
        }
    }
}
