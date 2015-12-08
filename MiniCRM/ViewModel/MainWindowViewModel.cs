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
            ClientListViewModel clientViewModel = new ClientListViewModel(_clientRepository);
            this.ViewModels.Add(clientViewModel);
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
