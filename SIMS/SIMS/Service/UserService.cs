using System;
using System.Collections.Generic;
using SIMS.Model;

namespace SIMS.Service
{
    public class UserService
    {
        private UserStorage userStorage;

        public UserService()
        {
            userStorage = new UserStorage();
        }

        public List<User> GetAll()
        {
            return userStorage.GetAll();
        }

        public User GetOne(String jmbg)
        {
            return userStorage.GetOne(jmbg);
        }

        public Boolean Create(User user)
        {
            if (userStorage.GetOne(user.Person.JMBG) == null)
            {
                userStorage.Create(user);
                return true;
            }
            else
            {
                return false;
            }

        }

        public Boolean Update(User newUser, User oldUser)
        {
            if (oldUser.Person.JMBG == newUser.Person.JMBG || userStorage.GetOne(newUser.Person.JMBG) == null)
            {
                userStorage.Update(newUser, oldUser);
                return true;
            }
            else
            {
                return false;
            }

        }
        public User FindUserByUsername(String Username)
        {
            return userStorage.FindUserByUsername(Username);
        }

        public Boolean CheckUserPassword (String Username, String Password)
        {
            User user = FindUserByUsername(Username);
            if (user.Password.Equals(Password))
            {
                return true;
            } else
            {
                return false;
            }
        }


    }
}
