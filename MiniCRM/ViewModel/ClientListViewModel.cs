using MiniCRM.Repository;
using System;
using System.Collections.ObjectModel;

namespace MiniCRM.ViewModel
{
    public class ClientListViewModel : ViewModelBase
    {
        readonly ClientRepository _clientRepository;

        public ObservableCollection<Model.Client> AllClients
        {
            get;
            private set;
        }

        public ClientListViewModel(ClientRepository clientRepository)
        {
            if (clientRepository == null)
            {
                throw new ArgumentNullException("clientRepository == null");
            }
            _clientRepository = clientRepository;
            this.AllClients = new ObservableCollection<Model.Client>(_clientRepository.GetClients());
        }

        protected override void OnDispose()
        {
            this.AllClients.Clear();
        }
    }
}
