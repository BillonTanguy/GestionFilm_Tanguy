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

namespace GestionFilm_Tanguy.UserControls
{
    /// <summary>
    /// Logique d'interaction pour ExplorateurFichierControl.xaml
    /// </summary>
    public partial class ExplorateurFichierControl : UserControl
    {
        public event RoutedEventHandler Open;
        public event RoutedEventHandler Save;

        public string CheminFile {get;set;}
        private bool btnOpen { get; set; }

        public string[] FilesPath { get; set; }
        public List<string> FileName { get; set; }

        public ExplorateurFichierControl()
        {
            InitializeComponent();

            FileName = new List<string>();
        }

        public void Init(string Chemin, bool Open = true)
        {
            CheminFile = Chemin;
            btnOpen = Open;

            if (btnOpen)
            {
                Btn_Ouvrir.Visibility = Visibility.Visible;
                Btn_Enregistrer.Visibility = Visibility.Collapsed;
            }
            else
            {
                Btn_Ouvrir.Visibility = Visibility.Collapsed;
                Btn_Enregistrer.Visibility = Visibility.Visible;
            }

            FilesPath = Directory.GetFiles(CheminFile);

            foreach (string s in FilesPath) FileName.Add(s.Split('\\')[s.Split('\\').Length-1]);
                
            ListViewFile.DataContext = FileName;
        }

        #region OPEN
        private void OpenFile_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (btnOpen) e.CanExecute = true;
            else e.CanExecute = false;
        }

        private void OpenFile_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (FileName.Contains(TextBox_Rechercher.Text))
                Open?.Invoke(FileName.FirstOrDefault(f => f == TextBox_Rechercher.Text), e);
        }
        #endregion

        #region SAVE
        private void SaveAsFile_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (!btnOpen) e.CanExecute = true;
            else e.CanExecute = false;
        }

        private void SaveAsFile_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string fileName = TextBox_Rechercher.Text;

            if (FileName.Contains(fileName)) return;  //pour l'instant on ne fait rien
            else Save?.Invoke(fileName, e);
        }
        #endregion

        #region RESEARCH
        private void Research_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Research_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            List<string> list = new List<string>();

            foreach (string s in FileName) if (s.Contains(TextBox_Rechercher.Text)) list.Add(s);
            ListViewReset(list);
        }
        #endregion

        private void ListViewReset(List<string> list)
        {
            ListViewFile.DataContext = null;
            ListViewFile.DataContext = list;
        }

        private void ListViewFile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBox_Rechercher.Text = (string)ListViewFile.SelectedItem;
        }
    }
}
