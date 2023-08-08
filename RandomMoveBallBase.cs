using System.Windows.Forms;

namespace BallsLibrary
{
    public class RandomMoveBallBase : MoveBall
    {
        public RandomMoveBallBase(Form form) : base(form)
        {
            vx = (float)random.NextDouble() * 10 - 5;
            vy = (float)random.NextDouble() * 10 - 5;
        }
    }
}