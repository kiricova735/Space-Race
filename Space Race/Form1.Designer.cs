namespace Space_Race
{
    partial class SpaceRace
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpaceRace));
            this.gameEngine = new System.Windows.Forms.Timer(this.components);
            this.leftScore = new System.Windows.Forms.Label();
            this.rightScore = new System.Windows.Forms.Label();
            this.winLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameEngine
            // 
            this.gameEngine.Interval = 20;
            this.gameEngine.Tick += new System.EventHandler(this.GameEngine_Tick);
            // 
            // leftScore
            // 
            this.leftScore.BackColor = System.Drawing.Color.Transparent;
            this.leftScore.Font = new System.Drawing.Font("mono 08_56", 25F);
            this.leftScore.ForeColor = System.Drawing.Color.White;
            this.leftScore.Location = new System.Drawing.Point(12, 359);
            this.leftScore.Name = "leftScore";
            this.leftScore.Size = new System.Drawing.Size(67, 53);
            this.leftScore.TabIndex = 0;
            this.leftScore.Text = "0";
            this.leftScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rightScore
            // 
            this.rightScore.BackColor = System.Drawing.Color.Transparent;
            this.rightScore.Font = new System.Drawing.Font("mono 08_55", 25F);
            this.rightScore.ForeColor = System.Drawing.Color.White;
            this.rightScore.Location = new System.Drawing.Point(721, 359);
            this.rightScore.Name = "rightScore";
            this.rightScore.Size = new System.Drawing.Size(67, 53);
            this.rightScore.TabIndex = 1;
            this.rightScore.Text = "0";
            this.rightScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // winLabel
            // 
            this.winLabel.BackColor = System.Drawing.Color.Transparent;
            this.winLabel.Font = new System.Drawing.Font("mono 08_56", 30F);
            this.winLabel.ForeColor = System.Drawing.Color.White;
            this.winLabel.Location = new System.Drawing.Point(114, 144);
            this.winLabel.Name = "winLabel";
            this.winLabel.Size = new System.Drawing.Size(593, 83);
            this.winLabel.TabIndex = 2;
            this.winLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.subtitleLabel.Font = new System.Drawing.Font("mono 07_65", 8F);
            this.subtitleLabel.ForeColor = System.Drawing.Color.Green;
            this.subtitleLabel.Location = new System.Drawing.Point(199, 240);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(508, 52);
            this.subtitleLabel.TabIndex = 3;
            // 
            // SpaceRace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.subtitleLabel);
            this.Controls.Add(this.winLabel);
            this.Controls.Add(this.rightScore);
            this.Controls.Add(this.leftScore);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SpaceRace";
            this.Text = "Space Race";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SpaceRace_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SpaceRace_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SpaceRace_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameEngine;
        private System.Windows.Forms.Label leftScore;
        private System.Windows.Forms.Label rightScore;
        private System.Windows.Forms.Label winLabel;
        private System.Windows.Forms.Label subtitleLabel;
    }
}

