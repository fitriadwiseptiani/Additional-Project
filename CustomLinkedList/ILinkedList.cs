namespace CustomLinkedList;

public interface ILinkedList<T> : ICollection<T>
{
    void AddToFront(T item);
    void AddToEnt(T item);
}
