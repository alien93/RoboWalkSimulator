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

namespace RoboWalk.model
{
    class AbstractObject
    {
        protected String name { get; set; }
        protected double height { get; set; }
        protected double width { get; set; }
        protected double depth { get; set; }
        protected double radius { get; set; }
        protected double length { get; set; }
        protected double sphereRadius { get; set; }

        public AbstractObject() { }

        public AbstractObject(AbstractObject ao)
        {
            name = ao.name;
            height = ao.height;
            width = ao.width;
            depth = ao.depth;
            radius = ao.radius;
            length = ao.length;
            sphereRadius = ao.sphereRadius;
        }

        ~AbstractObject() { }
        
    }
}
