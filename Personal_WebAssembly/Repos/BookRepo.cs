using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Personal_WebAssembly.Models;
using Personal_WebAssembly.Interfaces;
using Blazored.LocalStorage;
using System.Net.Http;

namespace Personal_WebAssembly.Repos
{
    public class BookRepo : BaseRepo<BookModel>, IBookRepo
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;

        public BookRepo(HttpClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _client = client;
            _localStorage = localStorage;

        }



    }
}
