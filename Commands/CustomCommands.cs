using System;
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
        public static readonly RoutedUICommand Delete_Film = new RoutedUICommand();
        

        public static readonly RoutedUICommand Ajouter_Personne = new RoutedUICommand();

        public static readonly RoutedUICommand Delete_Personne = new RoutedUICommand();
        public static readonly RoutedUICommand Details_Personne = new RoutedUICommand();
        public static readonly RoutedUICommand Add_Personne = new RoutedUICommand();
        public static readonly RoutedUICommand SaveChanges_Personne = new RoutedUICommand();

        public static readonly RoutedUICommand SaveChanges_Film = new RoutedUICommand();

    }
}
