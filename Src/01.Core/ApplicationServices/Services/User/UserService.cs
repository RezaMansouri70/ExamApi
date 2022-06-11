using ApplicationServices.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClass.UserExam;
using System.Security.Cryptography;

namespace ApplicationServices.Services.UserService
{

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool CanLogin(LoginUserDto loginModel)
        {
            var user = _userRepository.GetByMobile(loginModel.Mobile);
            if (user != null) 
            {
                return Security.SecurePasswordHasher.Verify(loginModel.Password, user.Password);
            }
            return false;
        }

        public User GetUserByMobile(string mobile)
        {
            return _userRepository.GetByMobile(mobile);

        }

        public User Register(AddUserDto addUserModel)
        {

            var hashpassword = Security.SecurePasswordHasher.Hash(addUserModel.Password);
            var user = new User()
            {
                Mobile = addUserModel.Mobile,
                Name = addUserModel.Name,
                Password = hashpassword
            };
            _userRepository.Insert(user);
            _userRepository.SaveChanges();
            return user;
        }
    }
}
