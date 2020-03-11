﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab
{
    public class Door : IDoor
    {
        public event EventHandler<DoorEventArgs> DoorEvent;

        private bool doorIsLocked = false;
        private bool doorIsClosed = false;


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
            doorIsClosed = false;
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
