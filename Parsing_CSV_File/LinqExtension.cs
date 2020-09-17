using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Parsing_CSV_File
{
    public static class LinqExtension
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null)
                throw new ArgumentNullException();
            if (action == null)
                throw new ArgumentNullException();

            foreach (var item in source)
            {
                action(item);
            }
        }
    }
}
