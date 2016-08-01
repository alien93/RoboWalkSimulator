using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class SafetyController
    {
        //An attribute specifying the lower joint boundary where the safety
        //controller starts limiting the position of the joint. This limit needs
        //to be larger than the lower joint limit (see above).
        private double softLowerLimit { get; set; }
        //An attribute specifying the upper joint boundary where the safety
        //controller starts limiting the position of the joint. This limit needs
        //to be smaller than the upper joint limit (see above).
        private double softUpperLimit { get; set; }
        //An attribute specifying the relation between position and velocity limits.
        private double kPosition { get; set; }
        //An attribute specifying the relation between effort and velocity limits.
        private double kVelocity { get; set; }

        public SafetyController() { }
        public SafetyController(double softLowerLimit, double softUpperLimit,
                                double kPosition, double kVelocity)
        {
            this.softLowerLimit = softLowerLimit;
            this.softUpperLimit = softUpperLimit;
            this.kPosition = kPosition;
            this.kVelocity = kVelocity;
        }
    }
}
