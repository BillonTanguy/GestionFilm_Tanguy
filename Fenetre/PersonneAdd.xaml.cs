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
    /// Logique d'interaction pour PersonneAdd.xaml
    /// </summary>
    public partial class PersonneAdd : Window
    {
        
        public PersonneAdd()
        {
            InitializeComponent();

            ComboBox.DataContext = Context.Personnes;
        }

        private void Ajouter_Personne_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Ajouter_Personne_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DataContext = Context.Personnes[ComboBox.SelectedIndex];
            this.Close();
        }
    }
}
