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
    /// Logique d'interaction pour ActeurDetails.xaml
    /// </summary>
    public partial class ActeurDetails : Window
    {
        public Acteur Acteur { get; set; }
        public ActeurDetails(Acteur acteur, bool btnSaveChanges = true, bool btnAdd = false)
        {
            InitializeComponent();

            Acteur = acteur;

            ActeurControl.Init(Acteur, btnSaveChanges, btnAdd);
        }

        //Les boutons sont dans le UserControl
        //Quand on a sauvegardé les changements, la fenêtre doit fermer
        private void ActeurControl_SaveChanges(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ActeurControl_Add(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
