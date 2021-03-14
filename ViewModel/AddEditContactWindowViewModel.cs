using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ContactsApp;
using ViewModel.Annotations;
using ViewModel.Commands;

namespace ViewModel
{
    /// <summary>
    /// ViewModel for window AddEditContactWindow
    /// </summary>
    public class AddEditContactWindowViewModel:INotifyPropertyChanged
    {
        /// <summary>
        /// Contact
        /// </summary>
        public Contact Contact { get; set; }

        /// <summary>
        /// Command when you click on the Ok button
        /// </summary>
        public RelayCommand OkCommand { get; set; }

        /// <summary>
        ///  Command when clicking the Cancel button
        /// </summary>
        public RelayCommand CancelCommand { get; set; }

        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;

        public AddEditContactWindowViewModel(Contact contact)
        {
            Contact = contact;
        }

        public AddEditContactWindowViewModel():this(null){}

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
