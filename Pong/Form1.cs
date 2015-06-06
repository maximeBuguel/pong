﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong
{

    public partial class Form1 : Form, IMessageFilter
    {

        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        const int refreshTime = 16;
        public Keys p1Up { get; set; }
        public Keys p1Down { get; set; }
        public Keys p2Up { get; set; }
        public Keys p2Down { get; set; }
        public Boolean gameRunning { get; set; }
        public Boolean Sound { get; set; }
        public PrivateFontCollection font { get; set; }
        public Boolean p1UpPressed { get; set; }

        public Boolean p1DownPressed { get; set; }

        public Boolean p2UpPressed { get; set; }

        public Boolean p2DownPressed { get; set; }
        public Keys Keyp { get; set; }
        public Boolean waitForEnter { get; set; }
        public Form1()
        {
            String path = Directory.GetCurrentDirectory() + "\\8-BIT WONDER.TTF";
            this.font = new PrivateFontCollection();
            this.font.AddFontFile(path);
            InitializeComponent();
        }

        Game game { get; set; }
        public Timer t { get; set; }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.waitForEnter = false;
            this.p1UpPressed = true;
            this.p1DownPressed = true;
            this.p2UpPressed = true;
            this.p2DownPressed = true;
            Application.AddMessageFilter(this);
            this.p1Up = Keys.Up;
            this.p1Down = Keys.Down;
            this.p2Up = Keys.Z;
            this.p2Down = Keys.S;
            this.t = new Timer();
            this.t.Interval = refreshTime;
            this.t.Tick += t_Tick;
            this.t.Start();
            timer1.Interval = 4500;
            timer1.Start();
            this.gameRunning = false;
            this.FormBorderStyle = (FormBorderStyle)BorderStyle.Fixed3D;
            this.Sound = true;
            Font myFont = new Font(this.font.Families[0], 40, FontStyle.Regular);
            this.settingBackLabel.Font = myFont;
            this.onePlayerLabel.Font = myFont;
            this.twoPlayerLabel.Font = myFont;
            this.settingLabel.Font = myFont;
            this.exitLabel.Font = myFont;
            this.settingPlayerOneLabel.Font = myFont;
            this.settingPlayerTwoLabel.Font = myFont;
            this.settingEngageLabel.Font = myFont;
            this.settingPlayerOneUpLabel.Font = myFont;
            this.settingPlayerOneDownLabel.Font = myFont;
            this.settingPlayerTwoUpLabel.Font = myFont;
            this.settingPlayerTwoDownLabel.Font = myFont;
            this.winningLabel.Font = myFont;
            this.resumeLabel.Font = myFont;
            this.pauseLabel.Font = myFont;
        }
        private void Initialize(Graphics g, int nbPlayer)
        {

            int contentWidth = this.ClientRectangle.Width;
            int contentHeight = this.ClientRectangle.Height;
            this.game = new Game(g, nbPlayer, contentWidth, contentHeight, this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (gameRunning)
            {
                this.game.incSpeed();
            }
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.KeyValue);
            //  this.game.KeyDown(e);
        }

        private void t_Tick(object sender, EventArgs e)
        {
            if (this.gameRunning)
            {
                this.game.Update();
            }
            //Invalidate();
        }

        private void onePlayerLabel_Click(object sender, EventArgs e)
        {

            this.hideHomeScreen();
            Graphics g = this.CreateGraphics();
            Initialize(g, 1);
            this.gameRunning = true;
            this.game.pauseGame();

        }

        private void twoPlayerLabel_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            hideHomeScreen();
            Initialize(g, 2);
            this.gameRunning = true;
        }


        private void exitLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitLabel_Click_1(object sender, EventArgs e)
        {
            showSettingScreen();
        }

        private void settingBackLabel_Click(object sender, EventArgs e)
        {
            if (this.p1DownPressed == true && this.p1UpPressed == true && this.p2UpPressed == true && this.p2DownPressed == true)
            {
                showHomeScreen();
            }
        }



        private void showHomeScreen()
        {
            onePlayerLabel.Show();
            twoPlayerLabel.Show();
            settingLabel.Show();
            exitLabel.Show();
            hideSettingScreen();
        }

        private void hideHomeScreen()
        {
            onePlayerLabel.Hide();
            twoPlayerLabel.Hide();
            settingLabel.Hide();
            exitLabel.Hide();
        }


        private void showSettingScreen()
        {
            hideHomeScreen();
            settingPlayerOneLabel.Show();
            settingPlayerTwoLabel.Show();
            settingEngageLabel.Show();
            settingPlayerOneUpLabel.Show();
            settingPlayerOneDownLabel.Show();
            settingPlayerTwoUpLabel.Show();
            settingPlayerTwoDownLabel.Show();
            pauseLabel.Show();
            settingPlayerOneUpLabel.Text = "UP : " + this.p1Up.ToString().ToUpper();
            settingPlayerOneDownLabel.Text = "DOWN : " + this.p1Down.ToString().ToUpper();
            settingPlayerTwoDownLabel.Text = "UP : " + this.p2Up.ToString().ToUpper();
            settingPlayerTwoUpLabel.Text = "DOWN : " + this.p2Down.ToString().ToUpper();
            settingBackLabel.Show();
            if (this.Sound == true)
            {
                pictureBox3.Show();
            }
            else
            {
                pictureBox4.Show();
            }

        }
        private void hideSettingScreen()
        {
            pauseLabel.Hide();
            settingPlayerOneLabel.Hide();
            settingPlayerTwoLabel.Hide();
            settingEngageLabel.Hide();
            settingPlayerOneUpLabel.Hide();
            settingPlayerOneDownLabel.Hide();
            settingPlayerTwoUpLabel.Hide();
            settingPlayerTwoDownLabel.Hide();
            settingBackLabel.Hide();
            pictureBox3.Hide();
            pictureBox4.Hide();
        }

        private void showPauseScreen()
        {
            this.game.cleanScore();
            this.resumeLabel.Show();
            this.gameRunning = false;
            this.showSettingScreen();
            this.settingBackLabel.Hide();
            this.exitLabel.Show();

        }

        private void hidePauseScreen()
        {
            this.gameRunning = true;
            this.resumeLabel.Hide();
            this.hideSettingScreen();
            this.exitLabel.Hide();
        }


       

        public void ShowWinningScreen(int winner)
        {

            moveWinningLabel();
            this.gameRunning = false;
            this.winningLabel.Text = String.Format("PLAYER {0} WON \r\n (PRESS ENTER)", winner);
            this.winningLabel.Show();
            Timer t_anim = new Timer();
            t_anim.Interval = 1000;
            t_anim.Tick += t_anim_Tick;
            t_anim.Start();
            this.waitForEnter = true;
        }

        public void HideWinningScreen() {
            this.winningLabel.Hide();
            this.showHomeScreen();
            this.waitForEnter = false;
        }

        private void t_anim_Tick(object sender, EventArgs e)
        {
            moveWinningLabel();
        }

        private void moveWinningLabel()
        {
            Random rnd = new Random();
            int x = rnd.Next(0, this.Width - 460);
            int y = rnd.Next(0, this.Height - 150);
            this.winningLabel.Location = new Point(x, y);
        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.pictureBox4.Hide();
            this.pictureBox3.Show();
            this.Sound = true;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.pictureBox4.Show();
            this.pictureBox3.Hide();
            this.Sound = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (this.p1DownPressed == true && this.p1UpPressed == true && this.p2UpPressed == true && this.p2DownPressed == true)
            {
                this.p1UpPressed = false;
                this.settingPlayerOneUpLabel.Text = "UP : ???";
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (this.p1DownPressed == true && this.p1UpPressed == true && this.p2UpPressed == true && this.p2DownPressed == true)
            {
                this.p1DownPressed = false;
                this.settingPlayerOneDownLabel.Text = "DOWN : ???";
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (this.p1DownPressed == true && this.p1UpPressed == true && this.p2UpPressed == true && this.p2DownPressed == true)
            {
                this.p2UpPressed = false;
                this.settingPlayerTwoDownLabel.Text = "UP : ???";
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (this.p1DownPressed == true && this.p1UpPressed == true && this.p2UpPressed == true && this.p2DownPressed == true)
            {
                this.p2DownPressed = false;
                this.settingPlayerTwoDownLabel.Text = "DOWN : ???";
            }
        }

        private void resumeLabel_Click(object sender, EventArgs e)
        {
            if (this.p1DownPressed == true && this.p1UpPressed == true && this.p2UpPressed == true && this.p2DownPressed == true)
            {
                this.hidePauseScreen();
            }
        }


        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_KEYDOWN)
            {
                Keys k = (Keys)m.WParam;
                if (gameRunning)
                {
                    if (k == p1Up)
                    {
                        this.game.p1UpPressed = true;
                    }
                    if (k == p1Down)
                    {
                        this.game.p1DownPressed = true;
                    }
                    if (k == p2Up)
                    {
                        this.game.p2UpPressed = true;
                    }
                    if (k == p2Down)
                    {
                        this.game.p2DownPressed = true;
                    }
                    if (k == Keys.Escape)
                    {
                        this.showPauseScreen();
                    }

                }
            }

            if (m.Msg == WM_KEYUP)
            {
                Keys k = (Keys)m.WParam;
                if (gameRunning)
                {
                    if (k == p1Up)
                    {
                        this.game.p1UpPressed = false;
                    }
                    if (k == p1Down)
                    {
                        this.game.p1DownPressed = false;
                    }
                    if (k == p2Up)
                    {
                        this.game.p2UpPressed = false;
                    }
                    if (k == p2Down)
                    {
                        this.game.p2DownPressed = false;
                    }
                }
                try
                {
                    if (this.game.gamePaused)
                    {
                        if (k == Keys.Space)
                        {
                            this.game.unPauseGame();
                        }
                    }
                }
                catch
                {
                    //Nothing to do no game started
                }
                if (this.p1UpPressed == false)
                {
                    if (k != Keys.Space && k != Keys.Escape && k != this.p1Down && k != p2Up && k != p2Down && k != Keys.Enter)
                    {
                        this.p1Up = k;
                        this.settingPlayerOneUpLabel.Text = "UP : " + k.ToString().ToUpper();
                        this.p1UpPressed = true;
                    }
                }
                if (this.p1DownPressed == false)
                {
                    if (k != Keys.Space && k != Keys.Escape && k != this.p1Up && k != p2Up && k != p2Down && k != Keys.Enter)
                    {
                        this.p1Down = k;
                        this.settingPlayerOneDownLabel.Text = "DOWN : " + k.ToString().ToUpper();
                        this.p1DownPressed = true;
                    }
                }
                if (this.p2UpPressed == false)
                {
                    if (k != Keys.Space && k != Keys.Escape && k != this.p1Down && k != p1Up && k != p2Down && k != Keys.Enter)
                    {
                        this.p2Up = k;
                        this.settingPlayerTwoUpLabel.Text = "UP : " + k.ToString().ToUpper();
                        this.p2UpPressed = true;
                    }
                }
                if (this.p2DownPressed == false)
                {
                    if (k != Keys.Space && k != Keys.Escape && k != this.p1Down && k != p2Up && k != p1Up && k != Keys.Enter)
                    {
                        this.p2Down = k;
                        this.settingPlayerTwoDownLabel.Text = "DOWN : " + k.ToString().ToUpper();
                        this.p2DownPressed = true;
                    }
                }

                if (this.waitForEnter) {
                    if (k == Keys.Enter) {
                        this.HideWinningScreen();
                    }
                }
            }

            return false;
        }



    }
}
