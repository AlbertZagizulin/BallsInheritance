using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace BallsLibrary
{
    public class Ball
    {
        protected Form form;
        public Timer timer;
        protected float vx;
        protected float vy;
        public float centerX;
        public float centerY;
        protected int radius;
        protected static Random random = new Random();
        public Brush brush = Brushes.Blue;
        public Ball(Form form)
        {
            this.form = form;
            timer = new Timer();
            timer.Interval = 20;
            timer.Tick += Timer_Tick;
        }
        public Ball(Form form, Brush brush)
        {
            this.brush = brush;
            this.form = form;
            timer = new Timer();
            timer.Interval = 20;
            timer.Tick += Timer_Tick;
        }

        public void Move()
        {
            Clear();
            Go();
            Show();
        }
        public void Show()
        {
            var brush = this.brush;
            Draw(brush);
        }

        protected virtual void Go()
        {
            centerX += vx;
            centerY += vy;
        }
        public int LeftSide()
        {
            return radius;
        }
        public int RightSide()
        {
            return form.ClientSize.Width - radius;
        }
        public int TopSide()
        {
            return radius;
        }
        public int DownSide()
        {
            return form.ClientSize.Height - radius;
        }
        public void Clear()
        {
            var brush = new SolidBrush(form.BackColor);
            Draw(brush);
        }
        public bool IsOnForm()
        {
            if (centerX - radius >= LeftSide() && centerX + radius <= RightSide() && centerY - radius >= TopSide() && centerY + radius <= DownSide())
            {
                return true;
            }
            return false;
        }
        public bool Contains(float pointX, float pointY)
        {
            var dx = pointX - centerX;
            var dy = pointY - centerY;
            return dx * dx + dy * dy <= radius * radius;
        }
        public void Draw(Brush brush)
        {
            var graphics = form.CreateGraphics();
            var rectangle = new RectangleF(centerX - radius, centerY - radius, 2 * radius, 2 * radius);
            graphics.FillEllipse(brush, rectangle);
        }
        public bool IsMoves()
        {
            return timer.Enabled;
        }
        protected virtual void Timer_Tick(object sender, EventArgs e)
        {
            Move();
        }

        public void Start()
        {
            timer.Start();
        }
        public void Stop()
        {
            timer.Stop();
        }
        public void GetBrush()
        {
            int colorNumber = random.Next(1, 7);
            switch (colorNumber)
            {
                case 1:
                    brush = Brushes.Red;
                    break;
                case 2:
                    brush = Brushes.Green;
                    break;
                case 3:
                    brush = Brushes.Blue;
                    break;
                case 4:
                    brush = Brushes.Magenta;
                    break;
                case 5:
                    brush = Brushes.Yellow;
                    break;
                case 6:
                    brush = Brushes.Black;
                    break;
            }
        }
    }
}
