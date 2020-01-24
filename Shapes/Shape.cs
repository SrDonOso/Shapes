using Shapes.Shapes;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shapes
{
    public class Shape
    {
        private IList<IGeometricShape> GeometricShapes { get; set; }
     
        public Shape()
        {
            GeometricShapes = new List<IGeometricShape>();
        }

        /// <summary>
        /// Add a Shape to an internal list depending on the ShapeType
        /// </summary>
        /// <param name="shapeType"></param>
        /// <param name="color"></param>
        /// <param name="measurements"></param>
        public void AddShape(Common.ShapeType shapeType, Common.Color color, IList<int> measurements)
        {
            switch(shapeType)
            {
                case Common.ShapeType.circle:
                    GeometricShapes.Add(new Circle
                    {
                        Color = color,
                        Radius = measurements[0]
                    });
                    break;
                case Common.ShapeType.rectangle:
                    GeometricShapes.Add(new Rectangle
                    {
                        Color = color,
                        Base = measurements[0],
                        Height = measurements[1]
                    });
                    break;
                case Common.ShapeType.square:
                    GeometricShapes.Add(new Square
                    {
                        Color = color,
                        Side = measurements[0]
                    });
                    break;
                case Common.ShapeType.trapezoid:
                    GeometricShapes.Add(new Trapezoid
                    {
                        Color = color,
                        Base1 = measurements[0],
                        Base2 = measurements[1],
                        Height = measurements[2]
                    });
                    break;
                case Common.ShapeType.triangle:
                    GeometricShapes.Add(new Triangle
                    {
                        Color = color,
                        Base = measurements[0],
                        Height = measurements[1]
                    });
                    break;
            }
        }

        /// <summary>
        /// it will return a string with or without filter depending on the shapeType
        /// </summary>
        /// <param name="shapeType"></param>
        /// <returns></returns>
        public string PrintShapes(Common.ShapeType? shapeType)
        {
            var sb = new StringBuilder();
            if (shapeType.HasValue)
            {
                foreach (var item in GeometricShapes.Where(x => x.ShapeType == shapeType.Value))
                    sb.AppendLine(item.ToString());
            }
            else
            {
                foreach (var item in GeometricShapes)
                    sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
    }
}
