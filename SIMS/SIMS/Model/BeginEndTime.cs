using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Model
{
   public class BeginEndTime
    {
        DateTime _Begin;
        DateTime _End;

        public BeginEndTime()
        {
        }

        public BeginEndTime(DateTime begin, DateTime end)
        {
            Begin = begin;
            End = end;
            
        }


        public DateTime Begin {
            get {
                return _Begin;
            }
            set
            {
                if (value != _Begin)
                {
                    _Begin = value;
                }
            }
        }
       public DateTime End {
            get
            {
                return _End;
            }
            set
            {
                if (value != _End)
                {
                    _End = value;
                }
            }
        }
 

    }
}
