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
            temp.Setup(JokeService => JokeService.GetJoke()).Returns("Knock Knock");
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





    }
}
