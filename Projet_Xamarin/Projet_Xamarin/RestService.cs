/*using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_Xamarin
{
    public class RestService
    {
        HttpClient client;
        public RestService()
        {
            client = new HttpClient();
        }
        public async Task<List<Contact>> loadAllContacts()
        {
            string RestUrl = "http://172.19.0.71:8088/api/personne/";
            var uri = new Uri(string.Format(RestUrl, string.Empty));
            List<Contact> items = new List<Contact>();
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<Contact>>(content);
                    return items;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

    }
}
*/