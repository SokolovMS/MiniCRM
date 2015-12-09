using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCRM.Model
{
    public class Client
    {
        public string Name { get; set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string CompanyName { get; set; }

        public Client(string Name, string Phone, string Email, string CompanyName)
        {
            this.Name = Name;
            this.Phone = Phone;
            this.Email = Email;
            this.CompanyName = CompanyName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Client)) return false;
            Client cl = (Client)obj;

            return
                Name.Equals(cl.Name) &&
                Phone.Equals(cl.Phone) &&
                Email.Equals(cl.Email) &&
                CompanyName.Equals(cl.CompanyName);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
