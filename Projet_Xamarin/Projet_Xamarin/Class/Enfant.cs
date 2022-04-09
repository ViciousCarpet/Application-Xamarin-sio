using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_Xamarin.Class
{
    public class Enfant
    {
        private string nom;
        private string prenom;
        private Parent leParent;
        private string classe;

        public Enfant(string unnom, string unprenom, Parent leParent, string laClasse)
        {
            this.nom = unnom;
            this.prenom = unprenom;
            this.leParent = leParent;
            this.classe = laClasse;
        }

        public Parent LeParent { get => leParent; set => leParent = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Classe { get => classe; set => classe = value; }
    }
}
