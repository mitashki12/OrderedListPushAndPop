using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OrderedList
{
    internal class QuickPushOrderedList<T> : IOrderedList<T>
        where T : IComparable
    {
        class ListElement
        {
            public ListElement? Next { get; set; }
            public ListElement? Previous { get; set; }
            public int Index { get; set; }

            public T Value { get; set; }


            public ListElement(T value, ListElement? next, ListElement? previous, int index)
            {
                Next = next;
                Previous = previous;
                Index = index;
                Value = value;

                if (previous != null)
                {
                    previous.Next = this;
                }
                if (next != null)
                {
                    next.Previous = this;
                }

            }
        }

        ListElement? top;
        ListElement? bottom;
        int length;

        internal QuickPushOrderedList()
        {
            top = bottom = null;
            length = 0;
        }

        public void Push(T obj)
        {
            if (length == 0)
            {
                top = bottom = new ListElement(obj, null, null, 0);
                length++;
            }
            else
            {
                ListElement newItem = new ListElement(obj, null, top, 0);
                top = newItem;
                top.Next = null;
                length++;
            }
        }

        public T Pop()
        {
            if (length == 0) throw new InvalidOperationException("The list is empty");
            if (length == 1)
            {
                T returnValue = top.Value;
                top = bottom = null;
                length--;
                return returnValue;
            }
            else
            {
                ListElement? maximalElement = bottom;
                ListElement? currentElement = bottom;
                while (currentElement != null)
                {
                    if (maximalElement.Value.CompareTo(currentElement.Value) < 0)
                    {
                        maximalElement = currentElement;
                    }
                    currentElement = currentElement.Next;

                }
                ListElement? previousElement = maximalElement.Previous;
                ListElement? nextElement = maximalElement.Next;
                if (previousElement != null) previousElement.Next = nextElement;
                if (nextElement != null) nextElement.Previous = previousElement;
                length--;
                if (maximalElement == top) top = maximalElement.Previous;
                if (maximalElement==bottom) bottom = maximalElement.Next;
                return maximalElement.Value;
            }
        }
    }
}
