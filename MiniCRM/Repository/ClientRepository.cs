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
        private List<Client> _clients = new List<Client>();

        public ClientRepository()
        {
            Add(new Client("name1", "phone1", "email1", "Enbridge"));
            Add(new Client("name2", "phone2", "email2", "Додо"));
            Add(new Client("name3", "phone3", "email3", "Авиком"));
            Add(new Client("name4", "phone4", "email4", "Павел"));
            Add(new Client("name5", "phone5", "email5", "Дмитрий"));
            Add(new Client("del", "del", "del", "del"));
            Remove(new Client("del", "del", "del", "del"));
        }

        public List<Client> GetClients()
        {
            return new List<Client>(_clients);
        }
        public Client Get(int index)
        {
            if (index < 0 || index >= _clients.Count)
                throw new IndexOutOfRangeException("ClientRepository.Get(" + index + ")");

            return _clients[index];
        }

        public void Add(Client newClient)
        {
            _clients.Add(newClient);
        }
        public void Remove(Client client)
        {
            _clients.Remove(client);
        }
    }
}
