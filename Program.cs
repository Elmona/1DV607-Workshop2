using System;
using Newtonsoft;

namespace BoatClub
{
    class Program
    {
        static void Main(string[] args)
        {
            var fs = new Model.Filesystem();
            var Members = new Model.MemberList(fs.ReadFile());

            Members.AddMember(new Model.Member("Kalle", "Svensson", 15));

            fs.SaveData(Members.getData());
        }
    }
}
