using System.Drawing;
using System.Windows.Forms;

namespace BallsLibrary
{
    public class RandomSizeAndPointBall : RandomPointBall
    {
        public RandomSizeAndPointBall(Form form) : base(form)
        {
            radius = random.Next(10, 40);
        }
        public RandomSizeAndPointBall(Form form, Brush brush) : base(form, brush)
        {
            radius = random.Next(10, 40);
        }
    }
}
