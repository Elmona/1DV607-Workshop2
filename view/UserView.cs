using System;

namespace View
{
    class UserView
    {
        public enum Event
        {
            ViewCompactList,
            ViewDetailedList,
            AddMember,
            None,
            Quit
        }

        public void DisplayInstructions()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.WriteLine("######################################");
            Console.WriteLine("#      Welcome to the Boat club.     #");
            Console.WriteLine("######################################");
            Console.WriteLine("");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. View Compact list of members");
            Console.WriteLine("2. View Detailed list of members");
            Console.WriteLine("3. Add member");
            Console.WriteLine("x. Quit");
            Console.Write("? ");
            
        }

        public Event GetInputEvent()
        {
            char inputtedCharacter = Console.ReadKey().KeyChar;

            if (inputtedCharacter == '1') return Event.ViewCompactList;
            if (inputtedCharacter == '2') return Event.ViewDetailedList;
            if (inputtedCharacter == '3') return Event.AddMember;
            if (inputtedCharacter == 'x') return Event.Quit;
            
            return Event.None;
        }

        public Model.Member AddMember(int id)
        {
            string name;
            long socialNumber;

            Console.WriteLine("\n");
            Console.WriteLine("You chose to add a member.");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Please fill in name.");
            Console.Write("? ");

            name = Console.ReadLine();

            do
            {
                Console.WriteLine("Please fill in social security number.");
                Console.WriteLine("Format: yymmddxxxx.");
                Console.Write("? ");
            } while (!long.TryParse(Console.ReadLine(), out socialNumber));

            return new Model.Member(name, id, socialNumber);
        }

        public void ViewMembers(string members)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("You chose to view all current members");
            Console.WriteLine("--------------------------------");
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
