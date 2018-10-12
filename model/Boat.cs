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
        // public int Id
        // {
        //     get
        //     {
        //         return _id;
        //     }
        //     set
        //     {
        //         if (value > 0)
        //         {
        //             _id = value;
        //         }
        //         else
        //         {
        //             throw new ArgumentOutOfRangeException("Id of a boat must be a positive number! (Greater than zero)");
        //         }
        //     }
        // }

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

        public override string ToString()
        {
            return $"Boat of type {this.Type} | Length of boat: {this.Length}";
        }


    }



}