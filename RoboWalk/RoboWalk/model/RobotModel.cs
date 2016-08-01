using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class RobotModel
    {
        private String name { get; set; }
        private DictionaryBase joints;
        private DictionaryBase links;
        private ArrayList jointsVector { get; set; }
        private ArrayList linksVector { get; set; }

        public RobotModel() { }
        public RobotModel(String name, DictionaryBase joints, DictionaryBase links,
                          ArrayList jointsVector, ArrayList linksVector)
        {
            this.name = name;
            this.joints = joints;
            this.links = links;
            this.jointsVector = jointsVector;
            this.linksVector = linksVector;
        }
    }
}
