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
    class RobotSimulator:IDisposable
    {

        private float xRotation=0.0f;
        private float yRotation = -90.0f;
        private float sceneDistance=-50.0f;

        public RobotSimulator()
        {
        }

        public RobotSimulator(int width, int height)
        {
            this.init();
            this.resize(width, height);
        }

        ~RobotSimulator()
        {
            this.Dispose();
        }

        //initialise and set openGL parameters
        public void init()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
        }

        //setting viewport and projection for openGL control
        public void resize(int w, int h)
        {
            Gl.glViewport(0, 0, w, h);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(45, (float)w / h, 1.0, 150.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }

        public void draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();
            Gl.glTranslatef(0.0f, -10.0f, 0.0f);
            Gl.glTranslatef(0.0f, 0.0f, sceneDistance);
            Gl.glRotatef(xRotation, 1.0f, 0.0f, 0.0f);
            Gl.glRotatef(yRotation, 0.0f, 1.0f, 0.0f);
            Gl.glScalef(30.0f, 30.0f, 30.0f);
            
            Gl.glPushMatrix();
            Gl.glTranslatef(0.0f, -.04f, 0.0f);
            drawGrid();
            Gl.glPopMatrix();
            Gl.glRotatef(-90.0f, 1.0f, 0.0f, 0.0f);


           /* if(parser->getInstance()->getFileParsed())
             {
                 drawRobot();    //robot from urdf
             }*/
        }


        public void drawGrid()
        {
            Gl.glColor3ub(0, 255, 255);
            for (float i = -88; i <= 88; i += 0.1f)
            {
                Gl.glBegin(Gl.GL_LINES);
                Gl.glVertex3f(-88.0f, 0.0f, i);
                Gl.glVertex3f(88.0f, 0.0f, i);
                Gl.glVertex3f(i, 0.0f, -88.0f);
                Gl.glVertex3f(i, 0.0f, 88.0f);
                Gl.glEnd();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
