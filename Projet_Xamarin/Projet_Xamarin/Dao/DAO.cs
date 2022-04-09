using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Projet_Xamarin.Class
{
    public class DAO
    {
        public string apiLink = "";
        public HttpClient client;
        public JObject json = new JObject();
        public string token = null;

        public DAO()
        {
            HttpClientHandler leclient = new HttpClientHandler();
            leclient.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            this.client = new HttpClient(leclient);
        }
    }
}
