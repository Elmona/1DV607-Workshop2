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
            _members.Add(member);
        }

        public List<Member> getMemberList() => _members;

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
            for ( int i = 0; i < _members.Count; i++ )
            {
                if (_members[i].MemberId == id)
                {
                    memberFound = true;
                    _members.RemoveAt(i);
                }
            }
            return memberFound;
        }

        public int getNextId()
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

        public string toStringCompact() 
        {
            string returnString = "";
            foreach (var member in _members)
            {
                returnString += member.toStringCompact();
            }
            return returnString;
        }

        public string toStringVerbose() 
        {
            string returnString = "";
            foreach (var member in _members)
            {
                returnString += member.toStringVerbose();
            }
            return returnString;
        }

        public override string ToString()
        {
            string result = "\n";
            _members.ForEach(x => result += x.ToString() + "\n");
            return result;
        }
    }
}