using MiniCRM.Repository;
using System.Collections.ObjectModel;

namespace MiniCRM.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ClientRepository _clientRepository = new ClientRepository();
        private StatusesRepository _statusesRepository = new StatusesRepository();
        private ProjectRepository _projectRepository = new ProjectRepository();

        private ObservableCollection<ViewModelBase> _viewModels = new ObservableCollection<ViewModelBase>();

        public MainWindowViewModel()
        {
            ClientListViewModel clientViewModel = new ClientListViewModel(_clientRepository, _projectRepository, _statusesRepository);
            ProjectListViewModel projectListViewModel = new ProjectListViewModel(_clientRepository, _projectRepository, _statusesRepository);

            this.ViewModels.Add(clientViewModel);
            this.ViewModels.Add(projectListViewModel);
        }

        public ObservableCollection<ViewModelBase> ViewModels
        {
            get
            {
                return _viewModels;
            }
        }
    }
}
