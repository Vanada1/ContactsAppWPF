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
using ViewModel.ControlViewModels;

namespace ViewModel
{
    /// <summary>
    /// ViewModel for window AddEditContactWindow
    /// </summary>
    public class ContactWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// PersonDataControlViewModel
        /// </summary>
        public PersonDataControlViewModel PersonDataControlViewModel { get; set; }

        public bool IsEnable => !PersonDataControlViewModel.Contact.HasErrors;

        /// <summary>
        /// Command when you click on the Ok button
        /// </summary>
        public RelayCommand OkCommand { get; set; }

        /// <summary>
        ///  Command when clicking the Cancel button
        /// </summary>
        public RelayCommand CancelCommand { get; set; }

        public ContactWindowViewModel(Contact contact)
        {
            PersonDataControlViewModel = new PersonDataControlViewModel(false, contact);
            PersonDataControlViewModel.Contact.PropertyChanged += ContactChanged;
        }
        
        public ContactWindowViewModel():this(new Contact()){}


        private void ContactChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(IsEnable));
        }
    }
}
