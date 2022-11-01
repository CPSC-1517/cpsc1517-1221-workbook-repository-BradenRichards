using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NhlSystem;

namespace TestNhlSystem
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        [DataRow("Connor McDavid", Position.C, 97)]
        [DataRow("Leon Draisaitl", Position.LW, 91)]
        public void Constructor_ValidData_ShouldPass(string fullName, Position playerPosition, int playerNo)
        {
            //Position playerPosition = (Position) Enum.Parse(typeof(Position), positionString);
            var currentPlayer = new Player(fullName, playerPosition, playerNo);
            Assert.AreEqual(fullName, currentPlayer.FullName);
            Assert.AreEqual(playerPosition, currentPlayer.Position);
            Assert.AreEqual(playerNo, currentPlayer.PrimaryNo);
            Assert.AreEqual(0, currentPlayer.Goals);
            Assert.AreEqual(0, currentPlayer.Points);

        }

        [TestMethod]
        [DataRow("Leon Draisaitl", Position.LW, 100)]   // Invalid PrimaryNo
        [DataRow("Leon Draisaitl", Position.LW, 99)]   // Invalid PrimaryNo
        [DataRow("Leon Draisaitl", Position.D, -1)]     // Invalid PrimaryNo
        public void Constructor_InvalidPrimaryNo_ShouldFail(string fullName, Position playerPosition, int playerNo)
        {
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() => 
            {
                var currentPlayer = new Player(fullName, playerPosition, playerNo);
            });
            Assert.AreEqual("PrimaryNo must between 0 and 98", exception.ParamName);
        }

        [TestMethod]
        [DataRow(null, Position.LW, 29)]   // Invalid FullName
        [DataRow("", Position.LW, 29)]   // Invalid FullName
        [DataRow("      ", Position.LW, 29)]     // Invalid FullName
        public void Constructor_NullFullName_ShouldFail(string fullName, Position playerPosition, int playerNo)
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                var currentPlayer = new Player(fullName, playerPosition, playerNo);
            });
            Assert.AreEqual("FullName value is required", exception.ParamName);
        }

        [TestMethod]
        [DataRow("A", Position.LW, 29)]   // Invalid FullName
        [DataRow("AB", Position.LW, 29)]   // Invalid FullName
        public void Constructor_FullNameTooShort_ShouldFail(string fullName, Position playerPosition, int playerNo)
        {
            var exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                var currentPlayer = new Player(fullName, playerPosition, playerNo);
            });
            Assert.AreEqual("FullName must contain 3 or more characters", exception.Message);
        }
    }
}
