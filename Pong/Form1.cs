using System;
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
        const int refreshTime = 20;
        public Keys p1Up { get; set; }
        public Keys p1Down { get; set; }
        public Keys p2Up { get; set; }
        public Keys p2Down { get; set; }
        public Boolean gameStarted { get; set; }
        public Boolean Sound { get; set; }
        public PrivateFontCollection font { get; set; }
        public Form1()
        {
            String path = Directory.GetCurrentDirectory() + "\\8-BIT WONDER.TTF";
            this.font = new PrivateFontCollection();
            this.font.AddFontFile(path);
            InitializeComponent();
        }

        Game game { get; set; }
        public Timer t { get; set; }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.hideHomeScreen();
            Graphics g = this.CreateGraphics();
            Initialize(g, 1);
            this.gameStarted = true;
            this.game.pauseGame();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            Application.AddMessageFilter(this);
            this.p1Up = Keys.Up;
            this.p1Down = Keys.Down;
            this.p2Up = Keys.A;
            this.p2Down = Keys.Q;
            this.t = new Timer();
            this.t.Interval = refreshTime;
            this.t.Tick += t_Tick;
            this.t.Start();
            timer1.Interval = 4500;
            timer1.Start();
            this.gameStarted = false;
            this.FormBorderStyle = (FormBorderStyle) BorderStyle.Fixed3D;
            pictureBox1.Hide();
            pictureBox2.Hide();
            this.Sound = true;
        }
        private void Initialize(Graphics g, int nbPlayer)
        {

            int contentWidth = this.ClientRectangle.Width;
            int contentHeight = this.ClientRectangle.Height;
            this.game = new Game(g, nbPlayer, contentWidth, contentHeight, this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (gameStarted)
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
            if (this.gameStarted)
            {
                this.game.Update();
            }
            //Invalidate();
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            hideHomeScreen();
            Initialize(g, 2);
            this.gameStarted = true;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            showSettingScreen();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            showHomeScreen();
        }

        private void showHomeScreen() {
            linkLabel1.Show();
            linkLabel2.Show();
            linkLabel3.Show();
            linkLabel4.Show();
            hideSettingScreen();
        }

        private void hideHomeScreen() {
            linkLabel1.Hide();
            linkLabel2.Hide();
            linkLabel3.Hide();
            linkLabel4.Hide();
        }

        private void showSettingScreen() {
            hideHomeScreen();
            label1.Show();
            label2.Show();
            label3.Show();
            pictureBox1.Show();
            pictureBox2.Show();
            linkLabel5.Show();
            if (this.Sound == true)
            {
                pictureBox3.Show();
            }
            else {
                pictureBox4.Show();
            }

        }
        private void hideSettingScreen()
        {
            label1.Hide();
            label2.Hide();
            label3.Hide();
            linkLabel5.Hide();
            pictureBox1.Hide();
            pictureBox2.Hide();
            pictureBox3.Hide();
            pictureBox4.Hide();
        }

        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_KEYDOWN)
            {
                Keys k = (Keys)m.WParam;
                if (gameStarted)
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
                }
            }

            if (m.Msg == WM_KEYUP)
            {
                Keys k = (Keys)m.WParam;
                if (gameStarted)
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
                if (this.game.gamePaused) {
                    if (k == Keys.Space)
                    {
                        this.game.unPauseGame();
                    }
                }
            }

            return false;
        }

        public void Restart()
        {
            this.gameStarted = false;
            this.showHomeScreen();
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

     
    }
}
