using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Personal_WebAssembly.Models;

namespace Personal_WebAssembly.Interfaces
{
    interface IAuthenticationRepo
    {
        public Task<bool> Register(Register_Personal user);
        public Task<bool> Login(ModelLogin user);
        public Task  Logout();
    }
}
