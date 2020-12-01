using GestionFilm_Tanguy.Models.Saves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFilm_Tanguy.Models.Factory
{
    public class ContextFactory
    {
        public static void GetContext(SaveContext saveContext)
        {
            foreach (SavePersonne p in saveContext.Personnes) Context.Personnes.Add(PersonneFactory.GetPersonne(p));
            foreach (SaveFilm f in saveContext.Films) Context.Films.Add(FilmFactory.GetFilm(f));
        }

        public static SaveContext GetContext()
        {
            SaveContext result = new SaveContext();

            foreach (Personne p in Context.Personnes) result.Personnes.Add(PersonneFactory.GetPersonne(p));
            foreach (Film f in Context.Films) result.Films.Add(FilmFactory.GetFilm(f));

            return result;
        }

    }
}
