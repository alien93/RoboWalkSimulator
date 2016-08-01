using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    enum Types { revolute, continuous, prismatic, fixeed, floating, planar};
    class Joint
    {
        private String name { get; set; } //name of the joint
        private Types type { get; set; }
        private Origin origin { get; set; }
        private Parent parent { get; set; }
        private Child child { get; set; }
        private Axis axis { get; set; }
        private Calibration calibration { get; set; }
        private Dynamics dynamics { get; set; }
        private Limit limit { get; set; }
        private Mimic mimic { get; set; }
        private SafetyController safetyController { get; set; }

        public Joint() { }
        public Joint(String name, Types type, Origin origin, Parent parent, Child child,
                     Axis axis, Calibration calibration, Dynamics dynamics, Limit limit,
                     Mimic mimic, SafetyController safetyController)
        {
            this.name = name;
            this.type = type;
            this.origin = origin;
            this.parent = parent;
            this.child = child;
            this.axis = axis;
            this.calibration = calibration;
            this.dynamics = dynamics;
            this.limit = limit;
            this.mimic = mimic;
            this.safetyController = safetyController;
        }

    }
}
