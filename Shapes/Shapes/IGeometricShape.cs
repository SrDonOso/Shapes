namespace Shapes.Shapes
{
    public interface IGeometricShape
    {
        public Common.Color Color { get; set; }
        public Common.ShapeType ShapeType { get; }
    }
}
