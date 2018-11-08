using System.Collections.Generic;

namespace Model
{
    class MemberList
    {
        private List<Member> _members;

        public MemberList(List<Member> members)
        {
            _members = members;
        }

        public void addMember(Member member)
        {
            member.MemberId = this.getNextId();
            _members.Add(member);
        }

        public IEnumerable<Member> getMemberList() => _members;

        public Member getMemberById(int id)
        {
            foreach (var member in _members)
            {
                if (member.MemberId == id)
                {
                    return member;
                }
            }
            return null;
        }

        public bool removeMember(int id)
        {
            bool memberFound = false;
            for (int i = 0; i < _members.Count; i++)
            {
                if (_members[i].MemberId == id)
                {
                    memberFound = true;
                    _members.RemoveAt(i);
                }
            }
            return memberFound;
        }

        private int getNextId()
        {
            int maxValue = 1;
            foreach (var member in _members)
            {
                if (member.MemberId >= maxValue)
                {
                    maxValue = member.MemberId + 1;
                }
            }
            return maxValue;
        }
    }
}