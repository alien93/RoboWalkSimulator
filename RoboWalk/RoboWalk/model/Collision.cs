using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class Collision
    {
        private String name { get; set; }
        private Origin origin { get; set; }
        private Geometry geometry { get; set; }

        public Collision() { }
        public Collision(String name, Origin origin, Geometry geometry)
        {
            this.name = name;
            this.origin = origin;
            this.geometry = geometry;
        }
    }
}
