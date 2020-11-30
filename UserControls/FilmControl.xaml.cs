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
        //public event RoutedEventHandler SaveChanges;

        public Film Film { get; set; }

        public FilmControl()
        {
            InitializeComponent();
        }

        public void Init(Film film, int width = 420, int height = 150, bool btnVisible = true)
        {
            Film = film;

            UserControl.DataContext = new { Width = width, Height = height };
            TB_Titre.Text = Film.Titre;
            TB_Annee.Text = Film.Annee;

            //if (!btnVisible) SavesChanges.Visibility = Visibility.Hidden;
            
            RealisateurControl.Init(Film.Realisateurs);
            ProducteurControl.Init(Film.Producteurs);
            ActeurControl.Init(Film.Acteurs);
            
        }

        /*
        private void SaveChanges_Film_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveChanges_Film_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Film.Titre = TB_Titre.Text;
            Film.Annee = TB_Annee.Text;

            Film.Realisateurs = (List<Personne>)RealisateurControl.DataContext;
            Film.Producteurs = (List<Personne>)ProducteurControl.DataContext;
            Film.Acteurs = (List<Personne>)ActeurControl.DataContext;

            SaveChanges?.Invoke(sender, e);
        }
        */
    }
}
