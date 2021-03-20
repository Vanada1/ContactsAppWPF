using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsApp;
using ViewModel.Commands;
using ViewModel.Services;

namespace ViewModel.ControlViewModels
{
    public class MenuControlViewModel:ViewModelBase
    {
        /// <summary>
        /// For open about window
        /// </summary>
        private IWindowService _aboutWindowService;

        /// <summary>
        /// Open about window command
        /// </summary>
        private RelayCommand _aboutCommand;

        /// <summary>
        /// Returns the commands used by buttons
        /// </summary>
        public Command Command { get; }

        /// <summary>
        /// Return exit command
        /// </summary>
        public RelayCommand ExitCommand { get; set; }

        /// <summary>
        /// Return open about window command
        /// </summary>
        public RelayCommand AboutCommand => _aboutCommand ?? (_aboutCommand = new RelayCommand(o =>
        {
            _aboutWindowService.ShowDialog(null);
        }));

        public MenuControlViewModel(IWindowService windowService, IMessageBoxService messageBoxService, IWindowService aboutWindowService)
        {
            _aboutWindowService = aboutWindowService;
            Command = new Command(windowService, messageBoxService);
        }
    }
}
