using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Commands;
using ViewModel.Services;

namespace ContactsAppUI.Services
{
    /// <summary>
    /// Service for display about window
    /// </summary>
    class AboutWindowService:IWindowService
    {
        /// <summary>
        /// About Window
        /// </summary>
        private readonly AboutWindow _about;

        /// <inheritdoc />
        public bool DialogResult { get; }

        /// <inheritdoc />
        public RelayCommand OkCommand { get; set; }

        /// <inheritdoc />
        public RelayCommand CancelCommand { get; set; }

        /// <inheritdoc />
        public void ShowDialog(object dataContext)
        {
            _about.ShowDialog();
        }

        public AboutWindowService()
        {
            _about = new AboutWindow();
        }
    }
}
