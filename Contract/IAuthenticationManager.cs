﻿
using Entities.DataTransfareObjects;
using Entities.Models;
using System.Threading.Tasks;


namespace Contract
{
    public interface IAuthenticationManager
    {
        public Task<bool> ValidateUser(LoginDTO loginDTO);
        public Task<string> CreateToken();
        public Task<User> GetUserProfile(LoginDTO loginDTO);
    }
}
