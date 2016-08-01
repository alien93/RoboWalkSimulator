using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class JointState
    {
        private String joint { get; set; }
        private ArrayList position { get; set; } //position for each degree of freedom of this joint
        private ArrayList velocity { get; set; } //velocity for each degree of freedom of this joint
        private ArrayList effort { get; set; } //effort for each degree of freedom of this joint

        public JointState() { }
        public JointState(String joint, ArrayList position, ArrayList velocity, ArrayList effort)
        {
            this.joint = joint;
            this.position = position;
            this.velocity = velocity;
            this.effort = effort;
        }
    }
}
