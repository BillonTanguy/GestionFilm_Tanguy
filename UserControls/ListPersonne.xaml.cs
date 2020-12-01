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
    /// Logique d'interaction pour ListPersonne.xaml
    /// </summary>
    public partial class ListPersonne : UserControl
    {

        public List<Personne> list { get; set; }

        public ListPersonne()
        {
            list = new List<Personne>();

            InitializeComponent();
        }

        public void Init(List<Personne> Personnes, string label = "Personnes", Film film = null)
        {
            //Les changements à ma liste ( => DataGrid ) impacteront ma list Personnes -> OK
            list = Personnes;

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
            PersonneDetails fenetreDetail = new PersonneDetails(list[DataGrid.SelectedIndex]);
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

            if (!list.Contains(personne)) list.Add(personne);

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
