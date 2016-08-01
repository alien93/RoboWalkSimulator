using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class Sphere:AbstractObject
    {
        public Sphere() { }
        public Sphere(AbstractObject ao) : base(ao) { }
        public Sphere(double radious)
        {
            this.radius = radius;
        }
    }
}
