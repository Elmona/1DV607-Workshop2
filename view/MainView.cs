using System;

namespace View
{
    class MainView
    {
        public enum Event
        {
            View,
            AddMember,
            None
        }

        public void DisplayInstructions()
        {
            Console.WriteLine("");
            Console.WriteLine("######################################");
            Console.WriteLine("#      Welcome to the Boatclub.      #");
            Console.WriteLine("######################################");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. View members");
            Console.WriteLine("2. Add member");
            Console.Write("? ");
        }

        public Event GetEvent()
        {
            char c = Console.ReadKey().KeyChar;

            if (c == '1') return Event.View;
            if (c == '2') return Event.AddMember;

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
            Console.WriteLine(members);
        }
    }
}
