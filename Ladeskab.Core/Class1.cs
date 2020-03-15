﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using System.Threading.Tasks;


namespace Ladeskab 
{
    public class Program
    {
        // SNAKKET MED FRANK OM HVORDAN DET DE KOM MED OVER, DOG KAN MAIN IKKE VÆRE STATIC, HVILKET HAN MENTE DEN SKULLE BLIVE VED MED AT VÆRE, MEN HAR FJERNET DET DA DET LAVEDE FEJL
        public IDoor _door;
        private StationControl _stationControl;

        
        //Static fjernet
        void Main(string[] args)
        {
            // Assemble your system here from all the classes

            //EN AF DE TING VI SKAL HA MED IND I VORES MAIN.
            _stationControl = new StationControl();


            bool finish = false;
            do
            {
                string input;
                System.Console.WriteLine("Indtast E, O, C, R: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) continue;

                switch (input[0])
                {
                    case 'E':
                        finish = true;
                        break;

                    case 'O':
                        _door.OnDoorOpen();
                        break;

                    case 'C':
                        _door.OnDoorClosed();
                        break;

                    case 'R':
                        System.Console.WriteLine("Indtast RFID id: ");
                        string idString = System.Console.ReadLine();

                        int id = Convert.ToInt32(idString);
                        //rfidReader.OnRfidRead(id); LAVER FEJL TIL DEN ER IMPLEMENTERET
                        break;

                    default:
                        break;
                }

            } while (!finish);
        }
    }
}
