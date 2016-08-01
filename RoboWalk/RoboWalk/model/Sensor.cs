using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class Sensor
    {
        private String name { get; set; }
        private float updateRate { get; set; } //Hz
        private Parent parent { get; set; }
        private Origin origin { get; set; }
        private Camera camera { get; set; }
        private Ray ray { get; set; }

        public Sensor() { }
        public Sensor(String name, float updateRate,
                      Parent parent, Origin origin,
                      Camera camera, Ray ray)
        {
            this.name = name;
            this.updateRate = updateRate;
            this.parent = parent;
            this.origin = origin;
            this.camera = camera;
            this.ray = ray;
        }
    }
}
