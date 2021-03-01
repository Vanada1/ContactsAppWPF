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
        public RelayCommand RemoveContactCommand { get; }

        public Command()
        {
            RemoveContactCommand= new RelayCommand(RemoveContact);
        }

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
