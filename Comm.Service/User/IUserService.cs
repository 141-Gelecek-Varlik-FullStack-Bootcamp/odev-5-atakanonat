using Comm.DB.Entities;
using Comm.Model;

namespace Comm.Service.User
{
    public interface IUserService
    {
        Common<Model.User.User> Login(Model.User.UserLogin registeredUser);
        Common<Model.User.User> Register(Model.User.User newUser);
    }
}