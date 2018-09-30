using System;

namespace Model
{
  class Boat
  {
    private int _id;
    private int _length;
    private BoatType _type;

    public Boat(int id, BoatType type, int length)
    {
      Id = id;
      Length = length;
      _type = type;
    }

    public BoatType Type { get; set; }
    public int Id
    {
      get
      {
        return _id;
      }
      set
      {
        if (value > 0)
        {
          _id = value;
        }
        else
        {
          throw new ArgumentOutOfRangeException("Id of a boat must be a positive number! (Greater than zero)");
        }
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

    public override string ToString()
    {
      return $"{this.Id.ToString()} | Boat of type {this.Type} | Length of boat: {this.Length}";
    }


  }



}