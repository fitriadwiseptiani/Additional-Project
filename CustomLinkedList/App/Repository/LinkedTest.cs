using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomLinkedList.App.Repository
{
    public class LinkedTest<T> : ILinkedList<T>, IEnumerable<T>
    {
        private SinglyLinkedTest<T> _singlyList;

        public LinkedTest(SinglyLinkedTest<T> singlyList)
        {
            _singlyList = singlyList;
        }

        public void AddToFront(T? item)
        {
            Node<T> new_node = new Node<T>(item);
            new_node.Next = _singlyList.head;
            _singlyList.head = new_node;
        }

        public void AddToEnd(T? item)
        {
            Node<T> new_node = new Node<T>(item);
            if (_singlyList.head == null)
            {
                _singlyList.head = new_node;
                return;
            }
            Node<T> lastNode = GetLastNode();
            lastNode.Next = new_node;
        }

        public Node<T> GetLastNode()
        {
            Node<T> temp = _singlyList.head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            return temp;
        }

        public bool Remove(T? item)
        {
            Node<T> temp = _singlyList.head;
            Node<T>? prev = null;

            if (temp != null && EqualityComparer<T?>.Default.Equals(temp.Data, item))
            {
                _singlyList.head = temp.Next;
                return true;
            }

            while (temp != null && !EqualityComparer<T?>.Default.Equals(temp.Data, item))
            {
                prev = temp;
                temp = temp.Next;
            }

            if (temp == null) return false;

            prev.Next = temp.Next;
            return true;
        }

        public void Add(T? item)
        {
            AddToEnd(item);
        }

        public bool Contains(T? item)
        {
            var current = _singlyList.head;
            while (current != null)
            {
                if (EqualityComparer<T?>.Default.Equals(current.Data, item))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (arrayIndex < 0 || arrayIndex + Count > array.Length) throw new ArgumentOutOfRangeException(nameof(arrayIndex));

            var current = _singlyList.head;
            for (int i = 0; i < Count; i++)
            {
                array[arrayIndex + i] = current.Data;
                current = current.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = _singlyList.head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Clear()
        {
            _singlyList.head = null;
        }

        public int Count => GetCount();

        private int GetCount()
        {
            int count = 0;
            var current = _singlyList.head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }

        public bool IsReadOnly => false;
    }
}
