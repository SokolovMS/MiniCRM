using MiniCRM.Model;
using MiniCRM.Repository;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MiniCRM.ViewModel
{
    public class ClientListViewModel : ViewModelBase
    {
        readonly ClientRepository _clientRepository;

        private ObservableCollection<Model.Client> _AllClients;
        public ObservableCollection<Model.Client> AllClients
        {
            get
            {
                return _AllClients;
            }
            private set
            {
                _AllClients = value;
            }
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


        RelayCommand _invasionCommand;
        public ICommand InvasionCommand
        {
            get
            {
                if (_invasionCommand == null)
                {
                    _invasionCommand = new RelayCommand(p => this.InvasionCommandExecute(), p => this.InvasionCommandCanExecute);
                }
                return _invasionCommand;
            }
        }
        void InvasionCommandExecute()
        {
            Client cl = new Client("1", "2", "3", "4");
            _clientRepository.Add(cl);
            AllClients.Insert(AllClients.Count - 1, cl);
        }
        bool InvasionCommandCanExecute
        {
            get
            {
                return AllClients.Count.Equals(0) ? false : true;
            }
        }
    }
}
