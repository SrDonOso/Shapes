using System.Collections.Generic;

namespace Shapes
{
    /// <summary>
    ///  Instruction will have the properties to create a new GeometricShape
    /// </summary>
    public class Instruction
    {
        public Common.Command Command { get; set; }
        public Common.ShapeType? ShapeType { get; set; }
        public Common.Color? Color { get; set; }
        public IList<int> Measurements { get; set; }
    }
}