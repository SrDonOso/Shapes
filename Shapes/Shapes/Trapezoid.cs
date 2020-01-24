namespace Shapes.Shapes
{
    internal class Trapezoid : IGeometricShape
    {
        public int Base1 { get; set; }
        public int Base2 { get; set; }
        public int Height { get; set; }
        public Common.Color Color { get; set; }

        public Common.ShapeType ShapeType => Common.ShapeType.trapezoid;

        public override string ToString()
        {
            return $"Trapezoid - Color: {this.Color}, Base1: {this.Base1}, Base2: {this.Base2}, Height: {this.Height}";
        }
    }
}
