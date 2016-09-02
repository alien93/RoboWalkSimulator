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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class RobotModel
    {
        public string name { get; set; }
        public IDictionary<string, Joint> joints { get; private set; }
        public IDictionary<string, Link> links { get; private set; }
        public List<Joint> jointsVector { get; private set; }
        public List<Link> linksVector { get; private set; }

        public RobotModel() {
            this.links = new Dictionary<string, Link>();
            this.joints = new Dictionary<string, Joint>();
            this.linksVector = new List<Link>();
            this.jointsVector = new List<Joint>();
        }
        public RobotModel(string name, IDictionary<string, Joint> joints, IDictionary<string, Link> links,
                          List<Joint> jointsVector, List<Link> linksVector)
        {
            this.name = name;
            this.joints = joints;
            this.links = links;
            this.jointsVector = jointsVector;
            this.linksVector = linksVector;
        }

        internal void addJoint(Joint joint)
        {
            joints.Add(joint.name, joint);
            jointsVector.Insert(jointsVector.Count, joint);
        }

        internal void addLink(Link link)
        {
            links.Add(link.name, link);
            linksVector.Insert(linksVector.Count, link);
        }

        internal List<Joint> sortJoints(IDictionary<string, Joint> jointsMap)
        {
            List<Joint> retVal = new List<Joint>();

            List<String> parentNodes = new List<String>();
            parentNodes.Add("base_link");

            foreach(Joint joint in joints.Values)
            {
                string parent = parentNodes.Last();
                if(joint.parent.link == parent)
                {
                    createBranch(ref retVal, joints, joint.name);
                }

            }

            return retVal;
        }

        private void createBranch(ref List<Joint> retVal, IDictionary<string, Joint> joints, string name)
        {
            List<string> childNodes = new List<string>();
            childNodes.Add(joints[name].child.link);
            retVal.Add(joints[name]);
            string parentNode = childNodes.Last();

            foreach(Joint joint in joints.Values)
            {
                if(joint.parent.link == parentNode)
                {
                    createBranch(ref retVal, joints, joint.name);
                }
            }
        }
    }
}
