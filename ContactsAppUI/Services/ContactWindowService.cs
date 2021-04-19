using GalaSoft.MvvmLight.Command;
using ViewModel;
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
        private void SetOk()
        {
            DialogResult = true;
            _window.Close();
        }

        /// <summary>
        /// Can close window and <see cref="DialogResult"/> is true
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool CanSetOk()
        {
	        var model = (ContactWindowViewModel) _window.DataContext;
	        return !model.PersonDataControlViewModel.Contact.HasErrors;
        }

        /// <summary>
        /// Close window and <see cref="DialogResult"/> is false
        /// </summary>
        private void SetCancel()
        {
            DialogResult = false;
            _window.Close();
        }
    }
}
