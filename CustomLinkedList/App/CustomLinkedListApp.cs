using System;
using System.Collections;
using System.Collections.Generic;
using CustomLinkedList.Enum;
using CustomLinkedList.App;
using CustomLinkedList.App.Repository;

namespace CustomLinkedList.App;

public class CustomLinkedListApp<T> : ICustomLinkedList <T>
{
    private SinglyLinkedTest<T>? _singlyList;
    private LinkedTest<T>? _linkedTest;
    private readonly IUserInteraction _ui;
    private readonly IAppInteraction _appUi;

    public CustomLinkedListApp(SinglyLinkedTest<T> singlyList, LinkedTest<T> linkedTest, IUserInteraction ui, IAppInteraction appUi)
    {
        _singlyList = singlyList;
        _linkedTest = linkedTest;
        _ui = ui;
        _appUi = appUi;
    }
    public CustomLinkedListError InsertNewItem(T? item)
    {
        while (true)
        {
            UserAction userAction = _appUi.ChooseAction();
            if (userAction == UserAction.AddToFront)
            {
                _ui.WriteMessage("Enter the item to be placed on the front");
                string userInput = _ui.GetUserInput();
                if (string.IsNullOrEmpty(userInput))
                {
                    if (TryParse(userInput, out T item))
                    {
                        _linkedTest.AddToFront(item);
                        _ui.WriteMessage("The item has been successfully added and placed on the front");
                    }
                    else
                    {
                        _ui.WriteMessage("The input you provided does not match the type of item in question");
                    }
                } 
            }
            else if (userAction == UserAction.AddToEnd)
            {
                _ui.WriteMessage("Enter the item to be placed on the front");
                string userInput = _ui.GetUserInput();
                if (string.IsNullOrEmpty(userInput))
                {
                    if (TryParse(userInput, out T item))
                    {
                        _linkedTest.AddToEnd(item);
                _ui.WriteMessage("The item has been successfully added and placed on the end");
                    }
                    else
                    {
                        _ui.WriteMessage("The input you provided does not match the type of item in question");
                    }
            }
            else if (userAction == UserAction.ShowItem)
            {
                var count = _linkedTest.Count();
                _ui.WriteMessage("Total item:");
                _ui.WriteMessage(count);
                _ui.WriteMessage("The contents of this list are:");
            foreach (var item in _linkedTest)
            {
                _ui.WriteMessage(item);
            }
            }
            else if (userAction == UserAction.ValidateExistingItem)
            {
                _ui.WriteMessage("Enter the item in order to validate its existence");
                string userInput = _ui.GetUserInput();
                if (string.IsNullOrEmpty(userInput))
                {
                    _ui.WriteMessage($"Whether {userInput} is in the list? " + _linkedTest.Contains(item));
                }
                else
                {
                    _ui.WriteMessage($"Sorry {userInput} you are referring to is not in the list");
                }
            }
            else if (userAction == UserAction.RemoveItem)
            {
                _ui.WriteMessage("Enter the item in order to validate its existence");
                string userInput = _ui.GetUserInput();
                if (string.IsNullOrEmpty(userInput))
                {
                    _ui.WriteMessage($"Are sure want to remove {userInput} from the list? (y/n)");
                    string choice = _ui.GetUserInput();
                    if (choice.ToLower() == "y")
                    {
                        _linkedTest.Remove(item);
                        _ui.WriteMessage($"{userInput} has been successfully removed from the list");
                        PrintList(singlyList);
                    }
                    else
                    {
                        _ui.WriteMessage("The command you entered is incorrect");
                    }
                }
                else
                {
                    _ui.WriteMessage("No input is given. You have to enter the item you want to delete.");
                }
            }
        }
        return CustomLinkedListError.NoError;
    }
    public void PrintList()
    {
        Node<T> current = _singlyList.head;
        while (current != null)
        {
            _ui.WriteMessage(current.Data + " ");
            current = current.Next;
        }
        _ui.WriteMessage();
    }

}
