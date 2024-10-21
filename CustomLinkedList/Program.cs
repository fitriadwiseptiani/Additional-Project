// using System;
// namespace CustomLinkedList;
// class Program
// {
//     static void Main(string[] args)
//     {
//         var singlyList = new SinglyLinkedTest<int>();
//         var linkedTest = new LinkedTest<int>(singlyList);

//         linkedTest.AddToFront(20);
//         linkedTest.AddToFront(50);
//         linkedTest.AddToFront(70);

//         Console.WriteLine("List setelah menambahkan elemen di depan:");
//         PrintList(singlyList);

//         linkedTest.AddToEnd(109);
//         linkedTest.AddToEnd(87);
//         linkedTest.AddToEnd(189);
//         Console.WriteLine("List setelah menambahkan elemen di belakang:");
//         PrintList(singlyList);

//         linkedTest.Remove(20);
//         Console.WriteLine("List setelah menghapus elemen 20:");
//         PrintList(singlyList);

//         var count = linkedTest.Count();
//         Console.WriteLine("Total item:");
//         Console.WriteLine(count);

//         Console.WriteLine("Apakah 20 ada di list? " + linkedTest.Contains(70));

//         int[] array = new int[5];
//             linkedTest.CopyTo(array, 0);
//             Console.WriteLine("Isi array setelah disalin:");
//             foreach (var item in array)
//             {
//                 Console.Write(item + " ");
//             }
//             Console.WriteLine();

        
//         Console.WriteLine("Isi linked list:");
//             foreach (var item in linkedTest)
//             {
//                 Console.WriteLine(item);
//             }
//     }
//     static void PrintList(SinglyLinkedTest<int> singlyList)
//     {
//         Node<int> current = singlyList.head;
//         while (current != null)
//         {
//             Console.Write(current.Data + " ");
//             current = current.Next;
//         }
//         Console.WriteLine();
//     }
//     static void 
// }
using CustomLinkedList.App;
using CustomLinkedList.App.Repository;
using CustomLinkedList.App.UI;
namespace CustomLinkedList{
    class Program{
        static void Main(){
            SinglyLinkedTest<int> singlyList = new SinglyLinkedTest<int>();
            LinkedTest<int> linkedTest = new LinkedTest<int>(singlyList);
            IUserInteraction ui= new ConsoleUserInteraction();
            IAppInteraction appUi = new AppInteraction();

            ICustomLinkedList<int> customLinkedList = new CustomLinkedListApp<int>(singlyList, linkedTest, ui, appUi);
            try{
                var result = customLinkedList.ManageLinkedList(default);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
        }
    }
}