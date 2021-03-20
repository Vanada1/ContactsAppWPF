using System;
using System.Collections.Generic;
using System.Text;
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
            OkCommand = new RelayCommand(SetOk);
            CancelCommand = new RelayCommand(SetCancel);
        }

        /// <inheritdoc />
        public void ShowDialog(object dataContext)
        {
            _window = new ContactWindow(((ContactWindowViewModel)dataContext).PersonDataControlViewModel.Contact)
                {DataContext = dataContext};
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
