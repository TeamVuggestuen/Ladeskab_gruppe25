﻿using System;
using System.Collections.Generic;
using System.IO;

using System.Text;
using System.Threading.Tasks;
using Ladeskab.Core;


namespace Ladeskab
{
    public class StationControl
    {
        // Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
        private enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        // Her mangler flere member variable
        private LadeskabState _state;
        public IUsbCharger _charger;
        public IDoor _Door;
        public IDisplay _Display;
        private int _oldId;

        private string logFile = "logfile.txt"; // Navnet på systemets log-fil

        // Attach
        // StationControl tilknytter sig en specifik dørs event og et specifikt display som vi skal kommunikere med
        public StationControl(IDoor Door, IDisplay display, IRFIDReader RfidReader, IUsbCharger usbCharger)
        {
            _Door = Door;
            Door.DoorEvent += HandleDoorEvent;
            _Display = display;
            RfidReader.RfidEvent += HandleRfidEvent;
            usbCharger.CurrentValueEvent += HandleUsbCharger; // EVENT PÅ USB
        }

        public StationControl()
        {
        }

        #region HandleRfidEvent

        private void HandleRfidEvent(object sender, RfidEventArgs e)
        {
            RfidDetected(e.Rfid_ID);
        }

        #endregion


        #region HandleDoorEvent

        private void HandleDoorEvent(object sender, DoorEventArgs e)
        {
            if (e.DoorClosed) // hvis døren åbnes beder vi brugeren om at tilslutte sin telefon
            {
                _Display.ConnectPhoneRequest();
            }

            else if (!e.DoorClosed) // hvis døren lukkes beder vi brugeren scanne RFID
            {
                _Display.ReadRFIDRequest();
            }
        }

        #endregion

        private void HandleUsbCharger(object sender, CurrentEventArgs e)
        {
          // VED IKKE LIGE HVAD SKAL HENVISE TIL HER
        }

        // Eksempel på event handler for eventet "RFID Detected" fra tilstandsdiagrammet for klassen
        private void RfidDetected(int id)
        {
            switch (_state)
            {
                case LadeskabState.Available:
                    // Check for ladeforbindelse
                    if (_charger.Connected)
                    {
                        _Door.LockDoor();
                        _charger.StartCharge();
                        _oldId = id;
                        using (var writer = File.AppendText(logFile))
                        {
                            writer.WriteLine(DateTime.Now + ": Skab låst med RFID: {0}", id);
                        }

                        Console.WriteLine("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
                        _state = LadeskabState.Locked;
                    }
                    else
                    {
                        Console.WriteLine("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
                    }

                    break;

                case LadeskabState.DoorOpen:
                    // Ignore
                    break;

                case LadeskabState.Locked:
                    // Check for correct ID
                    if (id == _oldId)
                    {
                        _charger.StopCharge();
                        _Door.UnlockDoor();
                        using (var writer = File.AppendText(logFile))
                        {
                            writer.WriteLine(DateTime.Now + ": Skab låst op med RFID: {0}", id);
                        }

                        Console.WriteLine("Tag din telefon ud af skabet og luk døren");
                        _state = LadeskabState.Available;
                    }
                    else
                    {
                        Console.WriteLine("Forkert RFID tag");
                    }

                    break;
            }
        }

        // Her mangler de andre trigger handlere
    }
}
