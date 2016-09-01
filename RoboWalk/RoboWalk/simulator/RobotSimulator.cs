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
using RoboWalk.model;
using RoboWalk.urdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace RoboWalk.simulator
{
    class RobotSimulator : IDisposable
    {

        private float xRotation = 0.0f;
        private float yRotation = -90.0f;
        private float sceneDistance=-50.0f;
        private URDFparser urdf = null;
        private IDictionary<string, float[]> matrices = new Dictionary<string, float[]>();    //matrix for each parent node
        private string jointName = "";
        private double limit = 0.1;
        public float XRotation
        {
            get
            {
                return xRotation;
            }
            set
            {
                xRotation = value;
            }
        }
        public float YRotation
        {
            get
            {
                return yRotation;
            }
            set
            {
                yRotation = value;
            }
        }
        public float SceneDistance
        {
            get
            {
                return sceneDistance;
            }
            set
            {
                sceneDistance = value;
            }
        }

        public RobotSimulator()
        {
        }

        public RobotSimulator(int width, int height)
        {
            urdf = URDFparser.getInstance();
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
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
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

            if (urdf.fileParsed)
                drawRobot();    //robot from urdf
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

        public void drawRobot()
        {
            IDictionary<string, Link> linksMap = urdf.rm.links;
            List<Link> links = urdf.rm.linksVector;
            IDictionary<string, Joint> jointsMap = urdf.rm.joints;
            List<Joint> joints = urdf.rm.jointsVector;

            float[] m = {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};

            //vector<Joint> joints = parser->getInstance()->rm.sortJoints(jointsMap);

            if (joints.Count != 0)
            {
                foreach (Joint j in joints)
                {
                    Parent p = j.parent;   //parent
                    Child c = j.child;     //child
                    Origin o = j.origin;   //position of the child link relative to parent link
                                                //draw parent link
                                                //  glPushMatrix();
                    Link lp = linksMap[p.link];
                    IDictionary<string, Link> usedLinks = urdf.usedLinks;
                    
                    if(usedLinks.ContainsKey(lp.name))
                    {
                        Gl.glLoadMatrixf(matrices[lp.name]);
                        drawLink(lp);
                    }
                    else
                    {
                        Gl.glGetFloatv(Gl.GL_MODELVIEW_MATRIX, m);
                        matrices[lp.name] = m;
                        usedLinks[lp.name] = lp;
                        urdf.usedLinks = usedLinks;
                        drawLink(lp);
                    }
                    //joint transformations
                    if (jointName != "" && j.child.link == jointName)
                    {
                        Axis axis = j.axis;
                        Gl.glTranslated(o.x, o.y, o.z);
                        rotateMe(limit * (axis.x), limit * (axis.y), limit * (axis.z));
                    }
                    else
                    {
                        Gl.glTranslated(o.x, o.y, o.z);
                        rotateMe(o.r, o.p, o.y);
                    }


                    //draw child link
                    Link lc = linksMap[c.link];
                    drawLink(lc);

                }

                IDictionary<string, Link> newMap = urdf.usedLinks;
                newMap.Clear();
                matrices.Clear();
                urdf.usedLinks = newMap;
            }
            else
                foreach(Link lp in links)
                {
                    Gl.glPushMatrix();
                    drawLink(lp);
                    Gl.glPopMatrix();
                }
        }

        private void rotateMe(double r, double p, double y)
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

        private double convertRadToDegrees(double value)
        {
            return value * 180 / Math.PI;
        }

        private void drawLink(Link l)
        {
            List<Visual> visuals = l.visual;
            
            if(visuals.Count > 0)
            {
                for(int i=0; i<visuals.Count; i++)
                {
                    Origin o = visuals[i].origin;
                    Geometry g = visuals[i].geometry;
                    Material m = visuals[i].material;

                    switch(g.abstractObject.name)
                    {
                        case "cylinder":
                            {
                                double length = g.abstractObject.length;
                                double radius = g.abstractObject.radius;
                                double red = 0;
                                double green = 0;
                                double blue = 0;
                                double alpha = 1;
                                if (m != null && m.color != null)
                                {
                                    red = m.color.red;
                                    green = m.color.green;
                                    blue = m.color.blue;
                                    alpha = m.color.alpha;
                                }

                                DrawCylinder cylinder = new DrawCylinder(length, radius,
                                                                     o.r, o.p, o.yy,
                                                                     o.x, o.y, o.z,
                                                                     red, green, blue, alpha);
                                cylinder.drawCylinder();

                                break;
                            }
                        case "box":
                            {
                                double width = g.abstractObject.width;
                                double height = g.abstractObject.height;
                                double depth = g.abstractObject.depth;
                                double red = 0;
                                double green = 0;
                                double blue = 0;
                                double alpha = 1;
                                if(m != null && m.color != null)
                                {
                                    red = m.color.red;
                                    green = m.color.green;
                                    blue = m.color.blue;
                                    alpha = m.color.alpha;
                                }
                               
                                DrawBox box = new DrawBox(width, height, depth,
                                                          o.r, o.p, o.yy,
                                                          o.x, o.y, o.z,
                                                          red, green, blue, alpha);
                                box.drawBox();
                                break;
                            }
                        case "sphere":
                            {
                                double radius = g.abstractObject.radius;
                                double red = 0;
                                double green = 0;
                                double blue = 0;
                                double alpha = 1;
                                if (m != null && m.color != null)
                                {
                                    red = m.color.red;
                                    green = m.color.green;
                                    blue = m.color.blue;
                                    alpha = m.color.alpha;
                                }
                                DrawSphere sphere = new DrawSphere(radius,
                                                                   o.r, o.p, o.yy,
                                                                   o.x, o.y, o.z,
                                                                   red, green, blue, alpha);
                                sphere.drawSphere();
                                break;
                            }
                    }
                }
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
