using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Personal_WebAssembly.Interfaces;
using System.Net.Http;
using Personal_WebAssembly.Models;
using Blazored.LocalStorage;

namespace Personal_WebAssembly.Repos

{
    public class AuthorRepo : BaseRepo<AuthorModel>, IAuthoRepo
    {

        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;

        public AuthorRepo(HttpClient client, ILocalStorageService localStorage) : base(client,localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

 
    }
}
