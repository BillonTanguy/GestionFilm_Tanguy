using GestionFilm_Tanguy.Fenetre;
using GestionFilm_Tanguy.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;

namespace GestionFilm_Tanguy
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Context Context { get; set; }

        public MainWindow()
        {
            //on initialise le context
            Context.Films = new List<Film>();
            Context.Personnes = new List<Personne>();

            InitializeComponent();
        }

        private void MenuItem_Ajouter_Film_Click(object sender, RoutedEventArgs e)
        {
            FilmDetails fenetre = new FilmDetails(new Film(), false, true);
            fenetre.ShowDialog();
        }

        private void MenuItem_Ajouter_Personne_Click(object sender, RoutedEventArgs e)
        {
            PersonneDetails fenetre = new PersonneDetails(new Personne(), false, true);
            fenetre.ShowDialog();
        }

        private void Btn_Rechercher_Click(object sender, RoutedEventArgs e)
        {
            List<Film> listFilm = new List<Film>();
            List<Personne> listPersonne = new List<Personne>();

            foreach (Film film in Context.Films)
            {
                if (film.Titre.Contains(TextBox_Rechercher.Text) || film.Annee.Contains(TextBox_Rechercher.Text))
                {
                    listFilm.Add(film);
                }
            }
            
            foreach (Personne personne in Context.Personnes)
            {
                if (personne.Nom.Contains(TextBox_Rechercher.Text) || personne.Prenom.Contains(TextBox_Rechercher.Text) || personne.Age.Contains(TextBox_Rechercher.Text))
                {
                    listPersonne.Add(personne);
                }
            }

            //Pour refresh les datagrid
            DataGridFilmReset(listFilm);
            DataGridPersonneReset(listPersonne);

        }

        //Ouvre fichiers xml
        private void MenuItem_Ouvrir_Click(object sender, RoutedEventArgs e)
        {
            SaveContext Save = new SaveContext();

            string CurrentDirectory = Directory.GetCurrentDirectory();
            string chemin_Context = System.IO.Path.Combine(CurrentDirectory, Context.DOSSIER_EXPORT, Context.CONTEXT_XML);

            XmlSerializer serializerFilm = new XmlSerializer(typeof(SaveContext));
            
            using (StreamReader reader = new StreamReader(chemin_Context))
                Save = serializerFilm.Deserialize(reader) as SaveContext;

            Context.Films = Save.Films;
            Context.Personnes = Save.Personnes;

            //Pour refresh les datagrid
            DataGridFilmReset(Context.Films);
            DataGridPersonneReset(Context.Personnes);
        }

        //Enregistre dans fichiers xml
        private void MenuItem_Enregistrer_Click(object sender, RoutedEventArgs e)
        {
            //On copie notre Context dans un objet intermédiaire car les liste sont static => probleme avec Serialisation
            SaveContext Save = new SaveContext();
            Save.Personnes = Context.Personnes;
            Save.Films = Context.Films;

            //Le chemin du fichier
            string CurrentDirectory = Directory.GetCurrentDirectory();
            string chemin_Context = System.IO.Path.Combine(CurrentDirectory, Context.DOSSIER_EXPORT, Context.CONTEXT_XML);

            XmlSerializer serializerFilm = new XmlSerializer(typeof(SaveContext));

            using (StreamWriter writer = new StreamWriter(chemin_Context))
                serializerFilm.Serialize(writer, Save);
        }

        private void MenuItem_EnregistrerSous_Click(object sender, RoutedEventArgs e)
        {

        }

        //Lance la fenetre Detail Film
        private void Film_ShowDetails(object sender, RoutedEventArgs e)
        {
            FilmDetails fenetre = new FilmDetails(((List<Film>)DG_Film.DataContext)[DG_Film.SelectedIndex], true, false);
            fenetre.ShowDialog();
        }

        //Lance la fenetre Detail Personne
        private void Personne_ShowDetails(object sender, RoutedEventArgs e)
        {
            PersonneDetails fenetre = new PersonneDetails(((List<Personne>)DG_Personne.DataContext)[DG_Personne.SelectedIndex]);
            fenetre.ShowDialog();
        }


        //Pour refresh les datagrid
        private void DataGridFilmReset(List<Film> list)
        {
            DG_Film.DataContext = null;
            DG_Film.DataContext = list;
        }
        
        private void DataGridPersonneReset(List<Personne> list)
        {
            DG_Personne.DataContext = null;
            DG_Personne.DataContext = list;
        }

    }
}
