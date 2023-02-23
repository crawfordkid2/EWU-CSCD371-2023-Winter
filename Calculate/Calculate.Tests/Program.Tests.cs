using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculate.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Program_CreateDefault_NotNull()
        {
            Program p = new();
            Assert.IsNotNull(p);
        }

        [TestMethod]
        public void Program_CreateWithParams_NotNull()
        {
            Program p = new()
            {
                WriteLine = (s)=>Console.WriteLine(s),
                ReadLine = () => Console.ReadLine(),
            };
            Assert.IsNotNull(p);
        }
    }
}