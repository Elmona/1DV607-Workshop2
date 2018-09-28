﻿using System;
using Newtonsoft;

namespace BoatClub
{
    class Program
    {
        static void Main(string[] args)
        {
            var fs = new Model.Filesystem();
            var memberlist = fs.GetData();
            var m = new Model.MemberList(memberlist);
            var v = new View.UserView();

            var mc = new Controller.MainController();

            while (mc.Start(v, m)) ;
        }
    }
}
