using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniCRM.Model;

namespace MiniCRMTest.Model
{
    [TestClass]
    public class ClientTest
    {
        private string dName = "1";
        private string dPhone = "2";
        private string dEmail = "3";
        private string dCompanyName = "4";

        [TestMethod]
        public void Client_Equals_Successful()
        {
            Client c1 = new Client(dName, dPhone, dEmail, dCompanyName);
            Client c2 = new Client(dName, dPhone, dEmail, dCompanyName);

            Assert.IsTrue(c1.Equals(c2));
        }

        [TestMethod]
        public void Client_Equals_WithNull()
        {
            Client c1 = new Client(dName, dPhone, dEmail, dCompanyName);
            object c2 = null;

            Assert.IsFalse(c1.Equals(c2));
        }

        [TestMethod]
        public void Client_Equals_WithObject()
        {
            Client c1 = new Client(dName, dPhone, dEmail, dCompanyName);
            object c2 = new object();

            Assert.IsFalse(c1.Equals(c2));
        }

        [TestMethod]
        public void Client_Equals_WrongName()
        {
            Client c1 = new Client(dName, dPhone, dEmail, dCompanyName);
            Client c2 = new Client(dName + "1", dPhone, dEmail, dCompanyName);

            Assert.IsFalse(c1.Equals(c2));
        }

        [TestMethod]
        public void Client_Equals_WrongPhone()
        {
            Client c1 = new Client(dName, dPhone, dEmail, dCompanyName);
            Client c2 = new Client(dName, dPhone + "1", dEmail, dCompanyName);

            Assert.IsFalse(c1.Equals(c2));
        }

        [TestMethod]
        public void Client_Equals_WrongEmail()
        {
            Client c1 = new Client(dName, dPhone, dEmail, dCompanyName);
            Client c2 = new Client(dName, dPhone, dEmail + "1", dCompanyName);

            Assert.IsFalse(c1.Equals(c2));
        }

        [TestMethod]
        public void Client_Equals_WrongCompanyName()
        {
            Client c1 = new Client(dName, dPhone, dEmail, dCompanyName);
            Client c2 = new Client(dName, dPhone, dEmail, dCompanyName + "1");

            Assert.IsFalse(c1.Equals(c2));
        }
    }
}
