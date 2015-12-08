using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniCRM.Model;

namespace MiniCRMTest.Model
{
    [TestClass]
    public class ProjectTest
    {
        private string dName = "1";
        private string dStatus = "2";
        private Client dClient1 = new Client("3", "4", "5", "6");
        private Client dClient2 = new Client("-3", "-4", "-5", "-6");
        private DateTime dDateTime1 = new DateTime(2015, 12, 11);
        private DateTime dDateTime2 = new DateTime(2015, 12, 12);

        [TestMethod]
        public void Project_Equals_Successful()
        {
            Project p1 = new Project(dName, dStatus, dClient1, dDateTime1);
            Project p2 = new Project(dName, dStatus, dClient1, dDateTime1);

            Assert.IsTrue(p1.Equals(p2));
        }

        [TestMethod]
        public void Project_Equals_WithNull()
        {
            Project p1 = new Project(dName, dStatus, dClient1, dDateTime1);
            object p2 = null;

            Assert.IsFalse(p1.Equals(p2));
        }

        [TestMethod]
        public void Project_Equals_WithObject()
        {
            Project p1 = new Project(dName, dStatus, dClient1, dDateTime1);
            object p2 = new object();

            Assert.IsFalse(p1.Equals(p2));
        }

        [TestMethod]
        public void Project_Equals_WrongName()
        {
            Project p1 = new Project(dName, dStatus, dClient1, dDateTime1);
            Project p2 = new Project(dName + "1", dStatus, dClient1, dDateTime1);

            Assert.IsFalse(p1.Equals(p2));
        }

        [TestMethod]
        public void Project_Equals_WrongStatus()
        {
            Project p1 = new Project(dName, dStatus, dClient1, dDateTime1);
            Project p2 = new Project(dName, dStatus + "1", dClient1, dDateTime1);

            Assert.IsFalse(p1.Equals(p2));
        }

        [TestMethod]
        public void Project_Equals_WrongClient()
        {
            Project p1 = new Project(dName, dStatus, dClient1, dDateTime1);
            Project p2 = new Project(dName, dStatus, dClient2, dDateTime1);

            Assert.IsFalse(p1.Equals(p2));
        }

        [TestMethod]
        public void Project_Equals_WrongDateTime()
        {
            Project p1 = new Project(dName, dStatus, dClient1, dDateTime1);
            Project p2 = new Project(dName, dStatus, dClient1, dDateTime2);

            Assert.IsFalse(p1.Equals(p2));
        }
    }
}
