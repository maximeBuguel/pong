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
        const int pointForWin = 10;
        const int ballSize = 10;
        public int windowSizeX { get; set; }
        public int windowSizeY { get; set; }
        public Graphics g { get; set; }
        public int nbPlayer { get; set; }
        public int scoreP1 { get; set; }
        public int scoreP2 { get; set; }
        public Point ballPosition { get; set; }
        public Player p1 { get; set; }
        public Player p2 { get; set; }
        public int xSpeed { get; set; }
        public int ySpeed { get; set; }
        public Rectangle ball { get; set; }
        public Boolean p1UpPressed { get; set; }
        public Boolean p1DownPressed { get; set; }
        public Boolean p2UpPressed { get; set; }
        public Boolean p2DownPressed { get; set; }
        public Form1 parent { get; set; }
        public Boolean gameFinished { get; set; }
        public SoundPlayer MyPlayer1 { get; set; }
        public SoundPlayer MyPlayer2 { get; set; }
        public Boolean gamePaused { get; set; }
        
        public Game(Graphics g, int nbPlayer, int width, int height, Form1 main)
        {

            this.parent = main;
            this.gamePaused = false;
            String path = Directory.GetCurrentDirectory()+"\\Beep1.wav";
            this.MyPlayer1 = new SoundPlayer(path);
            String path2 = Directory.GetCurrentDirectory() + "\\Beep2.wav";
            this.MyPlayer2 = new SoundPlayer(path2);
            this.gameFinished = false;
            this.windowSizeX = width;
            this.windowSizeY = height;
            this.g = g;
            this.nbPlayer = nbPlayer;
            this.scoreP1 = 0;
            this.scoreP2 = 0;
            this.ballPosition = new Point(windowSizeX / 2 - ballSize /2 , windowSizeY / 2 - ballSize/2);
            Map();
            Score();
            Ball();
            this.p1 = new Player(g, true, 1, this.windowSizeX, this.windowSizeY);
            if (nbPlayer == 2)
            {
                this.p2 = new Player(g, true, 2, this.windowSizeX, this.windowSizeY);
            }
            else
            {
                this.p2 = new Player(g, false, 2, this.windowSizeX, this.windowSizeY);
            }
            this.xSpeed = 5;
            this.ySpeed = 5;
        }

        private void Ball()
        {
            Pen pen = new Pen(Color.White, 2);
            this.ball = new Rectangle(ballPosition.X , ballPosition.Y , ballSize, ballSize);
            Brush brush = new SolidBrush(Color.White);
            this.g.DrawRectangle(pen, ball);
            this.g.FillRectangle(brush, ball);
            pen.Dispose();
        }

        private void Map()
        {
            Pen pen = new Pen(Color.White, 2);
            float[] dashValues = { 10, 10 };
            pen.DashPattern = dashValues;
            this.g.DrawLine(pen, new Point(windowSizeX / 2, 0), new Point(windowSizeX / 2, windowSizeY));
            pen.Dispose();

        }

        private void Score()
        {
            Font myFont = new Font(this.parent.font.Families[0], 40, FontStyle.Regular);
            Brush myBrush = new SolidBrush(System.Drawing.Color.White);
            this.g.DrawString(scoreP1.ToString(), myFont, myBrush, (windowSizeX / 2) - windowSizeX / 4, 40);
            this.g.DrawString(scoreP2.ToString(), myFont, myBrush, (windowSizeX / 2) + windowSizeX / 4 - 40, 40);
        }

        public void Refresh()
        {
            Map();
            Score();
            Ball();
            p1.refresh();
            p2.refresh();
        }

        public void Update()
        {

            move(p1, 1);
            move(p2, 2);
            MoveBall();
            if (!this.gameFinished)
            {
                Refresh();
            }

        }

        public void move(Player p, int player)
        {
            if (p.isHuman == false)
            {
                if (ball.Y + ballSize / 2 < p.posY + Player.paddleHeight / 2)
                {
                    p.move(Dirrection.Up);
                }
                if (ball.Y + ballSize / 2 > p.posY + Player.paddleHeight / 2)
                {
                    p.move(Dirrection.Down);
                }
            }
            else
            {
                if (player == 1)
                {
                    if (p1UpPressed == true)
                    {
                        p.move(Dirrection.Up);
                    }
                    if (p1DownPressed == true)
                    {
                        p.move(Dirrection.Down);
                    }
                }
                if (player == 2)
                {
                    if (p2UpPressed == true)
                    {
                        p.move(Dirrection.Up);
                    }
                    if (p2DownPressed == true)
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

                if (this.ball.Y + ballSize >= windowSizeY || this.ball.Y <= 0)
                {
                    if (this.parent.Sound == true)
                    {
                        this.MyPlayer1.Play();
                    }
                    this.ySpeed -= 2 * this.ySpeed;
                }

                cleanBall();
                this.ballPosition = new Point(this.ballPosition.X + xSpeed, this.ballPosition.Y + ySpeed);
            }
            else
            {
                if ((this.ballPosition.X < this.windowSizeX / 2) && ballIntersecPlayer(p1))
                {
                    if (this.parent.Sound == true)
                    {
                        this.MyPlayer2.Play();
                    }
                    this.xSpeed -= 2 * this.xSpeed;
                    int posX = this.ballPosition.X + xSpeed;
                    if (this.ballPosition.X + xSpeed < p1.posX+ Player.paddleWidth) {
                        posX = p1.posX + Player.paddleWidth;
                    }
                    cleanBall();
                    this.ballPosition = new Point(posX, this.ballPosition.Y + ySpeed);
                    this.increaseAngle(p1);
                }
                else if (this.ballPosition.X > this.windowSizeX / 2 && ballIntersecPlayer(p2))
                {
                    if (this.parent.Sound == true)
                    {
                        this.MyPlayer2.Play();
                    }
                    this.xSpeed -= 2 * this.xSpeed;
                    
                    int posX = this.ballPosition.X + xSpeed;
                    if (this.ballPosition.X + xSpeed + ballSize > p2.posX)
                    {
                        posX = p2.posX - ballSize;
                    }
                    cleanBall();
                    this.ballPosition = new Point(posX, this.ballPosition.Y + ySpeed);
                    this.increaseAngle(p2);
                }
                else
                {
                    incScore();
                }
            }

        }

        private void increaseAngle(Player p)
        {
            int playerCenter = p.posY + Player.paddleHeight/2;
            int ballCenter = ballPosition.Y + ballSize/2;
            int distCenterToCenter = Math.Abs(playerCenter - ballCenter);
            if (distCenterToCenter > Player.paddleHeight / 4) {
                this.incY(2);
                this.incX(3);
            }
            
            
            
        }

        public void incScore()
        {
            this.cleanBall();
            if (this.ballPosition.X < this.windowSizeX / 2)
            {
                scoreP2 += 1;
                this.xSpeed = -5;
            }
            else
            {
                scoreP1 += 1;
                this.xSpeed = 5;

            }
            if (scoreP1 == pointForWin || scoreP2 == pointForWin)
            {
                this.gameFinished = true;
                this.cleanScore();
                parent.Restart();
            }
            else
            {

                this.cleanScore();
                this.ySpeed = 5;
                this.ballPosition = new Point(windowSizeX / 2 - ballSize / 2, windowSizeY / 2 - ballSize / 2);
                this.p1.ResetPos();
                this.p2.ResetPos();
                this.p1UpPressed = false;
                this.p1DownPressed = false;
                this.p2UpPressed = false;
                this.p2DownPressed = false;
                this.pauseGame();
            }
        }

        public void pauseGame() {
            this.gamePaused = true;
            this.parent.gameStarted = false;

        }

        public void unPauseGame()
        {
            this.gamePaused = false;
            this.parent.gameStarted = true;
        }

        public void cleanBall()
        {
            Pen pen = new Pen(Color.Black, 2);
            Rectangle clean = new Rectangle(ballPosition.X , ballPosition.Y , ballSize, ballSize);
            Brush brush = new SolidBrush(Color.Black);
            this.g.DrawRectangle(pen, clean);
            this.g.FillRectangle(brush, clean);
            pen.Dispose();
        }

        public void cleanScore()
        {
            Pen pen = new Pen(Color.Black, 2);
            Rectangle clean = new Rectangle(0, 0, this.windowSizeX, this.windowSizeY);
            Brush brush = new SolidBrush(Color.Black);
            this.g.DrawRectangle(pen, clean);
            this.g.FillRectangle(brush, clean);
            pen.Dispose();
        }

        public Boolean pointMarked()
        {
            Boolean marked = false;
            if (this.ballPosition.X <= (20 + Player.paddleWidth))
            {
                marked = true;
            }

            if (this.ballPosition.X + ballSize >= this.windowSizeX - (20 + Player.paddleWidth))
            {
                marked = true;
            }
            return marked;
        }

        public Boolean ballIntersecPlayer(Player p)
        {
            Boolean intersect = false;
            Boolean up = this.ballPosition.Y + ballSize >= p.posY;
            Boolean down = this.ballPosition.Y <= p.posY + Player.paddleHeight;
            if (up && down)
            {
                intersect = true;
            }
            return intersect;

        }

        public void incSpeed()
        {
            this.incX(1);
            this.incY(1);
        }

        private void incX(int fact)
        {
            if (this.xSpeed > 0)
            {
                this.xSpeed += 1*fact;
            }
            if (this.xSpeed < 0)
            {
                this.xSpeed -= 1 * fact;
            }

        }

        private void incY(int fact) {
           if (this.ySpeed > 0)
            {
                this.ySpeed += 1*fact;
            }
            if (this.ySpeed < 0)
            {
                this.ySpeed -= 1*fact;
            }
        }
        private void decX(int fact)
        {
            if (this.xSpeed > 0)
            {
                this.xSpeed -= 1*fact;
            }
            if (this.xSpeed < 0)
            {
                this.xSpeed += 1*fact;
            }

        }

        private void decY(int fact)
        {
            if (this.ySpeed > 0)
            {
                this.ySpeed -= 1*fact;
            }
            if (this.ySpeed < 0)
            {
                this.ySpeed += 1*fact;
            }
        }
    }
}