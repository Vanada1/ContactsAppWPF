using ContactsApp;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ViewModel.ControlViewModels;
using ViewModel.Enumerators;
using ViewModel.Services;

namespace ViewModel
{
    /// <summary>
    /// Basic command class
    /// </summary>
    public class Command : ViewModelBase
    {
        /// <summary>
        /// Service for display new window
        /// </summary>
        private readonly IWindowService _windowService;

        /// <summary>
        /// Service for display messageBox
        /// </summary>
        private readonly IMessageBoxService _messageBoxService;

        /// <summary>
        /// Command to delete a contact
        /// </summary>
        private RelayCommand<object> _removeContactCommand;

        /// <summary>
        /// Command to add a contact
        /// </summary>
        private RelayCommand<object> _addContactCommand;

        /// <summary>
        /// Command to edit contact
        /// </summary>
        private RelayCommand<object> _editContactCommand;

        /// <summary>
        /// Return command delete a contact
        /// </summary>
        public RelayCommand<object> RemoveContactCommand => _removeContactCommand ?? 
                                                            (_removeContactCommand = new RelayCommand<object>(o =>
            {
	            var listBoxControl = GetContactsListControlViewModel(o);
	            if (listBoxControl.SelectedContact == null)
                {
                    _messageBoxService.Show("Item not selected", "Alert",
                        MessageBoxButton.Ok, MessageBoxImage.Warning);
                    return;
                }

                listBoxControl.AllContacts.Remove(listBoxControl.SelectedContact);
                RaisePropertyChanged(nameof(RemoveContactCommand));
            }));

        /// <summary>
        /// Return command to add a contact
        /// </summary>
        public RelayCommand<object> AddContactCommand => _addContactCommand ??
                                                         (_addContactCommand = new RelayCommand<object>(o =>
        {
            var viewModel = new ContactWindowViewModel
            {
                OkCommand = _windowService.OkCommand,
                CancelCommand = _windowService.CancelCommand
            };
            _windowService.ShowDialog(viewModel);
            if (!_windowService.DialogResult) return;

            var listBoxControl = GetContactsListControlViewModel(o);
            listBoxControl.AllContacts.Add(viewModel.PersonDataControlViewModel.Contact);
            RaisePropertyChanged(nameof(AddContactCommand));
        }));

        /// <summary>
        /// Return command to edit contact 
        /// </summary>
        public RelayCommand<object> EditContactCommand => _editContactCommand ?? 
                                                          (_editContactCommand = new RelayCommand<object>(o =>
        {
	        var listBoxControl = GetContactsListControlViewModel(o);
	        if (listBoxControl.SelectedContact == null)
            {
                _messageBoxService.Show("Select Item", "Alert",
                    MessageBoxButton.Ok, MessageBoxImage.Warning);
                return;
            }

            var window = new ContactWindowViewModel((Contact) listBoxControl.SelectedContact.Clone())
            {
                OkCommand = _windowService.OkCommand,
                CancelCommand = _windowService.CancelCommand
            };
            var itemIndex = listBoxControl.AllContacts.IndexOf(listBoxControl.SelectedContact);
            _windowService.ShowDialog(window);
            if (!_windowService.DialogResult) return;

            listBoxControl.SelectedContact =
                listBoxControl.AllContacts[itemIndex] = window.PersonDataControlViewModel.Contact;
            RaisePropertyChanged(nameof(EditContactCommand));
        }));

        public Command(IWindowService windowService, IMessageBoxService messageBoxService)
        {
            _windowService = windowService;
            _messageBoxService = messageBoxService;
        }

        /// <summary>
        /// Returns <see cref="ContactsListControlViewModel"/> object
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private ContactsListControlViewModel GetContactsListControlViewModel(object o)
        {
	        ContactsListControlViewModel listBoxControl;
	        if (o is MenuControlViewModel menu)
	        {
		        listBoxControl = menu.ContactsListControlViewModel;

	        }
	        else
	        {
		        listBoxControl = (ContactsListControlViewModel)o;
	        }

	        return listBoxControl;
        }
    }
}
