using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;


namespace SIMS.Controller
{
    public class UserController
    {
        private readonly UserService userService;

        public UserController()
        {
            userService = new UserService();
        }

        public List<User> GetAll()
        {
            return userService.GetAll();
        }

        public User GetOne(String jmbg)
        {
            return userService.GetOne(jmbg);
        }

        public Boolean Create(User user)
        {
            return userService.Create(user);
        }

        public Boolean Update(User newUser, User oldUser)
        {
            return userService.Update(newUser, oldUser);
        }

        public User FindUserByUsername(String Username)
        {
            return userService.FindUserByUsername(Username);
        }
        public Boolean CheckUserPassword(String Username, String Password)
        {
            return userService.CheckUserPassword(Username, Password);
        }

    }
}
