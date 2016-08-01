using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class ModelState
    {
        private String model { get; set; } //the name of the model in corresponding urdf
        private float timeStamp { get; set; } //time stamp of this state in seconds
        private ArrayList jointState { get; set; }

        public ModelState() { }
        public ModelState(String model, float timeStamp, ArrayList jointState)
        {
            this.model = model;
            this.timeStamp = timeStamp;
            this.jointState = jointState;
        }
    }
}
