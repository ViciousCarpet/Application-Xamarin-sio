using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_Xamarin
{
    public class Parent
    {
        private string identifiant;
        private string mdp;

        public Parent(string iden, string Motdp)
        {
            this.Identifiant = iden;
            this.Mdp = Motdp;
        }

        public string Identifiant { get => identifiant; set => identifiant = value; }
        public string Mdp { get => mdp; set => mdp = value; }
    }
}
