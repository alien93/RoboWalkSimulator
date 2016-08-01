using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class VerticalRay
    {
        private int samples { get; set; }
        private float resolution { get; set; }
        private float minAngle { get; set; }
        private float maxAngle { get; set; }

        public VerticalRay() { }
        public VerticalRay(int samples, float resolution, float minAngle, float maxAngle)
        {
            this.samples = samples;
            this.resolution = resolution;
            this.minAngle = minAngle;
            this.maxAngle = maxAngle;
        }
    }
}
