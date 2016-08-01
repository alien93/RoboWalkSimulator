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
//This tag is used to specify that the defined joint mimics another existing joint.
//The value of this joint can be computed as value = multiplier * other_joint_value + offset.

namespace RoboWalk.model
{
    class Mimic
    {
        private String joint { get; set; } //This specifies the name of the joint to mimic.
        private double multiplier { get; set; } //Specifies the multiplicative factor in the formula above. Defaults to 1.
        private double offset { get; set; } //Specifies the offset to add in the formula above. Defaults to 0.

        public Mimic() { }
        public Mimic(String joint, double multiplier, double offset)
        {
            this.joint = joint;
            this.multiplier = multiplier;
            this.offset = offset;
        }
    }
}
