using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class Box:AbstractObject
    {
        Box() { }
        Box(AbstractObject ao) : base(ao) { }
        Box(double height, double width, double depth)
        {
            this.height = height;
            this.depth = depth;
            this.width = width;
        }
    }
}
