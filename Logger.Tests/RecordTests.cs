using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests
{
    [TestClass]
    public class RecordTests
    {
        [TestMethod]
        public void EmployeeRecordContainsTest()
        {
            //Arrange
            Storage record = new();
            FullName empName = new("Laura", "Angles", "Wilder");
            Employee empRecord = new(empName, "Writer", "PBS");
            //Act
            record.Add(empRecord);


            //Assert
            Assert.IsTrue(record.Contains(empRecord));

        }
        [TestMethod]
        public void StudentRecordContainsTest()
        {
            //Arrange
            Storage record = new();
            FullName stuName = new("Laura", "Angles", "Wilder");
            Student stuRecord = new(stuName, "English", "EWU");
            //Act
            record.Add(stuRecord);


            //Assert
            Assert.IsTrue(record.Contains(stuRecord));

        }
        [TestMethod]
        public void StudentRecordRemoveTest()
        {
            //Arrange
            Storage record = new();
            FullName student = new("Laura", "Angles", "Wilder");
            Student stuRecord = new(student, "Comp Sci", "EWU");
            //Act
            record.Add(stuRecord);
            //Assert
            record.Remove(stuRecord);
            Assert.IsFalse(record.Contains(stuRecord));


        }
        [TestMethod]
        public void EmployeeRecordRemoveTest()
        {
            //Arrange
            Storage record = new();
            FullName emp = new("Laura", "Angles", "Wilder");
            Employee empRecord = new(emp, "Writer", "Valve");
            //Act
            record.Add(empRecord);
            //Assert
            record.Remove(empRecord);
            Assert.IsFalse(record.Contains(empRecord));


        }
        
        [TestMethod]
        public void CheckIDTest()
        {  
            Storage record = new();
            FullName name = new("Tom", "Cruise", null);
            Student stu = new(name, "Theater", "EWU");
            Guid id = stu.Id;
            record.Add(stu);
            

            Student stu2 = record.Get(id) as Student ?? throw new ArgumentNullException();
            Assert.IsNotNull(stu2);
            

        }
        

    }
   
}
