using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    public record VideoGame(
        string Title,
        string Platform,    // Playstation, Xbox, Nintendo, PC Games
        double Price,
        long WebCode
    );

}
