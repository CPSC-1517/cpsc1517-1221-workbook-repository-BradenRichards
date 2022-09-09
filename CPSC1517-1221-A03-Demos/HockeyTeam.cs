using System;
using static HockeyTeam;
/*Ask Sam about the code thats here on his thing*/

namespace OOPReview1
{

    public class NhlTeam
    {
        //Define an auto-implemented property with a private set
        // For the Conference of type NHLConference

        public NhlConference Conference { get; private set; }

        //Define an auto-implemented property with a private set
        //for the Division of type NhlDivision

        public NhlDivision Division { get; private set; }

        //Define a fully-implemented property for the Name of type string
        //Validate that the new name is not null or an empty string or
        //Contains just whitespaces
        //Trim all leading and trailing whitespaces
        private string _name; //Field for the name property

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) // <== If name is null or empty throw exception
                {
                    throw new ArgumentNullException("Name must contain text");
                }
                _name = value.Trim(); // <=== Trims leading and trailing whitespace

            }
        }

        private string _city; //Field for City Name

        public string City
        {
            get => _city;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name must contain text");
                }
                _city = value.Trim();
            }
        }


        private int _gamesPlayed;

        public int GamesPlayed
        {
            get => _gamesPlayed;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Games played must be >= 0")
                }
                _gamesPlayed = value;
            }
        }

        private int _wins;

        public int Wins
        {
            get => _wins;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Wins must be >=0")
                }
                _wins = value;
            }
        }

        private int _losses;

        public int Losses
        {
            get => _losses;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Losses must be >=0")
                }
                _losses = value;
            }
        }

        private int _otlosses;

        public int OvertimeLosses
        {
            get => _otlosses;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Overtime Losses must be >=0")
                }
                _otlosses = value;
            }
        }

        public int Points   //Computed property
        {
            get => Wins * 2 + OvertimeLosses;
        }

        //Define an auto-implemented property with a sprivate set for players
        public List<Roster> Players { get; private set; }

        public void AddPlayer(Roster currentPlayer)
        {
            if(Players.Count >= MaxPlayers)
            {
                throw new ArgumentException("Roster is full. Remove a player first")
            }
            Players.Add(currentPlayer);
        }

        public void RemovePlayer(int playerNumber)
        {
            //Remove from the Players list the player with the matching playerNo
            //Throw an argumentexception if the player no does not exist
            bool foundPlayer = false;
            int playerIndex = -1;
            for(int index = 0; index<Players.Count; index++)
            {
                if(Players[index].No == playerNumber)
                {
                    foundPlayer = true;
                    playerIndex = index;
                    index = Players.Count; //stop loop
                }
            }
            if (!foundPlayer) // if(foundPlayer == false)
            {
                throw new ArgumentException($"Player {playerNumber} is not on the team");
            }
        }

        //Constructor for building NHL Team
        public NhlTeam(
            NHLConference conference,
            NHLDivision division,
            string name,
            string city
            List<Roster> players
            )
        {
            if (players == null)
            {
                players = new List<Roster>();
            }
            else
            {
                Players = players;
            }

            players = new List<Roster>(); ///////////////////////
            Conference = conference;
            Division = division;
            Name = name;
            this.City = city;

            GamesPlayed = 0;
            Wins = 0;
            Losses = 0;
            OvertimeLosses = 0;
        }


        public override string ToString()
        {
            //return base.ToString();
            return $"{Conference},{Division}, {Name}, {City}, {GamesPlayed}, {Wins}, {Losses}, {OvertimeLosses}";
        }

    }
}
