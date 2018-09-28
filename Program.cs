using System;
using Newtonsoft;

namespace BoatClub
{
    class Program
    {
        static void Main(string[] args)
        {
            var fs = new Model.Filesystem();
            var m = new Model.MemberList(fs);
            var v = new View.MainView();

            var mc = new Controller.MainController();

            while (mc.Start(v, m)) ;
        }
    }
}
