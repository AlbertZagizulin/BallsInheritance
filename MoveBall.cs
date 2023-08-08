using System.Drawing;
using System.Windows.Forms;

namespace BallsLibrary
{
    public class MoveBall : RandomSizeAndPointBall
    {
        public MoveBall(Form form) : base(form)
        {
            vx = GenerateRandomProjection();
            vy = GenerateRandomProjection();           
        }
        public MoveBall(Form form, Brush brush) : base(form, brush)
        {
            vx = GenerateRandomProjection();
            vy = GenerateRandomProjection();
        }
        private int GenerateRandomProjection()
        {
            var randomDouble = random.NextDouble();
            var sign = 1;
            if(randomDouble < 0.5)
                sign = -1;
            return random.Next(2,5) * sign;
        }
    }
}
