using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Logger;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class BaseLoggerMixinsTests
    {
        [TestMethod]
        public void NullLogger_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => BaseLoggerMixins.Error(null, "Message"));
            Assert.ThrowsException<ArgumentNullException>(() => BaseLoggerMixins.Warning(null, "Message"));
            Assert.ThrowsException<ArgumentNullException>(() => BaseLoggerMixins.Information(null, "Message"));
            Assert.ThrowsException<ArgumentNullException>(() => BaseLoggerMixins.Debug(null, "Message"));

        }

        [TestMethod]
        public void Error_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.Error("Message {0}", 42);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
        }


        [TestMethod]
        public void TestError_WithMessageArgs()
        {
            string path = Path.GetTempFileName();
            if (File.Exists(path))
                File.Delete(path);
            FileLogger logger = new FileLogger(path);
            logger.Error("Error_Message_{0}_{1}_{2}", 1, 2, 3);
            DateTime expectedDate = DateTime.Now;
            StreamReader sr = File.OpenText(path);
            Assert.AreEqual($"{expectedDate} FileLogger Error: Error_Message_1_2_3", sr.ReadLine());
            sr.Close();
            File.Delete(path);
        }

    }

    public class TestLogger : BaseLogger
    {
        public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

        public override void Log(LogLevel logLevel, string message)
        {
            LoggedMessages.Add((logLevel, message));
        }
    }
}
