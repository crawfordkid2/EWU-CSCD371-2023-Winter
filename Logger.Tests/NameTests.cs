using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Tests
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        public void MiddleNameIsNullTest()
        {
            Assert.IsNotNull(new FullName("John", "Cena", null));
        }
        [TestMethod]
        public void MiddleNameIsNotNullTest()
        {
            Assert.IsNotNull(new FullName("John", "Cena", "Paul"));
        }


        [TestMethod]
        public void MakeStudentRecordTest()
        {
            FullName stu = new("John", "Jones", null);
            Assert.IsNotNull(new Student(stu, "UFC Fighter", "EWU"));
        }
        [TestMethod]
        public void MakeEmployeeRecordTest()
        {
            FullName stu = new("John", "Jones", null);
            Assert.IsNotNull(new Employee(stu, "UFC Fighter", "EWU"));
        }
        [TestMethod]
        public void CreateBookTest()
        {
            FullName author = new("John", "Jones", "Beast");
            Assert.IsNotNull(new Book("How to fight", author, "1738"));

        }

        [TestMethod]
        public void SameNameDifferentAddressTest()
        {
            FullName temp1 = new("John", "Cena", "Paul");
            FullName temp2 = new("John", "Cena", "Paul");

            Assert.AreEqual(temp1, temp2);

        }

        [TestMethod]
        public void DifferentNameDifferentAddressTest()
        {
            FullName temp1 = new("John", "Not", "Paul");
            FullName temp2 = new("John", "Cena", "Paul");

            Assert.AreNotEqual(temp1, temp2);

        }
        [TestMethod]
        public void AreStudentsSomeoneTest()
        {
            FullName name = new("Joey", "Diaz", null);
            Student stu = new(name, "comedian", "EWU");
            Assert.IsInstanceOfType(stu, typeof(Someone));

        }


    }
}
