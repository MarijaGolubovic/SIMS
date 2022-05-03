using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Model;
using SIMS.Service;

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

        public Boolean Create (User user)
        {
            return userService.Create(user);
        }

        public Boolean Update(User newUser, User oldUser)
        {
            return userService.Update(newUser, oldUser);
        }

    }
}
