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
    class ProjectListViewModel : ViewModelBase
    {
        private ClientRepository _clientRepository;
        private ProjectRepository _projectRepository;
        private StatusesRepository _statusesRepository;

        public ObservableCollection<Client> AllClients { get; private set; }
        public ObservableCollection<Project> AllProjects { get; private set; }
        public ObservableCollection<string> AllStatuses { get; private set; }

        public ProjectListViewModel(ClientRepository _clientRepository, ProjectRepository _projectRepository, StatusesRepository _statusesRepository)
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
        
        private Project testProject = new Project("123", "123", new Client("name123", "phone123", "email123", "123"));

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
    }
}
