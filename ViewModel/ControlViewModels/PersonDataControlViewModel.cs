using ContactsApp;
using GalaSoft.MvvmLight;

namespace ViewModel.ControlViewModels
{
    public class PersonDataControlViewModel : ViewModelBase
    {
        /// <summary>
        /// PersonDataControlViewModel
        /// </summary>
        private Contact _contact;

        /// <summary>
        /// IsReadOnly for textboxes
        /// </summary>
        private bool _isReadOnly;

        /// <summary>
        /// Return and set contact
        /// </summary>
        public Contact Contact
        {
            get => _contact;
            set => Set(ref _contact, value);
        }

        /// <summary>
        /// Return and set IsReadOnly for textboxes
        /// </summary>
        public bool IsReadOnly
        {
            get => _isReadOnly;
            set
            {
	            Set(ref _isReadOnly, value);
                RaisePropertyChanged(nameof(IsEnable));
            }
        }

        /// <summary>
        /// IsEnable calendar
        /// </summary>
        public bool IsEnable => !IsReadOnly;

        public PersonDataControlViewModel(bool isReadOnly, Contact contact)
        {
            IsReadOnly = isReadOnly;
            Contact = contact;
        }
    }
}
