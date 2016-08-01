using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class Dynamics
    {
        private double damping { get; set; } //the physical damping value of the joing (N*s/m for prismatic joints, N*m*s/rad for revolute joints)
        private double friction { get; set; } //the physical static friction value of the joint (N for prismatic joints, N*m for revolute joints)

        public Dynamics() { }
        public Dynamics(double damping, double friction)
        {
            this.damping = damping;
            this.friction = friction;
        }
    }
}
