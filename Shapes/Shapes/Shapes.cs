using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Shapes
{
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Square))]
    [XmlInclude(typeof(Circle))]
    public class Shape
    {
        public virtual string Name { get; }
        public virtual double Area { get; }
        public virtual string Colour { get; set; }
    }
}
