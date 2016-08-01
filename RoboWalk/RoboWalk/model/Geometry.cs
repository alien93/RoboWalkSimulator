using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class Geometry
    {
        private AbstractObject abstractObject { get; set; }

        public Geometry() { }
        public Geometry(AbstractObject ao)
        {
            this.abstractObject = ao;
        }
    }
}
