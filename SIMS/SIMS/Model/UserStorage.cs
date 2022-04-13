using System;
using System.Collections.Generic;

namespace SIMS.Model
{
    public class UserStorage
    {
        public List<User> GetAll()
        {
            Serialization.Serializer<User> userSerializer = new Serialization.Serializer<User>();
            List<User> users = userSerializer.fromCSV("user.txt");
            return users;
        }

        public User GetOne(String jmbg)
        {
            throw new NotImplementedException();
        }

        public Boolean Delete(String jmbg)
        {
            throw new NotImplementedException();
        }

        public Boolean Create(User user)
        {
            throw new NotImplementedException();
        }

        public Boolean Update(User user)
        {
            throw new NotImplementedException();
        }

        public String fileName;

    }
}