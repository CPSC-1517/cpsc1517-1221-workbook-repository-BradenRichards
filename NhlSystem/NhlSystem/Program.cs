using NhlSystem;
using System.IO;
using System.Text.Json;

/*  Test Plan for Person
 *  
 *  Test Case                   Test Data                       Expected Behaviour
 *  ==========                  ==========                      ==================
 *  Valid FullName              FullName: Connor McDavid        FullName = Connor McDavid
 *  
 *  Null FullName               FullName: null                  ArgumentNullException
 *                                                              "FullName value is required"
 *  Empty FullName              FullName: ""                    ArgumentNullException
 *                                                              "FullName value is required"
 *  Whitespace FullName         FullName: "            "        ArgumentNullException
 *                                                              "FullName value is required"
 *  FullName <3 characters      FullName: Bo                    ArgumentException
 *                                                              "FullName must contain 3 or more characters"
 */

//Test Case 1: Valid FullName
using NhlSystem;

var validPerson = new Person("Connor McDavid");
Console.WriteLine(validPerson.FullName); //Value should be Connor McDavid

//Test Case 2: Null FullName
try
{
    var nullPerson = new Person(null!);
    Console.WriteLine("Null Test Case failed");
}
catch(ArgumentNullException ex)
{
    Console.WriteLine(ex.ParamName); // Output should be "FullName value is required"
}


//Test Case 3: Empty FullName
try
{
    var emptyPerson = new Person("");
    Console.WriteLine("Empty Test Case failed");
}
catch (ArgumentNullException ex)
{
    Console.WriteLine(ex.ParamName); // Output should be "FullName value is required"
}

//Test Case 4: WhiteSpace FullName
try
{
    var whiteSpacePerson = new Person("");
    Console.WriteLine("WhiteSpace Test Case failed");
}
catch (ArgumentNullException ex)
{
    Console.WriteLine(ex.ParamName); // Output should be "FullName value is required"
}


//Test Case 5: MinimumLength FullNam
try
{
    var invalidLengthPerson = new Person("Bo");
    Console.WriteLine("Minimum Name Length Test Case failed");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.ParamName); // Output should be "FullName value is required"
}

//Test Creating a new Team
//Crete a new Coach for the Team
DateTime startDate = DateTime.Parse("2021-09-02");
Coach oilersCoach = new Coach("Jay Woodcroft", startDate);
//Create a new Team
Team oilersTeam = new Team("Edmonton Oilers", oilersCoach);
//Create 3 Players for the team
Player player1 = new Player("Connor McDavid", Position.C, 97);
Player player2 = new Player("Leon Draisaitl", Position.C, 27);
Player player3 = new Player("Evander Kane", Position.LW, 91);

oilersTeam.AddPlayer(player1);
oilersTeam.AddPlayer(player2);
oilersTeam.AddPlayer(player3);

//Assign Goals and Assists to each player
player1.Goals = 44;
player1.Assists = 79;

player2.Goals = 22;
player2.Assists = 17;

player3.Goals = 55;
player3.Assists = 55;


//Check that the team has 3 players
Console.WriteLine($"Players in team is {oilersTeam.Players.Count}");
//Print each player in the team
foreach(Player currentPlayer in oilersTeam.Players)
{
    Console.WriteLine(currentPlayer);
}

//Check the total player points (should be 44+79+22+17+55+55 = 272)
Console.WriteLine($"Total player points is {oilersTeam.TotalPlayerPoints}");

/* CreatePlayersCsvFile();

static void CreatePlayersCsvFile()
{
    DateTime startDate = DateTime.Parse("2021-09-02");
    Coach oilersCoach = new Coach("Jay Woodcroft", startDate);
    //Create a new Team
    Team oilersTeam = new Team("Edmonton Oilers", oilersCoach);
    //Create 3 Players for the team
    Player player1 = new Player("Connor McDavid", Position.C, 97);
    Player player2 = new Player("Leon Draisaitl", Position.C, 27);
    Player player3 = new Player("Evander Kane", Position.LW, 91);

    oilersTeam.AddPlayer(player1);
    oilersTeam.AddPlayer(player2);
    oilersTeam.AddPlayer(player3);

    const string PlayerCsvFile = "../../../Players.csv";
    File.WriteAllLines(PlayerCsvFile,
        oilersTeam.Players.Select(currentPlayer => currentPlayer.ToString()).ToList());
}*/


CreateTeamJsonFile();
static void CreateTeamJsonFile()
{
    DateTime startDate = DateTime.Parse("2021-09-02");
    Coach oilersCoach = new Coach("Jay Woodcroft", startDate);
    //Create a new Team
    Team oilersTeam = new Team("Edmonton Oilers", oilersCoach);
    //Create 3 Players for the team
    Player player1 = new Player("Connor McDavid", Position.C, 97);
    Player player2 = new Player("Leon Draisaitl", Position.C, 27);
    Player player3 = new Player("Evander Kane", Position.LW, 91);

    oilersTeam.AddPlayer(player1);
    oilersTeam.AddPlayer(player2);
    oilersTeam.AddPlayer(player3);

    const string TeamJsonFile = "../../../Team.json";
    JsonSerializerOptions options = new JsonSerializerOptions
    {
        WriteIndented = true,
        IncludeFields = true
    };
    string jsonString = JsonSerializer.Serialize<Team>(oilersTeam, options);
    File.WriteAllText(TeamJsonFile, jsonString);
    
}