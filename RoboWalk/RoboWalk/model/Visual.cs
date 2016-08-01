using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class Visual
    {
        private String name { get; set; }
        private Origin origin { get; set; }
        private Geometry geometry { get; set; }
        private Material material { get; set; }

        public Visual() { }
        public Visual(String name, Origin origin, Geometry geometry, Material material)
        {
            this.name = name;
            this.origin = origin;
            this.geometry = geometry;
            this.material = material;
        }
    }
}
