using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCTester
{
    interface IRcCar
    {
        int X { get; set; }
        int Y { get; set; }
        string Heading { get; set; }

        void MoveLeft();
        void MoveRight();
        void MoveForward();
        void MoveBack();
    }
}
