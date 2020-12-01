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
    /// Logique d'interaction pour FilmDetails.xaml
    /// </summary>
    public partial class FilmDetails : Window
    {
        public Film Film { get; set; }

        public List<Personne> Realisateurs { get; set; }
        public List<Personne> Producteurs { get; set; }
        public List<Acteur> Acteurs { get; set; }

        public FilmDetails(Film film, bool Save = true, bool Add = false)
        {
            InitializeComponent();

            Film = film;

            FilmControl.Init(Film, Save, Add);
        }

        private void SaveChanges_Film_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveChanges_Film_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //On réinitialise les listes
            Film.Realisateurs.Clear();
            Film.Producteurs.Clear();
            Film.Acteurs.Clear();

            //On copie
            foreach (Personne p in Realisateurs) Film.Realisateurs.Add(p);
            foreach (Personne p in Producteurs) Film.Producteurs.Add(p);
            foreach (Acteur a in Acteurs) Film.Acteurs.Add(a);

            //on ferme la fenêtre
            this.Close();
        }

        private void Event_SaveChanges(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
