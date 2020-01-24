using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Syntaxis
    {
        /// <summary>
        /// Validates the instruction typed in the console
        /// </summary>
        /// <param name="instruction">instruction typed in the console</param>
        /// <returns>Result that has information about the validity of the instruction</returns>
        public static Result ValidateInstruction(string instruction)
        {
            var result = new Result();
            var instructions = instruction.Split(' ');
            if (instructions.Length == 0)
            {
                result.ErrorList.Add(Common.formatError);
            }
            else
            {
                result.Instruction = new Instruction();
                if (VerifyExistence(instructions[0].ToLower(), typeof(Common.Command)))
                    result.Instruction.Command = Enum.Parse<Common.Command>(instructions[0].ToLower());
                else
                    result.ErrorList.Add(string.Format(Common.commandNotAvailable, ListEnum(typeof(Common.Command))));
                
                if(instructions.Length >= 2)
                {
                    if(VerifyExistence(instructions[1].ToLower(), typeof(Common.ShapeType)))
                        result.Instruction.ShapeType = Enum.Parse<Common.ShapeType>(instructions[1].ToLower());
                    else
                        result.ErrorList.Add(string.Format(Common.shapeNotAvailable, ListEnum(typeof(Common.ShapeType))));

                    if (result.Instruction.Command == Common.Command.add)
                    {
                        if (instructions.Length >= 3 && instructions.Length <= 4)
                        {
                            if (VerifyExistence(instructions[2].ToLower(), typeof(Common.Color)))
                                result.Instruction.Color = Enum.Parse<Common.Color>(instructions[2].ToLower());
                            else
                                result.ErrorList.Add(string.Format(Common.colorNotAvailable, ListEnum(typeof(Common.Color))));
                            if (instructions.Length == 4 && VerifyMeasurements(instructions[3].ToLower()))
                            {
                                result.Instruction.Measurements = getMeasurements(instructions[3]);
                                switch(result.Instruction.ShapeType)
                                {
                                    case Common.ShapeType.circle:
                                        if (result.Instruction.Measurements.Count != 1)
                                            result.ErrorList.Add(Common.circleMeasureError);
                                        break;
                                    case Common.ShapeType.rectangle:
                                    case Common.ShapeType.triangle:
                                        if (result.Instruction.Measurements.Count != 2)
                                            result.ErrorList.Add(Common.rectangleTriangleMeasureError);
                                        break;
                                    case Common.ShapeType.square:
                                        if (result.Instruction.Measurements.Count != 1)
                                            result.ErrorList.Add(Common.squareMeasureError);
                                        break;
                                    case Common.ShapeType.trapezoid:
                                        if (result.Instruction.Measurements.Count != 3)
                                            result.ErrorList.Add(Common.trapezoidMeasureError);
                                        break;
                                }
                            }
                            else
                                result.ErrorList.Add(Common.commaSeparatedMessage);
                        }
                        else
                            result.ErrorList.Add(Common.formatError);
                    }
                }
            }


            return result;
        }

        /// <summary>
        /// Will show in a formatted way the items in a specified enum
        /// </summary>
        /// <param name="enumType">Enum to be printed</param>
        /// <returns></returns>
        private static string ListEnum(Type enumType)
        {
            var enumItems = new StringBuilder();
            foreach (string name in Enum.GetNames(enumType))
                enumItems.Append(name + "|");
            return enumItems.ToString();
        }

        /// <summary>
        /// Verifies if the measurements are in the correct format and all numbers
        /// </summary>
        /// <param name="measurements"></param>
        /// <returns></returns>
        private static bool VerifyMeasurements(string measurements)
        {
            var mList = measurements.Split(',');
            foreach (var item in mList)
                if (!int.TryParse(item, out _)) return false;
            return true;
        }
        
        /// <summary>
        /// Returns a list of integers from the measurments in the instructions
        /// </summary>
        /// <param name="measurements"></param>
        /// <returns></returns>
        public static IList<int> getMeasurements(string measurements)
        {
            var intList = new List<int>();
            var mList = measurements.Split(',');
            foreach (var item in mList)
                intList.Add(int.Parse(item));
            return intList.ToArray();
        }

        /// <summary>
        /// Verifies if a given string is part of an Enum
        /// </summary>
        /// <param name="item"></param>
        /// <param name="enumType"></param>
        /// <returns></returns>
        private static bool VerifyExistence(string item, Type enumType) => Enum.IsDefined(enumType, item);

    }
}
