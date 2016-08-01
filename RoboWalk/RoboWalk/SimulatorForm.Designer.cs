namespace RoboWalk
{
    partial class SimulatorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.robotSimulator = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.SuspendLayout();
            // 
            // robotSimulator
            // 
            this.robotSimulator.AccumBits = ((byte)(0));
            this.robotSimulator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.robotSimulator.AutoCheckErrors = false;
            this.robotSimulator.AutoFinish = false;
            this.robotSimulator.AutoMakeCurrent = true;
            this.robotSimulator.AutoSwapBuffers = true;
            this.robotSimulator.BackColor = System.Drawing.Color.Black;
            this.robotSimulator.ColorBits = ((byte)(32));
            this.robotSimulator.DepthBits = ((byte)(16));
            this.robotSimulator.Location = new System.Drawing.Point(13, 13);
            this.robotSimulator.Name = "robotSimulator";
            this.robotSimulator.Size = new System.Drawing.Size(658, 281);
            this.robotSimulator.StencilBits = ((byte)(0));
            this.robotSimulator.TabIndex = 0;
            this.robotSimulator.Paint += new System.Windows.Forms.PaintEventHandler(this.robotSimulator_Paint);
            this.robotSimulator.Resize += new System.EventHandler(this.robotSimulator_Resize);
            // 
            // SimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 306);
            this.Controls.Add(this.robotSimulator);
            this.Name = "SimulatorForm";
            this.Text = "RoboWalk";
            this.ResumeLayout(false);

        }

        #endregion

        public Tao.Platform.Windows.SimpleOpenGlControl robotSimulator;
    }
}

