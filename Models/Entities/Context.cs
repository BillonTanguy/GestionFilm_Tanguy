using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFilm_Tanguy.Models
{
    public class Context
    {
        public static string DOSSIER_EXPORT = @"..\..\Saves";
        public static string CONTEXT_XML = "SaveContext.xml";

        public static List<Personne> Personnes { get; set; }
        public static List<Film> Films { get; set; }

        

        public Context()
        {
            Personnes = new List<Personne>();
            Films = new List<Film>();
        }
    }
}
