using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using ContactsApp;
using ViewModel;
using ViewModel.Commands;
using ViewModel.Services;

namespace ContactsAppUI.Services
{
    /// <summary>
    /// To work with the _window for adding / changing a contact
    /// </summary>
    public class ContactWindowService :IWindowService
    {
        /// <summary>
        /// Add edit contact window
        /// </summary>
        private ContactWindow _window;

        /// <inheritdoc />
        public bool DialogResult { get; set; } = false;

        /// <inheritdoc />
        public RelayCommand OkCommand { get; set; }

        /// <inheritdoc />
        public RelayCommand CancelCommand { get; set; }

        public ContactWindowService()
        {
            OkCommand = new RelayCommand(SetOk, CanSetOk);
            CancelCommand = new RelayCommand(SetCancel);
        }

        /// <inheritdoc />
        public void ShowDialog(object dataContext)
        {
            _window = new ContactWindow(dataContext);
            _window.ShowDialog();
        }


        /// <summary>
        /// Close window and <see cref="DialogResult"/> is true
        /// </summary>
        /// <param name="sender"></param>
        private void SetOk(object sender)
        {
            DialogResult = true;
            _window.Close();
        }

        /// <summary>
        /// Can close window and <see cref="DialogResult"/> is true
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool CanSetOk(object arg)
        {
	        if (arg == null)
	        {
		        var model = (ContactWindowViewModel)_window.DataContext;
		        return !model.PersonDataControlViewModel.Contact.HasErrors;
	        }

	        var contact = ((ContactWindowViewModel) arg).PersonDataControlViewModel.Contact;
	        return !contact.HasErrors;
        }

        /// <summary>
        /// Close window and <see cref="DialogResult"/> is false
        /// </summary>
        /// <param name="sender"></param>
        private void SetCancel(object sender)
        {
            DialogResult = false;
            _window.Close();
        }
    }
}
