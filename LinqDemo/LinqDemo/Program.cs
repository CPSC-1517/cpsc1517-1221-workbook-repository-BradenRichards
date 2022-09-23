using LinqDemo;
using static System.Console; //all you can use access all static methods in Console without
                                //without Console prefix


//Create a new list of Video Games with sample data
var games = new List<VideoGame>
{
    new VideoGame("Diablo III", "Nintendo", 34.99, 1),
    new VideoGame("NBA 2k22 (Xbox One)", "XBOX", 49.99, 2),
    new VideoGame("NBA 2k22 (PS4)", "Playstation 4", 49.99, 3),
    new VideoGame("NBA 2k22 (Switch)", "Nintendo", 49.99, 4),
    new VideoGame("Final Fantasy X", "Nintendo", 34.99, 5),
    new VideoGame("Forza Horizon 4", "XBOX", 39.99, 6),
    new VideoGame("The Outer Worlds", "Playstation", 49.99, 7),
    new VideoGame("Kingdom Hearts 3", "Playstation", 19.99, 8),
    new VideoGame("Overwatch Legendary Edition", "Nintendo", 34.99, 9),
    new VideoGame("WWE 2k22", "Playstation", 39.99, 10),
    new VideoGame("Kingdom Hearts 3", "Xbox", 19.99, 11),
    new VideoGame("Dragon Quest Builders 2", "Playstation", 29.99, 12),
};

//Print all games to the screen using foreach statement
foreach(VideoGame currentGame in games)
{
    /*Console.WriteLine(currentGame);*/
    WriteLine(currentGame); // <---- No need for Console.Writeline when using static System.Console
}
//Print all games to the screen using for statement
for(int index = 0; index < games.Count; index++)
{
    var currentGame = games[index];
    /* Console.WriteLine(currentGame);*/
    WriteLine(currentGame);
}

//Print all games to the screen using the Linq ForEach extension function
games.ForEach(currentGame => WriteLine(currentGame));

/*games.ForEach(currentGame =>
{
    WriteLine(currentGame);
});*/

//Print all Nintendo games using the LinQ Where extension function to filter elements
games.Where(currentGame => currentGame.Platform == "Nintendo")
    .ToList()
    .ForEach(currentGame => WriteLine(currentGame));

//Print all Nintendo games using LinQ Query syntax
var nintendoGameQuery = from currentGame in games
                        where currentGame.Platform == "Nintendo"
                        select currentGame;
foreach(var currentGame in nintendoGameQuery)
{
    WriteLine(currentGame);
}

// Print just the Title of each VideoGame
games.Select(currentGame => currentGame.Title)
    .ToList()
    .ForEach(title => WriteLine(title));

//Print only distinct game platforms
games.Select(currentGame => currentGame.Platform)
    .Distinct()
    .ToList()
    .ForEach(currentPlatform => WriteLine(currentPlatform));

//Sum all the Nintendo Games
double sumOfAllNintendoGames = games
    .Where(item => item.Platform == "Nintendo")
    .Sum(item => item.Price);

//Any games less than $20
bool isAnyGamesLessThan20 = games.Any(item => item.Price < 20);
//Are all Games less than $50
bool isAallGamesLessThan50 = games.All(item => item.Price < 50);
//NO PC Games on sales?
bool isPCGamesOnSale = !games.Any(item => item.Platform == "PC");