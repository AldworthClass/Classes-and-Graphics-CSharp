using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_and_Graphics
{
    class CircleTarget : Target
    {
        private static Random random = new Random();
        private Point location;
        private int radius;
        private SolidBrush fill;
        private Pen outline;
        private int hSpeed;
        private int vSpeed;

        // Constructors

        // Random Location and Size radius from 5-10 
        public CircleTarget()
        {

            this.radius = random.Next(5, 10);
            this.location = new Point(random.Next(1 + radius, 530 - radius), random.Next(1 + radius, 490 - radius));
            fill = new SolidBrush(Color.Red);
            NewSpeed();
        }

        // Location and Size Provided
        public CircleTarget(Point location, int radius)
        {
            this.location = location;
            this.radius = radius;
            fill = new SolidBrush(Color.Red);
            NewSpeed();
        }

        // Location provided, random size from 10-25
        public CircleTarget(Point location)
        {
            this.location = location;
            this.radius = random.Next(10, 26);
            fill = new SolidBrush(Color.Red);
            NewSpeed();
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
                return VSpeed;
            }
            set
            {
                vSpeed = value;
            }
        }

        // Assigns a random speed to the target
        public void NewSpeed()
        {
            do
            {
                hSpeed = random.Next(-3, 3);
            } while (hSpeed == 0);
            do
            {
                vSpeed = random.Next(-3, 3);
            } while (vSpeed == 0);

        }


        override
        public Boolean Hit(Point shot)
        {
            Console.WriteLine(MyMath.Distance(shot, location));
            Console.WriteLine();
            if (MyMath.Distance(shot, location) < radius + 3)
                return true;
            return false;
        }


        override
        public void Move(Size canvasSize)
        {
            location.X += hSpeed;
            location.Y += vSpeed;
            if (location.X + radius >= canvasSize.Width || location.X - radius <= 0)
                hSpeed *= -1;
            if (location.Y + radius >= canvasSize.Height || location.Y - radius <= 0)
                vSpeed *= -1;
        }

        override
        public void Draw(Graphics graphics)
        {
            graphics.FillEllipse(fill,location.X-radius, location.Y-radius, radius*2, radius*2);
        }

        

    }
}
