using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong
{
    class Player
    {
        const int speed = 15;
        public const int paddleWidth = 20;
        public const int paddleHeight = 80;
        public int windowSizeX { get; set; }
        public int windowSizeY { get; set; }
        public Graphics g { get; set; }
        public Point ballPosition { get; set; }
        public Boolean isHuman { get; set; }
        public int posX { get; set; }
        public int posY { get; set; }
        public Rectangle paddle { get; set; }
        public Player(Graphics g,Boolean b, int playerNb, int windowX,int windowY)
        {
            this.g = g;
            this.windowSizeX = windowX;
            this.windowSizeY = windowY;
            this.isHuman = b;
            if (playerNb == 1)
            {
                this.posX = 20;
            }
            else {
                this.posX = this.windowSizeX - (paddleWidth + 20);
            }
            this.posY = this.windowSizeY/2 - paddleHeight/2;
            Paddle();
        }

        private void Paddle()
        {
            Pen pen = new Pen(Color.White, 2);
            this.paddle = new Rectangle(posX, posY, paddleWidth, paddleHeight);
            Brush brush = new SolidBrush(Color.White);
            this.g.DrawRectangle(pen, this.paddle);
            this.g.FillRectangle(brush, this.paddle);
            pen.Dispose();
        }


      
        public void move(Dirrection dir)
        {
            this.Clean();
            int move;
            if (dir == Dirrection.Up) { 
                move = -1*speed;
            }else{
                move = speed;
            }
            if (this.posY + move >= 0 && this.posY + Player.paddleHeight + move < this.windowSizeY)
            {
                this.posY += move;
            }
            
            this.Paddle();
            //this.paddle.Location = new Point(this.posX, this.posY + Move);

            
        }

        public void ResetPos()
        {
            this.Clean();
            this.posY = this.windowSizeY/2 - paddleHeight/2;
            this.Paddle();
            //this.paddle.Location = new Point(this.posX, this.posY + Move);


        }

        public void refresh() {
            this.Paddle();
        }

        public void Clean() {
            Pen pen = new Pen(Color.Black, 2);
            Rectangle r = new Rectangle(posX, posY,Player.paddleWidth,Player.paddleHeight);
            Brush brush = new SolidBrush(Color.Black);
            this.g.DrawRectangle(pen, r);
            this.g.FillRectangle(brush, r);
        }
    }
}
