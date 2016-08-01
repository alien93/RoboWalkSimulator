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
    class Limit
    {
        private double lower { get; set; } //An attribute specifying the lower joint limit (radians for revolute joints, meters for prismatic joints). Omit if joint is continuous.
        private double upper { get; set; } //An attribute specifying the upper joint limit (radians for revolute joints, meters for prismatic joints). Omit if joint is continuous.
        private double effort { get; set; } //An attribute for enforcing the maximum joint effort (|applied effort| < |effort|)
        private double velocity { get; set; } //An attribute for enforcing the maximum joint velocity.

        public Limit() { }
        public Limit(double lower, double upper, double effort, double velocity)
        {
            this.lower = lower;
            this.upper = upper;
            this.effort = effort;
            this.velocity = velocity;
        }
    }
}
