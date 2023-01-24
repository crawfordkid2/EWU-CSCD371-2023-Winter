using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void Create_Null_NotSuccess()
        {
            Assert.IsNull(new LogFactory().CreateLogger("Successful"));
        }
    }
}
