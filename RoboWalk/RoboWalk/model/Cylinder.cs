using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class Cylinder:AbstractObject
    {
        public Cylinder() { }
        public Cylinder(AbstractObject ao) : base(ao) { }
        public Cylinder(double radius, double length)
        {
            this.radius = radius;
            this.length = length;
        }
    }
}
