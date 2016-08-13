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
using RoboWalk.model;
using System.Xml;
using System.IO;


namespace RoboWalk.urdf
{
    class URDFparser
    {
        private static URDFparser instance = null;
        private static bool fileParsed { get; set; }
        public RobotModel rm  { get; set; }

        public URDFparser()
        {
            fileParsed = false;
            rm = new RobotModel();
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
            string roboName = root.Attributes["name"]!=null?root.Attributes["name"].Value:"Undefined_Robot";
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
                                Origin origin = new Origin(x, y, z, r, p, yy);
                                break;
                            }
                        case "parent":
                            {
                                XmlNode parentNode = node.ChildNodes[j];
                                String linkName = parentNode.Attributes["link"] != null ? parentNode.Attributes["link"].Value : "";
                                Parent parent = new Parent(linkName);
                                break;
                            }
                        case "child":
                            {
                                XmlNode childNode = node.ChildNodes[j];
                                String childName = childNode.Attributes["link"] != null ? childNode.Attributes["link"].Value : "";
                                Child child = new Child(childName);
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
                                Axis axis = new Axis(x1, y1, z1, r1, p1, yy1);
                                break;
                            }
                        case "calibration":
                            {
                                XmlNode calibrationNode = node.ChildNodes[j];
                                string rising = calibrationNode.Attributes["rising"] != null ? calibrationNode.Attributes["rising"].Value : "";
                                string falling = calibrationNode.Attributes["falling"] != null ? calibrationNode.Attributes["falling"].Value : "";
                                Calibration calibration = new Calibration(Convert.ToDouble(rising), Convert.ToDouble(falling));
                                break;
                            }
                        case "dynamics":
                            {
                                XmlNode dynamicsNode = node.ChildNodes[j];
                                string damping = dynamicsNode.Attributes["damping"] != null ? dynamicsNode.Attributes["damping"].Value : "";
                                string friction = dynamicsNode.Attributes["friction"] != null ? dynamicsNode.Attributes["friction"].Value : "";
                                Dynamics dynamics = new Dynamics(Convert.ToDouble(damping), Convert.ToDouble(friction));
                                break;
                            }
                        case "limit":
                            {
                                XmlNode limitNode = node.ChildNodes[j];
                                string lower = limitNode.Attributes["lower"] != null ? limitNode.Attributes["lower"].Value : "";
                                string upper = limitNode.Attributes["upper"] != null ? limitNode.Attributes["upper"].Value : "";
                                string effort = limitNode.Attributes["effort"] != null ? limitNode.Attributes["effort"].Value : "";
                                string velocity = limitNode.Attributes["velocity"] != null ? limitNode.Attributes["velocity"].Value : "";
                                Limit limit = new Limit(Convert.ToDouble(lower), Convert.ToDouble(upper), Convert.ToDouble(effort), Convert.ToDouble(velocity));
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
                                Mimic mimic = new Mimic(jointMimic, Convert.ToDouble(multiplier), Convert.ToDouble(offset));
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
                                SafetyController safetyController = new SafetyController(Convert.ToDouble(soft_lower_limit),
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
            }
        }

    }
}