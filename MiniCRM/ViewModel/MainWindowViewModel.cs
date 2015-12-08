using MiniCRM.Repository;
using System.Collections.ObjectModel;

namespace MiniCRM.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        readonly ClientRepository _clientRepository;

        ObservableCollection<ViewModelBase> _viewModels;

        public MainWindowViewModel()
        {
            _clientRepository = new ClientRepository();

            ClientListViewModel clientViewModel = new ClientListViewModel(_clientRepository);
            this.ViewModels.Add(clientViewModel);
        }

        public ObservableCollection<ViewModelBase> ViewModels
        {
            get
            {
                if (_viewModels == null)
                {
                    _viewModels = new ObservableCollection<ViewModelBase>();
                }
                return _viewModels;
            }
        }
    }
}
