namespace Shapes.Shapes
{
    class Rectangle : IGeometricShape
    {
        public Common.Color Color { get; set; }
        public int Base { get; set; }
        public int Height { get; set; }

        public Common.ShapeType ShapeType => Common.ShapeType.rectangle;

        public override string ToString()
        {
            return $"Rectangle - Color: {this.Color}, Base: {this.Base}, Height: {this.Height}";
        }
    }
}
