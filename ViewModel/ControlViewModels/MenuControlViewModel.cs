using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ViewModel.Services;

namespace ViewModel.ControlViewModels
{
    public class MenuControlViewModel : ViewModelBase
    {
        /// <summary>
        /// For open about window
        /// </summary>
        private readonly IWindowService _windowService;

        /// <summary>
        /// Returns the commands used by buttons
        /// </summary>
        public Command Command { get; }

        /// <summary>
        /// Returns all contacts
        /// </summary>
        public ContactsListControlViewModel ContactsListControlViewModel { get; }

        /// <summary>
        /// Open about window command
        /// </summary>
        private RelayCommand _aboutCommand;

        /// <summary>
        /// Return exit command
        /// </summary>
        public RelayCommand ExitCommand { get; set; }

        /// <summary>
        /// Return open about window command
        /// </summary>
        public RelayCommand AboutCommand => _aboutCommand ?? (_aboutCommand = new RelayCommand(() =>
        {
            _windowService.ShowDialog(null);
        }));

        public MenuControlViewModel(ContactsListControlViewModel contactsListControlViewModelListControlViewModel,
	        IWindowService windowService, IMessageBoxService messageBoxService)
        {
	        ContactsListControlViewModel = contactsListControlViewModelListControlViewModel;
	        _windowService = windowService;
	        Command = new Command(windowService, messageBoxService);
        }
    }
}
