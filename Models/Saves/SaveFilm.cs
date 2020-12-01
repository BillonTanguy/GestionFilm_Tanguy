using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFilm_Tanguy.Models.Saves
{
    public class SaveFilm : BaseModel
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

        public List<int> Realisateurs { get; set; }
        public List<int> Producteurs { get; set; }
        public List<int> Acteurs { get; set; }
        public List<string> Roles { get; set; }

        public SaveFilm()
        {
            Realisateurs = new List<int>();
            Producteurs = new List<int>();
            Acteurs = new List<int>();
            Roles = new List<string>();
        }
    }
}
