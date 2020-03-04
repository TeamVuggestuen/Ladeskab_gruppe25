using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab.Core
{
    public class EventArgDoor : EventArgs
    {
        public DoorEvent doorEvent { get; set; }
    }
}
