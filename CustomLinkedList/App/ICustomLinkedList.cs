using CustomLinkedList.Enum;
namespace CustomLinkedList.App;

public interface ICustomLinkedList<T>
{
    CustomLinkedListError InsertNewItem(T? item);
}
