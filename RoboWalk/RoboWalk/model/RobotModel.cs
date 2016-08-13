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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class RobotModel
    {
        public string name { get; set; }
        private DictionaryBase joints;
        private DictionaryBase links;
        private ArrayList jointsVector { get; set; }
        private ArrayList linksVector { get; set; }

        public RobotModel() { }
        public RobotModel(string name, DictionaryBase joints, DictionaryBase links,
                          ArrayList jointsVector, ArrayList linksVector)
        {
            this.name = name;
            this.joints = joints;
            this.links = links;
            this.jointsVector = jointsVector;
            this.linksVector = linksVector;
        }
    }
}
