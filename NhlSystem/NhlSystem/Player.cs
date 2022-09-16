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

        public int PrimaryNo { get; set; }

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
    }
}
