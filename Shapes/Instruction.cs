using System.Collections.Generic;

namespace Shapes
{
    public class Instruction
    {
        public Common.Command Command { get; set; }
        public Common.ShapeType? ShapeType { get; set; }
        public Common.Color? Color { get; set; }
        public IList<int> Measurements { get; set; }
    }
}