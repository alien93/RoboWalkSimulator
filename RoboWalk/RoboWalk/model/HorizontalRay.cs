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
    class HorizontalRay
    {
        private int samples { get; set; } //The number of simulated rays to generate per complete laser sweep cycle.

        //This number is multiplied by samples to determine the number
        //of range data points returned. If resolution is less than one,
        //range data is interpolated. If resolution is greater than one, range data is averaged.
        private float resolution { get; set; }
        private float minAngle { get; set; } //rad;
        private float maxAngle { get; set; } //rad;

        public HorizontalRay() { }
        public HorizontalRay(int samples, float resolution, float minAngle, float maxAngle)
        {
            this.samples = samples;
            this.resolution = resolution;
            this.minAngle = minAngle;
            this.maxAngle = maxAngle;
        }
    }
}
