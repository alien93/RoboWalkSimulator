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
    class VerticalRay
    {
        private int samples { get; set; }
        private float resolution { get; set; }
        private float minAngle { get; set; }
        private float maxAngle { get; set; }

        public VerticalRay() { }
        public VerticalRay(int samples, float resolution, float minAngle, float maxAngle)
        {
            this.samples = samples;
            this.resolution = resolution;
            this.minAngle = minAngle;
            this.maxAngle = maxAngle;
        }
    }
}
