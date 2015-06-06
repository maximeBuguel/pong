namespace Pong
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.settingBackLabel = new System.Windows.Forms.Label();
            this.onePlayerLabel = new System.Windows.Forms.Label();
            this.twoPlayerLabel = new System.Windows.Forms.Label();
            this.exitLabel = new System.Windows.Forms.Label();
            this.settingLabel = new System.Windows.Forms.Label();
            this.settingPlayerOneLabel = new System.Windows.Forms.Label();
            this.settingPlayerTwoLabel = new System.Windows.Forms.Label();
            this.settingEngageLabel = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.settingPlayerOneUpLabel = new System.Windows.Forms.Label();
            this.settingPlayerOneDownLabel = new System.Windows.Forms.Label();
            this.settingPlayerTwoUpLabel = new System.Windows.Forms.Label();
            this.settingPlayerTwoDownLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // settingBackLabel
            // 
            this.settingBackLabel.AutoSize = true;
            this.settingBackLabel.ForeColor = System.Drawing.Color.White;
            this.settingBackLabel.Location = new System.Drawing.Point(831, 487);
            this.settingBackLabel.Name = "settingBackLabel";
            this.settingBackLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.settingBackLabel.Size = new System.Drawing.Size(35, 13);
            this.settingBackLabel.TabIndex = 6;
            this.settingBackLabel.TabStop = true;
            this.settingBackLabel.Text = "BACK";
            this.settingBackLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.settingBackLabel.Visible = false;
            this.settingBackLabel.Click += new System.EventHandler(this.settingBackLabel_Click);
            this.settingBackLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            // 
            // onePlayerLabel
            // 
            this.onePlayerLabel.AutoSize = true;
            this.onePlayerLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.onePlayerLabel.ForeColor = System.Drawing.Color.White;
            this.onePlayerLabel.Location = new System.Drawing.Point(36, 21);
            this.onePlayerLabel.Name = "onePlayerLabel";
            this.onePlayerLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.onePlayerLabel.Size = new System.Drawing.Size(75, 13);
            this.onePlayerLabel.TabIndex = 0;
            this.onePlayerLabel.TabStop = true;
            this.onePlayerLabel.Text = "ONE PLAYER";
            this.onePlayerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.onePlayerLabel.Click += new System.EventHandler(this.onePlayerLabel_Click);
            this.onePlayerLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            // 
            // twoPlayerLabel
            // 
            this.twoPlayerLabel.AutoSize = true;
            this.twoPlayerLabel.CausesValidation = false;
            this.twoPlayerLabel.ForeColor = System.Drawing.Color.White;
            this.twoPlayerLabel.Location = new System.Drawing.Point(36, 81);
            this.twoPlayerLabel.Name = "twoPlayerLabel";
            this.twoPlayerLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.twoPlayerLabel.Size = new System.Drawing.Size(78, 13);
            this.twoPlayerLabel.TabIndex = 1;
            this.twoPlayerLabel.TabStop = true;
            this.twoPlayerLabel.Text = "TWO PLAYER";
            this.twoPlayerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.twoPlayerLabel.Click += new System.EventHandler(this.twoPlayerLabel_Click);
            this.twoPlayerLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            // 
            // exitLabel
            // 
            this.exitLabel.AutoSize = true;
            this.exitLabel.ForeColor = System.Drawing.Color.White;
            this.exitLabel.Location = new System.Drawing.Point(36, 138);
            this.exitLabel.Name = "exitLabel";
            this.exitLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.exitLabel.Size = new System.Drawing.Size(54, 13);
            this.exitLabel.TabIndex = 2;
            this.exitLabel.TabStop = true;
            this.exitLabel.Text = "SETTING";
            this.exitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.exitLabel.Click += new System.EventHandler(this.exitLabel_Click_1);
            this.exitLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            // 
            // settingLabel
            // 
            this.settingLabel.AutoSize = true;
            this.settingLabel.ForeColor = System.Drawing.Color.White;
            this.settingLabel.Location = new System.Drawing.Point(831, 487);
            this.settingLabel.Name = "settingLabel";
            this.settingLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.settingLabel.Size = new System.Drawing.Size(31, 13);
            this.settingLabel.TabIndex = 3;
            this.settingLabel.TabStop = true;
            this.settingLabel.Text = "EXIT";
            this.settingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.settingLabel.Click += new System.EventHandler(this.exitLabel_Click);

            this.settingLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            // 
            // settingPlayerOneLabel
            // 
            this.settingPlayerOneLabel.AutoSize = true;
            this.settingPlayerOneLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.settingPlayerOneLabel.Location = new System.Drawing.Point(36, 108);
            this.settingPlayerOneLabel.Name = "settingPlayerOneLabel";
            this.settingPlayerOneLabel.Size = new System.Drawing.Size(75, 13);
            this.settingPlayerOneLabel.TabIndex = 4;
            this.settingPlayerOneLabel.Text = "PLAYER ONE";
            this.settingPlayerOneLabel.Visible = false;
            // 
            // settingPlayerTwoLabel
            // 
            this.settingPlayerTwoLabel.AutoSize = true;
            this.settingPlayerTwoLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.settingPlayerTwoLabel.Location = new System.Drawing.Point(36, 326);
            this.settingPlayerTwoLabel.Name = "settingPlayerTwoLabel";
            this.settingPlayerTwoLabel.Size = new System.Drawing.Size(78, 13);
            this.settingPlayerTwoLabel.TabIndex = 5;
            this.settingPlayerTwoLabel.Text = "PLAYER TWO";
            this.settingPlayerTwoLabel.Visible = false;
            // 
            // settingEngageLabel
            // 
            this.settingEngageLabel.AutoSize = true;
            this.settingEngageLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.settingEngageLabel.Location = new System.Drawing.Point(36, 21);
            this.settingEngageLabel.Name = "settingEngageLabel";
            this.settingEngageLabel.Size = new System.Drawing.Size(96, 13);
            this.settingEngageLabel.TabIndex = 9;
            this.settingEngageLabel.Text = "ENGAGE : SPACE";
            this.settingEngageLabel.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(852, 21);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(109, 100);
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(852, 21);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(109, 100);
            this.pictureBox4.TabIndex = 11;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Visible = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // settingPlayerOneUpLabel
            // 
            this.settingPlayerOneUpLabel.AutoSize = true;
            this.settingPlayerOneUpLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingPlayerOneUpLabel.Location = new System.Drawing.Point(83, 173);
            this.settingPlayerOneUpLabel.Name = "settingPlayerOneUpLabel";
            this.settingPlayerOneUpLabel.Size = new System.Drawing.Size(28, 13);
            this.settingPlayerOneUpLabel.TabIndex = 12;
            this.settingPlayerOneUpLabel.Text = "UP :";
            this.settingPlayerOneUpLabel.Visible = false;
            this.settingPlayerOneUpLabel.Click += new System.EventHandler(this.label4_Click);
            // 
            // settingPlayerOneDownLabel
            // 
            this.settingPlayerOneDownLabel.AutoSize = true;
            this.settingPlayerOneDownLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingPlayerOneDownLabel.Location = new System.Drawing.Point(83, 241);
            this.settingPlayerOneDownLabel.Name = "settingPlayerOneDownLabel";
            this.settingPlayerOneDownLabel.Size = new System.Drawing.Size(48, 13);
            this.settingPlayerOneDownLabel.TabIndex = 13;
            this.settingPlayerOneDownLabel.Text = "DOWN :";
            this.settingPlayerOneDownLabel.Visible = false;
            this.settingPlayerOneDownLabel.Click += new System.EventHandler(this.label5_Click);
            // 
            // settingPlayerTwoUpLabel
            // 
            this.settingPlayerTwoUpLabel.AutoSize = true;
            this.settingPlayerTwoUpLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingPlayerTwoUpLabel.Location = new System.Drawing.Point(83, 448);
            this.settingPlayerTwoUpLabel.Name = "settingPlayerTwoUpLabel";
            this.settingPlayerTwoUpLabel.Size = new System.Drawing.Size(48, 13);
            this.settingPlayerTwoUpLabel.TabIndex = 15;
            this.settingPlayerTwoUpLabel.Text = "DOWN :";
            this.settingPlayerTwoUpLabel.Visible = false;
            this.settingPlayerTwoUpLabel.Click += new System.EventHandler(this.label6_Click);
            // 
            // settingPlayerTwoDownLabel
            // 
            this.settingPlayerTwoDownLabel.AutoSize = true;
            this.settingPlayerTwoDownLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingPlayerTwoDownLabel.Location = new System.Drawing.Point(83, 377);
            this.settingPlayerTwoDownLabel.Name = "settingPlayerTwoDownLabel";
            this.settingPlayerTwoDownLabel.Size = new System.Drawing.Size(28, 13);
            this.settingPlayerTwoDownLabel.TabIndex = 14;
            this.settingPlayerTwoDownLabel.Text = "UP :";
            this.settingPlayerTwoDownLabel.Visible = false;
            this.settingPlayerTwoDownLabel.Click += new System.EventHandler(this.label7_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(973, 562);
            this.Controls.Add(this.settingPlayerTwoUpLabel);
            this.Controls.Add(this.settingPlayerTwoDownLabel);
            this.Controls.Add(this.settingPlayerOneDownLabel);
            this.Controls.Add(this.settingPlayerOneUpLabel);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.settingEngageLabel);
            this.Controls.Add(this.settingBackLabel);
            this.Controls.Add(this.settingPlayerTwoLabel);
            this.Controls.Add(this.settingPlayerOneLabel);
            this.Controls.Add(this.settingLabel);
            this.Controls.Add(this.exitLabel);
            this.Controls.Add(this.twoPlayerLabel);
            this.Controls.Add(this.onePlayerLabel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Old School Pong";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label settingBackLabel;
        private System.Windows.Forms.Label onePlayerLabel;
        private System.Windows.Forms.Label twoPlayerLabel;
        private System.Windows.Forms.Label exitLabel;
        private System.Windows.Forms.Label settingLabel;
        private System.Windows.Forms.Label settingPlayerOneLabel;
        private System.Windows.Forms.Label settingPlayerTwoLabel;
        private System.Windows.Forms.Label settingEngageLabel;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label settingPlayerOneUpLabel;
        private System.Windows.Forms.Label settingPlayerOneDownLabel;
        private System.Windows.Forms.Label settingPlayerTwoUpLabel;
        private System.Windows.Forms.Label settingPlayerTwoDownLabel;
    }
}

