using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;

namespace classRing
{
    class Ring : IComparable
    {
        Color color;
        int radius;

        public Ring()
        {
            this.radius = 0;
            this.color = Color.Empty;
        }
        public Ring(int radius, Color color)
        {
            this.radius = radius;
            this.color = color;
        }
        public Color Color { get { return color; } }
        public int Radius { get { return radius; } }


        public int CompareTo(object obj)
        {
           
            Ring ring = (Ring)obj;
           /* if (this.Radius > ring.Radius) { return 1; }
            if (this.Radius < ring.Radius) { return -1; }
            return 0;
            */
            return this.Radius.CompareTo(ring.Radius);
        }

        public override string ToString()
        {
            return String.Format("Ring : Radius = {0,3}  Color = {1}",
                this.radius, this.color);
        }
    }
}
