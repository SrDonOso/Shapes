using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Syntaxis
    {
        public static Result ValidateInstruction(string command)
        {
            var result = new Result();
            var instructions = command.Split(' ');
            if (instructions.Length == 0)
            {
                result.errorList.Add(Common.formatError);
            }
            else
            {
                result.Instruction = new Instruction();
                if (VerifyExistence(instructions[0].ToLower(), typeof(Common.Command)))
                    result.Instruction.Command = getCommand(instructions[0].ToLower());
                else
                    result.errorList.Add(string.Format(Common.commandNotAvailable, ListEnum(typeof(Common.Command))));
                
                if(instructions.Length >= 2)
                {
                    if(VerifyExistence(instructions[1].ToLower(), typeof(Common.ShapeType)))
                        result.Instruction.ShapeType = getShapeType(instructions[1].ToLower());
                    else
                        result.errorList.Add(string.Format(Common.shapeNotAvailable, ListEnum(typeof(Common.ShapeType))));

                    if (result.Instruction.Command == Common.Command.add)
                    {
                        if (instructions.Length >= 3 && instructions.Length <= 4)
                        {
                            if (VerifyExistence(instructions[2].ToLower(), typeof(Common.Color)))
                                result.Instruction.Color = getColor(instructions[2].ToLower());
                            else
                                result.errorList.Add(string.Format(Common.colorNotAvailable, ListEnum(typeof(Common.Color))));
                            if (instructions.Length == 4 && VerifyMeasurements(instructions[3].ToLower()))
                            {
                                result.Instruction.Measurements = getMeasurements(instructions[3]);
                                switch(result.Instruction.ShapeType)
                                {
                                    case Common.ShapeType.circle:
                                        if (result.Instruction.Measurements.Count != 1)
                                            result.errorList.Add(Common.circleMeasureError);
                                        break;
                                    case Common.ShapeType.rectangle:
                                    case Common.ShapeType.triangle:
                                        if (result.Instruction.Measurements.Count != 2)
                                            result.errorList.Add(Common.rectangleTriangleMeasureError);
                                        break;
                                    case Common.ShapeType.square:
                                        if (result.Instruction.Measurements.Count != 1)
                                            result.errorList.Add(Common.squareMeasureError);
                                        break;
                                    case Common.ShapeType.trapezoid:
                                        if (result.Instruction.Measurements.Count != 3)
                                            result.errorList.Add(Common.trapezoidMeasureError);
                                        break;
                                }
                            }
                            else
                                result.errorList.Add(Common.commaSeparatedMessage);
                        }
                        else
                            result.errorList.Add(Common.formatError);
                    }
                }
            }


            return result;
        }

        private static Common.Color getColor(string color)
        {
            return Enum.Parse<Common.Color>(color);
        }

        private static Common.ShapeType getShapeType(string shape)
        {
            return Enum.Parse<Common.ShapeType>(shape);
        }
        
        private static Common.Command getCommand(string command)
        {
            return Enum.Parse<Common.Command>(command);
        }

        private static string ListEnum(Type enumType)
        {
            var enumItems = new StringBuilder();
            foreach (string name in Enum.GetNames(enumType))
                enumItems.Append(name + "|");
            return enumItems.ToString();
        }

        private static bool VerifyMeasurements(string measurements)
        {
            var mList = measurements.Split(',');
            foreach (var item in mList)
                if (!int.TryParse(item, out _)) return false;
            return true;
        }
        
        public static IList<int> getMeasurements(string measurements)
        {
            var intList = new List<int>();
            var mList = measurements.Split(',');
            foreach (var item in mList)
                intList.Add(int.Parse(item));
            return intList.ToArray();
        }

        private static bool VerifyExistence(string command, Type enumType) => Enum.IsDefined(enumType, command);

    }
}
