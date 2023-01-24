using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using static Logger.ConsoleLogger;


namespace Logger.Tests
{
    [TestClass]
    public class ConsoleLoggerTests
    {
        [TestMethod]
        public void ConsoleLoggerTest()
        {
            string path = Path.GetTempFileName();
            if (File.Exists(path))
                File.Delete(path);
            StreamWriter sw = new StreamWriter(path);
            sw.AutoFlush = true;
            Console.SetOut(sw);

            ConsoleLogger logger = new ConsoleLogger();
            DateTime expectedDate = DateTime.Now;
            logger.Log(LogLevel.Error, "Test_Check");
            sw.Close();

            StreamReader sr = File.OpenText(path);
            Assert.AreEqual($"{expectedDate} ConsoleLogger Error: Test_Check", sr.ReadLine());
            sr.Close();
            File.Delete(path);
        }


    }
}
