using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Interfaces
{
    internal interface IQuestionStorage
    {
        public static List<Question> GetAll();
        public Question GetQuestionByID(int id);
    }
}
