using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class Axis
    {
        private double x { get; set; }
        private double y { get; set; }
        private double z { get; set; }

        private double r { get; set; }
        private double p { get; set; }
        private double yy { get; set; }

        public Axis() { }
        public Axis(double x, double y, double z,
                    double r, double p, double yy)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.r = r;
            this.p = p;
            this.yy = yy;
        }
    }
}
