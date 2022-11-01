// See https://aka.ms/new-console-template for more information
using OOPReview1;

// Test creating a new Roster with valid values
Roster validPlayer1 = new Roster(97, "Connor McDavid", Position.C);
//var validPlayer1 = new Roster(97, "Connor McDavid", Position.C);
// Print the validPlayer1 object to the screen
// The output should be "97,Connor McDavid,C"
// should be C
Console.WriteLine(validPlayer1);

try
{
    // Test creating a new Roster with a invalid No
    Roster invalidPlayer1 = new Roster(100, "Leon Draisatil", Position.C);
    // An ArgumentOutOfRangeException should be thrown with a message 
    // indentifying what the error is
}
catch(ArgumentOutOfRangeException ex)
{
    // The ParamName of the exception should be
    // "Player number must be between 1 and 98"
    //Console.WriteLine(ex.Message);  
    Console.WriteLine(ex.ParamName);
}

try
{
    // Test creating a new Roster with a invalid null name
    Roster invalidPlayer1 = new Roster(29, null, Position.C);
    // An ArgumentOutOfRangeException should be thrown with a message 
    // indentifying what the error is
}
catch (ArgumentNullException ex)
{
    // The ParamName of the exception should be
    // "Name must contain text"
    //Console.WriteLine(ex.Message);  
    Console.WriteLine(ex.ParamName);
}

try
{
    // Test creating a new Roster with a invalid whitespace  name
    Roster invalidPlayer1 = new Roster(29, "        ", Position.C);
    // An ArgumentOutOfRangeException should be thrown with a message 
    // indentifying what the error is
}
catch (ArgumentNullException ex)
{
    // The ParamName of the exception should be
    // "Name must contain text"
    //Console.WriteLine(ex.Message);  
    Console.WriteLine(ex.ParamName);
}






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
    


