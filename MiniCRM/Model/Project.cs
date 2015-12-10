using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCRM.Model
{
    public class Project
    {
        private enum Type
        {
            WithoutEndDate,
            WithEndDate
        }

        public string name { get; set; }
        public string status { get; set; }
        public Client client { get; set; }

        private Type type { get; set; }
        private DateTime endDateTime { get; set; }

        public Project(string name, string status, Client client)
        {
            this.name = name;
            this.status = status;
            this.client = client;

            type = Type.WithoutEndDate;
            endDateTime = DateTime.MinValue;
        }
        public Project(string name, string status, Client client, DateTime endDateTime)
        {
            this.name = name;
            this.status = status;
            this.client = client;

            type = Type.WithEndDate;
            this.endDateTime = endDateTime;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Project)) return false;
            Project pr = (Project)obj;

            return
                name.Equals(pr.name) &&
                status.Equals(pr.status) &&
                client.Equals(pr.client) &&
                type.Equals(pr.type) &&
                endDateTime.Equals(pr.endDateTime);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // Выставление счёта
        public void InvoiceProject(DateTime invoiceDate)
        {
            string invoice = InvoiceAsString(invoiceDate);

            if (invoice.Equals(""))
                return;

            string filename = BillNumber.GetCurrent() + ".txt";
            File.WriteAllText(filename, invoice);
            BillNumber.Next();
        }
        public string InvoiceAsString(DateTime invoiceDate)
        {
            if (type.Equals(Type.WithEndDate) && !endDateTime.Equals(invoiceDate))
                return "";
            if (type.Equals(Type.WithoutEndDate) &&
                !invoiceDate.Day.Equals(DateTime.DaysInMonth(endDateTime.Year, endDateTime.Month)))
                return "";

            return GetBillAsString(BillNumber.GetCurrent(), invoiceDate);
        }

        private string GetBillAsString(int billNumber, DateTime invoiceDate)
        {
            string res = "Имя клиента: " + client.Name + Environment.NewLine
                + "Счёт номер: " + billNumber + Environment.NewLine
                + "Дата выставления: " + invoiceDate + Environment.NewLine;

            return res;
        }
    }
}
