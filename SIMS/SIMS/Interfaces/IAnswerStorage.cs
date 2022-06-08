using SIMS.Interfaces;
using SIMS.Model;
using System;
using System.Collections.Generic;

namespace SIMS.Interfaces
{
    internal interface IAnswerStorage
    {
        public bool Create(Answers answer);
    }
}
