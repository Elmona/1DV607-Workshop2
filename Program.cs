using System;
using Newtonsoft;

namespace BoatClub
{
    class Program
    {
        static void Main(string[] args)
        {
            var fs = new Model.Filesystem();
            var members = new Model.MemberList(fs.GetData());
            var mainView = new View.MainView(fs, members);

            mainView.Start();
        }
    }
}
