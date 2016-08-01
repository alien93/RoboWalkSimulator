using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class Camera
    {
        private Image image { get; set; }

        public Camera() { }
        public Camera(Image image)
        {
            this.image = image;
        }
    }
}
