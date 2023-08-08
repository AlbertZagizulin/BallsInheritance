
using BallsLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatchBallsApp
{
    public partial class CatchForm : Form
    {
        private List<RandomMoveBallBase> moveBalls;
        private static Random random = new Random();
        private int ballsCounter;

        public CatchForm()
        {
            InitializeComponent();
        }

        private void createButon_Click(object sender, EventArgs e)
        {
            ballsCounter = 0;
            moveBalls = new List<RandomMoveBallBase>();
            int ballsQuantity = random.Next(5, 11);
            for (int i = 0; i < ballsQuantity; i++)
            {
                var ballToList = new RandomMoveBallBase(this);
                moveBalls.Add(ballToList);
                moveBalls[i].Start();
            }
            createButton.Enabled = false;
            clearButton.Enabled = true;
        }

        private void CatchForm_Load(object sender, EventArgs e)
        {
            clearButton.Enabled = false;
        }

        private void CatchForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (moveBalls != null)
            {
                foreach (var ball in moveBalls)
                {
                    if (ball.IsMoves() && ball.Contains(e.X, e.Y) && ball.IsOnForm())
                    {
                        ball.Stop();
                        ballsCounter++;
                    }
                }
                scoreLabel.Text = ballsCounter.ToString();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            foreach(var ball in moveBalls)
            {
                ball.Clear();
            }
            createButton.Enabled = true;
            clearButton.Enabled = false;
            MessageBox.Show("Вы поймали " + ballsCounter + " из " + moveBalls.Count + " шариков");
            scoreLabel.Text = 0.ToString();
        }
    }
}
