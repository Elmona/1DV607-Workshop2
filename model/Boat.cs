using System;

namespace Model
{
    class Boat
    {
        private int _length;
        private Model.BoatType _type;

        public Boat(Model.BoatType type, int length)
        {
            Type = type;
            Length = length;
        }

        public BoatType Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        public int Length
        {
            get { return _length; }
            set
            {
                if (value > 0)
                {
                    _length = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Length of a boat must be a positive number! (Greater than zero)");
                }
            }
        }
    }
}