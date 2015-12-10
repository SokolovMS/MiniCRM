using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniCRM.Repository;
using System.Collections.ObjectModel;
using MiniCRM.Model;
using System.Windows.Input;

namespace MiniCRM.ViewModel
{
    class ClientProjectViewModel : ViewModelBase
    {
        private ClientRepository _clientRepository;
        private ProjectRepository _projectRepository;
        private StatusesRepository _statusesRepository;

        public ObservableCollection<Client> AllClients { get; private set; }
        public ObservableCollection<Project> AllProjects { get; private set; }
        public ObservableCollection<string> AllStatuses { get; private set; }

        public ClientProjectViewModel(ClientRepository _clientRepository, ProjectRepository _projectRepository, StatusesRepository _statusesRepository)
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

        private static Client testClient = new Client("name123", "phone123", "email123", "123");
        private static Project testProject = new Project("123", "123", testClient);

        #region 
        RelayCommand _addClientCommand;
        public ICommand AddClientCommand
        {
            get
            {
                if (_addClientCommand == null)
                {
                    _addClientCommand = new RelayCommand(p => this.AddClientCommandExecute(), p => this.AddClientCommandCanExecute);
                }
                return _addClientCommand;
            }
        }
        void AddClientCommandExecute()
        {
            Client cl = new Client("1", "2", "3", "4");
            _clientRepository.Add(cl);
            AllClients.Insert(AllClients.Count - 1, cl);
        }
        bool AddClientCommandCanExecute
        {
            get
            {
                return AllClients.Count.Equals(0) ? false : true;
            }
        }
        #endregion

        #region Add project
        RelayCommand _addProjectCommand;
        public ICommand AddProjectCommand
        {
            get
            {
                if (_addProjectCommand == null)
                {
                    _addProjectCommand = new RelayCommand(p => this.AddProjectCommandExecute(), p => this.AddProjectCommandCanExecute);
                }
                return _addProjectCommand;
            }
        }
        void AddProjectCommandExecute()
        {
            _projectRepository.Add(testProject);
            AllProjects.Insert(AllClients.Count - 1, testProject);
        }
        bool AddProjectCommandCanExecute
        {
            get
            {
                return AllProjects.Count.Equals(0) ? false : true;
            }
        }
        #endregion

        #region Remove project
        RelayCommand _removeProjectCommand;
        public ICommand RemoveProjectCommand
        {
            get
            {
                if (_removeProjectCommand == null)
                {
                    _removeProjectCommand = new RelayCommand(p => this.RemoveProjectCommandExecute(), p => this.RemoveProjectCommandCanExecute);
                }
                return _removeProjectCommand;
            }
        }
        void RemoveProjectCommandExecute()
        {
            _projectRepository.Remove(testProject);
            AllProjects.Remove(testProject);
        }
        bool RemoveProjectCommandCanExecute
        {
            get
            {
                return AllProjects.Count.Equals(0) ? false : true;
            }
        }
        #endregion

        #region Invoice projects
        RelayCommand _invoiceProjectsCommand;
        public ICommand InvoiceProjectsCommand
        {
            get
            {
                if (_invoiceProjectsCommand == null)
                {
                    _invoiceProjectsCommand = new RelayCommand(p => this.InvoiceProjectsCommandExecute(), p => this.InvoiceProjectsCommandCanExecute);
                }
                return _invoiceProjectsCommand;
            }
        }
        void InvoiceProjectsCommandExecute()
        {
            _projectRepository.invoiceProjects(new DateTime(2015, 12, 31));
            _projectRepository.invoiceProjects(new DateTime(2015, 12, 12));
            _projectRepository.invoiceProjects(new DateTime(2015, 12, 13));
        }
        bool InvoiceProjectsCommandCanExecute
        {
            get
            {
                return AllProjects.Count.Equals(0) ? false : true;
            }
        }
        #endregion
    }
}
