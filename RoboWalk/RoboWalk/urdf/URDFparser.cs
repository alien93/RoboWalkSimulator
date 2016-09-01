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
using RoboWalk.model;
using System.Xml;
using System.IO;
using System.Collections;

namespace RoboWalk.urdf
{
    class URDFparser
    {
        private static URDFparser instance = null;
        public bool fileParsed { get; private set; }
        public RobotModel rm  { get; set; }
        public IDictionary<string, Link> usedLinks { get; set; }

        public URDFparser()
        {
            fileParsed = false;
            rm = new RobotModel();
            usedLinks = new Dictionary<string, Link>();
        }

        public static URDFparser getInstance()
        {
            if(instance == null)
            {
                instance = new URDFparser();
            }
            return instance;
        }

        /*public void addInertialElementChildren(int i, XmlElement inertialElement, Inertial inertial)
        {
            if(inertialElement.ChildNodes[i].ta)
        }*/

        public void parseURDF(string filename)
        {
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            string content = document.InnerXml;
            Console.WriteLine(content);

            XmlNode root = document.FirstChild; //root element
            string roboName = root.Attributes !=null && root.Attributes["name"]!=null?root.Attributes["name"].Value:"Undefined_Robot";
            rm.name = roboName;
            for(int i=0; i<root.ChildNodes.Count; i++)
            {
                parseChildNodes(root, i);
            }
            fileParsed = true;
        }

