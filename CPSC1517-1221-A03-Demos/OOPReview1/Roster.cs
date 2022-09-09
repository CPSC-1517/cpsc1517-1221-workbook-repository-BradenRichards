using System;

public enum PlayerPosition { G, C, LW, RW, D };

public class Roster
{
	
    //Define a fully implemented property for Player Name

    private string _playerName; //Field for the name property

    public string PlayerName
    {
        get => _playerName;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) // <== If name is null or empty throw exception
            {
                throw new ArgumentNullException("Name must contain text");
            }
            _name = value.Trim(); // <=== Trims leading and trailing whitespace

        }

    }


    //Better to use constants to improve code readability for player numbers
    private const int MinNo = 0;
    private const int MaxNo = 98;

    private int _playerNumber;

    public int PlayerNumber
    {
        get => _playerNumber;
        set
        {
            if (value < MinNumber || value > MaxNumber)
            {
                throw new ArgumentOutOfRangeException("Player Number must be greater than or equal to 0 and less than 99")
                }
            _playerNumber = value;
        }
    }


    //Define an auto-implemented property for position
    public PlayerPosition Position { get; set; }

    //Define a greedy constructor with parameters for Player Number, Name and Position (type ctor to auto generate constructor)

    public Roster(int no, string name, PlayerPosition position)
    {
        PlayerNumber = no;
        PlayerName = name;
        PlayerPosition = position;
    }

    //override the ToString to return the No, Name, position
    public override string ToString()
    {
        //return base.ToString();
        return $"{No}, {Name}, {Position}";
    }


}
