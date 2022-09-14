// See https://aka.ms/new-console-template for more information
using OOPReview1;

var senators = new NhlTeam(
    NhlConferene.Eastern, 
    NhlDivision.Atlantic,
    "Senators",
    "Ottawa");
senators.GamesPlayed = 82;
senators.Wins = 33;
senators.Losses = 42;
senators.OvertimeLosses = 7;
// Print the Points - should be 73
Console.WriteLine(senators);
Console.WriteLine($"Points = {senators.Points}");


//Test creating a new Roster with valid values
var validPlayer1 = new Roster(97, "Connor McDavid", Position.C);
//OR
//Roster validPlayer1 = new Roster(97, "Connor McDavid", Position.C);
//Print the validPlayer1 object to the screen

Console.WriteLine(validPlayer1); // Player Number should be 97, Name: Connor McDavid, Position: C

//Test creating a new Roster with a invalid No
//Expected behaviour is that ArgumentOutOfRangeException is Thrown
//With a message identifying what the error is
try
{
    Roster invalidPlayer1 = new Roster(100, "Leon Draisaitl", Position.C);
}
catch(ArgumentOutOfRangeException ex)
{
    Console.WriteLine(ex.ParamName);
    //The paramName of the exception should be 
    //"Player number must be between 0 and 98"

    //When firing parameter exception use ex.ParamName
    //instead of ex.message to avoid error message showing additional
    //and unnecessary information
}


//Test creating a new Roster with a invalid PlayerName ie.(empty name entered or not using text)
//Expected outcome is ArgumentNullException being fired
//"Name must contain text"
try
{
    //We can reuse invalidPlayer1 in every test case because once the try
    //is fired invalidPlayer essentially resets
    Roster invalidPlayer1 = new Roster(10, "  ", Position.G);
}
catch(ArgumentNullException ex)
{
    Console.WriteLine(ex.ParamName);
}

try
{
    Roster invalidPlayer1 = new Roster(91, null, Position.G);
}
catch(ArgumentNullException ex)
{
    Console.WriteLine(ex.ParamName);
}

