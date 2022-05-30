﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Model;
using SIMS.Service;

namespace SIMS.Controller
{
    public class AnswerController
    {
        private readonly AnswerService answerService = new AnswerService();
        public AnswerController()
        {
        }
        public bool Create(Answers answer)
        {
            return answerService.Create(answer);
        }
    }
}