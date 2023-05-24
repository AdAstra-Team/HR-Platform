using System.Collections.Generic;
using System.Threading.Tasks;
using AdAstra.HRPlatform.Entities;
using AdAstra.HRPlatform.Models;

namespace AdAstra.HRPlatform.Services.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        Task<AuthenticateResponse> Register(UserModel userModel);
        IEnumerable<User> GetAll();
        User GetById(int id);
        AuthenticateResponse UpdateToken(TokensModel model);
    }
}