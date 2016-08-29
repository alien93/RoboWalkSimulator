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
    class DrawCylinder
    {
        public double length { get; set; }
        public double radius { get; set; }
        public double r { get; set; }
        public double p { get; set; }
        public double yy { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public double red { get; set; }
        public double green { get; set; }
        public double blue { get; set; }
        public double alpha { get; set; }


        public DrawCylinder(double length, double radius, 
                            double r, double p, double yy,
                            double x, double y, double z,
                            double red, double green, double blue, double alpha)
        {
            this.length = length;
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
        }

        public void drawCylinder()
        {
            Gl.glPushMatrix();
            Gl.glTranslated(x, y, z);
            rotateMe(r, p, yy);
            Gl.glColor4d(red, green, blue, alpha);
            Glu.GLUquadric cylinder = Glu.gluNewQuadric();
            Glu.gluCylinder(cylinder, radius, radius, length, 32, 32);
            Glu.gluDisk(cylinder, 0, radius, 32, 32);
            Gl.glTranslated(0.0, 0.0, length);
            Glu.gluDisk(cylinder, 0, radius, 32, 32);
            Gl.glPopMatrix();
        }

        private void rotateMe(double r, double p, double yy)
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
            if (r + p + y > 1)
                Gl.glRotated(angle, r, p, y);
            Gl.glRotated(angle, r, p, y);
            Gl.glTranslated(0.0, 0.0, -length / 2);
        }

        private double convertRadToDegrees(double value)
        {
            return value * 180 / Math.PI;
        }
    }
}
