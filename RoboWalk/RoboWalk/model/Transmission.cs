using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class Transmission
    {
        private String name { get; set; }
        private TransmissionType type { get; set; }
        private ArrayList joint { get; set; }
        private ArrayList actuator { get; set; }

        public Transmission() { }
        public Transmission(String name, TransmissionType type,
                            ArrayList joint, ArrayList actuator)
        {
            this.name = name;
            this.type = type;
            this.joint = joint;
            this.actuator = actuator;
        }
    }
}
