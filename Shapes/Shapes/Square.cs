namespace Shapes.Shapes
{
    class Square : IGeometricShape
    {
        public Common.Color Color { get; set; }
        public int Side { get; set; }

        public Common.ShapeType ShapeType => Common.ShapeType.square;

        public override string ToString()
        {
            return $"Square - Color: {this.Color}, Side: {this.Side}";
        }
    }
}
