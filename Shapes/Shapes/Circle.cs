namespace Shapes.Shapes
{
    class Circle : IGeometricShape
    {
        public int Radius { get; set; }
        public Common.Color Color { get; set; }

        public Common.ShapeType ShapeType => Common.ShapeType.circle;

        public override string ToString()
        {
            return $"Circle - Color: {this.Color}, Radius: {this.Radius}";
        }
    }
}
