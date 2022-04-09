using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Projet_Xamarin.Class;
using Projet_Xamarin.Dao;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projet_Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoterLivre : ContentPage
    {
        private Livre livre;
        public NoterLivre(Livre l)
        {
            InitializeComponent();
            livre = l;
        }

        public void OnButtonNoterClicked(object sender, EventArgs e)
        {
            if(Note.Text != "0" && Description.Text != "")
            {
                string RestUrl = "https://baruff.fr:4443/index.html";
                var uri = new Uri(string.Format(RestUrl, string.Empty));
                var json = JsonConvert.SerializeObject(livre);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                string sContentType = "application/json";
                JObject oJsonObject = new JObject();
                oJsonObject.Add("unParent", Global.IdUtilisateur);
                oJsonObject.Add("unLivre", livre.Id);
                oJsonObject.Add("uneNote", Note.Text);
                oJsonObject.Add("unCommentaire", Description.Text);

                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback += (sender2, cert, chain, sslPolicyErrors) => true;
                HttpClient client = new HttpClient(handler);
                var response = client.PostAsync("https://baruff.fr:4443/MVC/index.php?action=note", new StringContent(oJsonObject.ToString(), Encoding.UTF8, sContentType)).Result;
                string content2 = response.Content.ReadAsStringAsync().Result;
                Debug.WriteLine(content2);

                App.Current.MainPage = new PageAccueille(App.gd.LesLivres);
            }
        }

        public void OnButtonReturnClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new PageAccueille(App.gd.LesLivres);
        }

        private async void voirCommentaires_Clicked(object sender, EventArgs e)
        {
            CommentaireDAO commdao = new CommentaireDAO(livre);
            ObservableCollection<Noter> lesComms = new ObservableCollection<Noter>();
            lesComms = await commdao.GetAllNoteMoyCommentairesAsync();
            if (lesComms == null)
            {
                erreurNbCommentaires.Text = "Erreur, il n'y a actuellement aucun commentaire sur ce livre.";
                erreurNbCommentaires.Opacity=100;
                erreurNbCommentaires.BackgroundColor= Color.DarkOrange;
            }
            else
            {
                App.Current.MainPage = new Commentaires(lesComms);
            }
            
        }
    }
}