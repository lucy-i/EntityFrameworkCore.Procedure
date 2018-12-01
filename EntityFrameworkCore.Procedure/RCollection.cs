using System;
using System.Collections.Generic;

namespace EntityFrameworkCore.Procedure
{
    /// <summary>
    /// Extended Type to store List Collection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RCollection<T> : List<T> where T : class, new()
    {
        public readonly Type type;

        public RCollection()
        {
            type = typeof(T);
        }

        public RCollection(IEnumerable<T> collection) : base(collection)
        {
            type = typeof(T);
        }

        public RCollection(int capacity) : base(capacity)
        {
            type = typeof(T);
        }
    }
}
