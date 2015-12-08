using MiniCRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCRM.Repository
{
    public class ClientRepository
    {
        readonly List<Client> _clients;

        public ClientRepository()
        {
            if (_clients == null)
            {
                _clients = new List<Client>();
            }

            _clients.Add(new Client("name1", "phone1", "email1", "Enbridge"));
            _clients.Add(new Client("name2", "phone2", "email2", "Додо"));
            _clients.Add(new Client("name3", "phone3", "email3", "Авиком"));
            _clients.Add(new Client("name4", "phone4", "email4", "Павел"));
            _clients.Add(new Client("name5", "phone5", "email5", "Дмитрий"));
        }

        public List<Client> GetClients()
        {
            return new List<Client>(_clients);
        }
    }
}
