using GestionFilm_Tanguy.Models.Saves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFilm_Tanguy.Models.Factory
{
    public class FilmFactory
    {
        public static SaveFilm GetFilm(Film film)
        {
            SaveFilm result = new SaveFilm();

            result.Id = film.Id;
            result.Titre = film.Titre;
            result.Annee = film.Annee;

            foreach (Personne p in film.Realisateurs) result.Realisateurs.Add(p.Id);
            foreach (Personne p in film.Producteurs) result.Producteurs.Add(p.Id);
            foreach (Personne p in film.Acteurs) result.Acteurs.Add(p.Id);

            return result;
        }

        public static Film GetFilm(SaveFilm saveFilm)
        {
            Film result = new Film();

            result.Id = saveFilm.Id;
            result.Titre = saveFilm.Titre;
            result.Annee = saveFilm.Annee;

            if (Context.Personnes.Count < 1) return result;

            foreach (int p in saveFilm.Realisateurs) result.Realisateurs.Add(Context.Personnes.FirstOrDefault(pers => pers.Id == p));
            foreach (int p in saveFilm.Producteurs) result.Producteurs.Add(Context.Personnes.FirstOrDefault(pers => pers.Id == p));
            for(int index = 0; index < saveFilm.Acteurs.Count; index++)
            {
                Acteur actor = new Acteur();

                Personne Personne = Context.Personnes.FirstOrDefault(pers => pers.Id == saveFilm.Acteurs[index]);

                actor.Id = Personne.Id;
                actor.Nom = Personne.Nom;
                actor.Prenom = Personne.Prenom;
                actor.Age = Personne.Age;
                actor.Role = saveFilm.Roles[index];
            }

            return result;
        }
    }
}
