
using Entities.DataTransfareObjects;
using System.Threading.Tasks;


namespace Contract.Authentication
{
    public interface IAuthenticationManager
    {
        public Task<bool> ValidateUser(LoginDTO loginDTO);
        public Task<string> CreateToken();
    }
}
