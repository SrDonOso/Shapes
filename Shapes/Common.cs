namespace Shapes
{
    public class Common
    {
        public const string formatError = "Please use the following format: [command] [shapeType] [color] [measurements(separated by commas)]";
        public const string writeCommandMessage = "Please type your command (exit to finish): ";
        public const string commandNotAvailable = "Command not available. Please use: {0}";
        public const string shapeNotAvailable = "Shape is not available. Please use: {0}";
        public const string colorNotAvailable = "Color is not available. Please use: {0}";
        public const string commaSeparatedMessage = "Pease add numbers separated by commas";
        public const string circleMeasureError = "You need to add only the radius";
        public const string rectangleTriangleMeasureError = "You need to add the base and height separated by commas";
        public const string squareMeasureError = "You need to add only the side";
        public const string trapezoidMeasureError = "You need to add the base1, base2 and height separated by commas";

        public enum Color
        {
            red,
            yellow,
            blue,
            pink,
            purple,
            green,
            brown
        };

        public enum ShapeType
        {
            triangle,
            square,
            circle,
            rectangle,
            trapezoid
        };

        public enum Command
        {
            add,
            list
        };   
    }
}
