using System;
using System.Collections.Generic;

namespace Model
{
    class Member
    {
        private string _name;
        private int _memberId;
        private long _socialId;
        private List<Model.Boat> _boats;

        public Member(string name, int memberId, long socialId)
        {
            Name = name;
            MemberId = memberId;
            SocialId = socialId;
            _boats = new List<Boat> { };
        }

        public string Name
        {
            get { return _name; }
            private set
            {
                if (value.Length > 0)
                {
                    _name = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Name of a Member cannot be set to and empty string!");
                }
            }
        }

        private List<Model.Boat> Boats
        {
            set
            {
                _boats = value;
            }
        }

        public IEnumerable<Model.Boat> getBoats()
        {
            return this._boats;
        }

        public int MemberId
        {
            get { return _memberId; }
            set
            {
                if (value > 0)
                {
                    _memberId = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("MemberId of a member must be a positive number over 0");
                }
            }
        }

        public int getNumberOfBoats()
        {
            return this._boats.Count;
        }

        public bool hasBoats()
        {
            return _boats.Count > 0;
        }

        public void updateMember(Model.Member newMember)
        {
            if (newMember.SocialId > 1)
                this.SocialId = newMember.SocialId;

            if (newMember.Name != "x")
                this.Name = newMember.Name;
        }

        public long SocialId
        {
            get { return _socialId; }
            set
            {
                if (value > 0)
                {
                    _socialId = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("SocialId of a member must be a positive number over 0");
                }
            }
        }

        public void addBoat(Model.Boat boat)
        {
            _boats.Add(boat);
        }

        public bool removeBoat(int indexOfBoat)
        {
            bool boatFound = false;
            for (int i = 0; i < _boats.Count; i++)

                if (indexOfBoat <= _boats.Count && indexOfBoat >= 0)
                {
                    boatFound = true;
                    _boats.RemoveAt(indexOfBoat);
                }

            return boatFound;
        }

        public Model.Boat GetBoat(int indexOfBoat)
        {
            if (indexOfBoat <= _boats.Count && indexOfBoat >= 0)
            {
                return _boats[indexOfBoat];
            }
            else
            {
                return null;
            }
        }
    }
}