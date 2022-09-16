using NhlSystem;

namespace TestNhlSystem
{
    [TestClass]
    public class PersonTest
    {

        //Valid Test
        [TestMethod]
        [DataRow("Connor McDavid")]
        [DataRow("Leon Draisaitl")]
        public void FullName_ValidName_FulNameSet(string fullName)
        {
            /* var validPerson = new Person("Connor McDavid");
             Assert.AreEqual("Connor McDavid", validPerson.FullName);*/
            var validPerson = new Person(fullName);
            Assert.AreEqual(fullName, validPerson.FullName);
        }

        //Invalid Test
        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("        ")]
        public void FullName_InvalidName_FulNameSet(string fullName)
        {
            var ex = Assert.ThrowsException<ArgumentNullException>(() => new Person(fullName));
            Assert.AreEqual("FullName value is required", ex.ParamName);
        }

        //Invalid Test
        [TestMethod]
        [DataRow("Bo")]
        public void FullName_InvalidNameLength_FulNameSet(string fullName)
        {
            var ex = Assert.ThrowsException<ArgumentException>(() => new Person(fullName));
            Assert.AreEqual("FullName must contain 3 or more characters", ex.Message);
        }
    }
}