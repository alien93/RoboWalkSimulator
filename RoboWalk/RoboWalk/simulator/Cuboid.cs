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
    class Cuboid
    {
        public double width {get; private set; }
        public double height { get; private set; }
        public double depth { get; private set; }

        public Cuboid(double width, double height, double depth)
        {
            this.width = width;
            this.height = height;
            this.depth = depth;
        }

        public void drawCuboid()
        {
            Gl.glPushMatrix();
            Gl.glRotatef(90.0f, 1.0f, 0.0f, 0.0f);
            Gl.glRotatef(90.0f, 0.0f, 1.0f, 0.0f);
            Gl.glRotatef(90.0f, 1.0f, 0.0f, 0.0f);
            Gl.glBegin(Gl.GL_QUADS);


            // right
            Gl.glVertex3d(width / 2, -height / 2, -depth / 2);
            Gl.glVertex3d(width / 2, height / 2, -depth / 2);
            Gl.glVertex3d(width / 2, height / 2, depth / 2);
            Gl.glVertex3d(width / 2, -height / 2, depth / 2);


            // left
            Gl.glVertex3d(-width / 2, -height / 2, depth / 2);
            Gl.glVertex3d(-width / 2, height / 2, depth / 2);
            Gl.glVertex3d(-width / 2, height / 2, -depth / 2);
            Gl.glVertex3d(-width / 2, -height / 2, -depth / 2);


            // back
            Gl.glVertex3d(-width / 2, -height / 2, -depth / 2);
            Gl.glVertex3d(-width / 2, height / 2, -depth / 2);
            Gl.glVertex3d(width / 2, height / 2, -depth / 2);
            Gl.glVertex3d(width / 2, -height / 2, -depth / 2);


            // front
            Gl.glVertex3d(width / 2, -height / 2, depth / 2);
            Gl.glVertex3d(width / 2, height / 2, depth / 2);
            Gl.glVertex3d(-width / 2, height / 2, depth / 2);
            Gl.glVertex3d(-width / 2, -height / 2, depth / 2);


            // bottom
            Gl.glVertex3d(-width / 2, -height / 2, -depth / 2);
            Gl.glVertex3d(width / 2, -height / 2, -depth / 2);
            Gl.glVertex3d(width / 2, -height / 2, depth / 2);
            Gl.glVertex3d(-width / 2, -height / 2, depth / 2);

            // up
            Gl.glVertex3d(-width / 2, height / 2, -depth / 2);
            Gl.glVertex3d(-width / 2, height / 2, depth / 2);
            Gl.glVertex3d(width / 2, height / 2, depth / 2);
            Gl.glVertex3d(width / 2, height / 2, -depth / 2);


            Gl.glEnd();
            Gl.glPopMatrix();
        }
    }
}
