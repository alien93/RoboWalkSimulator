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
    class DrawSphere
    {
        private Glu.GLUquadric quad;

        public double radius { get; private set; }
        public double r { get; private set; }
        public double p { get; private set; }
        public double yy { get; private set; }
        public double x { get; private set; }
        public double y { get; private set; }
        public double z { get; private set; }
        public double red { get; private set; }
        public double green { get; private set; }
        public double blue { get; private set; }
        public double alpha { get; private set; }

        public DrawSphere(double radius,
                          double r, double p, double yy,
                          double x, double y, double z,
                          double red, double green, double blue, double alpha)
        {
            this.radius = radius;
            this.r = r;
            this.p = p;
            this.yy = yy;
            this.x = x;
            this.y = y;
            this.z = z;
            this.red = red;
            this.green = green;
            this.blue = blue;
            this.alpha = alpha;
            quad = Glu.gluNewQuadric();
        }

        public void drawSphere()
        {
            Gl.glTranslated(x, y, z);
            DrawHelper.rotateMe(r, p, yy);
            Gl.glColor4d(red, green, blue, alpha);
            Glu.gluSphere(quad, radius, 32, 32);
        }
    }
}
