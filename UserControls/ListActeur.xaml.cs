using GestionFilm_Tanguy.Fenetre;
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
    /// Logique d'interaction pour ListActeur.xaml
    /// </summary>
    public partial class ListActeur : UserControl
    {
        private List<Acteur> list { get; set; }

        public ListActeur()
        {
            list = new List<Acteur>();

            InitializeComponent();
        }

        public void Init(List<Acteur> Acteurs, string label = "Acteurs")
        {
            //Les changements à ma liste ( => DataGrid ) impacteront ma list Personnes -> OK
            list = Acteurs;

            Label.Content = label;
            DataGrid.DataContext = list;
        }

        //On supprime la personne de la list
        private void Delete_Personne_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Delete_Personne_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            list.RemoveAt(DataGrid.SelectedIndex);
            DataGridInit();
        }


        //Ouvre une fenetre qui affiche la fenetre details d'une personne 
        private void Details_Personne_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Details_Personne_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ActeurDetails fenetreDetail = new ActeurDetails(list[DataGrid.SelectedIndex]);
            fenetreDetail.ShowDialog();
        }

        //Pour actualiser la DataGrid
        private void DataGridInit()
        {
            DataGrid.DataContext = null;
            DataGrid.DataContext = list;
        }


        //On ouvre une fenetre pour ajouter une personne
        private void Add_Personne_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Add_Personne_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            PersonneAdd fenetre = new PersonneAdd();

            fenetre.ShowDialog();
            Personne personne = (Personne)fenetre.DataContext;

            Acteur monActeur = new Acteur();
            monActeur.Nom = personne.Nom;
            monActeur.Prenom = personne.Prenom;
            monActeur.Age = personne.Age;
            monActeur.Role = "";

            if (!list.Contains(personne)) list.Add(monActeur);

            DataGridInit();
        }
    }
}
