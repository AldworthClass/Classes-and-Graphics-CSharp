using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_and_Graphics
{

    //This target moves in a repeating pattern
    class SquareTarget : Target
    {
        private Rectangle location;
        private int hSpeed;
        private int vSpeed;
        private int moveCount;
        Brush brush;


        public SquareTarget(Size size)
        {
            int width = random.Next(20, 55);
            Random generator = new Random();
            

            brush = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Red, Color.Blue);
            moveCount = random.Next(50);
            do
            {
                hSpeed = random.Next(-3, 3);
                vSpeed = random.Next(-3, 3);
            } while (hSpeed == 0 && vSpeed == 0);

            //Makes sure that square will never go out of window based on fixed path
            //This is not completley functional
            location = new Rectangle(random.Next(0 + Math.Abs(hSpeed) * 50, size.Width - width - Math.Abs(hSpeed) * 50), random.Next(0 + Math.Abs(vSpeed) * 50, size.Height - width - Math.Abs(vSpeed) * 50), width, width);
        }
        public SquareTarget(Rectangle location)
        {
            this.location = location;
            brush = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Red, Color.Blue);
            moveCount = random.Next(50);
            do
            {
                hSpeed = random.Next(-2, 2);
                vSpeed = random.Next(-2, 2);
            } while (hSpeed == 0 && vSpeed == 0);
            
        }

        public int HSpeed
        {
            get
            {
                return hSpeed;
            }
            set
            {
                hSpeed = value;
            }
        }

        public int VSpeed
        {
            get
            {
                return vSpeed;
            }
            set
            {
                vSpeed = value;
            }
        }


        public override Boolean Hit(Point shot)
        {
            return location.Contains(shot);
        }

        public override void Move()
        {
            moveCount++;
            location.Offset(hSpeed, vSpeed);
            if (moveCount >= 50)
            {
                hSpeed *= -1;
                vSpeed *= -1;
                moveCount = 0;
            }


        }

        public override void Draw(Graphics graphics)
        {
            graphics.FillRectangle(brush, location);
        }


    }
}
