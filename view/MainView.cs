using System;

namespace View
{
    class MainView
    {
        private Model.Filesystem fs;
        private Model.MemberList memberList;

        public MainView(Model.Filesystem Fs, Model.MemberList MemberList)
        {
            fs = Fs;
            memberList = MemberList;
        }

        public void Start()
        {
            byte result;

            Console.WriteLine("Welcome to the boatclub!");

            var i = new Input("Make your choice!");
            i.AddChoice("Do you pick the first?");
            i.AddChoice("Or the second?");
            result = i.Run();

            Console.WriteLine($"You picked: {result}");
        }
    }
}
