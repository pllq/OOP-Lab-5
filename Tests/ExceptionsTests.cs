using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exceptions;

namespace Tests
{
    [TestClass]
    public class ExceptionsTests
    {
        [TestMethod]
        public void HumanDataExceptionCreation_should_create_exception_when_no_params()
        {
            //Arrange
            HumanDataException exception;
            //Act
            exception = new HumanDataException();
            //Assert
            Assert.IsNotNull(exception);
        }
        [TestMethod]
        public void StudentDataExceptionCreation_should_create_exception_when_no_params()
        {
            //Arrange
            StudentDataException exception;
            //Act
            exception = new StudentDataException();
            //Assert
            Assert.IsNotNull(exception);
        }
        [TestMethod]
        public void FarmerDataExceptionCreation_should_create_exception_when_no_params()
        {
            //Arrange
            FarmerDataException exception;
            //Act
            exception = new FarmerDataException();
            //Assert
            Assert.IsNotNull(exception);
        }
        [TestMethod]
        public void PainterDataExceptionCreation_should_create_exception_when_no_params()
        {
            //Arrange
            PainterDataException exception;
            //Act
            exception = new PainterDataException();
            //Assert
            Assert.IsNotNull(exception);
        }
    }
}
