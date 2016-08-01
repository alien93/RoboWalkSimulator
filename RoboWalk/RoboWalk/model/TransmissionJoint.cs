using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class TransmissionJoint
    {
        private String name { get; set; }
        private ArrayList hardwareInterface { get; set; }

        public TransmissionJoint() { }
        public TransmissionJoint(String name, ArrayList hardwareInterface)
        {
            this.name = name;
            this.hardwareInterface = hardwareInterface;
        }
    }
}
