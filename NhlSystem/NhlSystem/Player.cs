using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhlSystem
{
    public class Player : Person
    {

        public Position Position { get; set; }

        public int Goals { get; set; }

        public int Assists { get; set; }

        //public int PrimaryNo { get; set; }

        public int _primaryNo;
        //public int PrimaryNo;


        //define a fully implemente property with a backing field for primaryNo
        public int PrimaryNo
        {
            get
            {
              return _primaryNo;
            }
            set
            {
                //Validate the new number is between 0 and 98
                if (value < 0 || value > 98)
                {
                    throw new ArgumentOutOfRangeException("PrimaryNo must be between 0 and 98");
                }
                _primaryNo = value;
            }
        }

        public int Points
        {
            get
            {
                return Goals + Assists;
            }
        }

        //Define a constructor that passes fullName to base class
        public Player(string _fullName, Position position, int primaryNo) : base(_fullName)
        {
            Position = position;
            PrimaryNo = primaryNo;
            Goals = 0;
            Assists = 0;
        }


        public Player(string _fullName ,Position position, int goals, int assists, int primaryNo) : base(_fullName)
        {
            Position = position;
            Goals = goals;
            Assists = assists;
            PrimaryNo = primaryNo;
        }

        public override string ToString()
        {
            return $"{FullName}, {PrimaryNo}, {Position}, {Goals}, {Assists}, {Points}";
        }

    }
}
