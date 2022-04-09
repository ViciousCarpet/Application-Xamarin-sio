using System;
using System.Collections.Generic;
using System.Text;
using Projet_Xamarin.Dao;
using Projet_Xamarin.Class;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Projet_Xamarin.Dao
{
    public class LivreDAO : DAO
    {
        private ObservableCollection<Livre> lesLivres = new ObservableCollection<Livre>();

        public LivreDAO()
        {

        }


        public async Task<ObservableCollection<Livre>> GetAllBookAsync()
        {
            var response = client.GetAsync(apiLink + "?action=livre").Result;
            var result = await response.Content.ReadAsStringAsync();

            this.lesLivres = JsonConvert.DeserializeObject<ObservableCollection<Livre>>(result);

            return lesLivres;
        }
    }
}
