using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ladeskab.Core;

namespace Ladeskab
{
    public class Door : IDoor
    {
        private IDisplay _display;

        public Door(IDisplay display)
        {
            _display = display;
        }

        public event EventHandler<DoorEventArgs> DoorEvent;

        public bool doorIsLocked = false;
        public bool doorIsClosed = false;


        public void OnDoorOpen()
        {
            if (doorIsLocked)
            {
                Console.WriteLine("Door is locked. Cannot open"); // display
            }
            else if (!doorIsLocked)
            {
                doorIsClosed = false;
                OnDoorChanged(new DoorEventArgs { DoorClosed = doorIsClosed });
            }
        }

        public void OnDoorClosed()
        {
            doorIsClosed = true;
            OnDoorChanged(new DoorEventArgs { DoorClosed = doorIsClosed });
        }


        protected virtual void OnDoorChanged(DoorEventArgs e)
        {
            DoorEvent?.Invoke(this, e);
        }


        // DISSE 2 FUNKTIONER ER KUN MED TIL AT VISE HVAD BRUGEREN ER I GANG MED, OG KALDER DERFOR VIDERE
        public void UnlockDoor()
        {
            if (!doorIsLocked)
            {
                doorIsLocked = true;
            }
            else
                return;
        }

        public void LockDoor()
        {
            if (!doorIsLocked)
            {
                doorIsLocked = true;
            }
            else
                return;
        }
    }



}
