using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class HardwareInterface
    {
        private String hardwareInterface { get; set; }

        public HardwareInterface() { }
        public HardwareInterface(String hardwareInterface)
        {
            this.hardwareInterface = hardwareInterface;
        }
    }
}
