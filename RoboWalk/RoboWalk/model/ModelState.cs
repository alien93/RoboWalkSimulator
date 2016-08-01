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
    class ModelState
    {
        private String model { get; set; } //the name of the model in corresponding urdf
        private float timeStamp { get; set; } //time stamp of this state in seconds
        private ArrayList jointState { get; set; }

        public ModelState() { }
        public ModelState(String model, float timeStamp, ArrayList jointState)
        {
            this.model = model;
            this.timeStamp = timeStamp;
            this.jointState = jointState;
        }
    }
}
