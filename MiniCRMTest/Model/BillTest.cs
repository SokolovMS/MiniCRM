using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniCRM.Model;

namespace MiniCRMTest.Model
{
    [TestClass]
    public class BillTest
    {
        private Client pClient = new Client("cName", "cPhone", "cEmail", "cCompanyname");

        private DateTime lastDay = new DateTime(2015, 12, 31);
        private DateTime midDay = new DateTime(2015, 12, 15);
        private DateTime firstDay = new DateTime(2015, 12, 1);

        [TestMethod]
        public void Client_UnLimitedTimeProject_WithoutBill1()
        {
            Project p = new Project("pName", "pStatus", pClient);

            string strBill = p.InvoiceAsString(firstDay);

            Assert.AreEqual("", strBill);
        }

        [TestMethod]
        public void Client_UnLimitedTimeProject_WithoutBill2()
        {
            Project p = new Project("pName", "pStatus", pClient);

            string strBill = p.InvoiceAsString(midDay);

            Assert.AreEqual("", strBill);
        }

        [TestMethod]
        public void Client_UnLimitedTimeProject_WithBill()
        {
            Project p = new Project("pName", "pStatus", pClient);

            string strBill = p.InvoiceAsString(lastDay);

            Assert.AreNotEqual("", strBill);
        }

        [TestMethod]
        public void Client_LimitedTimeProject_WithoutBill()
        {
            Project p = new Project("pName", "pStatus", pClient, midDay);

            string strBill = p.InvoiceAsString(firstDay);

            Assert.AreEqual("", strBill);
        }

        [TestMethod]
        public void Client_LimitedTimeProject_WithBill()
        {
            Project p = new Project("pName", "pStatus", pClient, midDay);

            string strBill = p.InvoiceAsString(midDay);

            Assert.AreNotEqual("", strBill);
        }
    }
}
