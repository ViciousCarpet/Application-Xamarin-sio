using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Projet_Xamarin.Dao;
using Projet_Xamarin.Class;

namespace Projet_Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inscription : ContentPage
    {
        public Inscription()
        {
            InitializeComponent();
        }


        public void OnButtonInscriptionConnexionClicked(object sender, EventArgs e)
        {
            if (NomDutilisateur.Text != "" && mdp.Text != "" && NomEnfant.Text != "" && PnomEnfant.Text != "" && ClasseEnfant.Text != "")
            {
                string id = NomDutilisateur.Text;
                string motdp = mdp.Text;
                string NomdEnfant = NomEnfant.Text;
                string PrenomEnfant = PnomEnfant.Text;
                string ClassedEnfant = ClasseEnfant.Text;
                Parent p = new Parent(id, motdp);
                Enfant enfant = new Enfant(NomdEnfant, PrenomEnfant, p, ClassedEnfant);

                string RestUrl = "https://baruff.fr:4443/index.html";
                var uri = new Uri(string.Format(RestUrl, string.Empty));
                var json = JsonConvert.SerializeObject(enfant);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                string sContentType = "application/json";
                JObject oJsonObject = new JObject();
                oJsonObject.Add("id", id);
                oJsonObject.Add("mdp", motdp);
                oJsonObject.Add("nomEnf", NomdEnfant);
                oJsonObject.Add("prenomEnf", PrenomEnfant);
                oJsonObject.Add("classe", ClassedEnfant);
                Debug.WriteLine(oJsonObject.ToString());


                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback += (sender2, cert, chain, sslPolicyErrors) => true;
                var authHeader = new AuthenticationHeaderValue("Bearer", "");
                HttpClient client = new HttpClient(handler);
                client.DefaultRequestHeaders.Authorization = authHeader;


                var response = client.PutAsync("https://baruff.fr:4443/MVC/index.php?action=connexion", new StringContent(oJsonObject.ToString(), Encoding.UTF8, sContentType)).Result;
                string content2 = response.Content.ReadAsStringAsync().Result;

                App.Current.MainPage = new MainPage();
            }
            else
            {
                erreur.Opacity = 100;
                erreur.BackgroundColor = Color.DarkRed;
                erreur.Text = "Les champs ne doivent pas être vide";
            }
        }
        public void OnButtonRetourClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage();
        }
    }
}