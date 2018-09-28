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
            _boats = new List<Boat>{};
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

        public long SocialId
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

        public void addBoat (Model.Boat boat)
        {
            _boats.Add(boat);
        }

        public bool removeBoat(int id)
        {
            bool boatFound = false;
            for ( int i = 0; i < _boats.Count; i++ )
            {
                if (_boats[i].Id == id)
                {
                    boatFound = true;
                    _boats.RemoveAt(i);
                }
            }
            return boatFound;
        }

        public Model.Boat GetBoat(int id)
        {
            for ( int i = 0; i < _boats.Count; i++ )
            {
                if (_boats[i].Id == id)
                {
                    // returnBoat = _boats[i];
                    return _boats[i];
                }
            }
            return null;
        }



        // DEPRECATED
        // TODO: use toStringCompact() and toStringVerbose() instead
        public override string ToString() =>
            $"Name is: {this.Name}, MemberId: {this.MemberId}, SocialId: {this.SocialId}, Number of boats: {this._boats.Count}";

        public string toStringCompact()
        {
            return $"Name is: {this.Name}, MemberId: {this.MemberId}, SocialId: {this.SocialId}, Number of boats: {this._boats.Count}\n";
        }

        public string toStringVerbose()
        {
            string returnString = $"Name is: {this.Name}, MemberId: {this.MemberId}, SocialId: {this.SocialId}, Number of boats: {this._boats.Count}\n";
            for (int i = 0; i < _boats.Count; i++)
            {
                returnString += $"--- Boat number {i} | ID - {_boats[i].Id} | Length - {_boats[i].Length} | Type - {_boats[i].Type} \n";
            }
            return returnString;
        }

        
    }
}