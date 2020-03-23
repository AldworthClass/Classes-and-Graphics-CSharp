using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_and_Graphics
{
    class Target
    {
        private static Random random = new Random();
        private Point location;
        private int radius;
        private SolidBrush fill;
        private Pen outline;
        private int hSpeed;
        private int vSpeed;

        public static double Distance(int x1, int y1, int x2, int y2)
        {
            return Distance(new Point(x1, y1), new Point(x2, y2));
        }
        public static double Distance(Point p1, Point p2)
        {
            return Math.Sqrt((p1.X - p2.X)* (p1.X - p2.X) + (p1.Y - p2.Y)* (p1.Y - p2.Y));
        }
        public Target(Point location, int radius)
        {
            this.location = location;
            this.radius = radius;
            fill = new SolidBrush(Color.Red);
            NewSpeed();
        }
        public Target(Point location)
        {
            this.location = location;
            this.radius = random.Next(10, 25);
            fill = new SolidBrush(Color.Red);
            NewSpeed();
        }
        public Target()
        {
            
            this.radius = random.Next(5, 10);
            this.location = new Point(random.Next(1 + radius, 530 - radius), random.Next(1 + radius, 490 - radius));
            fill = new SolidBrush(Color.Red);
            NewSpeed();
        }

        public Boolean Hit(Point shot)
        {
            Console.WriteLine(Distance(shot, location));
            Console.WriteLine();
            if (Distance(shot, location) < radius + 3)
                return true;
            return false;
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
        public void move(Size canvasSize)
        {
            location.X += hSpeed;
            location.Y += vSpeed;
            if (location.X + radius >= canvasSize.Width || location.X - radius <= 0)
                hSpeed *= -1;
            if (location.Y + radius >= canvasSize.Height || location.Y - radius <= 0)
                vSpeed *= -1;
        }
        public void draw(Graphics canvas)
        {
            canvas.FillEllipse(fill,location.X-radius, location.Y-radius, radius*2, radius*2);
        }

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

    }
}
