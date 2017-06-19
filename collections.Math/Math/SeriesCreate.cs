using static System.Math;
using static System.Linq.Functional.Enumerable;
using System.Linq;

namespace System.Collections.Generic
{
    public static class SeriesCreate
    {
        public static IEnumerable<double> div(double divider, IEnumerable<double> items) => items.Select(i => i / divider);
        public static IEnumerable<double> mul(double multiplier, IEnumerable<double> items) => items.Select(i => i * multiplier);
        public static IEnumerable<double> sum(IEnumerable<double> items1, IEnumerable<double> items2) => items1.Zip(items2, (d, d1) => d + d1);
        public static IEnumerable<double> sum(params IEnumerable<double>[] items) => ZipIterator(i => i.Aggregate((d1, d2) => d1 + d2), items);
        public static IEnumerable<double> subst(IEnumerable<double> items1, IEnumerable<double> items2) => items1.Zip(items2, (d, d1) => d - d1);

        public static double[] Div(double divider, IEnumerable<double> items) => div(divider, items).ToArray();
        public static double[] Mul(double multiplier, IEnumerable<double> items) => mul(multiplier, items).ToArray();
        public static double[] Sum(IEnumerable<double> items1, IEnumerable<double> items2) => sum(items1, items2).ToArray();
        public static double[] Sum(params IEnumerable<double>[] items) => sum(items).ToArray();
        public static double[] Subst(IEnumerable<double> items1, IEnumerable<double> items2) => subst(items1, items2).ToArray();
        
        public static IEnumerable<double> series(double start, double end, int count)
        {
            double step = (end - start) / Abs(count - 1);
            double project(int value) => start + value * step;
            return Enumerable.Range(0, count).Select(project);
        }

        public static IEnumerable<T> series<T>(int start, int count, Func<int, T> selector) => Enumerable.Range(start, count).Select(selector);

        public static T[] Series<T>(double start, double end, int count, Func<double, T> selector)
            => series(start, end, count).Select(selector).ToArray();

        public static double[] Series(double start, double end, int count)
            => series(start, end, count).ToArray();

        public static int[] Series(int start, int end) => Enumerable.Range(start, end).ToArray();
        public static T[] Series<T>(int start, int count, Func<int, T> selector) => series(start, count, selector).ToArray();

        public static List<int> ListSeries(int start, int end) => Enumerable.Range(start, end).ToList();
        public static List<T> ListSeries<T>(int start, int end, Func<int, T> selector) => Enumerable.Range(start, end).Select(selector).ToList();
    }
}