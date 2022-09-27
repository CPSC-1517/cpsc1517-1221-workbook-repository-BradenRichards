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
        public Player(string fullName, Position position, int primaryNo) : base(fullName)
        {
            Position = position;
            PrimaryNo = primaryNo;
            Goals = 0;
            Assists = 0;
        }


        public Player(string fullName ,Position position, int goals, int assists, int primaryNo) : base(fullName)
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

        public static Player ParseCsv(string line)
        {
            //Define a constant for the Delimiter character
            const char Delimiter = ',';
            //Split the line into an array where each value is seperated by a Delimiter
            string[] tokens = line.Split(Delimiter);
            //The columns in the line are in this order:
            // 1) Player Name
            /* 2) Player Number
                3) Player Positions
                4) Goals
                5}Assists
                6)Points
            */
            //Verify that there are six elements in the array
            if (tokens.Length != 6)
            {
                throw new FormatException($"CSV line must contain exactly 6 values. {line}");
            }
            string playerName = tokens[0];
            int playerNumber = int.Parse(tokens[1]);
            Position position = (Position) Enum.Parse(typeof(Position), tokens[2]);
            int goals = int.Parse(tokens[3]);
            int assists = int.Parse(tokens[4]);
            return new Player(
                fullName: playerName,
                primaryNo: playerNumber,
                position: position,
                goals: goals,
                assists: assists);
        }

        public static bool TryParse(string line, out Player player)
        {
            bool success = false;

            try
            {
                player = ParseCsv(line);
                success = true;
            }
            catch(FormatException ex)
            {
                throw new FormatException(ex.Message);
            }
            catch(Exception ex)
            {
                throw new Exception($"Player TryParse exception {ex.Message}");
            }
            return success;
        }
    }
}
