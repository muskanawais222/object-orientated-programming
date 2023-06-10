 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using challenge2.BL;

namespace challenge2.BL
{
    class MountainBike : Bicycle
    {
        private int seatHeight;

        public MountainBike(int seatHeight , int cadence , int speed , int gear) : base (cadence , speed , gear)
        {
            this.seatHeight = seatHeight;
        }
        public void setHeight(int setHeight)
        {
            this.seatHeight = setHeight;
        }
    }
}
