using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhlSystem
{
    // Define a class name Player that inherits from the Person base class
    public class Player : Person
    {
        // Define an fully-implemented property with a backing field for PrimaryNo
        private int _primaryNo;
        public int PrimaryNo
        {
            get
            {
                return _primaryNo;
            }
            set
            {
                // Validate the new value is between 0 and 98
                if (value < 0 || value > 98)
                {
                    throw new ArgumentOutOfRangeException("PrimaryNo must between 0 and 98");
                }
                _primaryNo = value;
            }
        }

        // Define auto-implemented properties for Position, Goals, Assists, PrimaryNo
        public Position Position { get; set; }  
        public int Goals { get; set; }
        public int Assists { get; set; }
        

        // Define a read-only computed property for Points
        public int Points
        {
            get
            {
                return Goals + Assists;
            }
        }

        // Define constructor that passes fullName to base class
        public Player(string fullName, Position position, int primaryNo) : base(fullName)
        {
            Position = position;
            PrimaryNo = primaryNo;
            Goals = 0;
            Assists = 0;
        }
        public Player(string fullName, Position position, int primaryNo, int goals, int assists) : base(fullName)
        {
            Position = position;
            PrimaryNo = primaryNo;
            Goals = goals;
            Assists = assists;
        }

        public override string ToString()
        {
            return $"{FullName},{PrimaryNo},{Position},{Goals},{Assists},{Points}";
        }
    }
}
