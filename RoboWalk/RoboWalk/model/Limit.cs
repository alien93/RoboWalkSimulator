using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboWalk.model
{
    class Limit
    {
        private double lower { get; set; } //An attribute specifying the lower joint limit (radians for revolute joints, meters for prismatic joints). Omit if joint is continuous.
        private double upper { get; set; } //An attribute specifying the upper joint limit (radians for revolute joints, meters for prismatic joints). Omit if joint is continuous.
        private double effort { get; set; } //An attribute for enforcing the maximum joint effort (|applied effort| < |effort|)
        private double velocity { get; set; } //An attribute for enforcing the maximum joint velocity.

        public Limit() { }
        public Limit(double lower, double upper, double effort, double velocity)
        {
            this.lower = lower;
            this.upper = upper;
            this.effort = effort;
            this.velocity = velocity;
        }
    }
}
