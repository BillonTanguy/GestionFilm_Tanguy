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
    /// Logique d'interaction pour Details_Film.xaml
    /// </summary>
    public partial class Details_Film : Window
    {
        public Film Film { get; set; }

        public Details_Film(Film Film)
        {
            this.Film = Film;

            InitializeComponent();

            Film_TB_Titre.DataContext = Film;
            Film_TB_Annee.DataContext = Film;
            Film_DG_Realisateur.DataContext = Film.Realisateurs;
            Film_DG_Producteurs.DataContext = Film.Producteurs;
            Film_DG_Acteurs.DataContext = Film.Acteurs;
        }

        //Les conditions ne marchent pas pour le moment
        private void Film_BTN_Realisateurs_Click(object sender, RoutedEventArgs e)
        {

            Ajout_Personne_To_Film fenetre = new Ajout_Personne_To_Film(Film.Realisateurs);
            fenetre.ShowDialog();

            //J'ai décidé de faire le control après l'ajout

            //On veut la liste avant d'avoir ajouter la personne pour comparer
            List<Personne> listAvant = new List<Personne>();
            for(int index = 0; index < Film.Realisateurs.Count-1; index++)
            {
                listAvant.Add(Film.Realisateurs[index]);
            }

            if (listAvant.Count == Film.Realisateurs.Count) return;

            //Conditions
            if (listAvant.Contains(Film.Realisateurs[Film.Realisateurs.Count-1]))
            {
                Film_LB_Erreur.Content = "ERREUR : cette personne est déjà réalisateur de ce film";
                Film.Realisateurs.RemoveAt(Film.Realisateurs.Count - 1);
            }
            else if (Film.Producteurs.Contains(Film.Realisateurs[Film.Realisateurs.Count - 1]))
            {
                Film_LB_Erreur.Content = "ERREUR : cette personne est réalisateur de ce film";
                Film.Realisateurs.RemoveAt(Film.Realisateurs.Count - 1);
            }
            else
            {
                //on refresh le datagrid concerné
                Film_DG_Realisateur.DataContext = null;
                Film_DG_Realisateur.DataContext = Film.Realisateurs;
            }
        }

        private void Film_BTN_Producteurs_Click(object sender, RoutedEventArgs e)
        {
            Ajout_Personne_To_Film fenetre = new Ajout_Personne_To_Film(Film.Producteurs);
            fenetre.ShowDialog();

            //On veut la liste avant d'avoir ajouter la personne pour comparer
            List<Personne> listAvant = new List<Personne>();
            for (int index = 0; index < Film.Producteurs.Count - 1; index++)
            {
                listAvant.Add(Film.Producteurs[index]);
            }

            if (listAvant.Count == Film.Producteurs.Count) return;

            //Conditions
            if (listAvant.Contains(Film.Producteurs[Film.Producteurs.Count - 1]))
            {
                Film_LB_Erreur.Content = "ERREUR : cette personne est déjà producteur de ce film";
                Film.Producteurs.RemoveAt(Film.Producteurs.Count - 1);
            }
            else if(Film.Realisateurs.Contains(Film.Producteurs[Film.Producteurs.Count - 1]))
            {
                Film_LB_Erreur.Content = "ERREUR : cette personne est réalisateur de ce film";
                Film.Producteurs.RemoveAt(Film.Producteurs.Count - 1);
            }
            else
            {
                Film_DG_Producteurs.DataContext = null;
                Film_DG_Producteurs.DataContext = Film.Producteurs;
            }
        }

        private void Film_BTN_Acteurs_Click(object sender, RoutedEventArgs e)
        {

            Ajout_Personne_To_Film fenetre = new Ajout_Personne_To_Film(Film.Acteurs);
            fenetre.ShowDialog();

            //On veut la liste avant d'avoir ajouter la personne pour comparer
            List<Personne> listAvant = new List<Personne>();
            for (int index = 0; index < Film.Acteurs.Count - 1; index++)
            {
                listAvant.Add(Film.Acteurs[index]);
            }

            if (listAvant.Count == Film.Acteurs.Count) return;


            if (listAvant.Contains(Film.Acteurs[Film.Acteurs.Count - 1]))
            {
                Film_LB_Erreur.Content = "ERREUR : cette personne est déjà présente dans la liste des acteur de ce film";
                Film.Acteurs.RemoveAt(Film.Acteurs.Count - 1);
            }
            else
            {
                Film_DG_Acteurs.DataContext = null;
                Film_DG_Acteurs.DataContext = Film.Acteurs;
            }
        }

        private void Delete_Personne_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        //ne fonctionne pas
        //On entre pas dans le if()
        //je voulais régler ça avec les userControl => je n'aurais plus besoin du switch etc ..
        private void Delete_Personne_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Console.WriteLine("Rentre dans le bouton");
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
            {
                if (vis is DataGridRow)
                {
                    Console.WriteLine($"row = {((DataGridRow)vis).GetIndex()}");
                    switch (e.Parameter.ToString())
                    {
                        case "REALISATEUR":
                            Film.Realisateurs.RemoveAt(((DataGridRow)vis).GetIndex());
                            break;
                        case "PRODUCTEUR":
                            Film.Producteurs.RemoveAt(((DataGridRow)vis).GetIndex());
                            break;
                        case "ACTEUR":
                            Film.Acteurs.RemoveAt(((DataGridRow)vis).GetIndex());
                            break;
                        default:
                            Console.WriteLine("switch default");
                            break;
                    }
                    break;
                }
            }

            Film_DG_Realisateur.DataContext = null;
            Film_DG_Realisateur.DataContext = Film.Realisateurs;

            Film_DG_Producteurs.DataContext = null;
            Film_DG_Producteurs.DataContext = Film.Producteurs;

            Film_DG_Acteurs.DataContext = null;
            Film_DG_Acteurs.DataContext = Film.Acteurs;
        }
    }
}
