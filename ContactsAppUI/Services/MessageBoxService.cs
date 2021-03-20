using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using ViewModel.Services;
using MessageBoxButton = ViewModel.Enumerators.MessageBoxButton;
using MessageBoxImage = ViewModel.Enumerators.MessageBoxImage;

namespace ContactsAppUI
{
    /// <summary>
    /// Shows the MessageBox
    /// </summary>
    class MessageBoxService :IMessageBoxService
    {
        /// <summary>
        /// Dictionary for defining buttons
        /// </summary>
        private readonly Dictionary<MessageBoxButton, System.Windows.MessageBoxButton> _buttons =
            new Dictionary<MessageBoxButton, System.Windows.MessageBoxButton>
            {
                {MessageBoxButton.Ok, System.Windows.MessageBoxButton.OK},
                {MessageBoxButton.OkCancel, System.Windows.MessageBoxButton.OKCancel},
                {MessageBoxButton.YesNo, System.Windows.MessageBoxButton.YesNo},
                {MessageBoxButton.YesNoCancel, System.Windows.MessageBoxButton.YesNoCancel}
            };

        /// <summary>
        /// Dictionary for defining a picture in a MessageBox
        /// </summary>
        private readonly Dictionary<MessageBoxImage, System.Windows.MessageBoxImage> _images =
            new Dictionary<MessageBoxImage, System.Windows.MessageBoxImage>
            {
                {MessageBoxImage.Error, System.Windows.MessageBoxImage.Error},
                {MessageBoxImage.Info, System.Windows.MessageBoxImage.Information},
                {MessageBoxImage.None, System.Windows.MessageBoxImage.None},
                {MessageBoxImage.Warning, System.Windows.MessageBoxImage.Warning}
            };

        /// <inheritdoc />
        public void Show(string message, string title, MessageBoxButton button, MessageBoxImage image)
        {
            MessageBox.Show(message, title, _buttons[button], _images[image]);
        }
    }
}
