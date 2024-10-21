using CustomLinkedList.Enum;
using System;
using System.Threading;

namespace CustomLinkedList.App.UI
{
    public class AppInteraction : IUserInteraction, IAppInteraction
    {
        public UserAction ChooseAction()
        {
            bool validInput = false;
            UserAction userAction = UserAction.AddToFront;
            while (!validInput)
            {
                WriteMessage("\nPlease choose one of this following actions:");
                WriteMessage("1. Insert Data In Front");
                WriteMessage("2. Insert Data In End");
                WriteMessage("3. Show List of Items");
                WriteMessage("4. Validate Existing Item");
                WriteMessage("5. Remove Item");
                WriteMessage("Your Input: ");
                string userInput = GetUserInput();
                try
                {
                    userAction = TryReadEnum<UserAction>(userInput);
                    validInput = true;
                }
                catch (ArgumentException)
                {
                    WriteMessage("Please input a valid number (1-5)");
                    Thread.Sleep(1000);
                }
            }
            return userAction;
        }

        public void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }

        public bool TryRead(string inputPlayer, out int id)
        {
            return Int32.TryParse(inputPlayer, out id);
        }

        public string GetUserInput()
        {
            return Console.ReadLine();
        }

        public int TryReadInt(string inputPlayer)
        {
            return Int32.Parse(inputPlayer);
        }

        public T TryReadEnum<T>(string input) where T : struct
        {
            if (Enum.TryParse(input, true, out T result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException("Invalid input for enum type");
            }
        }
    }
}
