using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace SIMS.Model
{
    public class Question : Serialization.Serializable
    {
        public ReportID ReportID { get; set; }
        public CategoryID CategoryID { get; set; }
        public string QuestionText { get; set; }

        public int ID { get; set; }


        public Question(ReportID reportID, CategoryID categoryID, string questionText, int iD)
        {
            ReportID = reportID;
            CategoryID = categoryID;
            QuestionText = questionText;
            ID = iD;
        }

        public Question()
        {

        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                ReportID.ToString(),
                CategoryID.ToString(),
                QuestionText,
                ID.ToString()
            };
            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            if (values[0] == "")
                return;
            ReportID = (ReportID)Enum.Parse(typeof(ReportID), values[0]);
            CategoryID = (CategoryID)Enum.Parse(typeof(CategoryID), values[1]);
            QuestionText = values[2];
            ID = int.Parse(values[3]);
        }

        public override string ToString()
        {
            return QuestionText.ToString();
        }
    }
}
