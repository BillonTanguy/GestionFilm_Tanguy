﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GestionFilm_Tanguy.Commands
{
    public class CustomCommands
    {
        public static readonly RoutedUICommand Ajouter_Film = new RoutedUICommand();
        public static readonly RoutedUICommand Ajouter_Personne = new RoutedUICommand();

        public static readonly RoutedUICommand Delete_Personne = new RoutedUICommand();
        public static readonly RoutedUICommand Details_Personne = new RoutedUICommand();
        public static readonly RoutedUICommand Add_Personne = new RoutedUICommand();
        public static readonly RoutedUICommand SaveChanges_Personne = new RoutedUICommand();

        public static readonly RoutedUICommand Delete_Film = new RoutedUICommand();
        public static readonly RoutedUICommand Details_Film = new RoutedUICommand();
        public static readonly RoutedUICommand Add_Film = new RoutedUICommand();
        public static readonly RoutedUICommand SaveChanges_Film = new RoutedUICommand();

        public static readonly RoutedUICommand Add_Acteur = new RoutedUICommand();
        public static readonly RoutedUICommand SaveChanges_Acteur = new RoutedUICommand();

        public static readonly RoutedUICommand OpenFile = new RoutedUICommand();
        public static readonly RoutedUICommand SaveAsFile = new RoutedUICommand();
        public static readonly RoutedUICommand Research = new RoutedUICommand();

    }
}
