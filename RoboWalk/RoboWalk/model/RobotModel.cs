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
        private IDictionary joints;
        private IDictionary links;
        private ArrayList jointsVector { get; set; }
        private ArrayList linksVector { get; set; }

        public RobotModel() {
            this.links = new Dictionary<string, Link>();
            this.joints = new Dictionary<string, Joint>();
            this.linksVector = new ArrayList();
            this.jointsVector = new ArrayList();
        }
        public RobotModel(string name, DictionaryBase joints, DictionaryBase links,
                          ArrayList jointsVector, ArrayList linksVector)
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
    }
}
