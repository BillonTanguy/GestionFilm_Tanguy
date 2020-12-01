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
    /// Logique d'interaction pour ActeurControl.xaml
    /// </summary>
    public partial class ActeurControl : UserControl
    {
        public event RoutedEventHandler SaveChangesActeur;
        public event RoutedEventHandler AddActeur;
        public Acteur Acteur { get; set; }
        public ActeurControl()
        {
            InitializeComponent();
        }

        public void Init(Acteur acteur, bool btnSaveChanges = true, bool btnAdd = false, int width = 420, int height = 150)
        {
            Acteur = acteur;

            MonControl.DataContext = new { Width = width, Height = height };
            TB_Nom.Text = Acteur.Nom;
            TB_Prenom.Text = Acteur.Prenom;
            TB_Age.Text = Acteur.Age;
            TB_Role.Text = Acteur.Role;

            //Pour cacher le bouton si besoin 
            if (!btnSaveChanges) BTN_SaveChanges.Visibility = Visibility.Collapsed;
            if (!btnAdd) BTN_Add.Visibility = Visibility.Collapsed;
        }

        //SavesChanges
        private void SaveChanges_Acteur_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveChanges_Acteur_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Acteur.Nom = TB_Nom.Text;
            Acteur.Prenom = TB_Prenom.Text;
            Acteur.Age = TB_Age.Text;
            Acteur.Role = TB_Role.Text;

            SaveChangesActeur?.Invoke(sender, e);
        }

        //AddPersonne
        private void Add_Acteur_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Add_Acteur_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Acteur.Nom = TB_Nom.Text;
            Acteur.Prenom = TB_Prenom.Text;
            Acteur.Age = TB_Age.Text;
            Acteur.Role = TB_Role.Text;

            Context.Personnes.Add(Acteur);

            AddActeur?.Invoke(sender, e);
        }
    }
}
