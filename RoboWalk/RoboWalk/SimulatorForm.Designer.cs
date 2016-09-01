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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadURDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
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
            this.robotSimulator.Location = new System.Drawing.Point(13, 27);
            this.robotSimulator.Name = "robotSimulator";
            this.robotSimulator.Size = new System.Drawing.Size(658, 267);
            this.robotSimulator.StencilBits = ((byte)(0));
            this.robotSimulator.TabIndex = 0;
            this.robotSimulator.Paint += new System.Windows.Forms.PaintEventHandler(this.robotSimulator_Paint);
            this.robotSimulator.Resize += new System.EventHandler(this.robotSimulator_Resize);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(703, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadURDFToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadURDFToolStripMenuItem
            // 
            this.loadURDFToolStripMenuItem.Name = "loadURDFToolStripMenuItem";
            this.loadURDFToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadURDFToolStripMenuItem.Text = "Load URDF";
            this.loadURDFToolStripMenuItem.Click += new System.EventHandler(this.loadURDFToolStripMenuItem_Click);
            // 
            // SimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 306);
            this.Controls.Add(this.robotSimulator);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SimulatorForm";
            this.Text = "RoboWalk";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SimulatorForm_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Tao.Platform.Windows.SimpleOpenGlControl robotSimulator;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadURDFToolStripMenuItem;
    }
}

