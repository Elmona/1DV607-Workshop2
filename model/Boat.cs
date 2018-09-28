using System;

namespace Model
{
    class Boat
    {
        private int _id;
        private BoatType _type;

        public Boat(int id, BoatType type)
        {
            Id = id;
            _type = type;
        }

        public BoatType Type { get => _type; }
        public int Id 
        { 
          get 
          {
            return _id;
          }
          private set
          {
            if (value > 0)
            {
              _id = value;
            }
            else
            {
              throw new ArgumentOutOfRangeException("Id of a boat must be a positive number! (Or not zero)");
            }
          }
        }

      public override string ToString() {
        return $"{this.Id.ToString()} | Boat of type {this.Type}";
      }




    // public override string ToString() =>
    //     $"First name: {this.firstName}, Last name: {this.lastName}, Age: {this.age}";
  }
}