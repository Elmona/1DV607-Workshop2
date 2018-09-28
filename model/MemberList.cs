using System.Collections.Generic;

namespace Model
{
    class MemberList
    {
        private List<Member> members;
        private Model.Filesystem filesystem;

        public MemberList(Model.Filesystem f)
        {
            filesystem = f;
            members = f.GetData();
        }

        public void AddMember(Member member)
        {
            members.Add(member);
            filesystem.SaveData(members);
        }

        public List<Member> getData()
            => members;

        public override string ToString()
        {
            string result = "\n";
            members.ForEach(x => result += x.ToString() + "\n");
            return result;
        }
    }
}