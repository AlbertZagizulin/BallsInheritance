using BallsLibrary;
using SalutWFApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NinjaWFApp
{
    internal class NinjaBall : MoveBall
    {
        private float ballG = 0.5f;
       private int chance = 0;
        public NinjaBall(Form form) : base(form)
        {
            radius = random.Next(15, 31);
            centerY = form.ClientSize.Height;
            centerX = random.Next(1, form.ClientSize.Width);
            vy = -Math.Abs(vy);
            GetBrush();
        }
        protected override void Go()
        {
            base.Go();
            if(centerY > form.ClientSize.Height / 2 && chance < 1)
            {
                vy -= 0.4f;
            }
            else
            {
                vy += ballG;
                chance = 1;
            }
            

        }
    }
}
