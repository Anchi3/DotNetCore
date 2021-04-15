using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        public double Radius { set; get; }

        public override string Colour { get => base.Colour; set => base.Colour = value; }
        public override string Name => GetType().Name;
        public override double Area => Math.PI * (Radius * Radius);
    }
}
