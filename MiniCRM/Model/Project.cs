using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCRM.Model
{
    public class Project
    {
        public enum Type
        {
            WithoutEndDate,
            WithEndDate
        }

        public string name { get; private set; }
        public string status { get; set; }
        public Client client { get; private set; }

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
                name == pr.name &&
                status == pr.status &&
                client == pr.client &&
                type == pr.type &&
                endDateTime == pr.endDateTime;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
