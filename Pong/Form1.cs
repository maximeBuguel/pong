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

        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        const int refreshTime = 16;
        public Keys PlayerOneUp { get; set; }
        public Keys PlayerOneDown { get; set; }
        public Keys PlayerTwoUp { get; set; }
        public Keys PlayerTwoDown { get; set; }
        public Boolean GameRunning { get; set; }
        public Boolean Sound { get; set; }
        public PrivateFontCollection Font8Bit { get; set; }
        public Boolean PlayerOneUpPressed { get; set; }

        public Boolean PlayerOneDownPressed { get; set; }

        public Boolean PlayerTwoUpPressed { get; set; }

        public Boolean PlayerTwoDownPressed { get; set; }
        public Keys Keyp { get; set; }
        public Boolean WaitForEnter { get; set; }
        Game game { get; set; }
        public Timer t { get; set; }
        public Form1()
        {
            String path = Directory.GetCurrentDirectory() + "\\Resources\\8-BIT WONDER.TTF";
            this.Font8Bit = new PrivateFontCollection();
            this.Font8Bit.AddFontFile(path);
            InitializeComponent();
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            this.WaitForEnter = false;
            this.PlayerOneUpPressed = true;
            this.PlayerOneDownPressed = true;
            this.PlayerTwoUpPressed = true;
            this.PlayerTwoDownPressed = true;
            Application.AddMessageFilter(this);
            this.PlayerOneUp = Keys.Up;
            this.PlayerOneDown = Keys.Down;
            this.PlayerTwoUp = Keys.Z;
            this.PlayerTwoDown = Keys.S;
            this.t = new Timer();
            this.t.Interval = refreshTime;
            this.t.Tick += t_Tick;
            this.t.Start();
            timer1.Interval = 4500;
            timer1.Start();
            this.GameRunning = false;
            this.FormBorderStyle = (FormBorderStyle)BorderStyle.Fixed3D;
            this.Sound = true;
            Font myFont = new Font(this.Font8Bit.Families[0], 40, FontStyle.Regular);
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
            if (GameRunning)
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
            if (this.GameRunning)
            {
                this.game.Update();
            }
            //Invalidate();
        }

        private void onePlayerLabel_Click(object sender, EventArgs e)
        {

            this.HideHomeScreen();
            Graphics g = this.CreateGraphics();
            Initialize(g, 1);
            this.GameRunning = true;
            this.game.PauseGame();

        }

        private void twoPlayerLabel_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            HideHomeScreen();
            Initialize(g, 2);
            this.GameRunning = true;
        }


        private void exitLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitLabel_Click_1(object sender, EventArgs e)
        {
            ShowSettingScreen();
        }

        private void settingBackLabel_Click(object sender, EventArgs e)
        {
            if (this.PlayerOneDownPressed == true && this.PlayerOneUpPressed == true && this.PlayerTwoUpPressed == true && this.PlayerTwoDownPressed == true)
            {
                ShowHomeScreen();
            }
        }



        private void ShowHomeScreen()
        {
            onePlayerLabel.Show();
            twoPlayerLabel.Show();
            settingLabel.Show();
            exitLabel.Show();
            HideSettingScreen();
        }

        private void HideHomeScreen()
        {
            onePlayerLabel.Hide();
            twoPlayerLabel.Hide();
            settingLabel.Hide();
            exitLabel.Hide();
        }


        private void ShowSettingScreen()
        {
            HideHomeScreen();
            settingPlayerOneLabel.Show();
            settingPlayerTwoLabel.Show();
            settingEngageLabel.Show();
            settingPlayerOneUpLabel.Show();
            settingPlayerOneDownLabel.Show();
            settingPlayerTwoUpLabel.Show();
            settingPlayerTwoDownLabel.Show();
            pauseLabel.Show();
            settingPlayerOneUpLabel.Text = "UP : " + this.PlayerOneUp.ToString().ToUpper();
            settingPlayerOneDownLabel.Text = "DOWN : " + this.PlayerOneDown.ToString().ToUpper();
            settingPlayerTwoUpLabel.Text = "UP : " + this.PlayerTwoUp.ToString().ToUpper();
            settingPlayerTwoDownLabel.Text = "DOWN : " + this.PlayerTwoDown.ToString().ToUpper();
            settingBackLabel.Show();
            if (this.Sound == true)
            {
                soundPictureBox.Show();
            }
            else
            {
                soundMutePictureBox.Show();
            }

        }
        private void HideSettingScreen()
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
            soundPictureBox.Hide();
            soundMutePictureBox.Hide();
        }

        private void ShowPauseScreen()
        {
            this.game.cleanScore();
            this.resumeLabel.Show();
            this.GameRunning = false;
            this.ShowSettingScreen();
            this.settingBackLabel.Hide();
            this.exitLabel.Show();

        }

        private void HidePauseScreen()
        {
            this.GameRunning = true;
            this.resumeLabel.Hide();
            this.HideSettingScreen();
            this.exitLabel.Hide();
        }




        public void ShowWinningScreen(int winner)
        {

            MoveWinningLabel();
            this.GameRunning = false;
            this.winningLabel.Text = String.Format("PLAYER {0} WON \r\n (PRESS ENTER)", winner);
            this.winningLabel.Show();
            Timer t_anim = new Timer();
            t_anim.Interval = 1000;
            t_anim.Tick += t_anim_Tick;
            t_anim.Start();
            this.WaitForEnter = true;
        }

        public void HideWinningScreen()
        {
            this.winningLabel.Hide();
            this.ShowHomeScreen();
            this.WaitForEnter = false;
        }

        private void t_anim_Tick(object sender, EventArgs e)
        {
            MoveWinningLabel();
        }

        private void MoveWinningLabel()
        {
            Random rnd = new Random();
            int x = rnd.Next(0, this.Width - 460);
            int y = rnd.Next(0, this.Height - 150);
            this.winningLabel.Location = new Point(x, y);
        }


        private void soundMutePictureBox_Click(object sender, EventArgs e)
        {
            this.soundMutePictureBox.Hide();
            this.soundPictureBox.Show();
            this.Sound = true;

        }

        private void soundPictureBox_Click(object sender, EventArgs e)
        {
            this.soundMutePictureBox.Show();
            this.soundPictureBox.Hide();
            this.Sound = false;
        }

        private void settingPlayerOneUpLabel_Click(object sender, EventArgs e)
        {
            if (this.PlayerOneDownPressed == true && this.PlayerOneUpPressed == true && this.PlayerTwoUpPressed == true && this.PlayerTwoDownPressed == true)
            {
                this.PlayerOneUpPressed = false;
                this.settingPlayerOneUpLabel.Text = "UP : ???";
            }
        }

        private void settingPlayerOneDownLabel_Click(object sender, EventArgs e)
        {
            if (this.PlayerOneDownPressed == true && this.PlayerOneUpPressed == true && this.PlayerTwoUpPressed == true && this.PlayerTwoDownPressed == true)
            {
                this.PlayerOneDownPressed = false;
                this.settingPlayerOneDownLabel.Text = "DOWN : ???";
            }
        }

        private void settingPlayerTwoDownLabel_Click(object sender, EventArgs e)
        {
            if (this.PlayerOneDownPressed == true && this.PlayerOneUpPressed == true && this.PlayerTwoUpPressed == true && this.PlayerTwoDownPressed == true)
            {
                this.PlayerTwoDownPressed = false;
                this.settingPlayerTwoDownLabel.Text = "DOWN : ???";
            }
        }

        private void settingPlayerTwoUpLabel_Click(object sender, EventArgs e)
        {
            if (this.PlayerOneDownPressed == true && this.PlayerOneUpPressed == true && this.PlayerTwoUpPressed == true && this.PlayerTwoDownPressed == true)
            {
                this.PlayerTwoUpPressed = false;
                this.settingPlayerTwoUpLabel.Text = "UP : ???";
            }
        }

        private void resumeLabel_Click(object sender, EventArgs e)
        {
            if (this.PlayerOneDownPressed == true && this.PlayerOneUpPressed == true && this.PlayerTwoUpPressed == true && this.PlayerTwoDownPressed == true)
            {
                this.HidePauseScreen();
            }
        }


        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_KEYDOWN)
            {
                Keys k = (Keys)m.WParam;
                if (GameRunning)
                {
                    if (k == PlayerOneUp)
                    {
                        this.game.PlayerOneUpPressed = true;
                    }
                    if (k == PlayerOneDown)
                    {
                        this.game.PlayerOneDownPressed = true;
                    }
                    if (k == PlayerTwoUp)
                    {
                        this.game.PlayerTwoUpPressed = true;
                    }
                    if (k == PlayerTwoDown)
                    {
                        this.game.PlayerTwoDownPressed = true;
                    }
                    if (k == Keys.Escape)
                    {
                        this.ShowPauseScreen();
                    }

                }
            }

            if (m.Msg == WM_KEYUP)
            {
                Keys k = (Keys)m.WParam;
                if (GameRunning)
                {
                    if (k == PlayerOneUp)
                    {
                        this.game.PlayerOneUpPressed = false;
                    }
                    if (k == PlayerOneDown)
                    {
                        this.game.PlayerOneDownPressed = false;
                    }
                    if (k == PlayerTwoUp)
                    {
                        this.game.PlayerTwoUpPressed = false;
                    }
                    if (k == PlayerTwoDown)
                    {
                        this.game.PlayerTwoDownPressed = false;
                    }
                }
                try
                {
                    if (this.game.GamePaused)
                    {
                        if (k == Keys.Space)
                        {
                            this.game.UnPauseGame();
                        }
                    }
                }
                catch
                {
                    //Nothing to do no game started
                }
                if (this.PlayerOneUpPressed == false)
                {
                    if (k != Keys.Space && k != Keys.Escape && k != this.PlayerOneDown && k != PlayerTwoUp && k != PlayerTwoDown && k != Keys.Enter)
                    {
                        this.PlayerOneUp = k;
                        this.settingPlayerOneUpLabel.Text = "UP : " + k.ToString().ToUpper();
                        this.PlayerOneUpPressed = true;
                    }
                }
                if (this.PlayerOneDownPressed == false)
                {
                    if (k != Keys.Space && k != Keys.Escape && k != this.PlayerOneUp && k != PlayerTwoUp && k != PlayerTwoDown && k != Keys.Enter)
                    {
                        this.PlayerOneDown = k;
                        this.settingPlayerOneDownLabel.Text = "DOWN : " + k.ToString().ToUpper();
                        this.PlayerOneDownPressed = true;
                    }
                }
                if (this.PlayerTwoUpPressed == false)
                {
                    if (k != Keys.Space && k != Keys.Escape && k != this.PlayerOneDown && k != PlayerOneUp && k != PlayerTwoDown && k != Keys.Enter)
                    {
                        this.PlayerTwoUp = k;
                        this.settingPlayerTwoUpLabel.Text = "UP : " + k.ToString().ToUpper();
                        this.PlayerTwoUpPressed = true;
                    }
                }
                if (this.PlayerTwoDownPressed == false)
                {
                    if (k != Keys.Space && k != Keys.Escape && k != this.PlayerOneDown && k != PlayerTwoUp && k != PlayerOneUp && k != Keys.Enter)
                    {
                        this.PlayerTwoDown = k;
                        this.settingPlayerTwoDownLabel.Text = "DOWN : " + k.ToString().ToUpper();
                        this.PlayerTwoDownPressed = true;
                    }
                }

                if (this.WaitForEnter)
                {
                    if (k == Keys.Enter)
                    {
                        this.HideWinningScreen();
                    }
                }
            }

            return false;
        }



    }
}
