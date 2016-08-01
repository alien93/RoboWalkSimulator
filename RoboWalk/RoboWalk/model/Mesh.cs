using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class Mesh
    {
        private String filePath { get; set; }
        private double scale { get; set; }

        public Mesh() { }
        public Mesh(String filePath, double scale)
        {
            this.filePath = filePath;
            this.scale = scale;
        }
    }
}
