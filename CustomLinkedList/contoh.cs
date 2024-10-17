using System;
using System.Collections;
using System.Collections.Generic;

// Interface definition for a linked list
public interface ILinkedList<T> : ICollection<T>
{
    void AddToFront(T? item);
    void AddToEnd(T? item);
}

// Singly linked list implementation
public class SinglyLinkedList<T> : ILinkedList<T>
{
    private class Node
    {
        public T? Value; // Changed from Data to Value for clarity
        public Node? NextNode; // Changed from Next to NextNode for clarity

        public Node(T? value)
        {
            Value = value;
            NextNode = null;
        }
    }

    private Node? headNode; // Changed from head to headNode for clarity
    private int itemCount; // Changed from count to itemCount for clarity

    // Property to get the count of items in the list
    public int Count => itemCount;

    // Property to indicate if the list is read-only
    public bool IsReadOnly => false;

    // Add an item to the front of the list
    public void AddToFront(T? item)
    {
        var newNode = new Node(item)
        {
            NextNode = headNode // Set the next node to the current head
        };
        headNode = newNode; // Update head to the new node
        itemCount++;
    }

    // Add an item to the end of the list
    public void AddToEnd(T? item)
    {
        var newNode = new Node(item);
        if (headNode == null)
        {
            headNode = newNode; // List is empty, new node becomes the head
        }
        else
        {
            Node currentNode = headNode; // Changed from current to currentNode for clarity
            while (currentNode.NextNode != null)
            {
                currentNode = currentNode.NextNode; // Traverse to the last node
            }
            currentNode.NextNode = newNode; // Link the new node at the end
        }
        itemCount++;
    }

    // Add an item to the end (same as AddToEnd)
    public void Add(T? item) => AddToEnd(item);

    // Check if the list contains the specified item
    public bool Contains(T? item)
    {
        Node? currentNode = headNode; // Changed from current to currentNode for clarity
        while (currentNode != null)
        {
            if (EqualityComparer<T?>.Default.Equals(currentNode.Value, item))
            {
                return true; // Item found
            }
            currentNode = currentNode.NextNode; // Move to the next node
        }
        return false; // Item not found
    }

    // Copy the list items to a specified array starting at the given index
    public void CopyTo(T?[] array, int arrayIndex)
    {
        if (array == null)
            throw new ArgumentNullException(nameof(array));
        if (arrayIndex < 0 || arrayIndex >= array.Length)
            throw new ArgumentOutOfRangeException(nameof(arrayIndex));
        if (array.Length - arrayIndex < itemCount)
            throw new ArgumentException("Not enough space in the target array.");

        Node? currentNode = headNode; // Changed from current to currentNode for clarity
        while (currentNode != null)
        {
            array[arrayIndex++] = currentNode.Value; // Copy the current node's value
            currentNode = currentNode.NextNode; // Move to the next node
        }
    }

    // Remove the first occurrence of the specified item from the list
    public bool Remove(T? item)
    {
        if (headNode == null) return false; // List is empty

        // Check if the item to remove is the head
        if (EqualityComparer<T?>.Default.Equals(headNode.Value, item))
        {
            headNode = headNode.NextNode; // Move head to the next node
            itemCount--;
            return true; // Item removed
        }

        Node? currentNode = headNode; // Changed from current to currentNode for clarity
        while (currentNode.NextNode != null)
        {
            if (EqualityComparer<T?>.Default.Equals(currentNode.NextNode.Value, item))
            {
                currentNode.NextNode = currentNode.NextNode.NextNode; // Bypass the node to remove
                itemCount--;
                return true; // Item removed
            }
            currentNode = currentNode.NextNode; // Move to the next node
        }
        return false; // Item not found
    }

    // Return an enumerator for iterating over the list
    public IEnumerator<T?> GetEnumerator()
    {
        Node? currentNode = headNode; // Changed from current to currentNode for clarity
        while (currentNode != null)
        {
            yield return currentNode.Value; // Return the current node's value
            currentNode = currentNode.NextNode; // Move to the next node
        }
    }

    // Non-generic enumerator
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
