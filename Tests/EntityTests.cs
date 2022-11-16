using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using Exceptions;
namespace Tests
{
    [TestClass]
    public class HumanTest//class Human, creation of student
    {
        [TestMethod]
        [ExpectedException(typeof(HumanDataException))]
        public void HumanInitialize_should_throw_exception_when_wrong_symbols_firstname()
        {
            //Arrange
            Human student;
            //Act
            student = new Student("123", "Lastname", 2000, 12, 12, "XX00000000", 1, false, new NoSwim());
            //Assert
            //ExpectedException
        }
        [TestMethod]
        [ExpectedException(typeof(HumanDataException))]
        public void HumanInitialize_should_throw_exception_when_wrong_size_firstname()
        {
            //Arrange
            Human student;
            //Act
            student = new Student("Nameeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee", "LastName", 2000, 12, 12, "XX00000000", 1, false, new NoSwim());
            //Assert
            //ExpectedException
        }
        [TestMethod]
        [ExpectedException(typeof(HumanDataException))]
        public void HumanInitialize_should_throw_exception_when_wrong_symbols_lastname()
        {
            //Arrange
            Human student;
            //Act
            student = new Student("Name", "123", 2000, 12, 12, "XX00000000", 1, false, new NoSwim());
            //Assert
            //ExpectedException
        }
        [TestMethod]
        [ExpectedException(typeof(HumanDataException))]
        public void HumanInitialize_should_throw_exception_when_wrong_size_lastname()
        {
            //Arrange
            Human student;
            //Act
            student = new Student("Name", "Lastnameeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee", 2000, 12, 12, "XX00000000", 1, false, new NoSwim());
            //Assert
            //ExpectedException
        }
        [TestMethod]
        public void HumanInitialize_should_create_student_when_right_data()
        {
            //Arrange
            Human student;
            //Act
            student = new Student("Name", "Lastname", 2000, 12, 12, "XX00000000", 2, false, new NoSwim());
            //Assert
            Assert.IsNotNull(student);
        }
        [TestMethod]
        public void HumanProperty_should_return_firstname()
        {
            //Arrange
            Human student;
            //Act
            student = new Student("Name", "Lasname", 2000, 12, 12, "XX00000000", 2, false, new NoSwim());
            //Assert
            Assert.AreEqual(student.FirstName, "Name");  
        }
        [TestMethod]
        public void HumanProperty_should_return_lastname()
        {
            //Arrange
            Human student;
            //Act
            student = new Student("Name", "Lastname", 2000, 12, 12, "XX00000000", 2, false, new NoSwim());
            //Assert
            Assert.AreEqual(student.LastName, "Lastname");
        }
        [TestMethod]
        public void HumanProperty_should_return_date()
        {
            //Arrange
            Human student;
            //Act
            student = new Student("Ivan", "Ivanov", 2000, 12, 12, "XX00000000", 2, false, new NoSwim());
            //Assert
            Assert.AreEqual(student.Date, new DateTime(2000, 12, 12));
        }
        [TestMethod]
        public void HumanProperty_should_return_age()
        {
            //Arrange
            Human student;
            //Act
            student = new Student("Ivan", "Ivanov", 2000, 12, 12, "XX00000000", 2, false, new NoSwim());
            TimeSpan time = DateTime.Now - student.Date;
            int age = Convert.ToInt32(Math.Floor(Math.Round(time.TotalDays) / 365.25));
            //Assert
            Assert.AreEqual(age, student.Age);
        }
        [TestMethod]
        public void HumanProperty_should_return_driving_license()
        {
            //Arrange
            Human student;
            //Act
            student = new Student("Ivan", "Ivanov", 2000, 12, 12, "XX00000000", 2, false, new NoSwim());
            //Assert
            Assert.AreEqual(student.DrivingLicense, false);
        }
        [TestMethod]
        public void Swim_should_return_true_when_YesSwim()
        {
            //Arrange
            Human student;
            //Act
            student = new Student("Ivan", "Ivanov", 2000, 12, 12, "XX00000000", 2, false, new YesSwim());
            //Assert
            Assert.IsTrue(student.Swim());
        }
        [TestMethod]
        public void Swim_should_return_false_when_NoSwim()
        {
            //Arrange
            Human student;
            //Act
            student = new Student("Ivan", "Ivanov", 2000, 12, 12, "XX00000000", 2, false, new NoSwim());
            //Assert
            Assert.IsFalse(student.Swim());
        }
    }
    [TestClass]
    public class StudentTest//test Student class
    {
        [TestMethod]
        [ExpectedException(typeof(StudentDataException))]
        public void StudentInitialize_should_throw_exception_when_wrong_symbols_studentID()
        {
            //Arrange
            Student student;
            //Act
            student = new Student("Name", "Lastname", 2000, 12, 12, "0000000000", 1, false, new NoSwim());
            //Assert
            //ExpectedException
        }
        [TestMethod]
        [ExpectedException(typeof(StudentDataException))]
        public void StudentInitialize_should_throw_exception_when_wrong_size_studentID()
        {
            //Arrange
            Student student;
            //Act
            student = new Student("Name", "Lastname", 2000, 12, 12, "XX0000000000", 1, false, new NoSwim());
            //Assert
            //ExpectedException
        }
        [TestMethod]
        [ExpectedException(typeof(StudentDataException))]
        public void StudentInitialize_should_throw_exception_when_wrong_value_grade()
        {
            //Arrange
            Student student;
            //Act
            student = new Student("Name", "Lastname", 2000, 12, 12, "XX00000000", 0, false, new NoSwim());
            //Assert
            //ExpectedException
        }
        [TestMethod]
        public void StudentInitialize_should_create_student_when_right_data()
        {
            //Arrange
            Student student;
            //Act
            student = new Student("Name", "Lastname", 2000, 12, 12, "XX00000000", 2, false, new NoSwim());
            //Assert
            Assert.IsNotNull(student);
        }
        [TestMethod]
        public void StudentProperty_should_return_studentID()
        {
            //Arrange
            Student student;
            //Act
            student = new Student("Name", "Lasname", 2000, 12, 12, "XX00000000", 2, false, new NoSwim());
            //Assert
            Assert.AreEqual(student.StudentID, "XX00000000");
        }
        [TestMethod]
        public void StudentProperty_should_return_grade()
        {
            //Arrange
            Student student;
            //Act
            student = new Student("Name", "Lasname", 2000, 12, 12, "XX00000000", 2, false, new NoSwim());
            //Assert
            Assert.AreEqual(student.Grade, 2);
        }
    }
    [TestClass]
    public class FarmerTest//test Farmer class
    {
        [TestMethod]
        [ExpectedException(typeof(FarmerDataException))]
        public void FarmerInitialize_should_throw_exception_when_wrong_value_experience()
        {
            //Arrange
            Farmer farmer;
            //Act
            farmer = new Farmer("Name", "Lastname", 2000, 12, 12, 50, false, new NoSwim());
            //Assert
            //ExpectedException
        }
        [TestMethod]
        public void FarmerInitialize_should_create_farmer_when_right_data()
        {
            //Arrange
            Farmer farmer;
            //Act
            farmer = new Farmer("Name", "Lastname", 2000, 12, 12, 5, false, new NoSwim());
            //Assert
            Assert.IsNotNull(farmer);
        }
        [TestMethod]
        public void FarmerProperty_should_return_experience()
        {
            //Arrange
            Farmer farmer;
            //Act
            farmer = new Farmer("Name", "Lastname", 2000, 12, 12, 5, false, new NoSwim());
            //Assert
            Assert.AreEqual(farmer.Experience, 5);
        }
    }
    [TestClass]
    public class PainterTest//test Painter class
    {
        [TestMethod]
        [ExpectedException(typeof(PainterDataException))]
        public void PainterInitialize_should_throw_exception_when_wrong_value_experience()
        {
            //Arrange
            Painter painter;
            //Act
            painter = new Painter("Name", "Lastname", 2000, 12, 12, 50, false, new NoSwim());
            //Assert
            //ExpectedException
        }
        [TestMethod]
        public void PainterInitialize_should_create_painter_when_right_data()
        {
            //Arrange
            Painter painter;
            //Act
            painter = new Painter("Name", "Lastname", 2000, 12, 12, 5, false, new NoSwim());
            //Assert
            Assert.IsNotNull(painter);
        }
        [TestMethod]
        public void PainterProperty_should_return_experience()
        {
            //Arrange
            Painter painter;
            //Act
            painter = new Painter("Name", "Lastname", 2000, 12, 12, 5, false, new NoSwim());
            //Assert
            Assert.AreEqual(painter.Experience, 5);
        }
    }
}
