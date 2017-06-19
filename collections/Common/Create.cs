using static System.Linq.Functional.Enumerable;
using System.Linq;

namespace System.Collections.Generic
{
    /// <summary>  
    ///  Required to add using static System.Collections.Generic.Create; to your code to use this class 
    /// </summary> 
    public static class Create
    {
        public static HashSet<object> set(params object[] items) => new HashSet<object>(items);
        public static HashSet<T> set<T>(IEnumerable<T> items) => new HashSet<T>(items);
        public static HashSet<T> set<T>(params T[] items) => new HashSet<T>(items);

        public static KeyValuePair<object, object> two(object key, object value) => new KeyValuePair<object, object>(key, value);
        public static KeyValuePair<K, V> pair<K, V>(K key, V value) => new KeyValuePair<K, V>(key, value);

        public static Dictionary<K, V> dictionary<K, V>(int capacity) => new Dictionary<K, V>(capacity);
        public static Dictionary<K, V> dictionary<K, V>() => new Dictionary<K, V>();
        public static Dictionary<K, V> dictionary<K, V>(params KeyValuePair<K, V>[] items) => dictionary((IEnumerable<KeyValuePair<K, V>>)items);
        public static Dictionary<K, V> dictionary<K, V>(IEnumerable<KeyValuePair<K, V>> items) => items.ToDictionary(_ => _.Key, _ => _.Value);
        public static Dictionary<K, V> dictionary<K, V>(params ValueTuple<K, V>[] items) => dictionary((IEnumerable<ValueTuple<K, V>>)items);
        public static Dictionary<K, V> dictionary<K, V>(IEnumerable<ValueTuple<K, V>> items) => items.ToDictionary(_ => _.Item1, _ => _.Item2);

        public static Dictionary<object, object> dictionary() => new Dictionary<object, object>();
        public static Dictionary<object, object> dictionary(params KeyValuePair<object, object>[] items) => items.ToDictionary(_ => _.Key, _ => _.Value);

        public static T[][] matrix<T>(IEnumerable<IEnumerable<T>> items) => items.Select(Linq.Enumerable.ToArray).ToArray();

        public static T[] array<T>(int size) => new T[size];
        public static T[] array<T>(IQueryable<T> items) => items.ToArray();
        public static T[] array<T>(IOrderedQueryable<T> items) => items.ToArray();
        public static T[] array<T>(IOrderedEnumerable<T> items) => items.ToArray();
        public static T[] array<T>(IEnumerable<T> items) => items.ToArray();
        public static T[] array<T>(params T[] items) => items;
        public static object[] array(params object[] items) => items;

        public static IEnumerable<T> part<T>(T[] items, int start, int end) => PartIterator(items, start, end);
        public static IEnumerable<T> part<T>(T[] items, int end) => PartIterator(items, 0, end);
        public static IEnumerable<T> partEnd<T>(T[] items, int start) => PartIterator(items, start, items.Length);

        public static T[] Part<T>(T[] items, int start, int end) => PartIterator(items, start, end).ToArray();
        public static List<T> partList<T>(List<T> items, int start, int end) => PartIterator(items, start, end).ToList();

        public static T[] PartEnd<T>(T[] items, int start) => PartIterator(items, start, items.Length).ToArray();
        public static T[] Part<T>(T[] items, int end) => PartIterator(items, 0, end).ToArray();

        public static IEnumerable<T> enumerable<T>(params T[] items) => items;

        public static IEnumerable<(K, T)> tupleZip<K, T>(IEnumerable<K> first, IEnumerable<T> second) => first.Zip(second, (one, two) => (one, two));
        public static (K, T)[] TupleZip<K, T>(IEnumerable<K> first, IEnumerable<T> second) => tupleZip(first, second).ToArray();
        public static List<(K, T)> TupleZipList<K, T>(IEnumerable<K> first, IEnumerable<T> second) => tupleZip(first, second).ToList();

        public static IEnumerable<(K, T, S)> tupleZip<K, T, S>(IEnumerable<K> first, IEnumerable<T> second, IEnumerable<S> third) => ZipIterator(first, second, third, (one, two, three) => (one, two, three));
        public static (K, T, S)[] TupleZip<K, T, S>(IEnumerable<K> first, IEnumerable<T> second, IEnumerable<S> third) => tupleZip(first, second, third).ToArray();
        public static List<(K, T, S)> TupleZipList<K, T, S>(IEnumerable<K> first, IEnumerable<T> second, IEnumerable<S> third) => tupleZip(first, second, third).ToList();

        public static List<T> zip<T>(params List<T>[] items) => ZipIterator(items).ToList();
        public static T[] zip<T>(params T[][] items) => ZipIterator(items).ToArray();

        public static List<object> zip(params List<object>[] items) => zip(items);
        public static object[] zip(params object[][] items) => zip(items);

        public static K[] first<K, T>(IEnumerable<(K, T)> source) => source.Select(tuple => tuple.Item1).ToArray();
        public static T[] second<K, T>(IEnumerable<(K, T)> source) => source.Select(tuple => tuple.Item2).ToArray();

        public static List<T> list<T>() => new List<T>();
        public static List<T> list<T>(IEnumerable<T> items) => new List<T>(items);
        public static List<T> list<T>(params T[] items) => items.ToList();
        public static List<object> list(params object[] items) => items.ToList();
    }
}