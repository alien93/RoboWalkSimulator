using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class HorizontalRay
    {
        private int samples { get; set; } //The number of simulated rays to generate per complete laser sweep cycle.

        //This number is multiplied by samples to determine the number
        //of range data points returned. If resolution is less than one,
        //range data is interpolated. If resolution is greater than one, range data is averaged.
        private float resolution { get; set; }
        private float minAngle { get; set; } //rad;
        private float maxAngle { get; set; } //rad;

        public HorizontalRay() { }
        public HorizontalRay(int samples, float resolution, float minAngle, float maxAngle)
        {
            this.samples = samples;
            this.resolution = resolution;
            this.minAngle = minAngle;
            this.maxAngle = maxAngle;
        }
    }
}
