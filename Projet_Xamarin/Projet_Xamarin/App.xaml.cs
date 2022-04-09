using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Projet_Xamarin.Dao;
using Projet_Xamarin.Class;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Projet_Xamarin
{
    public partial class App : Application
    {
        public static GestionData gd = new GestionData();

        public App()
        {
            InitializeComponent();

            MainPage mp = new MainPage();
            mp.Title = "Bienvenue sur mon appli !";

            this.MainPage = new NavigationPage(mp)
            {
                BarBackgroundColor = Color.FromHex("#e3f5ab"),
                BarTextColor = Color.Black,    
            };
        }

        protected override async void OnStart()
        {
            LivreDAO livreDAO = new LivreDAO();
            gd.LesLivres = await livreDAO.GetAllBookAsync();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
