using MarsRover.Model.Enums;
using MarsRover.Service.DirectionStates;
using MarsRover.Service.InputParserStates;
using MarsRover.Service.InstructionStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MarsRover.Service.Helpers
{
    public static class StateExtension
    {
        private static readonly IEnumerable<Instruction> _instruction = GetEnumerableOfType<Instruction>();
        private static readonly IEnumerable<Direction> _direction = GetEnumerableOfType<Direction>();

        public static Instruction ToInstructionState(this InstructionType instruction)
        {
            return _instruction.SingleOrDefault(x => x.InstructionType.Equals(instruction)) ?? throw new Exception($"Wrong instruction: {instruction}");
        }

        public static Direction ToDirectionState(this DirectionType direction)
        {
            return _direction.SingleOrDefault(x => x.DirectionType.Equals(direction)) ?? throw new Exception($"Wrong direction: {direction}");
        }
        public static InputParser ToInputParserState(this string input, params object[] constructorArgs)
        {
            var inputParserState = GetEnumerableOfType<InputParser>(constructorArgs).SingleOrDefault(x => x.IsMatch(input));
            return inputParserState ?? throw new Exception($"Wrong input: {input}");
        }

        public static IEnumerable<T> GetEnumerableOfType<T>(params object[] constructorArgs)
        {
            List<T> objects = new List<T>();
            foreach (Type type in
                Assembly.GetAssembly(typeof(T)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
            {
                objects.Add((T)Activator.CreateInstance(type, constructorArgs));
            }
            return objects;
        }
    }
}
