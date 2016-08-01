using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class Texture
    {
        private String filePath { get; set; }

        public Texture() { }
        public Texture(String filePath)
        {
            this.filePath = filePath;
        }
    }
}
