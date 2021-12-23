using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Personal_WebAssembly.Interfaces;
using System.Text;
using Blazored.LocalStorage;
using System.Net.Http.Json;

namespace Personal_WebAssembly.Repos
{
    public class BaseRepo <T> : IBaseRepo<T> where T : class
    {

        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;

        public BaseRepo(HttpClient client, ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        //mislq che toq method e po dobre i po lesno za implementirane
        //this are the 2 different methods i used but i think i made my lfie harder with the 2nd method i used in the server side so probbly have to change Server side as well
        // and m.b i dont need this Repos connections at all i can dicrectly use this in the Author razor page and make the call from there
        // if have time after giving the project before wrting the bachelro change the Page API calls so they look much ezer to understand from other users
        // so i can give the Githup code with the CV
        public async Task<T> Get(string url, int id)
        {

            _client.DefaultRequestHeaders.Authorization =
             new AuthenticationHeaderValue("bearer", await GetBearerToken());

            var result = await _client.GetFromJsonAsync<T>(url + id);

            return result;


       //     var requestlink = new HttpRequestMessage(HttpMethod.Get, url + id);
       //     if (id < 1)
       //     {
       //         return null;
       //     }
       ////     requestlink.Content = new StringContent(JsonConvert.SerializeObject(tmp));
       //     var client = _client.CreateClient();
       //     HttpResponseMessage responselink = await client.SendAsync(requestlink);
       //     if (responselink.StatusCode == System.Net.HttpStatusCode.OK)
       //     {
       //         var data = await responselink.Content.ReadAsStringAsync();
       //         // here i return the content
       //         return JsonConvert.DeserializeObject<T>(data);
       //     }
       //     return null;
        }

        public async Task<IList<T>> GetAll(string url)
        {

            _client.DefaultRequestHeaders.Authorization =
             new AuthenticationHeaderValue("bearer", await GetBearerToken());

            var result = await _client.GetFromJsonAsync<IList<T>>(url);

            return result;
        }

        public async Task<bool> Create(string url, T tmp)
        {
            //here i add the token for authen
            _client.DefaultRequestHeaders.Authorization =
              new AuthenticationHeaderValue("bearer", await GetBearerToken());

            HttpResponseMessage responselink = await _client.PostAsJsonAsync(url, tmp);

            if (responselink.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return true;
            }
            return false;

            //Server Base repo
            //var requestlink = new HttpRequestMessage(HttpMethod.Post, url);
            //if(tmp == null)
            //{
            //    return false;
            //}
            //requestlink.Content = new StringContent(JsonConvert.SerializeObject(tmp)
            //, Encoding.UTF8, "application/json");
            //var client = _client.CreateClient();
            //HttpResponseMessage responselink = await client.SendAsync(requestlink);
            //if (responselink.StatusCode == System.Net.HttpStatusCode.Created)
            //{
            //    return true;
            //}
            //return false;

        }

        public async Task<bool> Update(string url, T tmp , int id)
        {

            var requestlink = new HttpRequestMessage(HttpMethod.Put, url+id);
            if (tmp == null)
            {
                return false;
            }

            _client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("bearer", await GetBearerToken());

            HttpResponseMessage responselink = await _client.PutAsJsonAsync<T>(url + id, tmp);
            if (responselink.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(string url, int id)
        {

        
            if (id < 1)
            {
                return false;
            }
            //_client.DefaultRequestHeaders.Authorization =
            //new AuthenticationHeaderValue("bearer", await GetBearerToken());
            HttpResponseMessage responselink = await _client.DeleteAsync(url + id);
            if (responselink.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;


            //  var requestlink = new HttpRequestMessage(HttpMethod.Delete, url + id);
            //  if (id < 1)
            //  {
            //      return false;
            //  }
            ////  requestlink.Content = new StringContent(JsonConvert.SerializeObject(tmp));
            //  var client = _client.CreateClient();
            //  HttpResponseMessage responselink = await client.SendAsync(requestlink);
            //  if (responselink.StatusCode == System.Net.HttpStatusCode.NoContent)
            //  {
            //      return true;
            //  }
            //  return false;
        }


        private async Task<string> GetBearerToken()
        {
            return await _localStorage.GetItemAsync<string>("Token");
        }


    }
    
}