        public void parseChildNodes(XmlNode root, int i)
        {
            XmlNode node = root.ChildNodes[i];
            Origin origin = null;
            Parent parent = null;
            Child child = null;
            Axis axis = null;
            Calibration calibration = null;
            Dynamics dynamics = null;
            Limit limit = null;
            Mimic mimic = null;
            SafetyController safetyController = null;

            if (node.Name.Equals("joint"))
            {
                //joint name
                string name = node.Attributes["name"] != null ? node.Attributes["name"].Value : "Undefined_link";

                //get joint type - revolute, continuous, prismatic, fixeed, floating, planar
                Types type = new Types();
                string jointType = node.Attributes["type"] != null ? node.Attributes["type"].Value : "";
                if(jointType.Equals("fixed"))
                {
                    type = Types.fixeed;
                }
                else if (jointType.Equals("revolute"))
                {
                    type = Types.revolute;
                }
                else if (jointType.Equals("continuous"))
                {
                    type = Types.continuous;
                }
                else if (jointType.Equals("prismatic"))
                {
                    type = Types.prismatic;
                }
                else if (jointType.Equals("floating"))
                {
                    type = Types.floating;
                }
                else if (jointType.Equals("planar"))
                {
                    type = Types.planar;
                }

                for(int j=0; j<node.ChildNodes.Count; j++)
                {
                    switch(node.ChildNodes[j].Name.ToString())
                    {
                        case "origin":
                            {
                                XmlNode originNode = node.ChildNodes[j];
                                string rpy = originNode.Attributes["rpy"] != null ? originNode.Attributes["rpy"].Value : "";
                                string xyz = originNode.Attributes["xyz"] != null ? originNode.Attributes["xyz"].Value : "";
                                double x, y, z, r, p, yy;
                                if (xyz != "")
                                {
                                    string[] xyz_data = xyz.Split(' ');
                                    x = Convert.ToDouble(xyz_data[0]);
                                    y = Convert.ToDouble(xyz_data[1]);
                                    z = Convert.ToDouble(xyz_data[2]);
                                }
                                else
                                {
                                    x = 0;
                                    y = 0;
                                    z = 0;
                                }
                                
                                if(rpy != "")
                                {
                                    string[] rpy_data = rpy.Split(' ');
                                    r = Convert.ToDouble(rpy_data[0]);
                                    p = Convert.ToDouble(rpy_data[1]);
                                    yy = Convert.ToDouble(rpy_data[2]);
                                }
                                else
                                {
                                    r = 0;
                                    p = 0;
                                    yy = 0;
                                }
                                origin = new Origin(x, y, z, r, p, yy);
                                break;
                            }
                        case "parent":
                            {
                                XmlNode parentNode = node.ChildNodes[j];
                                String linkName = parentNode.Attributes["link"] != null ? parentNode.Attributes["link"].Value : "";
                                parent = new Parent(linkName);
                                break;
                            }
                        case "child":
                            {
                                XmlNode childNode = node.ChildNodes[j];
                                String childName = childNode.Attributes["link"] != null ? childNode.Attributes["link"].Value : "";
                                child = new Child(childName);
                                break;
                            }
                        case "axis":
                            {
                                XmlNode axisNode = node.ChildNodes[j];
                                String rpy_axis = axisNode.Attributes["rpy"] != null ? axisNode.Attributes["rpy"].Value : "";
                                string xyz_axis = axisNode.Attributes["xyz"] != null ? axisNode.Attributes["xyz"].Value : "";
                                double x1, y1, z1, r1, p1, yy1;
                                if(xyz_axis != "")
                                {
                                    string[] xyz_dataAxis = xyz_axis.Split(' ');
                                    x1 = Convert.ToDouble(xyz_dataAxis[0]);
                                    y1 = Convert.ToDouble(xyz_dataAxis[1]);
                                    z1 = Convert.ToDouble(xyz_dataAxis[2]);
                                }
                                else
                                {
                                    x1 = 1; y1 = 0; z1 = 0;
                                }

                                if(rpy_axis != "")
                                {
                                    string[] rpy_dataAxis = rpy_axis.Split(' ');
                                    r1 = Convert.ToDouble(rpy_dataAxis[0]);
                                    p1 = Convert.ToDouble(rpy_dataAxis[1]);
                                    yy1 = Convert.ToDouble(rpy_dataAxis[2]);
                                }
                                else
                                {
                                    r1 = 0;
                                    p1 = 0;
                                    yy1 = 0;
                                }
                                axis = new Axis(x1, y1, z1, r1, p1, yy1);
                                break;
                            }
                        case "calibration":
                            {
                                XmlNode calibrationNode = node.ChildNodes[j];
                                string rising = calibrationNode.Attributes["rising"] != null ? calibrationNode.Attributes["rising"].Value : "";
                                string falling = calibrationNode.Attributes["falling"] != null ? calibrationNode.Attributes["falling"].Value : "";
                                calibration = new Calibration(Convert.ToDouble(rising), Convert.ToDouble(falling));
                                break;
                            }
                        case "dynamics":
                            {
                                XmlNode dynamicsNode = node.ChildNodes[j];
                                string damping = dynamicsNode.Attributes["damping"] != null ? dynamicsNode.Attributes["damping"].Value : "";
                                string friction = dynamicsNode.Attributes["friction"] != null ? dynamicsNode.Attributes["friction"].Value : "";
                                dynamics = new Dynamics(Convert.ToDouble(damping), Convert.ToDouble(friction));
                                break;
                            }
                        case "limit":
                            {
                                XmlNode limitNode = node.ChildNodes[j];
                                string lower = limitNode.Attributes["lower"] != null ? limitNode.Attributes["lower"].Value : "";
                                string upper = limitNode.Attributes["upper"] != null ? limitNode.Attributes["upper"].Value : "";
                                string effort = limitNode.Attributes["effort"] != null ? limitNode.Attributes["effort"].Value : "";
                                string velocity = limitNode.Attributes["velocity"] != null ? limitNode.Attributes["velocity"].Value : "";
                                limit = new Limit(Convert.ToDouble(lower), Convert.ToDouble(upper), Convert.ToDouble(effort), Convert.ToDouble(velocity));
                                break;
                            }
                        case "mimic":
                            {
                                XmlNode mimicNode = node.ChildNodes[j];
                                string jointMimic = mimicNode.Attributes["joint"] != null ? mimicNode.Attributes["joint"].Value : "";
                                string multiplier = mimicNode.Attributes["multiplier"] != null ? mimicNode.Attributes["multiplier"].Value : "";
                                string offset = mimicNode.Attributes["offset"] != null ? mimicNode.Attributes["offset"].Value : "";
                                if (multiplier == "") multiplier = "1";
                                if (offset == "") offset = "0";
                                mimic = new Mimic(jointMimic, Convert.ToDouble(multiplier), Convert.ToDouble(offset));
                                break;
                            }
                        case "safety_controller":
                            {
                                XmlNode safetyControllerNode = node.ChildNodes[j];
                                string soft_lower_limit = safetyControllerNode.Attributes["soft_lower_limit"] != null ? safetyControllerNode.Attributes["soft_lower_limit"].Value : "";
                                string soft_upper_limit = safetyControllerNode.Attributes["soft_upper_limit"] != null ? safetyControllerNode.Attributes["soft_upper_limit"].Value : "";
                                string k_position = safetyControllerNode.Attributes["k_position"] != null ? safetyControllerNode.Attributes["k_position"].Value : "";
                                string k_velocity = safetyControllerNode.Attributes["k_velocity"] != null ? safetyControllerNode.Attributes["k_velocity"].Value : "";
                                if (soft_lower_limit == "") soft_lower_limit = "0";
                                if (soft_upper_limit == "") soft_upper_limit = "0";
                                if (k_position == "") k_position = "0";
                                if (k_velocity == "") k_velocity = "0";
                                safetyController = new SafetyController(Convert.ToDouble(soft_lower_limit),
                                                                                         Convert.ToDouble(soft_upper_limit),
                                                                                         Convert.ToDouble(k_position),
                                                                                         Convert.ToDouble(k_velocity));
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
                Joint joint = new Joint(name, type, origin, parent, child,
                                                    axis, calibration, dynamics, limit,
                                                    mimic, safetyController);
                rm.addJoint(joint);
            }
            else if(node.Name.Equals("link"))
            {
                //link name
                String name = node.Attributes["name"] != null ? node.Attributes["name"].Value : "noName link";

                //inertial
                Inertial inertial = null;
                List<Visual> visuals = new List<Visual>();
               
                for (int j = 0; j < node.ChildNodes.Count; j++)
                {
                    switch (node.ChildNodes[j].Name.ToString())
                    {
                        case "inertial":
                            {
                                XmlNode inertialNode = node.ChildNodes[j];
                                for(int k = 0; k<inertialNode.ChildNodes.Count; k++)
                                {
                                    addInertialElementChildren(k, inertialNode, inertial);
                                }
                                break;
                            }
                        case "visual":
                            {
                                string visualName = "";
                                Geometry geometry = null;
                                Origin visualOrigin = null;
                                Material material = null;

                                for (int k = 0; k < node.ChildNodes.Count; k++)
                                {
                                    if (node.ChildNodes[k].Name.Equals("visual"))
                                    {
                                        for (int m = 0; m < node.ChildNodes[k].ChildNodes.Count; m++)
                                        {
                                            XmlNode visualNode = node.ChildNodes[k].ChildNodes[m];
                                            visualName = visualNode.Attributes["name"] != null ? visualNode.Attributes["name"].Value : "";

                                           
                                            switch (visualNode.Name.ToString())
                                            {
                                                case "origin":
                                                    {
                                                        XmlNode originNode = visualNode;
                                                        string rpy = originNode.Attributes["rpy"] != null ? originNode.Attributes["rpy"].Value : "";
                                                        string xyz = originNode.Attributes["xyz"] != null ? originNode.Attributes["xyz"].Value : "";
                                                        double x, y, z, r, p, yy;
                                                        if (xyz != "")
                                                        {
                                                            string[] xyz_data = xyz.Split(' ');
                                                            x = Convert.ToDouble(xyz_data[0]);
                                                            y = Convert.ToDouble(xyz_data[1]);
                                                            z = Convert.ToDouble(xyz_data[2]);
                                                        }
                                                        else
                                                        {
                                                            x = 0; y = 0; z = 0;
                                                        }
                                                        if (rpy != "")
                                                        {
                                                            string[] rpy_data = rpy.Split(' ');
                                                            r = Convert.ToDouble(rpy_data[0]);
                                                            p = Convert.ToDouble(rpy_data[1]);
                                                            yy = Convert.ToDouble(rpy_data[2]);
                                                        }
                                                        else
                                                        {
                                                            r = 0; p = 0; yy = 0;
                                                        }
                                                        visualOrigin = new Origin(x, y, z, r, p, yy);
                                                        break;
                                                    }
                                                case "geometry":
                                                    {
                                                        XmlNode originNode = visualNode;
                                                        geometry = new Geometry();
                                                        for (int l = 0; l < originNode.ChildNodes.Count; l++)
                                                        {
                                                            switch (originNode.ChildNodes[l].Name.ToString())
                                                            {
                                                                case "box":
                                                                    {
                                                                        XmlNode boxNode = originNode.ChildNodes[l];
                                                                        if (!boxNode.Name.Equals(""))
                                                                        {
                                                                            string sizeText = boxNode.Attributes["size"] != null ? boxNode.Attributes["size"].Value : "";
                                                                            string[] sizeVal = sizeText.Split(' ');
                                                                            double x_box = Convert.ToDouble(sizeVal[0]);
                                                                            double y_box = Convert.ToDouble(sizeVal[1]);
                                                                            double z_box = Convert.ToDouble(sizeVal[2]);
                                                                            Box box = new Box(x_box, y_box, z_box);
                                                                            box.name = "box";
                                                                            geometry = new Geometry(box);
                                                                        }
                                                                        break;
                                                                    }
                                                                case "cylinder":
                                                                    {
                                                                        XmlNode cylinderNode = originNode.ChildNodes[l];
                                                                        if (!cylinderNode.Name.Equals(""))
                                                                        {
                                                                            string radiusText = cylinderNode.Attributes["radius"] != null ? cylinderNode.Attributes["radius"].Value : "";
                                                                            string lengthText = cylinderNode.Attributes["length"] != null ? cylinderNode.Attributes["length"].Value : "";
                                                                            double radius = Convert.ToDouble(radiusText);
                                                                            double length = Convert.ToDouble(lengthText);
                                                                            Cylinder cylinder = new Cylinder(radius, length);
                                                                            cylinder.name = "cylinder";
                                                                            geometry = new Geometry(cylinder);
                                                                        }
                                                                        break;
                                                                    }
                                                                case "sphere":
                                                                    {
                                                                        XmlNode sphereNode = originNode.ChildNodes[l];
                                                                        if (!sphereNode.Name.Equals(""))
                                                                        {
                                                                            string radiusText = sphereNode.Attributes["radius"] != null ? sphereNode.Attributes["radius"].Value : "";
                                                                            double radius = Convert.ToDouble(radiusText);
                                                                            Sphere sphere = new Sphere(radius);
                                                                            sphere.name = "sphere";
                                                                            geometry = new Geometry(sphere);
                                                                        }
                                                                        break;
                                                                    }
                                                                default:
                                                                    {
                                                                        break;
                                                                    }
                                                            }
                                                        }
                                                        break;
                                                    }
                                                case "material":
                                                    {
                                                        XmlNode materialNode = visualNode;
                                                        string materialName = materialNode.Attributes["name"] != null ? materialNode.Attributes["name"].Value : "";
                                                        Color color = null; Texture texture = null;

                                                        for (int z = 0; z < materialNode.ChildNodes.Count; z++)
                                                        {
                                                            switch (materialNode.ChildNodes[z].Name)
                                                            {
                                                                case "color":
                                                                    {
                                                                        XmlNode colorNode = materialNode.ChildNodes[z];
                                                                        string colorText = colorNode.Attributes["rgba"] != null ? colorNode.Attributes["rgba"].Value : "";
                                                                        double rColor, gColor, bColor, aColor;
                                                                        if (!colorText.Equals(""))
                                                                        {
                                                                            string[] rgbaList = colorText.Split(' ');
                                                                            rColor = Convert.ToDouble(rgbaList[0]);
                                                                            gColor = Convert.ToDouble(rgbaList[1]);
                                                                            bColor = Convert.ToDouble(rgbaList[2]);
                                                                            aColor = Convert.ToDouble(rgbaList[3]);
                                                                        }
                                                                        else
                                                                        {
                                                                            rColor = 0; gColor = 0; bColor = 0; aColor = 0;
                                                                        }
                                                                        color = new Color(rColor, gColor, bColor, aColor);
                                                                        break;
                                                                    }
                                                                case "texture":
                                                                    {
                                                                        texture = new Texture();
                                                                        break;
                                                                    }
                                                                default:
                                                                    {
                                                                        break;
                                                                    }
                                                            }
                                                            material = new Material(materialName, color, texture);

                                                        }

                                                        break;
                                                    }
                                                default:
                                                    {
                                                        break;
                                                    }


                                            }
                                            
                                        }

                                    }
                                }
                                Visual visual = new Visual(visualName, visualOrigin, geometry, material);
                                visuals.Add(visual);
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
                Collision collision = null; 
                Link link = new Link(name, inertial, visuals, collision);
                rm.addLink(link);
             }
        }

        private void addInertialElementChildren(int k, XmlNode inertialNode, Inertial inertial)
        {
            if(inertialNode.ChildNodes[k].Name.Equals("origin"))
            {
                for(int i=0; i<inertialNode.ChildNodes.Count; i++)
                {
                    switch (inertialNode.ChildNodes[i].Name.ToString())
                    {
                        case "origin":
                            {
                                XmlNode originNode = inertialNode.ChildNodes[i];
                                String rpy = originNode.Attributes["rpy"] != null ? originNode.Attributes["rpy"].Value : "";
                                String xyz = originNode.Attributes["xyz"] != null ? originNode.Attributes["xyz"].Value : "";
                                double x, y, z, r, p, yy;
                                if(xyz != "")
                                {
                                    string[] xyz_data = xyz.Split(' ');
                                    x = Convert.ToDouble(xyz_data[0]);
                                    y = Convert.ToDouble(xyz_data[1]);
                                    z = Convert.ToDouble(xyz_data[2]);
                                }
                                else
                                {
                                    x = 0; y = 0; z = 0;
                                }
                                if(rpy != "")
                                {
                                    string[] rpy_data = rpy.Split(' ');
                                    r = Convert.ToDouble(rpy_data[0]);
                                    p = Convert.ToDouble(rpy_data[1]);
                                    yy = Convert.ToDouble(rpy_data[2]);
                                }
                                else
                                {
                                    r = 0; p = 0; yy = 0;
                                }
                                Origin origin = new Origin(x, y, z, r, p, yy);
                                inertial.origin = origin;

                                break;
                            }
                        case "mass":
                            {
                                XmlNode massNode = inertialNode.ChildNodes[i];
                                string massVal = massNode.Attributes["value"] != null ? massNode.Attributes["value"].Value : "";
                                Mass mass = new Mass(Convert.ToDouble(massVal));
                                inertial.mass = mass;
                                break;
                            }
                        case "inertia":
                            {
                                XmlNode inertiaNode = inertialNode.ChildNodes[i];
                                string ixx = inertiaNode.Attributes["ixx"].Value;
                                string ixy = inertiaNode.Attributes["ixy"].Value;
                                string ixz = inertiaNode.Attributes["ixz"].Value;
                                string iyy = inertiaNode.Attributes["iyy"].Value;
                                string iyz = inertiaNode.Attributes["iyz"].Value;
                                string izz = inertiaNode.Attributes["izz"].Value;
                                if (ixx.Equals("")) ixx = "0";
                                if (ixy.Equals("")) ixy = "0";
                                if (ixz.Equals("")) ixz = "0";
                                if (iyy.Equals("")) iyy = "0";
                                if (iyz.Equals("")) iyz = "0";
                                if (izz.Equals("")) izz = "0";
                                Inertia inertia = new Inertia(Convert.ToDouble(ixx),
                                                              Convert.ToDouble(ixy),
                                                              Convert.ToDouble(ixz),
                                                              Convert.ToDouble(iyy),
                                                              Convert.ToDouble(iyz),
                                                              Convert.ToDouble(izz));
                                inertial.inertia = inertia;
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
            }
        }
    }
}
