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
    /// Logique d'interaction pour Ajout_Personne_To_Film.xaml
    /// </summary>
    public partial class Ajout_Personne_To_Film : Window
    {

        public List<Personne> aModifier { get; set; }

        public Ajout_Personne_To_Film(List<Personne> personnes)
        {
            aModifier = personnes;

            InitializeComponent();

            Add_Personne_To_Film_CB.DataContext = Context.Personnes;
        }


        private void Ajouter_Personne_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Ajouter_Personne_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            aModifier.Add(Context.Personnes[Add_Personne_To_Film_CB.SelectedIndex]);
            this.Close();
        }
    }
}
