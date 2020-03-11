using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab.Core
{
    public class RFIDReader : IRFIDReader
    {
        public event EventHandler<RfidEventArgs> RfidEvent;

        public void onRfidRead(int id)
        {
            OnRfidDetected(new RfidEventArgs { Rfid_ID = id});
        }

        protected virtual void OnRfidDetected(RfidEventArgs e)
        {
            RfidEvent?.Invoke(this, e);
        }
    }
}
