using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsApp;
using ViewModel.Commands;

namespace ViewModel
{
    /// <summary>
    /// ViewModel для окна AddEditContactWindow
    /// </summary>
    public class AddEditContactWindowViewModel
    {
        /// <summary>
        /// Контакт
        /// </summary>
        public Contact Contact { get; set; }

        /// <summary>
        /// Команда при нажатии на кнопку Ок
        /// </summary>
        public RelayCommand OkCommand { get; set; }

        /// <summary>
        ///  Команда при нажатии на кнопку Cancel
        /// </summary>
        public RelayCommand CancelCommand { get; set; }

        public AddEditContactWindowViewModel(Contact contact)
        {
            Contact = contact;
        }

        public AddEditContactWindowViewModel():this(null){}
    }
}
