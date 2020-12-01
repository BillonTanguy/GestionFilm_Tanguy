using GestionFilm_Tanguy.Models.Saves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFilm_Tanguy.Models
{
    public class SaveContext
    {
        public List<SavePersonne> Personnes { get; set; }
        public List<SaveFilm> Films { get; set; }

        public SaveContext()
        {
            Personnes = new List<SavePersonne>();
            Films = new List<SaveFilm>();
        }
    }
}
