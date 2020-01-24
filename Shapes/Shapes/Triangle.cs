using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Shapes
{
    class Triangle : IGeometricShape
    {
        public Common.Color Color { get; set; }
        public int Base { get; set; }
        public int Height { get; set; }

        public Common.ShapeType ShapeType => Common.ShapeType.triangle;

        public override string ToString()
        {
            return $"Triangle - Color: {this.Color}, Base: {this.Base}, Height: {this.Height}";
        }
    }
}
