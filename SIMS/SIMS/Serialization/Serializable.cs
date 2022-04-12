using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Serialization
{
    interface Serializable
    {

        string[] toCSV();

        void fromCSV(string[] values);
    }


}
