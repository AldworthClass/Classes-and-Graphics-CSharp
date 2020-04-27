using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_and_Graphics
{
    abstract class Target
    {
        protected static Random random = new Random();
        public abstract void Move();

        public abstract Boolean Hit(Point shot);

        public abstract void Draw(Graphics graphics);


    }
}
