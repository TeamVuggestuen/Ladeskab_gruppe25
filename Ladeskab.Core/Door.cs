using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab
{
    public class Door : IDoor
    {
        public event EventHandler<DoorEventArgs> DoorEvent;

        private bool _DoorState;

        public void OpenDoor()
        {
            if (_DoorState == false)
            {
                OnDoorChanged(new DoorEventArgs{ DoorState = true});
                _DoorState = true;
            }
        }

        public void CloseDoor()
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


        // DISSE 2 FUNKTIONER ER KUN MED TIL AT VISE HVAD BRUGEREN ER I GANG MED, OG KALDER DERFOR VIDERE
        public void UnlockDoor()
        {

            Console.WriteLine("Door Open");
            //UnlockDoor();

        }

        public void LockDoor()
        {

            Console.WriteLine("Door Closed");
            //LockDoor();

        }
    }



}
