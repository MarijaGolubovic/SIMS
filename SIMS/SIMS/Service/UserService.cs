using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Repository;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIMS.Service
{
    public class UserService
    {
        private IUserStorage userStorage;

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
            if (oldUser.CheckJMBG(newUser.Person.JMBG) || userStorage.GetOne(newUser.Person.JMBG) == null)
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

        public Boolean CheckUserPassword(String Username, String Password)
        {
            User user = FindUserByUsername(Username);
            return user.CheckPassword(Password);
        }


    }
}
