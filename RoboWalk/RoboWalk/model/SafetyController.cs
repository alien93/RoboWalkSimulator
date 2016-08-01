/*Copyright (c) 2016  Nina Marjanovic
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
