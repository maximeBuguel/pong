using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong
{
    class Game
    {
        const int IASensitivity = 0;
        const int PointToWin = 10;
        const int BallSize = 10;
        public int WindowSizeX { get; set; }
        public int WindowSizeY { get; set; }
        public Graphics GraphicView { get; set; }
        public int NbPlayer { get; set; }
        public int ScoreP1 { get; set; }
        public int ScoreP2 { get; set; }
        public Point BallPosition { get; set; }
        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }
        public int XSpeed { get; set; }
        public int YSpeed { get; set; }
        public Rectangle Ball { get; set; }
        public Boolean PlayerOneUpPressed { get; set; }
        public Boolean PlayerOneDownPressed { get; set; }
        public Boolean PlayerTwoUpPressed { get; set; }
        public Boolean PlayerTwoDownPressed { get; set; }
        public Form1 FormParent { get; set; }
        public Boolean GameFinished { get; set; }
        public SoundPlayer MyPlayer1 { get; set; }
        public SoundPlayer MyPlayer2 { get; set; }
        public Boolean GamePaused { get; set; }
        
        public Game(Graphics g, int nbPlayer, int width, int height, Form1 main)
        {

            this.FormParent = main;
            this.GamePaused = false;
            this.MyPlayer1 = new SoundPlayer(global::Pong.Properties.Resources.Beep1);
            this.MyPlayer1.Load();
            this.MyPlayer2 = new SoundPlayer(global::Pong.Properties.Resources.Beep2);
            this.MyPlayer2.Load();
            this.GameFinished = false;
            this.WindowSizeX = width;
            this.WindowSizeY = height;
            this.GraphicView = g;
            this.NbPlayer = nbPlayer;
            this.ScoreP1 = 0;
            this.ScoreP2 = 0;
            this.BallPosition = new Point(WindowSizeX / 2 - BallSize /2 , WindowSizeY / 2 - BallSize/2);
            Map();
            Score();
            CreateBall();
            this.PlayerOne = new Player(g, true, 1, this.WindowSizeX, this.WindowSizeY);
            if (nbPlayer == 2)
            {
                this.PlayerTwo = new Player(g, true, 2, this.WindowSizeX, this.WindowSizeY);
            }
            else
            {
                this.PlayerTwo = new Player(g, false, 2, this.WindowSizeX, this.WindowSizeY);
            }
            this.XSpeed = 5;
            this.YSpeed = 5;
        }

        private void CreateBall()
        {
            Pen pen = new Pen(Color.White, 2);
            this.Ball = new Rectangle(BallPosition.X , BallPosition.Y , BallSize, BallSize);
            Brush brush = new SolidBrush(Color.White);
            this.GraphicView.DrawRectangle(pen, Ball);
            this.GraphicView.FillRectangle(brush, Ball);
            pen.Dispose();
        }

        private void Map()
        {
            Pen pen = new Pen(Color.White, 2);
            float[] dashValues = { 10, 10 };
            pen.DashPattern = dashValues;
            this.GraphicView.DrawLine(pen, new Point(WindowSizeX / 2, 0), new Point(WindowSizeX / 2, WindowSizeY));
            pen.Dispose();

        }

        private void Score()
        {
            Font myFont = new Font(this.FormParent.Font8Bit.Families[0], 40, FontStyle.Regular);
            Brush myBrush = new SolidBrush(System.Drawing.Color.White);
            this.GraphicView.DrawString(ScoreP1.ToString(), myFont, myBrush, (WindowSizeX / 2) - WindowSizeX / 4, 40);
            this.GraphicView.DrawString(ScoreP2.ToString(), myFont, myBrush, (WindowSizeX / 2) + WindowSizeX / 4 - 40, 40);
        }

        public void Refresh()
        {
            Map();
            Score();
            CreateBall();
            PlayerOne.refresh();
            PlayerTwo.refresh();
        }

        public void Update()
        {

            Move(PlayerOne, 1);
            Move(PlayerTwo, 2);
            MoveBall();
            if (!this.GameFinished)
            {
                Refresh();
            }

        }

        public void Move(Player p, int player)
        {
            if (p.isHuman == false)
            {
                if (Ball.Y + BallSize / 2 < p.posY + Player.paddleHeight / 2 + IASensitivity)
                {
                    p.move(Dirrection.Up);
                }
                if (Ball.Y + BallSize / 2 > p.posY + Player.paddleHeight / 2 + IASensitivity)
                {
                    p.move(Dirrection.Down);
                }
            }
            else
            {
                if (player == 1)
                {
                    if (PlayerOneUpPressed == true)
                    {
                        p.move(Dirrection.Up);
                    }
                    if (PlayerOneDownPressed == true)
                    {
                        p.move(Dirrection.Down);
                    }
                }
                if (player == 2)
                {
                    if (PlayerTwoUpPressed == true)
                    {
                        p.move(Dirrection.Up);
                    }
                    if (PlayerTwoDownPressed == true)
                    {
                        p.move(Dirrection.Down);
                    }
                }
            }
        }
        public void MoveBall()
        {

            Boolean point = pointMarked();
            if (!point)
            {

                if (this.Ball.Y + BallSize >= WindowSizeY || this.Ball.Y <= 0)
                {
                    if (this.FormParent.Sound == true)
                    {
                        this.MyPlayer1.Play();
                    }
                    this.YSpeed -= 2 * this.YSpeed;
                }

                CleanBall();
                this.BallPosition = new Point(this.BallPosition.X + XSpeed, this.BallPosition.Y + YSpeed);
            }
            else
            {
                if ((this.BallPosition.X < this.WindowSizeX / 2) && ballIntersecPlayer(PlayerOne))
                {
                    if (this.FormParent.Sound == true)
                    {
                        this.MyPlayer2.Play();
                    }
                    this.XSpeed -= 2 * this.XSpeed;
                    int posX = this.BallPosition.X + XSpeed;
                    if (this.BallPosition.X + XSpeed < PlayerOne.posX+ Player.paddleWidth) {
                        posX = PlayerOne.posX + Player.paddleWidth;
                    }
                    CleanBall();
                    this.BallPosition = new Point(posX, this.BallPosition.Y + YSpeed);
                    this.IncreaseAngle(PlayerOne);
                }
                else if (this.BallPosition.X > this.WindowSizeX / 2 && ballIntersecPlayer(PlayerTwo))
                {
                    if (this.FormParent.Sound == true)
                    {
                        this.MyPlayer2.Play();
                    }
                    this.XSpeed -= 2 * this.XSpeed;
                    
                    int posX = this.BallPosition.X + XSpeed;
                    if (this.BallPosition.X + XSpeed + BallSize > PlayerTwo.posX)
                    {
                        posX = PlayerTwo.posX - BallSize;
                    }
                    CleanBall();
                    this.BallPosition = new Point(posX, this.BallPosition.Y + YSpeed);
                    this.IncreaseAngle(PlayerTwo);
                }
                else
                {
                    IncScore();
                }
            }

        }

        private void IncreaseAngle(Player p)
        {
            int playerCenter = p.posY + Player.paddleHeight/2;
            int ballCenter = BallPosition.Y + BallSize/2;
            int distCenterToCenter = Math.Abs(playerCenter - ballCenter);
            if (distCenterToCenter > Player.paddleHeight / 4) {
                this.IncY(2);
                this.IncX(3);
            }
            
            
            
        }

        public void IncScore()
        {
            this.CleanBall();
            if (this.BallPosition.X < this.WindowSizeX / 2)
            {
                ScoreP2 += 1;
                this.XSpeed = -5;
            }
            else
            {
                ScoreP1 += 1;
                this.XSpeed = 5;

            }
            if (ScoreP1 == PointToWin)
            {
                this.GameFinished = true;
                this.cleanScore();
                this.PlayerOne.Clean();
                this.PlayerTwo.Clean();
                FormParent.ShowWinningScreen(1);
            }
            else if (ScoreP2 == PointToWin)
            {
                this.GameFinished = true;
                this.cleanScore();
                this.PlayerOne.Clean();
                this.PlayerTwo.Clean();
                FormParent.ShowWinningScreen(2);
            }
            else
            {

                this.cleanScore();
                this.YSpeed = 5;
                this.BallPosition = new Point(WindowSizeX / 2 - BallSize / 2, WindowSizeY / 2 - BallSize / 2);
                this.PlayerOne.ResetPos();
                this.PlayerTwo.ResetPos();
                this.PlayerOneUpPressed = false;
                this.PlayerOneDownPressed = false;
                this.PlayerTwoUpPressed = false;
                this.PlayerTwoDownPressed = false;
                this.PauseGame();
            }
        }

        public void PauseGame() {
            this.GamePaused = true;
            this.FormParent.GameRunning = false;

        }

        public void UnPauseGame()
        {
            this.GamePaused = false;
            this.FormParent.GameRunning = true;
        }

        public void CleanBall()
        {
            Pen pen = new Pen(Color.Black, 2);
            Rectangle clean = new Rectangle(BallPosition.X , BallPosition.Y , BallSize, BallSize);
            Brush brush = new SolidBrush(Color.Black);
            this.GraphicView.DrawRectangle(pen, clean);
            this.GraphicView.FillRectangle(brush, clean);
            pen.Dispose();
        }

        public void cleanScore()
        {
            Pen pen = new Pen(Color.Black, 2);
            Rectangle clean = new Rectangle(0, 0, this.WindowSizeX, this.WindowSizeY);
            Brush brush = new SolidBrush(Color.Black);
            this.GraphicView.DrawRectangle(pen, clean);
            this.GraphicView.FillRectangle(brush, clean);
            pen.Dispose();
        }

        public Boolean pointMarked()
        {
            Boolean marked = false;
            if (this.BallPosition.X <= (20 + Player.paddleWidth))
            {
                marked = true;
            }

            if (this.BallPosition.X + BallSize >= this.WindowSizeX - (20 + Player.paddleWidth))
            {
                marked = true;
            }
            return marked;
        }

        public Boolean ballIntersecPlayer(Player p)
        {
            Boolean intersect = false;
            Boolean up = this.BallPosition.Y + BallSize >= p.posY;
            Boolean down = this.BallPosition.Y <= p.posY + Player.paddleHeight;
            if (up && down)
            {
                intersect = true;
            }
            return intersect;

        }

        public void incSpeed()
        {
            this.IncX(1);
            this.IncY(1);
        }

        private void IncX(int fact)
        {
            if (this.XSpeed > 0)
            {
                this.XSpeed += 1*fact;
            }
            if (this.XSpeed < 0)
            {
                this.XSpeed -= 1 * fact;
            }

        }

        private void IncY(int fact) {
           if (this.YSpeed > 0)
            {
                this.YSpeed += 1*fact;
            }
            if (this.YSpeed < 0)
            {
                this.YSpeed -= 1*fact;
            }
        }
        private void DecX(int fact)
        {
            if (this.XSpeed > 0)
            {
                this.XSpeed -= 1*fact;
            }
            if (this.XSpeed < 0)
            {
                this.XSpeed += 1*fact;
            }

        }

        private void decY(int fact)
        {
            if (this.YSpeed > 0)
            {
                this.YSpeed -= 1*fact;
            }
            if (this.YSpeed < 0)
            {
                this.YSpeed += 1*fact;
            }
        }
    }
}