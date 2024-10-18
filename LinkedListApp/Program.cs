using System;
using LinkedListApp;

class Program
{
    static void Main(string[] args)
    {
        var singlyList = new SingleLinkedList();
        var linkedList = new LinkedList();

        // Menambahkan elemen di depan
        linkedList.InsertFront(singlyList, 10);
        linkedList.InsertFront(singlyList, 20);
        linkedList.InsertFront(singlyList, 30);

        Console.WriteLine("List setelah menambahkan elemen di depan:");
        PrintList(singlyList);

        // Menambahkan elemen di belakang
        linkedList.InsertLast(singlyList, 40);
        linkedList.InsertLast(singlyList, 50);

        Console.WriteLine("List setelah menambahkan elemen di belakang:");
        PrintList(singlyList);

        // Menghapus node dengan key
        linkedList.DeleteNodebyKey(singlyList, 20);
        Console.WriteLine("List setelah menghapus elemen 20:");
        PrintList(singlyList);

        // Membalikkan linked list
        linkedList.ReverseLinkedList(singlyList);
        Console.WriteLine("List setelah dibalik:");
        PrintList(singlyList);
    }

    static void PrintList(SingleLinkedList singlyList)
    {
        Node current = singlyList.head;
        while (current != null)
        {
            Console.Write(current.data + " ");
            current = current.next;
        }
        Console.WriteLine();
    }
}
