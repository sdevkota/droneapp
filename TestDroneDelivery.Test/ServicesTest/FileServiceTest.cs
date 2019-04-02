using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DroneScheduler;
using System.IO;
using System.Reflection;

namespace TestDroneDelivery.Test
{

    [TestClass]
    public class FileServiceTest
    {
        IDataIOService _fileService;

        [TestInitialize]
        public void TestInit()
        {
            _fileService = Factory.CreateFileService();
        }
        [TestCleanup]
        public void TestClean()
        {
            _fileService = null;
        }
        [TestMethod]
        public void TestReadFile_Successful()
        {
      //      var fileService = new FileService();
      //      Assembly thisAssembly = Assembly.GetExecutingAssembly();

      //      string path = "DroneScheduler.DroneProject.MockData.orders.txt";
      //      var stream= new StreamReader(thisAssembly.GetManifestResourceStream(path));
      //      string dir = System.IO.Path.GetDirectoryName(
      //System.Reflection.Assembly.GetExecutingAssembly().Location);

        }
      
        [TestMethod]
        [ExpectedException(typeof(Exception), "Something went wrong:")]
        public void TestReadFile_FileNotFoundException()
        {
            _fileService.ReadOrders(@"c:\orders.text");
        }
        [TestMethod]
        public void TestFileOutPut_Successful()
        {
            var expected = System.AppDomain.CurrentDomain.BaseDirectory + @"output.txt"; ;
            var actual = _fileService.CreateOutput(new List<Delivery>());
            Assert.AreEqual(expected,actual);
        }
    }
}
