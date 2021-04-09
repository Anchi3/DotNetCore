using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Square : Shape
    {
        public double Side { set; get; }

        public override string Colour { get => base.Colour; set => base.Colour = value; }
        public override string Name => GetType().Name;
        public override double Area => Side * Side;
    }
}
