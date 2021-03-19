using Microsoft.AspNetCore.Identity;
using Shop.Business.Abstract;
using Shop.DataAccess.Abstract;
using Shop.Entities.Concrete;
using System.Collections.Generic;

namespace Shop.Business.Concrete.Managers
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User FindByUserNameWithRoles(string username) =>
            _userRepository.Find(x => x.UserName.Equals(username), nameof(User.Roles));
    }
}