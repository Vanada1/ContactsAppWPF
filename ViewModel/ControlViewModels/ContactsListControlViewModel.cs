using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ContactsApp;
using ViewModel.Annotations;
using ViewModel.Commands;

namespace ViewModel.ControlViewModels
{
    public class ContactsListControlViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Выбранный контакт
        /// </summary>
        private Contact _selectedContact;

        /// <summary>
        /// Строка поиска
        /// </summary>
        private string _searchingString;

        private ObservableCollection<Contact> _searchedContacts;

        /// <summary>
        /// Возвращает все контакты
        /// </summary>
        public ObservableCollection<Contact> AllContacts { get; }

        /// <summary>
        /// Возвращает и устанавливает все найденные контакты
        /// </summary>
        public ObservableCollection<Contact> SearchedContacts 
        { 
            get => _searchedContacts;
            set
            {
                _searchedContacts = value;
                OnPropertyChanged(nameof(SearchedContacts));
            }

        }

        /// <summary>
        /// Возвращает команды, которые используются кнопками
        /// </summary>
        public Command Command { get; }

        /// <summary>
        /// Возвращает и устанавливает выбранный контакт 
        /// </summary>
        public Contact SelectedContact
        {
            get => _selectedContact;
            set
            {
                _selectedContact = value;
                OnPropertyChanged(nameof(SelectedContact));
            }
        }
        
        /// <summary>
        /// Возвращает и устанавливает поисковую строку
        /// </summary>
        public string SearchingString
        {
            get => _searchingString;
            set
            {
                _searchingString = value;
                OnPropertyChanged(nameof(SearchingString));
                SearchedStringChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public ContactsListControlViewModel(ObservableCollection<Contact> allContacts)
        {
            SearchedContacts = AllContacts = allContacts;
            Command = new Command();
        }

        /// <summary>
        /// Событие, возникающее при изменении поисковой строки
        /// </summary>
        public event EventHandler SearchedStringChanged;

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
