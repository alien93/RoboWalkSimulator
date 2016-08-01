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
    class Calibration
    {
        private double rising { get; set; } //When the joint moves in a positive direction, this reference position will trigger a rising edge.
        private double falling { get; set; } //When the joint moves in a positive direction, this reference position will trigger a falling edge.

        public Calibration() { }
        public Calibration(double rising, double falling)
        {
            this.rising = rising;
            this.falling = falling;
        }
    }
}
