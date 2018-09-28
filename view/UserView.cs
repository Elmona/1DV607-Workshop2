using System;

namespace View
{
    class UserView
    {
        public enum Event
        {
            View,
            AddMember,
            None,
            Quit
        }

        public void DisplayInstructions()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.WriteLine("######################################");
            Console.WriteLine("#      Welcome to the Boat club.      #");
            Console.WriteLine("######################################");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. View members");
            Console.WriteLine("2. Add member");
            Console.WriteLine("x. Quit");
            Console.Write("? ");
        }

        public Event GetInputEvent()
        {
            char inputtedCharacter = Console.ReadKey().KeyChar;

            if (inputtedCharacter == '1') return Event.View;
            if (inputtedCharacter == '2') return Event.AddMember;
            if (inputtedCharacter == 'x') return Event.Quit;
            
            return Event.None;
        }

        public Model.Member AddMember()
        {
            string name;
            int socialNumber;

            Console.WriteLine("");
            Console.WriteLine("Adding new member.");
            Console.WriteLine("Fill in name.");
            Console.Write("? ");

            name = Console.ReadLine();

            do
            {
                Console.WriteLine("Fill in social security number 10 digits.");
                Console.Write("? ");
            } while (!int.TryParse(Console.ReadLine(), out socialNumber));

            return new Model.Member(name, "blaha", socialNumber);
        }

        public void ViewMembers(string members)
        {
            Console.WriteLine("");
            Console.WriteLine("Showing all members");
            Console.WriteLine("--------------------------------");
            Console.WriteLine(members);
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        public void ErrorInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine("Error in input");
            Console.WriteLine("Please press a character corresponding to one of the choices above.");
        }
    }
}
