using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class Actuator
    {
        private String name { get; set; }
        private ArrayList mechanicalReduction { get; set; }

        public Actuator() { }
        public Actuator(String name, ArrayList mechanicalReduction)
        {
            this.name = name;
            this.mechanicalReduction = mechanicalReduction;
        }
    }
}
