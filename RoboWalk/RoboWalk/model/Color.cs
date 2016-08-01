using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class Color
    {
        private double red { get; set; }
        private double green { get; set; }
        private double blue { get; set; }
        private double alpha { get; set; }

        public Color() { }
        public Color(double red, double green, double blue, double alpha)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
            this.alpha = alpha;
        }
    }
}
