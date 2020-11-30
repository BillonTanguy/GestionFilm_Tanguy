using GestionFilm_Tanguy.Controls;
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

        public const string DOSSIER_EXPORT = @"..\..\Saves";

        public const string FILM_XML = "Film.xml";
        public const string PERSONNE_XML = "Personne.xml";

        public MainWindow()
        {
            //on initialise le context
            Context.Films = new List<Film>();
            Context.Personnes = new List<Personne>();

            InitializeComponent();
        }

        private void MenuItem_Ajouter_Film_Click(object sender, RoutedEventArgs e)
        {
            NewFilm fenetre = new NewFilm();
            fenetre.ShowDialog();
        }

        private void MenuItem_Ajouter_Personne_Click(object sender, RoutedEventArgs e)
        {
            NewPersonne fenetre = new NewPersonne();
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
            string CurrentDirectory = Directory.GetCurrentDirectory();
            //J'ai un fichier par type
            string chemin_personne = System.IO.Path.Combine(CurrentDirectory,DOSSIER_EXPORT, PERSONNE_XML);
            string chemin_film = System.IO.Path.Combine(CurrentDirectory, DOSSIER_EXPORT,FILM_XML);

            XmlSerializer serializerPersonne = new XmlSerializer(typeof(List<Personne>));
            XmlSerializer serializerFilm = new XmlSerializer(typeof(List<Film>));

            using (StreamReader reader = new StreamReader(chemin_personne))
                Context.Personnes = serializerPersonne.Deserialize(reader) as List<Personne>;
                

            using (StreamReader reader = new StreamReader(chemin_film))
                Context.Films = serializerFilm.Deserialize(reader) as List<Film>;

            //Pour refresh les datagrid
            DataGridFilmReset(Context.Films);
            DataGridPersonneReset(Context.Personnes);
        }

        //Enregistre dans fichiers xml
        //1 fichier pour les films et 1 fichiers pour les personnes pour simplifier
        private void MenuItem_Enregistrer_Click(object sender, RoutedEventArgs e)
        {

            string CurrentDirectory = Directory.GetCurrentDirectory();
            //J'ai un fichier par type
            string chemin_personne = System.IO.Path.Combine(CurrentDirectory, DOSSIER_EXPORT, PERSONNE_XML);
            string chemin_film = System.IO.Path.Combine(CurrentDirectory, DOSSIER_EXPORT, FILM_XML);

            XmlSerializer serializerPersonne = new XmlSerializer(typeof(List<Personne>));
            XmlSerializer serializerFilm = new XmlSerializer(typeof(List<Film>));

            using (StreamWriter writer = new StreamWriter(chemin_personne))
                serializerPersonne.Serialize(writer, Context.Personnes);

            using (StreamWriter writer = new StreamWriter(chemin_film))
                serializerFilm.Serialize(writer, Context.Films);
        }

        //Lance la fenetre Detail Film
        private void Film_ShowDetails(object sender, RoutedEventArgs e)
        {
            FilmDetails fenetre = new FilmDetails(((List<Film>)DG_Film.DataContext)[DG_Film.SelectedIndex]);
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
