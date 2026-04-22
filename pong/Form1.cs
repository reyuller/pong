namespace pong
{
    public partial class Form1 : Form
    {
        int playerY = 150;
        int AiY = 150;

        int ballX = 200;
        int ballY = 150;

        int ballspeedX = 10;
        int ballspeedY = 10;

        int playerScore = 0;
        int AiScore = 0;
        bool moveUp, moveDown;
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }
        private void UPdateGame(object sender, EventArgs e)
        {
            /*if (moveUp && playerY > 0) playerY -= 6;
            if (moveDown && playerY < this.ClientSize.Height - 800) 
                playerY += 6;

            if (AiY + 40 < ballY) AiY += 2;
            if (AiY + 40 > ballY) AiY -= 2;

            if (AiY < 0) AiY = 0;
            if (AiY > this.ClientSize.Height - 80)
                AiY = this.ClientSize.Height - 80;

            ballX += ballspeedX;
            ballY += ballspeedY;

            if (ballY <= 0  || ballY>=this.ClientSize.Height - 10)
                ballspeedY *= -1;

            Rectangle playerRect = new Rectangle(10, playerY, 10, 80);
            Rectangle ballRect = new Rectangle(ballX, ballY, 10, 10);

            if (playerRect.IntersectsWith(ballRect))
                ballspeedX = -Math.Abs (ballspeedX);

            Rectangle AiRect = new Rectangle(this.ClientSize.Width - 20, AiY, 10, 80);

            if (AiRect.IntersectsWith(ballRect))
                ballspeedX = -Math.Abs (ballspeedX);

            if (ballX < 0)
            {
                AiScore++;
                ResetBall();
            }

            if(ballX > this.ClientSize.Width)
            {
                playerScore++;
                ResetBall();
            }
            Invalidate();*/
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (moveUp && playerY > 0) playerY -= 6;
            if (moveDown && playerY < this.ClientSize.Height - 80)
                playerY += 6;

            if (AiY + 40 < ballY) AiY += 5;
            if (AiY + 40 > ballY) AiY -= 5;

            if (AiY < 0) AiY = 0;
            if (AiY > this.ClientSize.Height - 80)
                AiY = this.ClientSize.Height - 80;

            ballX += ballspeedX;
            ballY += ballspeedY;

            if (ballY <= 0 || ballY >= this.ClientSize.Height - 10)
                ballspeedY *= -1;

            Rectangle playerRect = new Rectangle(10, playerY, 10, 80);
            Rectangle ballRect = new Rectangle(ballX, ballY, 10, 10);

            if (playerRect.IntersectsWith(ballRect))
                ballspeedX = Math.Abs(ballspeedX);

            Rectangle AiRect = new Rectangle(this.ClientSize.Width - 20, AiY, 10, 80);

            if (AiRect.IntersectsWith(ballRect))
                ballspeedX = -Math.Abs(ballspeedX);

            if (ballX < 0)
            {
                AiScore++;
                ResetBall();
            }

            if (ballX > this.ClientSize.Width)
            {
                playerScore++;
                ResetBall();
            }
            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) moveUp = true;
            if (e.KeyCode == Keys.Down) moveDown = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) moveUp = false;
            if (e.KeyCode == Keys.Down) moveDown = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(Brushes.White, 10, playerY, 10, 80);
            g.FillRectangle(Brushes.White, this.ClientSize.Width - 20, AiY, 10, 80);

            g.FillEllipse(Brushes.White, ballX, ballY, 10, 10);

            g.DrawString($"Gracz: {playerScore}", new Font("Arial", 12), Brushes.White, 50, 10);
            g.DrawString($"AI: {AiScore}", new Font("Arial", 12), Brushes.White, 400, 10);
        }
        private void ResetBall()
        {
            ballX = this.ClientSize.Width / 2;
            ballY = this.ClientSize.Height / 2;

            ballspeedX *= -1;
        }
    }
}