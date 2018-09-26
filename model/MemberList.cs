using System.Collections.Generic;

namespace Model
{
    class MemberList
    {
        private List<Member> members;

        public MemberList(List<Member> Members)
        {
            members = Members;
        }

        public void AddMember(Member member)
           => members.Add(member);

        public List<Member> getData()
            => members;
    }
}