/*Copyright (c) 2016  Nina Marjanovic
This file is part of RoboWalk.
RoboWalk is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
Robowalk is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with RoboWalk.  If not, see <http://www.gnu.org/licenses/>*/
using RoboWalk.simulator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.Platform.Windows;
using RoboWalk.urdf;

namespace RoboWalk
{
    public partial class SimulatorForm : Form
    {
        private RobotSimulator rs = null;

        public SimulatorForm()
        {
            InitializeComponent();
            robotSimulator.InitializeContexts();
            rs = new RobotSimulator(robotSimulator.Width, robotSimulator.Height);
            URDFparser parser = URDFparser.getInstance();
            Console.WriteLine("starting...");
            parser.parseURDF("D:/urdf/biped.urdf");
            Console.WriteLine("done...");
        }

        private void robotSimulator_Paint(object sender, PaintEventArgs e)
        {
            rs.draw();
        }

        private void robotSimulator_Resize(object sender, EventArgs e)
        {
            rs.resize(robotSimulator.Width, robotSimulator.Height);
        }

        private void SimulatorForm_KeyDown(object sender, KeyEventArgs e)
        {
            float xRotation = rs.XRotation;
            float yRotation = rs.YRotation;
            float sceneDistance = rs.SceneDistance;

            switch (e.KeyCode)
            {
                case Keys.S:
                    {
                        xRotation -= 5.0f;
                        rs.XRotation = xRotation;
                        break;
                    }
                case Keys.W:
                    {
                        xRotation += 5.0f;
                        rs.XRotation = xRotation;
                        break;
                    }
                case Keys.D:
                    {
                        yRotation -= 5.0f;
                        rs.YRotation = yRotation;
                        break;
                    }
                case Keys.A:
                    {
                        yRotation += 5.0f;
                        rs.YRotation = yRotation;
                        break;
                    }
                case Keys.Add:
                    {
                        sceneDistance += 10.0f;
                        rs.SceneDistance = sceneDistance;
                        break;
                    }
                case Keys.Subtract:
                    {
                        sceneDistance -= 10.0f;
                        rs.SceneDistance = sceneDistance;
                        break;
                    }
            }
            robotSimulator.Refresh();
        }
    }
}
