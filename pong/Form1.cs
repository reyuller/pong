namespace pong
{
    public partial class Form1 : Form
    {
        int playerY = 150;
        int AiY = 150;

        int ballX = 200;
        int ballY = 150;

        int ballspeedX = 6;
        int ballspeedY = 7;

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
            if (moveUp && playerY > 0) playerY -= 6;
            if (moveDown && playerY < this.ClientSize.Height - 800) playerY += 6;

            //if (AiY + 40 < ballY) 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

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
    }
}