using System;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            var shape = new Shape();
            while (!exit)
            {
                Console.Write(Common.writeCommandMessage);
                var command = Console.ReadLine();
                exit = command == "exit";
                if (exit) break;
                var result = Syntaxis.ValidateInstruction(command);

                if(result.IsValid)
                {
                    if (result.Instruction.Command == Common.Command.add)
                        shape.AddShape(result.Instruction.ShapeType.Value, result.Instruction.Color.Value, result.Instruction.Measurements);
                    else if (result.Instruction.Command == Common.Command.list)
                        Console.WriteLine(shape.PrintShapes(result.Instruction.ShapeType));
                }
                else
                {
                    Console.WriteLine(result.PrintErrors());
                }

                // var parameters = command.Split(' ');
                //var errorMessages = new List<string>();
                //if (parameters.Length > 0)
                //{
                //    if (!Common.VerifyExistence(parameters[0], typeof(Common.Command)))
                //    {
                //        errorMessages.Add($"Command not available. Please use: {Common.ListEnum(typeof(Common.Command))}");
                //    }
                //    else
                //    {
                //        if (parameters[0].ToLower() == "add")
                //        {
                //            if (parameters.Length < 4)
                //            {
                //                Console.WriteLine(formatError);
                //            }
                //            else
                //            {
                //                if (!Common.VerifyShapeType(parameters[1]))
                //                    errorMessages.Add($"Shape is not available. Please use: {Common.ListEnum(typeof(Common.ShapeType))}");
                //                if (!Common.VerifyColor(parameters[2]))
                //                    errorMessages.Add($"Color is not available. Please use: {Common.ListEnum(typeof(Common.Color))}");
                //                if (!Common.VerifyMeasurements(parameters[3]))
                //                    errorMessages.Add("Pease add numbers separated by commas");
                //                if (errorMessages.Count == 0)
                //                {
                //                    var shape = Enum.Parse(typeof(Common.ShapeType), parameters[1]);
                //                    int[] measurements = Common.getMeasurements(parameters[3]);
                //                    switch (shape)
                //                    {
                //                        case Common.ShapeType.circle:
                //                            if (measurements.Length == 1)
                //                                shapeList.Add(new Shapes.Circle
                //                                {
                //                                    Color = Enum.Parse<Common.Color>(parameters[2]),
                //                                    Radius = measurements[0]
                //                                });
                //                            else
                //                                errorMessages.Add("You need to add only the radius");
                //                            break;
                //                        case Common.ShapeType.rectangle:
                //                            if (measurements.Length == 2)
                //                                shapeList.Add(new Shapes.Rectangle
                //                                {
                //                                    Color = Enum.Parse<Common.Color>(parameters[2]),
                //                                    Base = measurements[0],
                //                                    Height = measurements[1]
                //                                });
                //                            else
                //                                errorMessages.Add("You need to add the base and height separated by commas");
                //                            break;
                //                        case Common.ShapeType.square:
                //                            if (measurements.Length == 1)
                //                                shapeList.Add(new Shapes.Square
                //                                {
                //                                    Color = Enum.Parse<Common.Color>(parameters[2]),
                //                                    Side = measurements[0]
                //                                });
                //                            else
                //                                errorMessages.Add("You need to add only the side");
                //                            break;
                //                        case Common.ShapeType.trapezoid:
                //                            if (measurements.Length == 3)
                //                                shapeList.Add(new Shapes.Trapezoid
                //                                {
                //                                    Color = Enum.Parse<Common.Color>(parameters[2]),
                //                                    Base1 = measurements[0],
                //                                    Base2 = measurements[1],
                //                                    Height = measurements[2]
                //                                });
                //                            else
                //                                errorMessages.Add("You need to add the base1, base2 and height separated by commas");
                //                            break;
                //                        case Common.ShapeType.triangle:
                //                            if (measurements.Length == 2)
                //                                shapeList.Add(new Shapes.Triangle
                //                                {
                //                                    Color = Enum.Parse<Common.Color>(parameters[2]),
                //                                    Base = measurements[0],
                //                                    Height = measurements[1]
                //                                });
                //                            else
                //                                errorMessages.Add("You need to add the base and height separated by commas");
                //                            break;
                //                    }
                //                }
                //            }

                //        }
                //        else if (parameters[0].ToLower() == "list" && parameters.Length == 1)
                //        {
                //            foreach (var shape in shapeList)
                //                Console.WriteLine(shape.ToString());
                //        }
                //        else if (parameters[0].ToLower() == "list" && parameters.Length == 2)
                //        {
                //            if (!Common.VerifyExistence(parameters[1], typeof(Common.ShapeType)))
                //                errorMessages.Add(string.Format(Common.shapeNotAvailable, Common.ListEnum(typeof(Common.ShapeType))));
                //            if (errorMessages.Count == 0)
                //            {
                //                foreach (var shape in shapeList.Where(x => x.GetType().Name.ToLower() == parameters[1].ToLower()))
                //                {
                //                    Console.WriteLine(shape.ToString());
                //                }
                //            }
                //        }
                //    }


                //    foreach (var message in errorMessages)
                //        Console.WriteLine(message);
                //}
                //else
                //{
                //    Console.WriteLine(Common.formatError);
                //}
            }
        }
    }
}