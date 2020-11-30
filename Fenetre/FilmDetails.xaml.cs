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
        public List<Personne> Acteurs { get; set; }

        public FilmDetails(Film film)
        {
            Film = film;

            //Pour ne pas impacter directement mon film et pouvoir sauvegarder les changements si besoin
            //on copie les objets un à un dans des listes séparées

            Realisateurs = new List<Personne>();
            Producteurs = new List<Personne>();
            Acteurs = new List<Personne>();

            foreach (Personne p in film.Realisateurs)
                Realisateurs.Add(p);

            foreach (Personne p in film.Producteurs)
                Producteurs.Add(p);

            foreach (Personne p in film.Acteurs)
                Acteurs.Add(p);

            InitializeComponent();

            //FilmControl.Init(Film);

            TB_Titre.Text = Film.Titre;
            TB_Annee.Text = Film.Annee;

            RealisateurControl.Init(Realisateurs, "Réalisateurs");
            ProducteurControl.Init(Producteurs, "Producteurs");
            ActeurControl.Init(Acteurs, "Acteurs");
        }

        private void SaveChanges_Film_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveChanges_Film_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Film.Titre = TB_Titre.Text;
            Film.Annee = TB_Annee.Text;

            //On réinitialise les listes
            Film.Realisateurs.Clear();
            Film.Producteurs.Clear();
            Film.Acteurs.Clear();

            //On copie
            foreach (Personne p in Realisateurs) Film.Realisateurs.Add(p);
            foreach (Personne p in Producteurs) Film.Producteurs.Add(p);
            foreach (Personne p in Acteurs) Film.Acteurs.Add(p);

            //on ferme la fenêtre
            this.Close();
        }
    }
}
