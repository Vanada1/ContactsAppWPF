using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Commands;
using ViewModel.ControlViewModels;

namespace ViewModel
{
    public class Command
    {
        /// <summary>
        /// Команда на удаление контакта
        /// </summary>
        public RelayCommand RemoveContactCommand { get; }

        /// <summary>
        /// Команда на добавление контакта
        /// </summary>
        public RelayCommand AddContactCommand { get; set; }

        /// <summary>
        /// Команда на изменения контакта
        /// </summary>
        public RelayCommand EditContactCommand { get; set; }

        public Command()
        {
            RemoveContactCommand= new RelayCommand(RemoveContact);
        }

        /// <summary>
        /// Удаляет выбранный объект
        /// </summary>
        /// <param name="obj"><see cref="ContactsListControlViewModel"/></param>
        private void RemoveContact(object obj)
        {
            if (!(obj is ContactsListControlViewModel model))
            {
                throw new TypeAccessException("Inappropriate data type");
            }

            if (model.SelectedContact == null)
            {
                throw new ArgumentNullException("Item not selected");
            }

            model.AllContacts.Remove(model.SelectedContact);
        }
    }
}
