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
    class Sensor
    {
        private String name { get; set; }
        private float updateRate { get; set; } //Hz
        private Parent parent { get; set; }
        private Origin origin { get; set; }
        private Camera camera { get; set; }
        private Ray ray { get; set; }

        public Sensor() { }
        public Sensor(String name, float updateRate,
                      Parent parent, Origin origin,
                      Camera camera, Ray ray)
        {
            this.name = name;
            this.updateRate = updateRate;
            this.parent = parent;
            this.origin = origin;
            this.camera = camera;
            this.ray = ray;
        }
    }
}
