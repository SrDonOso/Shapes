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
            }
        }
    }
}