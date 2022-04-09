using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;

namespace Projet_Xamarin.Class
{
    public class GestionData
    {
        private ObservableCollection<Livre> lesLivres;

        public ObservableCollection<Livre> LesLivres { get => lesLivres; set => lesLivres = value; }

        public GestionData()
        {
            this.lesLivres = new ObservableCollection<Livre>();

            this.lesLivres.Add(new Livre() { Id = 1, Titre = "Ouioui à la plage", Auteur = "toto", Isbn = "123456789" });
            this.lesLivres.Add(new Livre() { Id = 2, Titre = "Ouioui à la plage 2", Auteur = "toto", Isbn = "123456745" });
            this.lesLivres.Add(new Livre() { Id = 3, Titre = "petit ours brun", Auteur = "toto", Isbn = "112456789" });
            this.lesLivres.Add(new Livre() { Id = 4, Titre = "Titeuf", Auteur = "toto", Isbn = "123976789" });
        }
    }
}
