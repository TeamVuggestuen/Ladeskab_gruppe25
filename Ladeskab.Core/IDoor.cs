using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab.Core
{
    public class DoorEventArgs : EventArgs
    {
        public bool DoorState { get; set; }
    }

    public interface IDoor
    {
        event EventHandler<DoorEventArgs> DoorEvent;
        void UnlockDoor();
        void LockDoor();
    }
}


    
