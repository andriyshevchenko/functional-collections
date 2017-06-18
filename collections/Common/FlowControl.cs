using System;
using System.Collections.Generic;
using System.Text;

namespace System.Functional
{
    public static class FlowControl
    {
        public static void Switch<T>(
            T on,
            Action<T> @default,
            params (T, Action<T>)[] labels
            ) where T : IEquatable<T>
        {
            check(@default);

            int i = 0;
            bool notfound = false;
            while (i < labels.Length &&
                  (notfound = !on.Equals(labels[i].Item1)))
            {
                i++;
            }
            if (notfound)
            {
                @default?.Invoke(on);
            }
            else
            {
                labels[i].Item2?.Invoke(on);
            }
        }

        public static void Switch<T>(
            T on,
            Action<T> @default,
            params KeyValuePair<T, Action<T>>[] labels
            ) where T : IEquatable<T>
        {
            check(@default);
            int i = 0;
            bool notfound = false;
            while (i < labels.Length &&
                  (notfound = !on.Equals(labels[i].Key)))
            {
                i++;
            }
            if (notfound)
            {
                @default?.Invoke(on);
            }
            else
            {
                labels[i].Value?.Invoke(on);
            }
        }

        public static void Switch<T>(
           T on,
           Action<T> @default,
           params Tuple<T, Action<T>>[] labels
           ) where T : IEquatable<T>
        {
            check(@default);
            int i = 0;
            bool notfound = false;
            while (i < labels.Length &&
                  (notfound = !on.Equals(labels[i].Item1)))
            {
                i++;
            }
            if (notfound)
            {
                @default?.Invoke(on);
            }
            else
            {
                labels[i].Item2?.Invoke(on);
            }
        }

        private static void check<T>(Action<T> @default) where T : IEquatable<T>
        {
            if (@default == null)
            {
                throw new ArgumentNullException(nameof(@default));
            }
        }
    }
}
