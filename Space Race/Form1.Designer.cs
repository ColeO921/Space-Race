namespace Space_Race
{
    partial class spaceRacer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(spaceRacer));
            this.score1Output = new System.Windows.Forms.Label();
            this.gameEngine = new System.Windows.Forms.Timer(this.components);
            this.score2Output = new System.Windows.Forms.Label();
            this.winnerOutput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // score1Output
            // 
            this.score1Output.BackColor = System.Drawing.Color.Transparent;
            this.score1Output.ForeColor = System.Drawing.SystemColors.Control;
            this.score1Output.Location = new System.Drawing.Point(114, 708);
            this.score1Output.Name = "score1Output";
            this.score1Output.Size = new System.Drawing.Size(360, 26);
            this.score1Output.TabIndex = 0;
            this.score1Output.Text = "Player 1 Score:";
            // 
            // gameEngine
            // 
            this.gameEngine.Enabled = true;
            this.gameEngine.Interval = 20;
            this.gameEngine.Tick += new System.EventHandler(this.gameEngine_Tick);
            // 
            // score2Output
            // 
            this.score2Output.BackColor = System.Drawing.Color.Transparent;
            this.score2Output.Location = new System.Drawing.Point(968, 708);
            this.score2Output.Name = "score2Output";
            this.score2Output.Size = new System.Drawing.Size(252, 25);
            this.score2Output.TabIndex = 1;
            this.score2Output.Text = "Player 2 Score: ";
            // 
            // winnerOutput
            // 
            this.winnerOutput.BackColor = System.Drawing.Color.Transparent;
            this.winnerOutput.Font = new System.Drawing.Font("Segoe MDL2 Assets", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winnerOutput.ForeColor = System.Drawing.SystemColors.Control;
            this.winnerOutput.Location = new System.Drawing.Point(452, 318);
            this.winnerOutput.Name = "winnerOutput";
            this.winnerOutput.Size = new System.Drawing.Size(377, 102);
            this.winnerOutput.TabIndex = 2;
            // 
            // spaceRacer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(1300, 743);
            this.Controls.Add(this.winnerOutput);
            this.Controls.Add(this.score2Output);
            this.Controls.Add(this.score1Output);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "spaceRacer";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Space Racer";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label score1Output;
        private System.Windows.Forms.Timer gameEngine;
        private System.Windows.Forms.Label score2Output;
        private System.Windows.Forms.Label winnerOutput;
    }
}

