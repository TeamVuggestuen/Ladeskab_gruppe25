using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab.Core
{
    public class DoorEventArgs : EventArgs
    {
        public bool DoorClosed { get; set; }
    }

    public interface IRFIDReader
    {
        void onRfidRead(int id);
    }
}
