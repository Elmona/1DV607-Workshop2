using System;

namespace Model
{
    class Member
    {
        private string _name;
        private int _memberId;
        private int _socialId;

        public Member(string name, int memberId, int socialId)
        {
            Name = name;
            MemberId = memberId;
            SocialId = socialId;
        }

        public string Name 
        {
            get { return _name; }
            private set
            {
                if ( value.Length > 0)
                {
                    _name = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Name of a Member cannot be set to and empty string!");
                }
            } 
        }

        public int MemberId
        {
            get { return _memberId; }
            set {
                if ( value > 0)
                {
                    _memberId = value;
                }
                else 
                {
                    throw new ArgumentOutOfRangeException("MemberId of a member must be a positive number over 0");
                }
            }
        }

        public int SocialId
        {
            get { return _socialId; }
            set {
                if ( value > 0)
                {
                    _socialId = value;
                }
                else 
                {
                    throw new ArgumentOutOfRangeException("SocialId of a member must be a positive number over 0");
                }
            } 
        }
        // DEPRECATED
        // TODO: use toStringCompact() and toStringVerbose() instead
        public override string ToString() =>
            $"Name is: {this.Name}, MemberId: {this.MemberId}, SocialId: {this.SocialId}";

        public string toStringCompact()
        {
            return $"Name is: {this.Name}, MemberId: {this.MemberId}, SocialId: {this.SocialId}";
        }

        
    }
}