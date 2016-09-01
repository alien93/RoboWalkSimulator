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
using Tao.OpenGl;

namespace RoboWalk.simulator
{
    class DrawHelper
    {
        public static void rotateMe(double r, double p, double y)
        {
            double angle = 0;
            if (r != 0)
            {
                angle = convertRadToDegrees(r);
                r = 1;
            }
            if (p != 0)
            {
                angle = convertRadToDegrees(p);
                p = 1;
            }
            if (y != 0)
            {
                angle = convertRadToDegrees(y);
                y = 1;
            }
            Gl.glRotated(angle, r, p, y);
        }

        public static double convertRadToDegrees(double value)
        {
            return value * 180 / Math.PI;
        }
    }
}
