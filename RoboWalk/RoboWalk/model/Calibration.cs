using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class Calibration
    {
        private double rising { get; set; } //When the joint moves in a positive direction, this reference position will trigger a rising edge.
        private double falling { get; set; } //When the joint moves in a positive direction, this reference position will trigger a falling edge.

        public Calibration() { }
        public Calibration(double rising, double falling)
        {
            this.rising = rising;
            this.falling = falling;
        }
    }
}
