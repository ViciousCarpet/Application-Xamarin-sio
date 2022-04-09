using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using Projet_Xamarin.Class;
using Projet_Xamarin.Dao;
using System.IdentityModel.Tokens.Jwt;

namespace Projet_Xamarin
{
    public class Global
    {
        public static string jwt;

        public static string JWT { get; set; }

        private static int idUtilisateur;
        public static int IdUtilisateur { get => idUtilisateur; set => idUtilisateur = value; }
    }
    public partial class MainPage : ContentPage
    {
        private string token;


        public PageAccueille pa;
        public MainPage()
        {
            InitializeComponent();
        }

        protected Dictionary<string, string> GetTokenInfo(string token)
        {
            var TokenInfo = new Dictionary<string, string>();

            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var claims = jwtSecurityToken.Claims.ToList();

            foreach (var claim in claims)
            {
                TokenInfo.Add(claim.Type, claim.Value);
            }

            return TokenInfo;
        }

        public async void OnButtonConnexionClicked(object sender, EventArgs e)
        {
            if (NomDutilisateur.Text != "" && mdp.Text != "")
            {
                string id = NomDutilisateur.Text;
                string motdp = mdp.Text;
                Parent p = new Parent(id, motdp);

                string RestUrl = "https://baruff.fr:4443/index.html";
                var uri = new Uri(string.Format(RestUrl, string.Empty));
                var json = JsonConvert.SerializeObject(p);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                string sContentType = "application/json";
                JObject oJsonObject = new JObject();
                oJsonObject.Add("id", id);
                oJsonObject.Add("mdp", motdp);
                Debug.WriteLine(oJsonObject.ToString());


                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback += (sender2, cert, chain, sslPolicyErrors) => true;
                var authHeader = new AuthenticationHeaderValue("Bearer", "");
                HttpClient client = new HttpClient(handler);
                client.DefaultRequestHeaders.Authorization = authHeader;


                var response = client.PostAsync("https://baruff.fr:4443/MVC/index.php?action=connexion", new StringContent(oJsonObject.ToString(), Encoding.UTF8, sContentType)).Result;
                string content2 = response.Content.ReadAsStringAsync().Result;

                if (content2 != "")
                {
                    this.token = content2;
                    Dictionary<string, string> resuToken = this.GetTokenInfo(content2);
                    string partieUser = resuToken.ElementAt(5).Value;
                    var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(partieUser);

                    char[] separators = new char[] { ' ', ':' };

                    string[] test = values.ElementAt(0).Value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    Debug.WriteLine(test);

                    Global.IdUtilisateur = Convert.ToInt32(test[0]);

                    Debug.WriteLine(resuToken);

                    Global.JWT = content2;

                    App.Current.MainPage = new PageAccueille(App.gd.LesLivres);
                }


                else
                {
                    erreur.Opacity = 100;
                    erreur.BackgroundColor = Color.DarkRed;
                    erreur.Text = "L\'identifiant ou le mot de passe est incorrect!";
                    NomDutilisateur.Text = null;
                    mdp.Text = null;
                    this.token = null;
                }
            }
            else
            {
                erreur.Opacity = 100;
                erreur.BackgroundColor = Color.DarkOrange;
                erreur.Text = "Il faut renseigner un identifiant et un mot de passe!";
                this.token = null;
            }
        }
        public void OnButtonInscriptionClicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Inscription();
        }

    }
}
