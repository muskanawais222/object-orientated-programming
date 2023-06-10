using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge2.BL
{
    class Bicycle
    {
        private int cadence;
        private int gear;
        private int speed;

        public Bicycle(int c , int s , int g)
        {
            this.cadence = c;
            this.gear = g;
            this.speed = s;
        }

        public void setcadence(int cardence)
        {
            this.cadence = cardence;
        }
        public void setGear(int gear)
        {
            this.gear = gear;
        }
        public void applyBreak(int decrement)
        {
            this.speed = decrement--;
        }
        public void speedUp(int increment)
        {
            this.speed = increment++;
        }
        public int getGear()
        {
            return gear;
        }
    }
}
