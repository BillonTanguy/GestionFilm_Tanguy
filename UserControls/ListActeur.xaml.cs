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

        #region DELETE
        private void Delete_Personne_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Delete_Personne_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            list.RemoveAt(DataGrid.SelectedIndex);
            DataGridInit();
        }
        #endregion

        #region DETAILS
        private void Details_Personne_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Details_Personne_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ActeurDetails fenetreDetail = new ActeurDetails(list[DataGrid.SelectedIndex]);
            fenetreDetail.ShowDialog();
        }
        #endregion

        #region ADD
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
            monActeur.Id = personne.Id;
            monActeur.Nom = personne.Nom;
            monActeur.Prenom = personne.Prenom;
            monActeur.Age = personne.Age;

            //Je n'ai pas concervé la référence d'objet,
            //Je compare les Id
            bool present = false;
            foreach(Acteur a in list)
                if (a.Id == monActeur.Id) present = true;

            if (!present) list.Add(monActeur);

            DataGridInit();
        }
        #endregion

        //Pour actualiser la DataGrid
        private void DataGridInit()
        {
            DataGrid.DataContext = null;
            DataGrid.DataContext = list;
        }
    }
}
