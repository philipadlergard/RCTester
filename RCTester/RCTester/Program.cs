using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RCTester
{
    class Program
    {
        static void Main(string[] args)
        {
            string roomSize;
            string startingPos;
            string commands;

            Console.Write("Set roomsize (two integers separated with whitespace, start with height)");
            Console.WriteLine();

            roomSize = Console.ReadLine();

            while (!ValidateRoomSizeInput(roomSize))
            {
                roomSize = Console.ReadLine();
                Console.WriteLine();
            }

            Room room = CreateRoom(roomSize);

            Console.Write("Set startingposition and heading of the car (two integers followed by one letter, separated with whitespaces)");
            Console.WriteLine();

            startingPos = Console.ReadLine();
            Console.WriteLine();

            while (!ValidateStartPosInput(startingPos))
            {
                startingPos = Console.ReadLine();
                Console.WriteLine();
            }

            IRcCar car = CreateCar(startingPos);

            Console.Write("Type commands for the car. Available are F, B, L and R");
            Console.WriteLine();

            commands = Console.ReadLine();
            Console.WriteLine();

            while (!ValidateCommandInput(commands))
            {
                commands = Console.ReadLine();
                Console.WriteLine();
            }

            StartTest(car, room, commands);
        }

        private static IRcCar CreateCar(string startingPos)
        {
            IRcCar truck = new MonsterTruck();
            truck.X = int.Parse(startingPos.Substring(0, 1));
            truck.Y = int.Parse(startingPos.Substring(2, 1));
            truck.Heading = startingPos.Substring(4, 1);
            return truck;
        }

        private static Room CreateRoom(string roomSize)
        {
            Room room = new Room();
            room.MaxXPos = int.Parse(roomSize.Substring(0, 1));
            room.MaxYPos = int.Parse(roomSize.Substring(2, 1));
            return room;
        }

        private static bool ValidateCommandInput(string commands)
        {
            Regex regex = new Regex(@"[FBRL]");

            if (!regex.IsMatch(commands))
            {
                Console.Write("Incorrect format, try again");
                Console.WriteLine();

                return false;
            }

            return true;
        }

        private static bool ValidateStartPosInput(string startingPos)
        {
            Regex regex = new Regex(@"[0-9]{1} [0-9]{1} [NSWE]{1}");

            if (!regex.IsMatch(startingPos))
            {
                Console.Write("Incorrect format, try again");
                Console.WriteLine();

                return false;
            }

            return true;
        }

        private static bool ValidateRoomSizeInput(string roomSize)
        {
            Regex regex = new Regex(@"[0-9]{1} [0-9]{1}");

            if (!regex.IsMatch(roomSize))
            {
                Console.Write("Incorrect format, try again");
                Console.WriteLine();

                return false;
            }

            return true;
        }

        static void StartTest(IRcCar car, Room room, string commands)
        {
            for (int i = 0; i < commands.Length; i++)
            {
                switch (commands[i])
                { 
                    case 'F':
                        car.MoveForward();
                        break;
                    case 'B':
                        car.MoveBack();
                        break;
                    case 'L':
                        car.MoveLeft();
                        break;
                    case 'R':
                        car.MoveRight();
                        break;
                    default:
                        break;
                }

                bool validMove = CheckMove(car, room);

                if (!validMove)
                {
                    Console.WriteLine("Test failed, car crashed into the wall trying to head {0} {1} meters from the bottom and {2} meters from the left", car.Heading, car.Y, car.X);
                    Console.ReadKey();
                }
            }

            Console.WriteLine("Test was successfull, car stopped {0} meters from the bottom and {1} meters from the left facing {2}", car.Y, car.X, car.Heading);
            Console.ReadKey();
        }

        static bool CheckMove(IRcCar car, Room room)
        {
            if (car.X < 0 || car.X > room.MaxXPos)
            {
                return false;
            }
            if (car.Y < 0 || car.Y > room.MaxYPos)
            {
                return false;
            }

            return true;
        }
    }
}
