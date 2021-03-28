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
	    private PersonDataControlViewModel _personDataControlViewModel;

	    /// <summary>
	    /// PersonDataControlViewModel
	    /// </summary>
	    public PersonDataControlViewModel PersonDataControlViewModel
	    {
		    get => _personDataControlViewModel;
		    set
		    {
			    _personDataControlViewModel = value;
                OnPropertyChanged(nameof(PersonDataControlViewModel));
		    }
	    }

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
	        contact.PropertyChanged += ContactChanged;
	        PersonDataControlViewModel = new PersonDataControlViewModel(false, contact);
        }
        
        public ContactWindowViewModel():this(new Contact()){}


        private void ContactChanged(object sender, PropertyChangedEventArgs e)
        {
	        OkCommand?.RaiseCanExecuteChanged();
        }
    }
}
