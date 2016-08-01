using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class Parent
    {
        private String link { get; set; } // The name of the link that is the parent of this link in the robot tree structure.

        public Parent() { }
        public Parent(String link)
        {
            this.link = link;
        }
    }
}
