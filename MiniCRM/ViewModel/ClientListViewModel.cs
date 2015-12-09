using MiniCRM.Model;
using MiniCRM.Repository;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MiniCRM.ViewModel
{
    class ClientListViewModel : ViewModelBase
    {
        private ClientRepository _clientRepository;
        private ProjectRepository _projectRepository;
        private StatusesRepository _statusesRepository;

        public ObservableCollection<Client> AllClients { get; private set; }
        public ObservableCollection<Project> AllProjects { get; private set; }
        public ObservableCollection<string> AllStatuses { get; private set; }

        public ClientListViewModel(ClientRepository _clientRepository, ProjectRepository _projectRepository, StatusesRepository _statusesRepository)
        {
            this._clientRepository = _clientRepository;
            this._projectRepository = _projectRepository;
            this._statusesRepository = _statusesRepository;

            AllClients = new ObservableCollection<Client>(_clientRepository.GetClients());
            AllProjects = new ObservableCollection<Project>(_projectRepository.GetProjects());
            AllStatuses = new ObservableCollection<string>(_statusesRepository.GetStatuses());
        }

        protected override void OnDispose()
        {
            AllClients.Clear();
            AllProjects.Clear();
            AllStatuses.Clear();
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
