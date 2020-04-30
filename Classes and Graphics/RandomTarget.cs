using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_and_Graphics
{
    class RandomTarget : Target
    {
        private Rectangle location;
        private Size canvasSize;
        private int movePoint;
        Brush brush;


        public RandomTarget(Size size)
        {
            brush = new SolidBrush(Color.Brown);
            canvasSize = size;
            location = new Rectangle(random.Next(0, canvasSize.Width - location.Width), random.Next(0, canvasSize.Height - location.Height), random.Next(30, 50), random.Next(30, 50));
            newLocation();
            movePoint = 0;
        }

        private void newLocation()
        {
            location.X = random.Next(0, canvasSize.Width - location.Width);
            location.Y = random.Next(0, canvasSize.Height - location.Height);
        }

        public override void Draw(Graphics graphics)
        {
            graphics.FillRectangle(brush, location);
        }

        public override bool Hit(Point shot)
        {
            return location.Contains(shot);
        }

        public override void Move()
        {
            movePoint += 1;
            if (movePoint >= 40)
            {
                newLocation();
                movePoint = 0;
            }
                
        }
    }
}
