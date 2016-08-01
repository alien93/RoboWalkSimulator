using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class Link
    {
        private String name { get; set; }
        private Inertial inertial { get; set; }
        private ArrayList visual { get; set; }
        private Collision collision { get; set; }

    public Link() { }
        public Link(String name, Inertial inertial, ArrayList visual, Collision collision)
        {
            this.name = name;
            this.inertial = inertial;
            this.visual = visual;
            this.collision = collision;
        }
    }
}
