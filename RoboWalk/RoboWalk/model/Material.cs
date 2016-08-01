using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class Material
    {
        private String name { get; set; }
        private Color color { get; set; }
        private Texture texture { get; set; }

        public Material() { }
        public Material(String name, Color color, Texture texture)
        {
            this.name = name;
            this.color = color;
            this.texture = texture;
        }
    }
}
