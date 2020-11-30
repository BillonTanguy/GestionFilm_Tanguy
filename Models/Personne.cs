using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFilm_Tanguy.Models
{
    public class Personne : BaseModel
    {
        private string nom;
        private string prenom;
        private string age;

        public string Nom
        {
            get { return nom; }
            set 
            {
                nom = value;
                Notify();
            }
        }
        public string Prenom
        {
            get { return prenom; }
            set
            {
                prenom = value;
                Notify();
            }
        }
        public string Age
        {
            get { return age; }
            set
            {
                age = value;
                Notify();
            }
        }
    }
}
