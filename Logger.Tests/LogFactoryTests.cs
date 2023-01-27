using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{

    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void Create_Null_NotSuccess()
        {
            Assert.IsNull(new LogFactory().CreateLogger("Unknown"));
        }

        [TestMethod]
        public void Create_FileLogger_NotSuccess()
        {
            Assert.IsNull(new LogFactory().CreateLogger("FileLogger"));
        }

        [TestMethod]
        public void Create_ConsoleLogger()
        {
            var logger = new LogFactory().CreateLogger("ConsoleLogger");
            Assert.IsNotNull(logger);
            Assert.IsInstanceOfType(logger, typeof(ConsoleLogger));
        }
    }

}
