using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ContactsApp;
using ContactsApp.Annotations;

namespace ViewModel.ControlViewModels
{
    public class PersonDataControlViewModel:INotifyPropertyChanged
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
            set
            {
                _contact = value;
                OnPropertyChanged(nameof(Contact));
            }
        }

        /// <summary>
        /// Return and set IsReadOnly for textboxes
        /// </summary>
        public bool IsReadOnly
        {
            get => _isReadOnly;
            set
            {
                _isReadOnly = value;
                OnPropertyChanged(nameof(IsReadOnly));
                OnPropertyChanged(nameof(IsEnable));
            }
        }

        public bool IsEnable => !IsReadOnly;

        public PersonDataControlViewModel(bool isReadOnly, Contact contact)
        {
            IsReadOnly = isReadOnly;
            Contact = contact;
        }

        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// Notifies about value change
        /// </summary>
        /// <param name="propertyName"></param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
