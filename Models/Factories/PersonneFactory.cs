using GestionFilm_Tanguy.Models.Saves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFilm_Tanguy.Models.Factory
{
    public class PersonneFactory
    {
        public static Personne GetPersonne(SavePersonne savePersonne)
        {
            Personne result = new Personne();

            result.Id = savePersonne.Id;
            result.Nom = savePersonne.Nom;
            result.Prenom = savePersonne.Prenom;
            result.Age = savePersonne.Age;

            return result;
        }

        public static SavePersonne GetPersonne(Personne personne)
        {
            SavePersonne result = new SavePersonne();

            result.Id = personne.Id;
            result.Nom = personne.Nom;
            result.Prenom = personne.Prenom;
            result.Age = personne.Age;

            return result;
        }
    }
}
