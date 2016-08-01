using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class Inertial
    {
        private Origin origin { get; set; }
        private Mass mass { get; set; }
        private Inertia inertia { get; set; }

        public Inertial() { }
        public Inertial(Origin origin, Mass mass, Inertia inertia)
        {
            this.origin = origin;
            this.mass = mass;
            this.inertia = inertia;
        }
    }
}
