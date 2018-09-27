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

            var inputView = new InputView("Make your choice!");
            inputView.AddChoice("Do you pick the first?");
            inputView.AddChoice("Or the second?");
            result = inputView.Run();

            Console.WriteLine($"You picked: {result}");
        }
    }
}
