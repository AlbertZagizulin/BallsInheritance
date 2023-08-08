using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NinjaWFApp
{
    public partial class NinjaForm : Form
    {
        public Timer gameTimer = new Timer();
        public Timer slowGameTimer = new Timer();
        public int score = 0;
        public static Random random = new Random();
        private List<NinjaBall> ninjaBalls = new List<NinjaBall>();
        public int slowTimerTickCount;
        public NinjaForm()
        {
            InitializeComponent();
            gameTimer.Interval = 1200;
            gameTimer.Tick += GameTimer_Tick;
            slowGameTimer.Interval = 2500;
            slowGameTimer.Tick += SlowGameTimer_Tick;
        }
        private void NinjaForm_Load(object sender, EventArgs e)
        {
            gameTimer.Start();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            slowTimerTickCount = 0;
            var ninjaBall = new NinjaBall(this);
            ninjaBalls.Add(ninjaBall);
            ninjaBall.Start();
        }
        private void SlowGameTimer_Tick(object sender, EventArgs e)
        {
            if (slowTimerTickCount <= 5)
            {
                var ninjaBall = new NinjaBall(this);
                ninjaBalls.Add(ninjaBall);
                ninjaBall.Start();
                foreach (var ball in ninjaBalls)
                {
                    ball.timer.Interval = 40;
                }
            }
            else
            {
                slowGameTimer.Stop();
                gameTimer.Start();
            }
            slowTimerTickCount++;
        }

            private void NinjaForm_MouseMove(object sender, MouseEventArgs e)
            {
                if (ninjaBalls != null)
                {
                    foreach (var ball in ninjaBalls)
                    {
                        if (ball.IsMoves() && ball.IsOnForm() && ball.Contains(e.X, e.Y))
                        {
                            if (ball.brush == Brushes.Black)
                            {
                                gameTimer.Stop();
                                MessageBox.Show("Вы задели черный шар. Игра окончена");
                                Application.Restart();
                            }
                            else
                            {
                                if (ball.brush == Brushes.Yellow)
                                {
                                    gameTimer.Stop();
                                    slowGameTimer.Start();
                                    score += 1;
                                    scoreLabel.Text = score.ToString();
                                    ball.Clear();
                                    ball.Stop();
                                }
                                else
                                {
                                    score += 1;
                                    scoreLabel.Text = score.ToString();
                                    ball.Clear();
                                    ball.Stop();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
