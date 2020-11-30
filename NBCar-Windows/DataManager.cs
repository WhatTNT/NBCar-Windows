using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBCar_Windows
{
    class DataManager
    {

        private static int leftPower;
        private static int rightPower;
        public const int MAX_POWER = Int16.MaxValue;

        public static void Cauculate(int x ,int y ,int rt)
        {
            int relativeX = x - UInt16.MaxValue / 2;
            int power = MAX_POWER * (Int16.MaxValue - rt) / Int16.MaxValue; 
            if (relativeX > 0)
            {
                leftPower = power;
                rightPower = power - power * relativeX / UInt16.MaxValue * 2;
            }
            else
            {
                rightPower = power;
                leftPower = power - power * relativeX / UInt16.MaxValue * -2;
            }
        }

        public static int GetLeftPower()
        {
            return leftPower;
        }

        public static int GetRightPower()
        {
            return rightPower;
        }
    }
}
