using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Interfaces
{
    internal interface IUserStorage
    {
        public List<User> GetAll();
        public User GetOne(String jmbg);
        public Boolean Create(User user);
        public Boolean Update(User newUser, User oldUser);
        public User FindUserByUsername(String Username);
    }
}
