﻿/*Copyright (c) 2016  Nina Marjanovic
This file is part of RoboWalk.
RoboWalk is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
Robowalk is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with RoboWalk.  If not, see <http://www.gnu.org/licenses/>*/
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
        public string name { get; set; } //name of the joint
        public Types type { get; private set; }
        public Origin origin { get; private set; }
        public Parent parent { get; private set; }
        public Child child { get; private set; }
        public Axis axis { get; private set; }
        public Calibration calibration { get; private set; }
        public Dynamics dynamics { get; private set; }
        public Limit limit { get; private set; }
        public Mimic mimic { get; private set; }
        public SafetyController safetyController { get; private set; }

        public Joint() { }
        public Joint(string name, Types type, Origin origin, Parent parent, Child child,
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
