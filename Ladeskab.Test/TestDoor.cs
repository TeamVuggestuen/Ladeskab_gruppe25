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

        [SetUp]
        public void Setup()
        {
            _uut = new Door();
        }

        [Test]
        public void CheckOnDoorIsOpen()
        {
            _uut.OnDoorOpen();
            
            Assert.That(_uut.doorIsLocked, Is.False);
        }
    }


}