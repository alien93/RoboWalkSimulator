using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class Inertia
    {
        private double ixx { get; set; }
        private double ixy { get; set; }
        private double ixz { get; set; }
        private double iyy { get; set; }
        private double iyz { get; set; }
        private double izz { get; set; }

        public Inertia() { }
        public Inertia(double ixx, double ixy, double ixz,
                       double iyy, double iyz, double izz)
        {
            this.ixx = ixx;
            this.ixy = ixy;
            this.ixz = ixz;
            this.iyy = iyy;
            this.iyz = iyz;
            this.izz = izz;
        }
    }
}
