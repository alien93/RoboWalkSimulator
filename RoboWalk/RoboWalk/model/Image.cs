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
