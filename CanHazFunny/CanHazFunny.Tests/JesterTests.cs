using Castle.Core.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        public void CreateJesterAndTest()
        {
            Jester temp = new(new DisplayOutput(), new JokeService());

            Assert.IsInstanceOfType(temp, typeof(Jester));
        }

        [TestMethod]
        public void TellJokeAndReturn()
        {
            string joke = "Knock Knock";
            Mock<InterfaceJokeServices> temp = new Mock<InterfaceJokeServices>();
            temp.Setup(JokeService => JokeService.GetJoke()).Returns(joke);
            Assert.AreEqual<string>(joke, temp.Object.GetJoke());
        }

        [TestMethod]
        public void NoChuckAloud()
        {
            Jester temp = new(new DisplayOutput(), new JokeService());
            temp.TellAJoke();
            Assert.IsFalse(temp.Joke!.Contains("Chuck Norris"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ServiceAndDisplayNullTest()
        {
            InterfaceJokeServices? services = null;
            new Jester(new DisplayOutput(), services);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DisplayNullTest()
        {
            #nullable enable
            InterfaceJokeDisplay? display = null;
            new Jester(display, new JokeService());
        }

        // Extra credit - unit test the console write line
        [TestMethod]
        public void DisplayOutputTest()
        {
            // Setup console to write to a file
            string path = Path.GetTempFileName();
            if (File.Exists(path))
                File.Delete(path);
            StreamWriter sw = new StreamWriter(path);
            sw.AutoFlush = true;
            Console.SetOut(sw);

            string joke = "Knock Knock";
            Mock<InterfaceJokeServices> jokeService = new Mock<InterfaceJokeServices>();
            jokeService.Setup(JokeService => JokeService.GetJoke()).Returns(joke);
            
            Jester temp = new(new DisplayOutput(), jokeService.Object);
            temp.TellAJoke();
            sw.Close();

            // Read the file that contains console output and compare
            StreamReader sr = File.OpenText(path);
            Assert.AreEqual<string>(joke, sr?.ReadLine() ?? "");
            sr?.Close();
            File.Delete(path);
        }
    }
}
