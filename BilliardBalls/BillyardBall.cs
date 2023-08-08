using System;
using System.Drawing;
using System.Windows.Forms;
using BallsLibrary;

namespace BilliardBalls
{
    public class BillyardBall : MoveBall
    {
        public event EventHandler<HitEventArgs> Hited;
        public BillyardBall(Form form) : base(form)
        {
            radius= 10;

        }

        public BillyardBall(Form form, Brush brush) : base(form, brush)
        {
            radius= 10;
            centerX = random.Next(LeftSide(), RightSide());
            centerY = random.Next(TopSide(),DownSide());
        }
        public bool IsLeftByCenter()
        {
            return centerX + radius < form.ClientSize.Width / 2;
        }
        public bool IsRightByCenter()
        {
            return centerX - radius < form.ClientSize.Width / 2;
        }
        protected override void Go()
        {
            base.Go();
            if (centerX <= LeftSide())
            {
                centerX = LeftSide();
                vx = -vx;
                Hited.Invoke(this, new HitEventArgs(Side.Left));
            }
            if (centerX >= RightSide())
            {
                centerX = RightSide();
                vx = -vx;
                Hited.Invoke(this, new HitEventArgs(Side.Right));
            }
            if (centerY <= TopSide())
            {
                centerY = TopSide();
                vy = -vy;
                Hited.Invoke(this, new HitEventArgs(Side.Top));
            }
            if (centerY >= DownSide())
            {
                centerY = DownSide();
                vy = -vy;
                Hited.Invoke(this, new HitEventArgs(Side.Bottom));
            }
        }
    }
}
