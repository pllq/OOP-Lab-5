using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using BLL;
using Services;
namespace Tests
{
    [TestClass]
    public class EntityServiceTests
    {
        [TestMethod]
        public void EntityServiceInitialize_should_create_entityService_when_no_params()
        {
            //Arrange
            EntityService service;
            //Act
            service = new EntityService();
            //Assert
            Assert.IsNotNull(service);
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void EntityServiceProperty_should_throw_exception_when_set_null()
        {
            //Arrange
            EntityService service = new EntityService();
            //Act
            service.DataCollection = null;
            //Assert
            //ExpectedException
        }
        [TestMethod]
        public void EntityServiceProperty_should_set_collection()
        {
            //Arrange
            EntityService service = new EntityService();
            //Act
            service.DataCollection = new List<Human>();
            //Assert
            Assert.IsNotNull(service.DataCollection);
        }
        [TestMethod]
        public void EntityServiceProperty_should_return_collection()
        {
            //Arrange
            EntityService service = new EntityService();
            //Act
            ICollection<Human> collection = service.DataCollection;
            //Assert
            Assert.IsNotNull(collection);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EntityServiceIndexer_should_throw_exception_when_index_out_of_range()
        {
            //Arrange
            EntityService service = new EntityService();
            //Act
            Human human = service[0];
            //Assert
            //ExpectedException
        }
        [TestMethod]
        public void EntityServiceIndexer_should_return_human_when_index_ok()
        {
            //Arrange
            EntityService service = new EntityService();
            service.Add(new Painter("Name", "Lasname", 2000, 12, 12, 5, false, new NoSwim()));
            //Act
            Human human = service[0];
            //Assert
            Assert.IsNotNull(human);
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Add_should_throw_exception_when_item_null()
        {
            //Arrange
            EntityService service = new EntityService();
            //Act
            service.Add(null);
            //Assert
            //ExpectedException
        }
        [TestMethod]
        public void Add_should_add_human_to_collection_when_item_not_null()
        {
            //Arrange
            EntityService service = new EntityService();
            //Act
            service.Add(new Painter("Name", "Lasname", 2000, 12, 12, 5, false, new NoSwim()));
            //Assert
            Assert.IsNotNull(service[0]);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Remove_should_throw_exception_when_index_out_of_range()
        {
            //Arrange
            EntityService service = new EntityService();
            service.Add(new Painter("Name", "Lasname", 2000, 12, 12, 5, false, new NoSwim()));
            //Act
            service.Remove(2);
            //Assert
            //ExpectedException
        }
        [TestMethod]
        public void Remove_should_remove_human_when_index_ok()
        {
            //Arrange
            EntityService service = new EntityService();
            service.Add(new Painter("Name", "Lasname", 2000, 12, 12, 5, false, new NoSwim()));
            //Act
            bool remove = service.Remove(0);
            //Assert
            Assert.IsTrue(remove);
        }
        [TestMethod]
        public void Operation_should_return_0_when_collection_has_no_students_2_grade_winter()
        {
            //Arrange
            EntityService service = new EntityService();
            //Act
            int operation = service.Operation();
            //Assert
            Assert.AreEqual(0, operation);
        }
        [TestMethod]
        public void Operation_should_return_1_when_collection_has_1_student_2_grade_winter()
        {
            //Arrange
            EntityService service = new EntityService();
            service.Add(new Student("Name", "Lastname", 2000, 12, 12, "XX00000000", 2, false, new NoSwim()));
            //Act
            int operation = service.Operation();
            //Assert
            Assert.AreEqual(1, operation);
        }
    }
    [TestClass]
    public class ReadWriteServiceTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ReadWriteServiceInitialize_should_throw_exception_when_path_null()
        {
            //Arrange
            ReadWriteService service;
            //Act
            service = new ReadWriteService(null, EProviders.Bin);
            //Assert
            //ExpectedException
        }
        [TestMethod]
        public void ReadWriteServiceInitialize_should_create_RWService_when_right_path()
        {
            //Arrange
            ReadWriteService service;
            //Act
            service = new ReadWriteService("file", EProviders.Bin);
            //Assert
            Assert.IsNotNull(service.File);
        }
        [TestMethod]
        public void ReadWriteServiceProperty_should_return_filename()
        {
            //Arrange
            ReadWriteService service = new ReadWriteService("file", EProviders.Json);
            //Act
            string filename = service.File;
            //Assert
            Assert.AreEqual("file.json", filename);
        }
        [TestMethod]
        public void ReadWriteServiceProperty_should_set_filename()
        {
            //Arrange
            ReadWriteService service = new ReadWriteService("file", EProviders.Xml);
            //Act
            service.File = "file_2";
            //Assert
            Assert.AreEqual("file_2.xml", service.File);
        }
        [TestMethod]
        public void WriteData_should_retun_void_when_called()
        {
            //Arrange
            ReadWriteService service = new ReadWriteService("testing_read_data", EProviders.Custom);
            //Act
            service.WriteData(null);
            //Assert
            //void
        }
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ReadData_should_throw_exception_when_no_data()
        {
            //Arrange
            ReadWriteService service = new ReadWriteService("testing_read_data", EProviders.Custom);
            //Act
            List <Human> list = service.ReadData();
            //Assert
            //ExpectedException
        }
        [TestMethod]
        public void ReadData_should_return_list()
        {
            //Arrange
            ReadWriteService service = new ReadWriteService("testing_read_data", EProviders.Custom);
            service.WriteData(new List<Human>() { new Painter("Nam", "Lastname", 2000, 12, 12, 5, false, new NoSwim()) });
            //Act
            List<Human> list = service.ReadData();
            File.Delete(service.File);
            //Assert
            Assert.IsNotNull(list);
        }
    }
}
