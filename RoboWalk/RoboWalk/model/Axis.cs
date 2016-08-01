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
    class Axis
    {
        private double x { get; set; }
        private double y { get; set; }
        private double z { get; set; }

        private double r { get; set; }
        private double p { get; set; }
        private double yy { get; set; }

        public Axis() { }
        public Axis(double x, double y, double z,
                    double r, double p, double yy)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.r = r;
            this.p = p;
            this.yy = yy;
        }
    }
}
