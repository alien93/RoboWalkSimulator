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
    class Image
    {
        private int width { get; set; } //pixels
        private int height { get; set; } //pixels
        private String format { get; set; } //iamge format of the camera
        private float hfov { get; set; } //radians, horizontal field of view of the camera
        private float near { get; set; } //m, near clip distance of the camera in meters
        private float far { get; set; } //m, far clip distance of the camera in meters. This needs to be greater or equal to near clip

        public Image() { }
        public Image(int width, int height, String format, float hfov, float near, float far)
        {
            this.width = width;
            this.height = height;
            this.format = format;
            this.hfov = hfov;
            this.near = near;
            this.far = far;
        }
    }
}
