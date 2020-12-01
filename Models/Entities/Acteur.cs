using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFilm_Tanguy.Models
{
    public class Acteur : Personne
    {
        private string role;

        public string Role
        {
            get { return role; }
            set
            {
                role = value;
                Notify();
            }
        }
    }
}
