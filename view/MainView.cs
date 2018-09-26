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
            Console.WriteLine("Welcome to the boatclub!");
        }
    }
}
