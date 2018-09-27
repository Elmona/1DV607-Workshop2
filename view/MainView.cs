using System;

namespace View
{
    class MainView
    {
        public enum Event
        {
            None,
            View,
            Add
        }

        public void DisplayInstructions()
        {
            Console.Clear();
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
            if (c == '2') return Event.Add;

            return Event.None;
        }
    }
}
