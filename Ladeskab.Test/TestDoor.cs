using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ladeskab;

namespace Ladeskab.Test
{
    [TestFixture]
    public class TestDoor
    {
        private Door _uut;
        private EventArgs _receivedEventArgs;

        [SetUp]
        public void Setup()
        {
            _uut = new Door();


            //Tjekker på events
            _receivedEventArgs = null;

            _uut.DoorEvent +=
                (o, args) =>
                {
                    _receivedEventArgs = args;
                };

        }

        [Test]
        public void CheckOnDoorIsOpen()
        {
            _uut.OnDoorOpen();
            
            Assert.That(_uut.doorIsLocked, Is.False);
           
        }

        [Test]
        public void CheckOnDoorIsClose()
        {
            _uut.OnDoorOpen();

            Assert.That(_uut.doorIsLocked, Is.True);

        }

        [Test]
        public void CheckOnDoorIsOpenEvent()
        {
            _uut.doorIsClosed = true;
            Assert.That(_receivedEventArgs, Is.True);
        }
    }


}