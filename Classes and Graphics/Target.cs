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
        private Point location;
        private int radius;
        private SolidBrush fill;
        private Pen outline;      

        public Target(Point location, int radius)
        {
            this.location = location;
            this.radius = radius;
            fill = new SolidBrush(Color.Red);
        }
    }
}
