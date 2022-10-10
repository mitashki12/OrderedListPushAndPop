using OrderedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderedList
{
    internal class QuickPopOrderedList<T> : IOrderedList<T>
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

                if (next != null)
                {
                    next.Previous = this;
                }
                if (previous != null)
                {
                    previous.Next = this;
                }
            }
        }

        ListElement? top;
        ListElement? bottom;
        int length;

        internal QuickPopOrderedList()
        {
            top = bottom = null;
            length = 0;
        }

        public void Push(T obj)
        {
            ListElement currentElement;
            if (length == 0)
            {
                top = bottom = new ListElement(obj, null, null, 0);
                length++;
            }
            else
            {
                currentElement = bottom;
                bool elementInserted = false;
                for (int i = 0; i < length; i++)
                {
                    if (obj.CompareTo(currentElement.Value) < 0 && elementInserted == false)
                    {
                        ListElement newElement = new ListElement(obj, currentElement, currentElement.Previous, i);
                        if (currentElement == bottom)
                        {
                            bottom = newElement;
                        }
                        elementInserted = true;
                        currentElement.Index++;
                        length++;
                        continue;

                    }
                    else if (elementInserted == true)
                    {
                        currentElement.Index++;
                    }
                    else if(currentElement==top)
                    {
                        ListElement newElement = new ListElement(obj, null, currentElement, i+1);
                        elementInserted = true;
                        length++;
                        top = newElement;
                        break;
                    }
                    currentElement = currentElement.Next;
                }
            }
        }

        public T Pop() {
            if (length == 0) throw new InvalidOperationException("The list is empty");
            if (length == 1)
            {
                T returnValue = top.Value;
                bottom = top = null;
                length--;
                return returnValue;
            }
            else
            {
                T returnValue = top.Value;
                top = top.Previous;
                top.Next = null;
                length--;
                return returnValue;
            }
        }

        private ListElement? GetMiddleElement(int leftIndex, int rightIndex)
        {
            if (length == 0)
            {
                return null;
            }
            else if (length == 1)
            {
                return top;
            }
            else
            {
                return GetElementAtIndex(leftIndex + (rightIndex-leftIndex)/2);
            }
        }
        private ListElement? GetElementAtIndex(int index)
        {
            ListElement? currentElement = bottom;
            while (currentElement != null && currentElement.Index!=index)
            {
                currentElement = currentElement.Next;
                
            }
            return currentElement;
        }
    }
}
