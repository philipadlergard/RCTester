using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCTester
{
    public class MonsterTruck : IRcCar
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Heading { get; set; }
        
        public void MoveLeft()
        {
            switch (Heading)
            { 
                case "N":
                    X -= 1;
                    Heading = "W";
                    break;
                case "S":
                    X += 1;
                    Heading = "E";
                    break;
                case "E":
                    Y += 1;
                    Heading = "N";
                    break;
                case "W":
                    Y -= 1;
                    Heading = "S";
                    break;
                default:
                    break;
            }
        }

        public void MoveRight()
        {
            switch (Heading)
            {
                case "N":
                    X += 1;
                    Heading = "E";
                    break;
                case "S":
                    X -= 1;
                    Heading = "W";
                    break;
                case "E":
                    Y -= 1;
                    Heading = "S";
                    break;
                case "W":
                    Y += 1;
                    Heading = "N";
                    break;
                default:
                    break;
            }
        }

        public void MoveForward()
        {
            switch (Heading)
            {
                case "N":
                    Y += 1;
                    break;
                case "S":
                    Y -= 1;
                    break;
                case "E":
                    X += 1;
                    break;
                case "W":
                    X -= 1;
                    break;
                default:
                    break;
            }
        }

        public void MoveBack()
        {
            switch (Heading)
            {
                case "N":
                    Y -= 1;
                    break;
                case "S":
                    Y += 1;
                    break;
                case "E":
                    X -= 1;
                    break;
                case "W":
                    X += 1;
                    break;
                default:
                    break;
            }
        }
    }
}
