﻿using GestionFilm_Tanguy.Fenetre;
using GestionFilm_Tanguy.Models;
using GestionFilm_Tanguy.Models.Factory;
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
        public MainWindow()
        {
            //on initialise le context
            Context.Films = new List<Film>();
            Context.Personnes = new List<Personne>();

            InitializeComponent();
        }

        #region MENU AJOUTER
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
        #endregion

        #region RECHERCHER
        private void Btn_Rechercher_Click(object sender, RoutedEventArgs e)
        {
            List<Film> listFilm = new List<Film>();
            List<Personne> listPersonne = new List<Personne>();

            foreach (Film film in Context.Films)
                if (film.Titre.Contains(TextBox_Rechercher.Text) || film.Annee.Contains(TextBox_Rechercher.Text))
                    listFilm.Add(film);
            
            foreach (Personne personne in Context.Personnes)
                if (personne.Nom.Contains(TextBox_Rechercher.Text) || personne.Prenom.Contains(TextBox_Rechercher.Text) || personne.Age.Contains(TextBox_Rechercher.Text))
                    listPersonne.Add(personne);

            //Pour refresh les datagrid
            DataGridFilmReset(listFilm);
            DataGridPersonneReset(listPersonne);

        }
        #endregion

        #region XML
        //Ouvre fichiers xml
        private void MenuItem_Ouvrir_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow_FileExplorer();

            SaveContext Save = GetFile();

            if (Save == null) return;

            Context.Films.Clear();
            Context.Personnes.Clear();
            ContextFactory.GetContext(Save);

            //Pour refresh les datagrid
            DataGridFilmReset(Context.Films);
            DataGridPersonneReset(Context.Personnes);
        }

        //Enregistre dans fichiers xml
        private void MenuItem_Enregistrer_Click(object sender, RoutedEventArgs e)
        {
            if (Context.CONTEXT_XML == "") return;

            //On copie notre Context dans un objet intermédiaire car les liste sont static => probleme avec Serialisation
            SaveContext Save = ContextFactory.GetContext();

            //Le chemin du fichier
            string CurrentDirectory = Directory.GetCurrentDirectory();
            string chemin_Context = System.IO.Path.Combine(CurrentDirectory, Context.DOSSIER_EXPORT, Context.CONTEXT_XML);

            XmlSerializer serializerFilm = new XmlSerializer(typeof(SaveContext));

            using (StreamWriter writer = new StreamWriter(chemin_Context))
                serializerFilm.Serialize(writer, Save);
        }

        private void MenuItem_EnregistrerSous_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow_FileExplorer(false);
            MenuItem_Enregistrer_Click(null, null);
        }

        private void OpenWindow_FileExplorer(bool OpenMode = true)
        {
            //On ouvre l'explorateur de fichier
            string CurrentDirectory2 = Directory.GetCurrentDirectory();
            string chemin_Context3 = System.IO.Path.Combine(CurrentDirectory2, Context.DOSSIER_EXPORT);

            ExplorateurFichier fenetre = new ExplorateurFichier(chemin_Context3, OpenMode);
            fenetre.ShowDialog();
        }

        private SaveContext GetFile()
        {
            if (Context.CONTEXT_XML == "") return null;

            SaveContext Save = new SaveContext();

            string CurrentDirectory = Directory.GetCurrentDirectory();
            string chemin_Context = System.IO.Path.Combine(CurrentDirectory, Context.DOSSIER_EXPORT, Context.CONTEXT_XML);

            XmlSerializer serializerFilm = new XmlSerializer(typeof(SaveContext));

            using (StreamReader reader = new StreamReader(chemin_Context))
                Save = serializerFilm.Deserialize(reader) as SaveContext;

            return Save;
        }
        #endregion

        #region DETAILS
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

        #endregion

        #region REFRESH GRID
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
        #endregion
    }
}
