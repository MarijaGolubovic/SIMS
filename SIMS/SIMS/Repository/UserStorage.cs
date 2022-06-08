using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIMS.Model
{
    public class UserStorage : IUserStorage
    {
        public List<User> GetAll()
        {
            Serialization.Serializer<User> userSerializer = new Serialization.Serializer<User>();
            List<User> users = userSerializer.fromCSV("user.txt");
            return users;
        }

        public User GetOne(String jmbg)
        {
            List<User> users = GetAll();
            User user = new User();
            user = users.Find(u => u.Person.JMBG.Equals(jmbg));
            return user;

        }

        public Boolean Create(User user)
        {
            Serialization.Serializer<User> userSerializer = new Serialization.Serializer<User>();
            List<User> users = new List<User>();
            foreach (User u in userSerializer.fromCSV("user.txt"))
            {
                users.Add(u);
            }
            users.Add(user);
            userSerializer.toCSV("user.txt", users);
            return true;
        }

        public Boolean Update(User newUser, User oldUser)
        {
            Serialization.Serializer<User> userSerializer = new Serialization.Serializer<User>();
            List<User> users = new List<User>();
            foreach (User u in userSerializer.fromCSV("user.txt"))
            {
                users.Add(u);
            }
            users.Add(newUser);
            users.Remove(users.Find(u => u.Person.JMBG.Equals(oldUser.Person.JMBG)));
            userSerializer.toCSV("user.txt", users);
            return true;
        }

        public User FindUserByUsername(String Username)
        {
            List<User> users = GetAll();
            return users.Find(u => u.Username.Equals(Username));
        }

        public String fileName;

    }
}