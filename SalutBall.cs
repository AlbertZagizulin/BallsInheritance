using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BallsLibrary;

namespace SalutWFApp
{
    public class SalutBall : MoveBall
    {
        private float ballG = 0.2f;
        public SalutBall(Form form, float centerX, float centerY) : base(form)
        {
            radius = 15;
            this.centerX = centerX;
            this.centerY = centerY;
            vy = -Math.Abs(vy);
            GetBrush();
        }
        protected override void Go()
        {
            base.Go();
            vy += ballG;

        }
        
        }
    }

