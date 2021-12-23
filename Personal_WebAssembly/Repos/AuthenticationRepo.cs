using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Personal_WebAssembly.Interfaces;
using Personal_WebAssembly.Models;
using Personal_WebAssembly.Connections;
using System.Text;
using Newtonsoft.Json;
using Blazored.LocalStorage;
using Personal_WebAssembly.Token;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;

namespace Personal_WebAssembly.Repos
{
    public class AuthenticationRepo : IAuthenticationRepo
    {
      
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;


        public AuthenticationRepo(HttpClient client , ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider)
        {
            _client = client;
            _localStorage = localStorage;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> Login(ModelLogin user)
        {


            var result =  await _client.PostAsJsonAsync(Endpoint.LoginEndpoint, user);

            if (!result.IsSuccessStatusCode)
            {
                return false;
            }
            var data = await result.Content.ReadAsStringAsync();

            var token = JsonConvert.DeserializeObject<TokenJWT>(data);
            //Save token Local
            await _localStorage.SetItemAsync("Token", token.Token);
            //Change auth state of app
            await ((TokenAuthen)_authenticationStateProvider).LoggedIn();

            // moga da go iztriq tova cuz dobavqm vseki put kato pravq callove on Base REPo :GetBearerToken i go addvam kam calla
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token.Token);
            return true;

            //No need at all change all much harder  implement and understand
            //request.Content = new StringContent(JsonConvert.SerializeObject(user),
            //    Encoding.UTF8,
            //    "application/json");

            //var client = _client.CreateClient();
            //HttpResponseMessage responselink = await client.SendAsync(request);
            //here i add the token as well



            //if(responselink.IsSuccessStatusCode == false)
            //  {
            //      return false;
            //  }
            //  var data = await responselink.Content.ReadAsStringAsync();

            //  var token = JsonConvert.DeserializeObject<TokenJWT>(data);
            //  // save token
            //  await _localStorage.SetItemAsync("Token", token.Token);
            //  await ((TokenAuthen)_authenticationStateProvider).LoggedIn();
            //  client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token.Token);
            //  return true;


        }

        public  async Task Logout()
        {
            await _localStorage.RemoveItemAsync("Token");
            ((TokenAuthen)_authenticationStateProvider).LoggedOut();
        }

        public async Task<bool> Register(Register_Personal user)
        {

            var result = await _client.PostAsJsonAsync(Endpoint.RegisterEndpoint, user);

            return result.IsSuccessStatusCode;
            //var request = new HttpRequestMessage(HttpMethod.Post, Endpoint.RegisterEndpoint);
            //request.Content = new StringContent(JsonConvert.SerializeObject(user), 
            //    Encoding.UTF8, 
            //    "application/json");

            //var client = _client.CreateClient();
            //HttpResponseMessage response = await client.SendAsync(request);

            //return response.IsSuccessStatusCode;
        }
    }
}
