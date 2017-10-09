using Newtonsoft.Json;
using PonyXamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PonyXamarin.Services
{
    
    public sealed class RestClient
    {
        private const string API = "https://pony-api.herokuapp.com/api/pony";

        private HttpClient httpClient;

        public RestClient()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<Pony>> GetPonies() 
        {
            try
            {
                var response = await httpClient.GetAsync(API);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var list = JsonConvert.DeserializeObject<List<Pony>>(json);

                    return list;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return new List<Pony>();

        }

        public async Task<bool> PostPony(Pony pony)
        {
            try
            {
                var json = JsonConvert.SerializeObject(pony);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(API, content);
                if (response.StatusCode == HttpStatusCode.Created)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return false;

        }

        public async Task<bool> TruncatePonies()
        {
            try
            {
                var response = await httpClient.DeleteAsync(API);
                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return false;

        }
    }
}
