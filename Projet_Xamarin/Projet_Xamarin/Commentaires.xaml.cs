using Projet_Xamarin.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet_Xamarin.Dao;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace Projet_Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Commentaires : ContentPage
    {
        private ObservableCollection<Noter> lesComs = new ObservableCollection<Noter>();
        public Commentaires(ObservableCollection<Noter> lesComms)
        {
            this.lesComs = lesComms;
            InitializeComponent();
            CommentaireView.ItemsSource = lesComms;
           
        }
        public void OnButtonReturnClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new PageAccueille(App.gd.LesLivres);
        }
    }
}