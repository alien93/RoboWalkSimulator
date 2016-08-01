using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class AbstractObject
    {
        protected String name { get; set; }
        protected double height { get; set; }
        protected double width { get; set; }
        protected double depth { get; set; }
        protected double radius { get; set; }
        protected double length { get; set; }
        protected double sphereRadius { get; set; }

        public AbstractObject() { }

        public AbstractObject(AbstractObject ao)
        {
            name = ao.name;
            height = ao.height;
            width = ao.width;
            depth = ao.depth;
            radius = ao.radius;
            length = ao.length;
            sphereRadius = ao.sphereRadius;
        }

        ~AbstractObject() { }
        
    }
}
