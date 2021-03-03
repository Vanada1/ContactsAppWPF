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
        public RelayCommand RemoveContactCommand { get; set; }

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

        }
    }
}
