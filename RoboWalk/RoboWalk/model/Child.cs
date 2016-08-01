using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class Child
    {
        private String link { get; set; }

        public Child() { }
        public Child(String link)
        {
            this.link = link;
        }
    }
}
