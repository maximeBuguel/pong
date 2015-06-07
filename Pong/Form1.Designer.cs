using System.Drawing;
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
            this.settingLabel = new System.Windows.Forms.Label();
            this.exitLabel = new System.Windows.Forms.Label();
            this.settingPlayerOneLabel = new System.Windows.Forms.Label();
            this.settingPlayerTwoLabel = new System.Windows.Forms.Label();
            this.settingEngageLabel = new System.Windows.Forms.Label();
            this.soundPictureBox = new System.Windows.Forms.PictureBox();
            this.soundMutePictureBox = new System.Windows.Forms.PictureBox();
            this.settingPlayerOneUpLabel = new System.Windows.Forms.Label();
            this.settingPlayerOneDownLabel = new System.Windows.Forms.Label();
            this.settingPlayerTwoUpLabel = new System.Windows.Forms.Label();
            this.settingPlayerTwoDownLabel = new System.Windows.Forms.Label();
            this.resumeLabel = new System.Windows.Forms.Label();
            this.pauseLabel = new System.Windows.Forms.Label();
            this.winningLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.soundPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundMutePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // settingBackLabel
            // 
            this.settingBackLabel.AutoSize = true;
            this.settingBackLabel.Cursor = System.Windows.Forms.Cursors.Hand;
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
            // 
            // onePlayerLabel
            // 
            this.onePlayerLabel.AutoSize = true;
            this.onePlayerLabel.Cursor = System.Windows.Forms.Cursors.Hand;
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
            // 
            // twoPlayerLabel
            // 
            this.twoPlayerLabel.AutoSize = true;
            this.twoPlayerLabel.CausesValidation = false;
            this.twoPlayerLabel.Cursor = System.Windows.Forms.Cursors.Hand;
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
            // 
            // settingLabel
            // 
            this.settingLabel.AutoSize = true;
            this.settingLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingLabel.ForeColor = System.Drawing.Color.White;
            this.settingLabel.Location = new System.Drawing.Point(36, 138);
            this.settingLabel.Name = "settingLabel";
            this.settingLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.settingLabel.Size = new System.Drawing.Size(54, 13);
            this.settingLabel.TabIndex = 2;
            this.settingLabel.TabStop = true;
            this.settingLabel.Text = "SETTING";
            this.settingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.settingLabel.Click += new System.EventHandler(this.exitLabel_Click_1);
            // 
            // exitLabel
            // 
            this.exitLabel.AutoSize = true;
            this.exitLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitLabel.ForeColor = System.Drawing.Color.White;
            this.exitLabel.Location = new System.Drawing.Point(831, 487);
            this.exitLabel.Name = "exitLabel";
            this.exitLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.exitLabel.Size = new System.Drawing.Size(31, 13);
            this.exitLabel.TabIndex = 3;
            this.exitLabel.TabStop = true;
            this.exitLabel.Text = "EXIT";
            this.exitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.exitLabel.Click += new System.EventHandler(this.exitLabel_Click);
            // 
            // settingPlayerOneLabel
            // 
            this.settingPlayerOneLabel.AutoSize = true;
            this.settingPlayerOneLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.settingPlayerOneLabel.Location = new System.Drawing.Point(36, 151);
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
            this.settingPlayerTwoLabel.Location = new System.Drawing.Point(36, 335);
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
            // soundPictureBox
            // 
            this.soundPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.soundPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("soundPictureBox.Image")));
            this.soundPictureBox.Location = new System.Drawing.Point(852, 21);
            this.soundPictureBox.Name = "soundPictureBox";
            this.soundPictureBox.Size = new System.Drawing.Size(109, 100);
            this.soundPictureBox.TabIndex = 10;
            this.soundPictureBox.TabStop = false;
            this.soundPictureBox.Visible = false;
            this.soundPictureBox.Click += new System.EventHandler(this.soundPictureBox_Click);
            // 
            // soundMutePictureBox
            // 
            this.soundMutePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.soundMutePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("soundMutePictureBox.Image")));
            this.soundMutePictureBox.Location = new System.Drawing.Point(852, 21);
            this.soundMutePictureBox.Name = "soundMutePictureBox";
            this.soundMutePictureBox.Size = new System.Drawing.Size(109, 100);
            this.soundMutePictureBox.TabIndex = 11;
            this.soundMutePictureBox.TabStop = false;
            this.soundMutePictureBox.Visible = false;
            this.soundMutePictureBox.Click += new System.EventHandler(this.soundMutePictureBox_Click);
            // 
            // settingPlayerOneUpLabel
            // 
            this.settingPlayerOneUpLabel.AutoSize = true;
            this.settingPlayerOneUpLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingPlayerOneUpLabel.Location = new System.Drawing.Point(83, 202);
            this.settingPlayerOneUpLabel.Name = "settingPlayerOneUpLabel";
            this.settingPlayerOneUpLabel.Size = new System.Drawing.Size(28, 13);
            this.settingPlayerOneUpLabel.TabIndex = 12;
            this.settingPlayerOneUpLabel.Text = "UP :";
            this.settingPlayerOneUpLabel.Visible = false;
            this.settingPlayerOneUpLabel.Click += new System.EventHandler(this.settingPlayerOneUpLabel_Click);
            // 
            // settingPlayerOneDownLabel
            // 
            this.settingPlayerOneDownLabel.AutoSize = true;
            this.settingPlayerOneDownLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingPlayerOneDownLabel.Location = new System.Drawing.Point(83, 247);
            this.settingPlayerOneDownLabel.Name = "settingPlayerOneDownLabel";
            this.settingPlayerOneDownLabel.Size = new System.Drawing.Size(48, 13);
            this.settingPlayerOneDownLabel.TabIndex = 13;
            this.settingPlayerOneDownLabel.Text = "DOWN :";
            this.settingPlayerOneDownLabel.Visible = false;
            this.settingPlayerOneDownLabel.Click += new System.EventHandler(this.settingPlayerOneDownLabel_Click);
            // 
            // settingPlayerTwoUpLabel
            // 
            this.settingPlayerTwoUpLabel.AutoSize = true;
            this.settingPlayerTwoUpLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingPlayerTwoUpLabel.Location = new System.Drawing.Point(83, 399);
            this.settingPlayerTwoUpLabel.Name = "settingPlayerTwoUpLabel";
            this.settingPlayerTwoUpLabel.Size = new System.Drawing.Size(28, 13);
            this.settingPlayerTwoUpLabel.TabIndex = 15;
            this.settingPlayerTwoUpLabel.Text = "UP :";
            this.settingPlayerTwoUpLabel.Visible = false;
            this.settingPlayerTwoUpLabel.Click += new System.EventHandler(this.settingPlayerTwoUpLabel_Click);
            // 
            // settingPlayerTwoDownLabel
            // 
            this.settingPlayerTwoDownLabel.AutoSize = true;
            this.settingPlayerTwoDownLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingPlayerTwoDownLabel.Location = new System.Drawing.Point(83, 448);
            this.settingPlayerTwoDownLabel.Name = "settingPlayerTwoDownLabel";
            this.settingPlayerTwoDownLabel.Size = new System.Drawing.Size(48, 13);
            this.settingPlayerTwoDownLabel.TabIndex = 14;
            this.settingPlayerTwoDownLabel.Text = "DOWN :";
            this.settingPlayerTwoDownLabel.Visible = false;
            this.settingPlayerTwoDownLabel.Click += new System.EventHandler(this.settingPlayerTwoDownLabel_Click);
            // 
            // resumeLabel
            // 
            this.resumeLabel.AutoSize = true;
            this.resumeLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resumeLabel.ForeColor = System.Drawing.Color.White;
            this.resumeLabel.Location = new System.Drawing.Point(831, 448);
            this.resumeLabel.Name = "resumeLabel";
            this.resumeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.resumeLabel.Size = new System.Drawing.Size(35, 13);
            this.resumeLabel.TabIndex = 16;
            this.resumeLabel.TabStop = true;
            this.resumeLabel.Text = "BACK";
            this.resumeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.resumeLabel.Visible = false;
            this.resumeLabel.Click += new System.EventHandler(this.resumeLabel_Click);
            // 
            // pauseLabel
            // 
            this.pauseLabel.AutoSize = true;
            this.pauseLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.pauseLabel.Location = new System.Drawing.Point(36, 68);
            this.pauseLabel.Name = "pauseLabel";
            this.pauseLabel.Size = new System.Drawing.Size(100, 13);
            this.pauseLabel.TabIndex = 17;
            this.pauseLabel.Text = "PAUSE  :  ESCAPE";
            this.pauseLabel.Visible = false;
            // 
            // winningLabel
            // 
            this.winningLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.winningLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.winningLabel.Location = new System.Drawing.Point(449, 275);
            this.winningLabel.Name = "winningLabel";
            this.winningLabel.Size = new System.Drawing.Size(450, 100);
            this.winningLabel.TabIndex = 18;
            this.winningLabel.Text = "CONGRATULATION";
            this.winningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.winningLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(973, 562);
            this.Controls.Add(this.winningLabel);
            this.Controls.Add(this.pauseLabel);
            this.Controls.Add(this.resumeLabel);
            this.Controls.Add(this.settingPlayerTwoUpLabel);
            this.Controls.Add(this.settingPlayerTwoDownLabel);
            this.Controls.Add(this.settingPlayerOneDownLabel);
            this.Controls.Add(this.settingPlayerOneUpLabel);
            this.Controls.Add(this.soundMutePictureBox);
            this.Controls.Add(this.soundPictureBox);
            this.Controls.Add(this.settingEngageLabel);
            this.Controls.Add(this.settingBackLabel);
            this.Controls.Add(this.settingPlayerTwoLabel);
            this.Controls.Add(this.settingPlayerOneLabel);
            this.Controls.Add(this.exitLabel);
            this.Controls.Add(this.settingLabel);
            this.Controls.Add(this.twoPlayerLabel);
            this.Controls.Add(this.onePlayerLabel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Old School Pong";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.soundPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundMutePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label settingBackLabel;
        private System.Windows.Forms.Label onePlayerLabel;
        private System.Windows.Forms.Label twoPlayerLabel;
        private System.Windows.Forms.Label settingLabel;
        private System.Windows.Forms.Label exitLabel;
        private System.Windows.Forms.Label settingPlayerOneLabel;
        private System.Windows.Forms.Label settingPlayerTwoLabel;
        private System.Windows.Forms.Label settingEngageLabel;
        private System.Windows.Forms.PictureBox soundPictureBox;
        private System.Windows.Forms.PictureBox soundMutePictureBox;
        private System.Windows.Forms.Label settingPlayerOneUpLabel;
        private System.Windows.Forms.Label settingPlayerOneDownLabel;
        private System.Windows.Forms.Label settingPlayerTwoUpLabel;
        private System.Windows.Forms.Label settingPlayerTwoDownLabel;
        private System.Windows.Forms.Label resumeLabel;
        private System.Windows.Forms.Label pauseLabel;
        private System.Windows.Forms.Label winningLabel;
    }
}

