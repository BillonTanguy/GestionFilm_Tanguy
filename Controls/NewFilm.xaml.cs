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
    /// Logique d'interaction pour NewFilm.xaml
    /// </summary>
    public partial class NewFilm : Window
    {

        public NewFilm()
        {
            InitializeComponent();
        }

        private void Ajouter_Film_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Ajouter_Film_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Film film = new Film
            {
                Titre = Film_TextBox_Titre.Text,
                Annee = Film_TextBox_Anne.Text,
            };

            Context.Films.Add(film);

            this.Close();
        }
    }
}
