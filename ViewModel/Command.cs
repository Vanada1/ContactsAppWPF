using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsApp;
using ViewModel.Commands;
using ViewModel.ControlViewModels;
using ViewModel.Enumerators;
using ViewModel.Services;

namespace ViewModel
{
    /// <summary>
    /// Basic command class
    /// </summary>
    public class Command
    {
        /// <summary>
        /// Service for display new window
        /// </summary>
        private IWindowService _windowService;

        /// <summary>
        /// Service for display messageBox
        /// </summary>
        private IMessageBoxService _messageBoxService;

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
                //TODO: сохранение
            }));

        /// <summary>
        /// Return command to add a contact
        /// </summary>
        public RelayCommand AddContactCommand => _addContactCommand ?? (_addContactCommand = new RelayCommand(o =>
        {
            var viewModel = new ContactWindowViewModel();
            if (_windowService.ShowDialog(viewModel) != true) return;

            ((ContactsListControlViewModel)o).AllContacts.Add(viewModel.PersonDataControlViewModel.Contact);
            //TODO: сохранение
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

            var window = new ContactWindowViewModel((Contact) listBoxControl.SelectedContact.Clone());
            var itemIndex = listBoxControl.AllContacts.IndexOf(listBoxControl.SelectedContact);
            if (_windowService.ShowDialog(window) != true) return;

            listBoxControl.SelectedContact =
                listBoxControl.AllContacts[itemIndex] = window.PersonDataControlViewModel.Contact;
            //TODO: сохранение
        }));

        public Command(IWindowService windowService, IMessageBoxService messageBoxService)
        {
            _windowService = windowService;
            _messageBoxService = messageBoxService;
        }
    }
}
