namespace CustomLinkedList;

public class LinkedTest : ILinkedTest
{
    public void AddToFront(T? item){
        if(string.IsNullOrEmpty(item)){
            throw new ArgumentNullException("Item cannot be empty");
        }
        List<Item> items = new();
        items.Add(item);
    }
    public void AddToEnd(T? item){
        if(string.IsNullOrEmpty(item)){
            throw new ArgumentNullException("Item cannot be empty");
        }
        List<Item> items = new();
        items.Add(item);
    }
    public int Count(List<Item> items){
        return items.Count();
    }
    public bool IsReadOnly{

    }
    public void Add(T? item);
    public bool Contains(T? item);
    void Copy(T?[] array, int arrayIndex);
    bool Remove(T? item)
    IEnumerator<T?> GetEnumerator();
    IEnumerator GetEnumerator();

}
