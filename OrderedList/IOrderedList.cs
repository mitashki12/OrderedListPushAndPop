using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderedList
{
    internal interface IOrderedList<T>
        where T : IComparable
    {
        public void Push(T obj);

        public T Pop();
    }
}
