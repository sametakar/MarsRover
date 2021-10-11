using System;
using System.Collections.Generic;

namespace MarsRover.Service.Helpers
{
    public static class EnumExtension
    {
        public static T ToEnum<T>(this string text) where T : struct
        {
            if (!Enum.TryParse(text, out T result))
                throw new ArgumentOutOfRangeException($"Wrong {typeof(T).Name}: {text}");

            return result;
        }
        public static IEnumerable<T> ToEnumList<T>(this string instructions) where T : struct
        {
            List<T> list = new List<T>();
            foreach (var instruction in instructions)
            {
                list.Add(instruction.ToString().ToEnum<T>());
            }

            return list;
        }
        
    }
}
