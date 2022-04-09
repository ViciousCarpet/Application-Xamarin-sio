using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Collections.ObjectModel;

namespace Projet_Xamarin.Class
{
    public class Livre
    {
        private int id;
        private string titre;
        private string auteur;
        private string isbn;

        public Livre()
        {
        }

        public Livre(int id, string titre, string auteur, string isbn)
        {
            this.id = id;
            this.titre = titre;
            this.auteur = auteur;
            this.isbn = isbn;
        }

        public int Id { get => id; set => id = value; }
        public string Titre { get => titre; set => titre = value; }
        public string Auteur { get => auteur; set => auteur = value; }
        public string Isbn { get => isbn; set => isbn = value; }
    }
}
