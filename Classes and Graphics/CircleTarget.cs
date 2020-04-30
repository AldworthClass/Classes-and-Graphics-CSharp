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
        private Point location;
        private int radius;
        private Brush fill;
        private Pen outline;
        private int hSpeed;
        private int vSpeed;
        private Size canvasSize;

        // Constructors

        // Random Location and Size radius from 5-10 
        public CircleTarget(Size size)
        {
            canvasSize = size;
            this.radius = random.Next(10, 20);
            this.location = new Point(random.Next(1 + radius, size.Width - radius), random.Next(1 + radius, size.Height - radius));
            fill = new SolidBrush(Color.Red);
            NewSpeed();
        }

        // Location and Size Provided
        public CircleTarget(Point location, int radius, Size size)
        {
            this.location = location;
            this.radius = radius;
            canvasSize = size;
            fill = new SolidBrush(Color.Red);
            NewSpeed();
        }

        // Location provided, random size from 10-25
        public CircleTarget(Point location, Size size)
        {
            this.location = location;
            this.radius = random.Next(10, 26);
            fill = new SolidBrush(Color.Red);
            NewSpeed();
            canvasSize = size;
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

        // Assigns a random speed to the target
        public void NewSpeed()
        {
            do
            {
                hSpeed = random.Next(-3, 3);
                vSpeed = random.Next(-3, 3);

            } while (hSpeed == 0 && vSpeed == 0);
            

        }
        

        // Indicated whether provided point hits target
        public override Boolean Hit(Point shot)
        {
            Console.WriteLine(MyMath.Distance(shot, location));
            Console.WriteLine();
            if (MyMath.Distance(shot, location) < radius + 3)
                return true;
            return false;
        }


        // Moves target to a valid location
        public override void Move()
        {
            location.X += hSpeed;
            location.Y += vSpeed;
            if (location.X + radius >= canvasSize.Width || location.X - radius <= 0)
                hSpeed *= -1;
            if (location.Y + radius >= canvasSize.Height || location.Y - radius <= 0)
                vSpeed *= -1;
        }

        //Draws the shape
        public override void Draw(Graphics graphics)
        {
            graphics.FillEllipse(fill,location.X-radius, location.Y-radius, radius*2, radius*2);
        }

        

    }
}
