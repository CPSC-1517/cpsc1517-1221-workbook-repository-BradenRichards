using System;
using static HockeyTeam;
/*Ask Sam about the code thats here on his thing*/

public class HockeyTeam
{
	public HockeyTeam()
	{
		public enum NHLConference { Eastern, Western };

		public enum NHLDivision { Pacific, Atlantic, Central, Metropolitan };

	//Define data fields for storing data
	private NHLConference _conference;
	private NHLDivision _division;

	//Define fully-implemented properties for the data fields
	public NHLConference Conference
	{
		get { return _conference; }
	}

	public NHLDivision Division
	{
		get { return _division; }
		set { _division = value; }
	}

	}

	
}

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


        //Constructor for building NHL Team
        public NhlTeam(
            NhlConference conference,
            NhlDivision division,
            string name,
            string city
            )
        {
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
