using NhlSystem;

public class Team
{

	//Define a readonly property for the Coach
	//The Coach property is known as Aggregation/Compostition when
	//the field is an object

	public Coach Coach { get; private set; } = null!;

	public List<Player> Players { get; } = new List<Player>();

	public string Name { get; private set; } = null!; //null! is null forgiving makes error go bye bye

	//Define a method used to add a new Player to the Team
	public void AddPlayer(Player newPlayer)
	{
		//Validate thta the newPlayer is not null
		if (newPlayer == null)
		{
			throw new ArgumentNullException("Player is required");
		}

		//Validate that the team size (max 23) is not full
		if (Players.Count >= 3)
		{
			throw new ArgumentOutOfRangeException("Team is full. Cannot add any more players");
		}
		//Validate that the new player PrimaryNo is not already in use
		bool primaryNoFound = false;
		foreach(Player currentPlayer in Players)
		{
			if(currentPlayer.PrimaryNo == newPlayer.PrimaryNo)
			{
				primaryNoFound = true;
				break;	//exit for each statement
			}
		}
		if (primaryNoFound)
		{
			throw new ArgumentException("PrimaryNo is already in use by another player");
		}

		//Add the newPlayer to the team
		Players.Add(newPlayer);
	}

	//Define a computed property to treturn the total of points of all players

	public int TotalPlayerPoints
	{
		get
		{
			int totalpoints = 0;
			foreach(Player currentPlayer in Players)
			{
				totalpoints += currentPlayer.Points;
			}
			return totalpoints;
		}
	}


	private string _teamName = string.Empty;
	public string TeamName
	{
		get { return _teamName; }

		set
		{
			//Validate the new value is not null, empty, or whitespace
			if (string.IsNullOrWhiteSpace(value))
			{
				throw new ArgumentNullException("TeamName is required.");
			}

			if (value.Trim().Length < 5)
			{
				throw new ArgumentException("TeamName must contain 5 or more characters");
			}
		}
	}

	public Team(string teamName, Coach coach)
	{
		if(coach == null)
		{
			throw new ArgumentNullException("A Team requires a Coach. I am available");
		}
		Coach = coach;
		TeamName = teamName;
	}

	public override string ToString()
	{
		return $"{TeamName}, {Coach}";
	}
}
