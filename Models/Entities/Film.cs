using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFilm_Tanguy.Models
{
    public class Film : BaseModel
    {
        private int id;
        private string titre;
        private string annee;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                Notify();
            }
        }

        public string Titre
        {
            get { return titre; }
            set
            {
                titre = value;
                Notify();
            }
        }
        public string Annee
        {
            get { return annee; }
            set
            {
                annee = value;
                Notify();
            }
        }

        public List<Personne> Realisateurs { get; set; }
        public List<Personne> Producteurs { get; set; }
        public List<Acteur> Acteurs { get; set; }

        public Film()
        {
            Realisateurs = new List<Personne>();
            Producteurs = new List<Personne>();
            Acteurs = new List<Acteur>();
        }
    }
}
