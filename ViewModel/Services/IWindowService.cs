using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Commands;

namespace ViewModel.Services
{
    /// <summary>
    /// Interface to show second window
    /// </summary>
    public interface IWindowService
    {
        /// <summary>
        /// Dialog result
        /// </summary>
        bool DialogResult { get; }

        /// <summary>
        /// Command for processing the Ok button
        /// </summary>
        RelayCommand OkCommand { get; set; }

        /// <summary>
        /// Command for handling the Cancel button
        /// </summary>
        RelayCommand CancelCommand { get; set; }

        /// <summary>
        /// Shows second window
        /// </summary>
        /// <param name="dataContext"></param>
        void ShowDialog(object dataContext);
    }
}
