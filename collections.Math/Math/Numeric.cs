using System.Collections.Generic;
using static System.Collections.Generic.Create;
namespace System.Functional.Memoize
{
    public static class Numeric
    {
        private static Dictionary<int, Dictionary<int, double>> _values = Dictionary<int, Dictionary<int, double>>();

        public static double MemoizeInt(Func<double> function, int capacity = 100)
          => MemoizeDouble(x => function(), 0, capacity);

        public static int MemoizeInt<T>(Func<T, int> function, T arg, int capacity = 100)
          => (int)MemoizeDouble(x => function(x), arg, capacity);

        public static double MemoizeDouble(Func<double> function, int capacity = 100)
          => MemoizeDouble(x => function(), 0, capacity);

        public static double MemoizeDouble<T>(Func<T, double> function, T arg, int capacity = 100)
        {
            Dictionary<int, double> dictionary;
            if (!_values.ContainsKey(function.GetHashCode()))
            {
                _values[function.GetHashCode()] = dictionary = Dictionary<int, double>(capacity);
            }
            else
            {
                dictionary = _values[function.GetHashCode()];
            }
            double integer;
            int hashCode = arg.GetHashCode();
            if (dictionary.ContainsKey(hashCode))
            {
                return dictionary[hashCode];
            }
            else
            {
                dictionary[hashCode] = integer = function(arg);
            }
            return integer;
        }
    }
}