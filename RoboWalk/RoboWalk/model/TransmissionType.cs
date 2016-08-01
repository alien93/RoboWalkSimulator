using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class TransmissionType
    {
        private String type { get; set; }

        public TransmissionType() { }
        public TransmissionType(String type)
        {
            this.type = type;
        }
    }
}
