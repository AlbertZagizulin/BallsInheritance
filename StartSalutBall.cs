using BallsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalutWFApp
{
    public class StartSalutBall : MoveBall
    {
        private float explosionHeigh;
        public StartSalutBall(Form form, Random random) : base(form)
        {
            radius = 10;
            centerY = form.ClientSize.Height;
            centerX = random.Next(1, form.ClientSize.Width);
            explosionHeigh = random.Next(0, form.ClientSize.Height / 2);
        }
        protected override void Go()
        {
            base.Go();
            vy -= 0.5f;
            vx = 0;
        }
        protected override void Timer_Tick(object sender, EventArgs e)
        {
            base.Timer_Tick(sender, e);
            if (centerY == explosionHeigh || centerY < explosionHeigh)
            {
                Stop();               
                var spotX = ExplosionSpotX();
                var spotY = ExplosionSpotY();
                var ballsQuantity = random.Next(1, 11);
                for (int i = 0; i < ballsQuantity; i++)
                {
                    
                    var salut = new SalutBall(form, spotX, spotY);
                    salut.Start();
                }
                Clear();
            }
        }
        public float ExplosionSpotX()
        {
            return centerX;
        }
        public float ExplosionSpotY()
        {
            return centerY;
        }
    }
}
