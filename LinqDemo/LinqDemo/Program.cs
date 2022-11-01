using LinqDemo; // for VideoGame 
using static System.Console;   // all you use access all static methods in Console class
                               // without Console prefix

// create a new List of VideoGame with sample data

var games = new List<VideoGame>
{
    new VideoGame("Diablo III","Nintendo",34.99,1),
    new VideoGame("NBA 2K20 (PS4)","Playstation",49.99,2),
    new VideoGame("NBA 2K20 (Switch)","Nintendo",49.99,3),
    new VideoGame("NBA 2K20 (Xbox One)","XBox",49.99,4),
    new VideoGame("Forza Horizon 4","XBox",39.99,5),
    new VideoGame("Final Fantasy X","Nintendo",34.99,6),
    new VideoGame("The Outer Worlds","Playstation",49.99,7),
    new VideoGame("Kingdom Hearts 3","Playstation",19.99,8),
    new VideoGame("Overwatch Legendary Edition","Nintendo",34.99,9),
    new VideoGame("WWE 2K20","Playstation",39.99,10),
    new VideoGame("Kingdom Hearts 3","Xbox",19.99,11),
    new VideoGame("Dragon Question Builders 2","Playstation",29.99,12),
};

// Print all games to the screen using foreach statement
foreach (VideoGame currentGame in games)
{
    //Console.WriteLine(currentGame);
    WriteLine(currentGame);
}
// Print all games to the screen using for statement
for (int index = 0; index < games.Count; index++)
{
    var currentGame = games[index];
    //Console.WriteLine(currentGame);
    WriteLine(currentGame);
}
// Print all games to the screen using the LinQ ForEach extension function
games.ForEach(currentGame => WriteLine(currentGame));

//games.ForEach(currentGame => {
//    WriteLine(currentGame);
//});
// Print all Nintendo games using the LinQ Where extension function to filter elements
games.Where(currentGame => currentGame.Platform == "Nintendo")
    .ToList()
    .ForEach(currentGame => WriteLine(currentGame));
// Print all Nintendo games using LinQ Query syntax
var nintendoGameQuery = from currentGame in games
                        where currentGame.Platform == "Nintendo"
                        select currentGame;
foreach (var currentGame in nintendoGameQuery)
{
    WriteLine(currentGame);
}

// Print just the Title of each VideoGame
games.Select(currentGame => currentGame.Title)
    .ToList()
    .ForEach(title => WriteLine(title));
// Print only distinct game platform
games.Select(currentGame => currentGame.Platform)
    .Distinct()
    .ToList()
    .ForEach(currentPlatform => WriteLine(currentPlatform));

// Sum all the Nintendo games
double sumOfAllNintendoGaemes = games
    .Where(item => item.Platform == "Nintendo")
    .Sum(item => item.Price);

// Any games less than $20?
bool isAnyGamesLessThan20 = games.Any(item => item.Price < 20);
// All games less than $50
bool isAllGamesLessThan50 = games.All(item => item.Price < 50);
// No PC Games on sales?
bool isNoPcGamesOnSales = !games.Any(item => item.Platform == "PC Games");