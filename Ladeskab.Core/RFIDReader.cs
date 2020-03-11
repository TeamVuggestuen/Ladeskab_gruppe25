using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab.Core
{
    public class RFIDReader : IRFIDReader
    {
        private int ID;

        void onRfidRead(int id)
        {
            ID = id;
        }
    }
}
