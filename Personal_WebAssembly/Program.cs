using Blazored.LocalStorage;
using Blazored.Toast;
using BlazorPro.BlazorSize;
using BlazorStrap;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Personal_WebAssembly.Interfaces;
using Personal_WebAssembly.Repos;
using Personal_WebAssembly.Token;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Personal_WebAssembly
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            // logcalstorage service here
            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddTransient<IAuthenticationRepo, AuthenticationRepo>();
            // same for intface Iauthor and AuthorRepo
            builder.Services.AddTransient<IAuthoRepo, AuthorRepo>();
            //Book store repo add here
            builder.Services.AddTransient<IBookRepo, BookRepo>();
            // logcalstorage service here

            //Toasthere

            //here is the Idetitny mdoe token jwt
            builder.Services.AddScoped<TokenAuthen>();
            builder.Services.AddScoped<AuthenticationStateProvider>(p =>
                p.GetRequiredService<TokenAuthen>());
            builder.Services.AddScoped<JwtSecurityTokenHandler>();

            // here is the Implrementation for filre upload img 
            //builder.Services.AddTransient<IHochladen, Hochlade>();
            builder.Services.AddBootstrapCss();

            builder.Services.AddAuthorizationCore();

            builder.Services.AddMediaQueryService();

            builder.Services.AddBlazoredToast();


            await builder.Build().RunAsync();
        }
    }
}
