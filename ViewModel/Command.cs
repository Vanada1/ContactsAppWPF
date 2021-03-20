using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ContactsApp;
using ContactsApp.Annotations;
using ViewModel.Commands;
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
        private RelayCommand _removeContactCommand;

        /// <summary>
        /// Command to add a contact
        /// </summary>
        private RelayCommand _addContactCommand;

        /// <summary>
        /// Command to edit contact
        /// </summary>
        private RelayCommand _editContactCommand;

        /// <summary>
        /// Return command delete a contact
        /// </summary>
        public RelayCommand RemoveContactCommand =>
            _removeContactCommand ?? (_removeContactCommand = new RelayCommand(o =>
            {
                if (!(o is ContactsListControlViewModel model))
                {
                    _messageBoxService.Show("Inappropriate data type", "Error", MessageBoxButton.Ok,
                        MessageBoxImage.Error);
                    return;
                }

                if (model.SelectedContact == null)
                {
                    _messageBoxService.Show("Item not selected", "Alert",
                        MessageBoxButton.Ok, MessageBoxImage.Warning);
                    return;
                }

                model.AllContacts.Remove(model.SelectedContact);
                OnPropertyChanged(nameof(RemoveContactCommand));
            }));

        /// <summary>
        /// Return command to add a contact
        /// </summary>
        public RelayCommand AddContactCommand => _addContactCommand ?? (_addContactCommand = new RelayCommand(o =>
        {
            var viewModel = new ContactWindowViewModel
            {
                OkCommand = _windowService.OkCommand,
                CancelCommand = _windowService.CancelCommand
            };
            _windowService.ShowDialog(viewModel);
            if (!_windowService.DialogResult) return;

            ((ContactsListControlViewModel)o).AllContacts.Add(viewModel.PersonDataControlViewModel.Contact);
            OnPropertyChanged(nameof(AddContactCommand));
        }));

        /// <summary>
        /// Return command to edit contact 
        /// </summary>
        public RelayCommand EditContactCommand => _editContactCommand ?? (_editContactCommand = new RelayCommand(o =>
        {
            var listBoxControl = (ContactsListControlViewModel) o;
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
            OnPropertyChanged(nameof(EditContactCommand));
        }));

        public Command(IWindowService windowService, IMessageBoxService messageBoxService)
        {
            _windowService = windowService;
            _messageBoxService = messageBoxService;
        }
    }
}
