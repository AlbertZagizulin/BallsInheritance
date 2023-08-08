using BallsLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BilliardBalls
{
    public partial class BillyardForm : Form
    {
        private Timer timer = new Timer();
        List<BillyardBall> redBalls = new List<BillyardBall>();
        List<BillyardBall> blueBalls = new List<BillyardBall>();
        int countOfBallsInList = 10;
        public BillyardForm()
        {
            InitializeComponent();
            timer.Interval = 15;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ShowVerticalCenterLine();
            int leftByCenterBlueCount = 0;
            int rightByCenterBlueCount = 0;
            int leftByCenterRedCount = 0;
            int rightByCenterRedCount = 0;
            foreach (var ball in blueBalls)
            {
                if (ball.IsLeftByCenter())
                {
                    leftByCenterBlueCount++;
                }
                else rightByCenterBlueCount++;
            }
            if (leftByCenterBlueCount == countOfBallsInList / 2 && rightByCenterBlueCount == countOfBallsInList / 2)
            {
                foreach (var ball in redBalls)
                {
                    if (ball.IsLeftByCenter())
                    {
                        leftByCenterRedCount++;
                    }
                    else rightByCenterRedCount++;
                }
                if (leftByCenterRedCount == countOfBallsInList / 2 && rightByCenterRedCount == countOfBallsInList / 2)
                {
                    foreach (var ball in redBalls)
                    {
                        ball.Stop();
                    }
                    foreach (var ball in blueBalls)
                    {
                        ball.Stop();
                    }
                }
            }
        }

        private void BillyardForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < countOfBallsInList; i++)
            {
                var ball = new BillyardBall(this, Brushes.Blue);
                if (ball.IsOnForm())
                {
                    ball.Hited += Ball_Hited1;
                    ball.Start();
                    blueBalls.Add(ball);
                }
                else
                {
                    ball.Clear();
                    i--;
                }
            }
            for (int i = 0; i < countOfBallsInList; i++)
            {
                var ball = new BillyardBall(this, Brushes.Red);
                if (ball.IsOnForm())
                {
                    ball.Hited += Ball_Hited2;
                    ball.Start();
                    redBalls.Add(ball);
                }
                else
                {
                    ball.Clear();
                    i--;
                }
            }
        }

        private void ShowVerticalCenterLine()
        {
            var graphics = CreateGraphics();
            graphics.DrawLine(Pens.Black, ClientSize.Width / 2, 0, ClientSize.Width / 2, ClientSize.Height);
        }

        private void Ball_Hited2(object sender, HitEventArgs e)
        {
            switch (e.Side)
            {
                case Side.Left:
                    leftCounterRed.Text = (Convert.ToInt32(leftCounterRed.Text) + 1).ToString();
                    break;
                case Side.Right:
                    rightCounterRed.Text = (Convert.ToInt32(rightCounterRed.Text) + 1).ToString();
                    break;
                case Side.Top:
                    topCounterRed.Text = (Convert.ToInt32(topCounterRed.Text) + 1).ToString();
                    break;
                case Side.Bottom:
                    bottomCounterRed.Text = (Convert.ToInt32(bottomCounterRed.Text) + 1).ToString();
                    break;
            }
        }

        private void Ball_Hited1(object sender, HitEventArgs e)
        {
            switch (e.Side)
            {
                case Side.Left:
                    leftCounterBlue.Text = (Convert.ToInt32(leftCounterBlue.Text) + 1).ToString();
                    break;
                case Side.Right:
                    rightCounterBlue.Text = (Convert.ToInt32(rightCounterBlue.Text) + 1).ToString();
                    break;
                case Side.Top:
                    topCounterBlue.Text = (Convert.ToInt32(topCounterBlue.Text) + 1).ToString();
                    break;
                case Side.Bottom:
                    bottomCounterBlue.Text = (Convert.ToInt32(bottomCounterBlue.Text) + 1).ToString();
                    break;
            }
        }

        private void Ball_Hited(object sender, HitEventArgs e)
        {
            switch (e.Side)
            {
                case Side.Left:
                    leftCounterBlue.Text = (Convert.ToInt32(leftCounterBlue.Text) + 1).ToString();
                    break;
                case Side.Right:
                    rightCounterBlue.Text = (Convert.ToInt32(rightCounterBlue.Text) + 1).ToString();
                    break;
                case Side.Top:
                    topCounterBlue.Text = (Convert.ToInt32(topCounterBlue.Text) + 1).ToString();
                    break;
                case Side.Bottom:
                    bottomCounterBlue.Text = (Convert.ToInt32(bottomCounterBlue.Text) + 1).ToString();
                    break;
            }
        }

    }
}
