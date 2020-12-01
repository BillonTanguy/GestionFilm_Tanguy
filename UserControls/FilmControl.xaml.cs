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
    /// Logique d'interaction pour FilmControl.xaml
    /// </summary>
    public partial class FilmControl : UserControl
    {
        public event RoutedEventHandler EventSavesChanges;
        private Film Film { get; set; }

        private List<Personne> Realisateurs { get; set; }
        private List<Personne> Producteurs { get; set; }
        private List<Acteur> Acteurs { get; set; }

        public FilmControl()
        {
            InitializeComponent();

            Realisateurs = new List<Personne>();
            Producteurs = new List<Personne>();
            Acteurs = new List<Acteur>();
        }

        public void Init(Film film, bool btnSaveChanges = true, bool btnAdd = false, int width = 420, int height = 150)
        {
            Film = film;

            UserControl.DataContext = new { Width = width, Height = height };
            TB_Titre.Text = Film.Titre;
            TB_Annee.Text = Film.Annee;

            foreach (Personne p in film.Realisateurs) Realisateurs.Add(p);
            foreach (Personne p in film.Producteurs) Producteurs.Add(p);
            foreach (Acteur a in film.Acteurs) Acteurs.Add(a);

            if (!btnSaveChanges) SavesChanges.Visibility = Visibility.Collapsed;
            if (!btnAdd) Add.Visibility = Visibility.Collapsed;
            
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

            Film.Realisateurs = (List<Personne>)(RealisateurControl.DataGrid.DataContext);
            Film.Producteurs = (List<Personne>)(ProducteurControl.DataGrid.DataContext);
            Film.Acteurs = (List<Acteur>)(ActeurControl.DataGrid.DataContext);

            EventSavesChanges?.Invoke(sender, e);
        }

        private void Add_Film_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Add_Film_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (Context.Films.Count > 0) Film.Id = Context.Films[Context.Films.Count - 1].Id + 1;
            else Film.Id = 1;

            Film.Titre = TB_Titre.Text;
            Film.Annee = TB_Annee.Text;

            Film.Realisateurs = (List<Personne>)(RealisateurControl.DataGrid.DataContext);
            Film.Producteurs = (List<Personne>)(ProducteurControl.DataGrid.DataContext);
            Film.Acteurs = (List<Acteur>)(ActeurControl.DataGrid.DataContext);

            Context.Films.Add(Film);

            EventSavesChanges?.Invoke(sender, e);
        }
    }
}
