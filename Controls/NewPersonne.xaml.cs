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
    /// Logique d'interaction pour NewPersonne.xaml
    /// </summary>
    public partial class NewPersonne : Window
    {
        public NewPersonne()
        {
            InitializeComponent();
        }

        private void Ajouter_Personne_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Ajouter_Personne_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Personne personnes = new Personne
            {
                Nom = Personne_TextBox_Nom.Text,
                Prenom = Personne_TextBox_Prenom.Text,
                Age = Personne_TextBox_Age.Text,
            };

            Context.Personnes.Add(personnes);

            this.Close();
        }
    }
}
