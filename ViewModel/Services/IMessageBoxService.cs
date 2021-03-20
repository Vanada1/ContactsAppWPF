using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Enumerators;

namespace ViewModel.Services
{
    /// <summary>
    /// Interface for MessageBox
    /// </summary>
    public interface IMessageBoxService
    {
        /// <summary>
        /// Shows notification MessageBox
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="button"></param>
        /// <param name="image"></param>
        void Show(string message, string title, MessageBoxButton button, MessageBoxImage image);
    }
}
