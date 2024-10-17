using System;
using System.Collections;
using System.Collections.Generic;

public interface ILinkedList<T> : ICollection<T>
{
    void AddToFront(T? item);
    void AddToEnd(T? item);
}

public class SinglyLinkedList<T> : ILinkedList<T>
{
    private class Node
    {
        public T? Data;
        public Node? Next;

        public Node(T? data)
        {
            Data = data;
            Next = null;
        }
    }

    private Node? head;
    private int count;

    public int Count => count;
    public bool IsReadOnly => false;

    public void AddToFront(T? item)
    {
        var newNode = new Node(item);
        newNode.Next = head;
        head = newNode;
        count++;
    }

    public void AddToEnd(T? item)
    {
        var newNode = new Node(item);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
        count++;
    }

    public void Add(T? item) => AddToEnd(item);

    public bool Contains(T? item)
    {
        Node? current = head;
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

    public void CopyTo(T?[] array, int arrayIndex)
    {
        if (array == null)
            throw new ArgumentNullException(nameof(array));
        if (arrayIndex < 0 || arrayIndex >= array.Length)
            throw new ArgumentOutOfRangeException(nameof(arrayIndex));
        if (array.Length - arrayIndex < count)
            throw new ArgumentException("Not enough space in the target array.");

        Node? current = head;
        while (current != null)
        {
            array[arrayIndex++] = current.Data;
            current = current.Next;
        }
    }

    public bool Remove(T? item)
    {
        if (head == null) return false;

        if (EqualityComparer<T?>.Default.Equals(head.Data, item))
        {
            head = head.Next;
            count--;
            return true;
        }

        Node? current = head;
        while (current.Next != null)
        {
            if (EqualityComparer<T?>.Default.Equals(current.Next.Data, item))
            {
                current.Next = current.Next.Next;
                count--;
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public IEnumerator<T?> GetEnumerator()
    {
        Node? current = head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
