using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using static Logger.FileLogger;


namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void FileLoggerTest()
        {
            string path = Path.GetTempFileName(); 
            if (File.Exists(path))
                File.Delete(path);
            FileLogger logger = new FileLogger(path);
            DateTime expectedDate = DateTime.Now;
            logger.Log(LogLevel.Error, "Test_Check");
            StreamReader sr = File.OpenText(path);
            Assert.AreEqual($"{expectedDate} FileLogger Error: Test_Check", sr.ReadLine());
            sr.Close();
            File.Delete(path);
        }

        [TestMethod]
        public void FileLoggerMultiLineTest()
        {
            string path = Path.GetTempFileName();
            Console.WriteLine(path);
            if (File.Exists(path))
                File.Delete(path);
            FileLogger logger = new FileLogger(path);
            DateTime expectedDate = DateTime.Now;
            logger.Log(LogLevel.Error, "Line1");
            logger.Log(LogLevel.Error, "Line2");
            StreamReader sr = File.OpenText(path);
            Assert.AreEqual($"{expectedDate} FileLogger Error: Line1", sr.ReadLine());
            Assert.AreEqual($"{expectedDate} FileLogger Error: Line2", sr.ReadLine());
            sr.Close();
            File.Delete(path);
        }

    }
}
