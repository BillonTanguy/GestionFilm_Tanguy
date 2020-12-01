using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFilm_Tanguy.Models
{
    public class SaveContext
    {
        public List<Personne> Personnes { get; set; }
        public List<Film> Films { get; set; }

        public SaveContext()
        {
            Personnes = new List<Personne>();
            Films = new List<Film>();
        }
    }
}
