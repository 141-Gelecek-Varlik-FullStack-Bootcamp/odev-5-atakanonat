using System;
using System.Linq;
using AutoMapper;
using Comm.DB.Entities;
using Comm.Model;

namespace Comm.Service.User
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        public UserService(IMapper _mapper)
        {
            mapper = _mapper;
        }
        public Common<Model.User.User> Login(Model.User.UserLogin registeredUser)
        {
            var result = new Common<Model.User.User>() { IsSuccess = false };
            using (var srv = new CommContext())
            {
                var dbUser = srv.Person.SingleOrDefault(
                    user => !user.IsDeleted &&
                    user.Username == registeredUser.Username &&
                    user.Password == registeredUser.Password);
                var mappedUser = mapper.Map<Model.User.User>(dbUser);

                if (dbUser is not null)
                {
                    result.Entity = mappedUser;
                    result.IsSuccess = true;
                }
            }
            return result;
        }

        public Common<Model.User.User> Register(Model.User.User newUser)
        {
            var result = new Common<Model.User.User>() { IsSuccess = false };
            try
            {
                var mappedUser = mapper.Map<Person>(newUser);
                using (var srv = new CommContext())
                {
                    mappedUser.Idate = System.DateTime.Now;
                    srv.Person.Add(mappedUser);
                    srv.SaveChanges();
                    result.Entity = mapper.Map<Model.User.User>(mappedUser);
                    result.IsSuccess = true;
                }
            }
            catch (Exception e)
            {
                result.ExceptionMessage = e.Message;
            }
            return result;
        }
    }
}