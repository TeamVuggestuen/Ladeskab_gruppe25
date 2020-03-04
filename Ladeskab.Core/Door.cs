using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab.Core
{
    public class Door : IDoor
    {
        public event EventHandler<DoorEventArgs> DoorEvent;

        private bool _DoorState;

        public void UnlockDoor()
        {
            if (_DoorState == false)
            {
                OnDoorChanged(new DoorEventArgs{ DoorState = true});
                _DoorState = true;
            }
        }

        public void LockDoor()
        {
            if (_DoorState == true)
            {
                OnDoorChanged(new DoorEventArgs { DoorState = false });
                _DoorState = false;
            }
        }

        protected virtual void OnDoorChanged(DoorEventArgs e)
        {
            DoorEvent?.Invoke(this, e);
        }
    }
}
