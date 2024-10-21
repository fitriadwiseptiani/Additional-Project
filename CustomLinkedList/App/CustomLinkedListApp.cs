using System;
using System.Collections;
using System.Collections.Generic;
using CustomLinkedList.Enum;
using CustomLinkedList.App;
using CustomLinkedList.App.Repository;

namespace CustomLinkedList.App
{
    public class CustomLinkedListApp<T> : ICustomLinkedList<T>
    {
        private LinkedTest<T>? _linkedTest;
        private readonly IUserInteraction _ui;
        private readonly IAppInteraction _appUi;

        public CustomLinkedListApp(SinglyLinkedTest<T> singlyList, LinkedTest<T> linkedTest, IUserInteraction ui, IAppInteraction appUi)
        {
            _linkedTest = linkedTest;
            _ui = ui;
            _appUi = appUi;
        }

        public CustomLinkedListError ManageLinkedList(T? item)
        {
            while (true)
            {
                UserAction userAction = _appUi.ChooseAction();
                switch (userAction)
                {
                    case UserAction.AddToFront:
                        AddItemAtFront();
                        break;
                    case UserAction.AddToEnd:
                        AddItemToEnd();
                        break;
                    case UserAction.ShowItem:
                        DisplayItems();
                        break;
                    case UserAction.ValidateExistingItem:
                        ValidateExistingItem();
                        break;
                    case UserAction.RemoveItem:
                        RemoveItem();
                        break;
                    default:
                        _ui.WriteMessage("Invalid action. Please try again.");
                        break;
                }
                return CustomLinkedListError.NoError;
            }
        }

        private void AddItemAtFront()
        {
            _ui.WriteMessage("Enter the item to be placed on the front");
            string userInput = _ui.GetUserInput();
            if (!string.IsNullOrEmpty(userInput) && (TryParse(userInput, out T item)))
            {
                    _linkedTest.AddToFront(item);
                    _ui.WriteMessage("The item has been successfully added and placed on the front");
                }
                else
                {
                    _ui.WriteMessage("The input you provided does not match the type of item in question");
                }
            }


        private void AddItemToEnd()
        {
            _ui.WriteMessage("Enter the item to be placed on the end");
            string userInput = _ui.GetUserInput();
            if (!string.IsNullOrEmpty(userInput) && TryParse(userInput, out T item))
            {
                _linkedTest.AddToEnd(item);
                _ui.WriteMessage("The item has been successfully added and placed on the end");
            }
            else
            {
                _ui.WriteMessage("The input you provided does not match the type of item in question");
            }
        }


        private void DisplayItems()
        {
            var count = _linkedTest.Count();
            _ui.WriteMessage($"Total items: {count}");
            _ui.WriteMessage("The contents of this list are:");
            foreach (var item in _linkedTest)
            {
                _ui.WriteMessage(item.ToString());
            }
        }

        private void ValidateExistingItem()
        {
            _ui.WriteMessage("Enter the item in order to validate its existence");
            string userInput = _ui.GetUserInput();
            if (!string.IsNullOrEmpty(userInput) && TryParse(userInput, out T item)) 
            {

                    _ui.WriteMessage($"Is {userInput} in the list? " + _linkedTest.Contains(item));
                }
                else
                {
                    _ui.WriteMessage($"Sorry, {userInput} is not a valid input.");
                }
            }
        

        private void RemoveItem()
        {
            _ui.WriteMessage("Enter the item to be removed");
            string userInput = _ui.GetUserInput();
            if (!string.IsNullOrEmpty(userInput) && TryParse(userInput, out T parsedItem))
            {
                    _ui.WriteMessage($"Are you sure you want to remove {userInput} from the list? (y/n)");
                    string choice = _ui.GetUserInput();
                    if (choice.ToLower() == "y")
                    {
                        if (_linkedTest.Remove(parsedItem))
                        {
                            _ui.WriteMessage($"{userInput} has been successfully removed from the list");
                        }
                        else
                        {
                            _ui.WriteMessage($"{userInput} was not found in the list.");
                        }
                    }
            }
            else
            {
                _ui.WriteMessage("No input is given. You have to enter the item you want to delete.");
            }
        }

        private bool TryParse(string input, out T result)
        {
            try
            {
                result = (T)Convert.ChangeType(input, typeof(T));
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }
    }
}
