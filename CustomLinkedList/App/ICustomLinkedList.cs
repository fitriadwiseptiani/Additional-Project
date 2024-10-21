using CustomLinkedList.Enum;
namespace CustomLinkedList.App;

public interface ICustomLinkedList<T>
{
    CustomLinkedListError ManageLinkedList(T? item);
}
