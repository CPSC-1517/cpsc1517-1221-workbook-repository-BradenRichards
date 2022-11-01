using OOPReview1;

namespace NhlSystemTest
{
    [TestClass]
    public class RosterTest
    {
        [TestMethod]
        [DataRow(97,"Connor McDavid", Position.C)]
        [DataRow(18, "Zach Hyman", Position.LW)]
        [DataRow(25, "Darnell Nurse", Position.D)]
        public void Constructor_ValidValues_SetsNoNamePosition(
            int playerNo,
            string playerName,
            Position playerPosition)
        {
            // Arrange
            Roster validPlayer1 = new Roster(playerNo, playerName, playerPosition);

            // Act and Assert
            Assert.AreEqual(playerNo, validPlayer1.No);
            Assert.AreEqual(playerName, validPlayer1.Name);
            Assert.AreEqual(playerPosition, validPlayer1.Position);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(99)]
        public void No_InvalidNo_ThrowsArgumentOutOfRangeException(int playerNo)
        {

            // Act and Assert
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>( () => 
            {
                // Arrange
                Roster invalidPlayer1 = new Roster(playerNo, "Connor McDavid", Position.C);
            }
            );
            Assert.AreEqual("Player number must be between 0 and 98", exception.ParamName);

        }
    }
}