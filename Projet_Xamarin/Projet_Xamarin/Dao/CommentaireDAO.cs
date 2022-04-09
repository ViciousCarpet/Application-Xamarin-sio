using System;
using System.Collections.Generic;
using System.Text;
using Projet_Xamarin.Dao;
using Projet_Xamarin.Class;
using System.Net.Http;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Projet_Xamarin.Dao
{
    class CommentaireDAO : DAO
    {
        private ObservableCollection<Noter> lesNotesMoyCommentaires = new ObservableCollection<Noter>();
        private Livre livre;
        public CommentaireDAO(Livre unLivre) {
            this.livre = unLivre;
        }

        public async Task<ObservableCollection<Noter>> GetAllNoteMoyCommentairesAsync()
        {
            var response = client.GetAsync(apiLink + "?action=note&idLivre="+livre.Id).Result;
            var result = await response.Content.ReadAsStringAsync();

            if (result!="false")
            {
                this.lesNotesMoyCommentaires = JsonConvert.DeserializeObject<ObservableCollection<Noter>>(result);
                return lesNotesMoyCommentaires;
            }

            else
            {
                return null;
            }
            
        }

    }
}
