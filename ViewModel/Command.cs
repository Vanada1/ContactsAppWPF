using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Commands;
using ViewModel.ControlViewModels;

namespace ViewModel
{
    /// <summary>
    /// Basic command class
    /// </summary>
    public class Command
    {
        /// <summary>
        /// Command to delete a contact
        /// </summary>
        public RelayCommand RemoveContactCommand { get; set; }

        /// <summary>
        /// Command to add a contact
        /// </summary>
        public RelayCommand AddContactCommand { get; set; }

        /// <summary>
        /// PersonDataControlViewModel change command
        /// </summary>
        public RelayCommand EditContactCommand { get; set; }

        public Command()
        {

        }
    }
}
