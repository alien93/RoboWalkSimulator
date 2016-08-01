using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class Ray
    {
        private HorizontalRay hRay { get; set; }
        private VerticalRay vRay { get; set; }

        public Ray() { }
        public Ray(HorizontalRay hRay, VerticalRay vRay)
        {
            this.hRay = hRay;
            this.vRay = vRay;
        }
    }
}
