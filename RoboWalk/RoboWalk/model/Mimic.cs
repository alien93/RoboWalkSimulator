using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//This tag is used to specify that the defined joint mimics another existing joint.
//The value of this joint can be computed as value = multiplier * other_joint_value + offset.

namespace RoboWalk.model
{
    class Mimic
    {
        private String joint { get; set; } //This specifies the name of the joint to mimic.
        private double multiplier { get; set; } //Specifies the multiplicative factor in the formula above. Defaults to 1.
        private double offset { get; set; } //Specifies the offset to add in the formula above. Defaults to 0.

        public Mimic() { }
        public Mimic(String joint, double multiplier, double offset)
        {
            this.joint = joint;
            this.multiplier = multiplier;
            this.offset = offset;
        }
    }
}
