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
    class Link
    {
        public string name { get; set; }
        private Inertial inertial { get; set; }
        private ArrayList visual { get; set; }
        private Collision collision { get; set; }

    public Link() { }
        public Link(string name, Inertial inertial, ArrayList visual, Collision collision)
        {
            this.name = name;
            this.inertial = inertial;
            this.visual = visual;
            this.collision = collision;
        }
    }
}
