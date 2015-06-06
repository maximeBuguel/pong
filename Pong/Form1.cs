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
        const int refreshTime = 16;
        public Keys p1Up { get; set; }
        public Keys p1Down { get; set; }
        public Keys p2Up { get; set; }
        public Keys p2Down { get; set; }
        public Boolean gameStarted { get; set; }
        public Boolean Sound { get; set; }
        public PrivateFontCollection font { get; set; }
        public Boolean p1UpPressed { get; set; }

        public Boolean p1DownPressed { get; set; }

        public Boolean p2UpPressed { get; set; }

        public Boolean p2DownPressed { get; set; }
        public Keys Keyp { get; set; }
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
            this.gameStarted = false;
            this.FormBorderStyle = (FormBorderStyle) BorderStyle.Fixed3D;
            this.Sound = true;
            Font myFont = new Font(this.font.Families[0], 40, FontStyle.Regular);
            this.linkLabel5.Font = myFont;
            this.linkLabel1.Font = myFont;
            this.linkLabel2.Font = myFont;
            this.linkLabel3.Font = myFont;
            this.linkLabel4.Font = myFont;
            this.label1.Font = myFont;
            this.label2.Font = myFont;
            this.label3.Font = myFont;
            this.label4.Font = myFont;
            this.label5.Font = myFont;
            this.label6.Font = myFont;
            this.label7.Font = myFont;
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
            if (this.p1DownPressed == true && this.p1UpPressed == true && this.p2UpPressed == true && this.p2DownPressed == true)
            {
                showHomeScreen();
            }
            
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
            label4.Show();
            label5.Show();
            label6.Show();
            label7.Show();

            label4.Text = "UP : "+ this.p1Up.ToString();
            label5.Text = "DOWN : " + this.p1Down.ToString();
            label7.Text = "UP : " + this.p2Up.ToString();
            label6.Text = "DOWN : " + this.p2Down.ToString();
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
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            linkLabel5.Hide();
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
                catch { 
                    //Nothing to do no game started
                }
                if (this.p1UpPressed == false) {
                    if (k != Keys.Space && k != Keys.Escape && k != this.p1Down && k != p2Up && k != p2Down) {
                        Console.WriteLine("Key");
                        this.p1Up = k;
                        this.label4.Text = "UP : " + k.ToString().ToUpper();
                        this.p1UpPressed = true;
                    }
                }
                if (this.p1DownPressed == false)
                {
                    if (k != Keys.Space && k != Keys.Escape && k != this.p1Up && k != p2Up && k != p2Down)
                    {
                        Console.WriteLine("Key");
                        this.p1Down = k;
                        this.label5.Text = "DOWN : " + k.ToString().ToUpper();
                        this.p1DownPressed = true;
                    }
                }
                if (this.p2UpPressed == false)
                {
                    if (k != Keys.Space && k != Keys.Escape && k != this.p1Down && k != p1Up && k != p2Down)
                    {
                        Console.WriteLine("Key");
                        this.p2Up = k;
                        this.label6.Text = "UP : " + k.ToString().ToUpper();
                        this.p2UpPressed = true;
                    }
                }
                if (this.p2DownPressed == false)
                {
                    if (k != Keys.Space && k != Keys.Escape && k != this.p1Down && k != p2Up && k != p1Up)
                    {
                        Console.WriteLine("Key");
                        this.p2Down = k;
                        this.label7.Text = "DOWN : " + k.ToString().ToUpper();
                        this.p2DownPressed = true;
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

        private void label4_Click(object sender, EventArgs e)
        {
            if (this.p1DownPressed == true && this.p1UpPressed == true && this.p2UpPressed == true && this.p2DownPressed == true)
            {
                this.p1UpPressed = false;
                this.label4.Text = "UP : ???";
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (this.p1DownPressed == true && this.p1UpPressed == true && this.p2UpPressed == true && this.p2DownPressed == true)
            {
                this.p1DownPressed = false;
                this.label5.Text = "DOWN : ???";
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (this.p1DownPressed == true && this.p1UpPressed == true && this.p2UpPressed == true && this.p2DownPressed == true)
            {
                this.p2UpPressed = false;
                this.label7.Text = "UP : ???";
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (this.p1DownPressed == true && this.p1UpPressed == true && this.p2UpPressed == true && this.p2DownPressed == true)
            {
                this.p2DownPressed = false;
                this.label7.Text = "DOWN : ???";
            }
        }


     
    }
}
