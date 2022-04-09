using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_Xamarin.Class
{
    public class Noter
    {
        private int idParent;
        private int idLivre;
        private int note;
        private string commentaire;
        private DateTime dateNot;

        public Noter(int parent, int livre, int note, string commentaire, DateTime uneDate)
        {
            this.idParent = parent;
            this.idLivre = livre;
            this.note = note;
            this.commentaire = commentaire;
            this.dateNot = uneDate;
        }

        public string Commentaire { get => commentaire; set => commentaire = value; }
        public int Note { get => note; set => note = value; }
        public int IdLivre { get => idLivre; set => idLivre = value; }
        public int IdParent { get => idParent; set => idParent = value; }
        public DateTime DateNot { get => dateNot; set => dateNot = value; }
    }
}
