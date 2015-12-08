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
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }

        public Client(string Name, string Phone, string Email, string CompanyName)
        {
            this.Name = Name;
            this.Phone = Phone;
            this.Email = Email;
            this.CompanyName = CompanyName;
        }
    }
}
