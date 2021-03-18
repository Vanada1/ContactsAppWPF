using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Services;

namespace ContactsAppUI.Services
{
    class AddEditWindowService:IWindowService
    {
        public bool? ShowDialog(object dataContext)
        {
            var window = new AddEditContactWindow {DataContext = dataContext};
            return window.ShowDialog();
        }
    }
}
