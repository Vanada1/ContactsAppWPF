using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ContactsApp;
using ViewModel.Annotations;
using ViewModel.Commands;

namespace ViewModel
{
    /// <summary>
    /// ViewModel для окна AddEditContactWindow
    /// </summary>
    public class AddEditContactWindowViewModel:INotifyPropertyChanged
    {
        /// <summary>
        /// Контакт
        /// </summary>
        public Contact Contact { get; set; }

        /// <summary>
        /// Команда при нажатии на кнопку Ок
        /// </summary>
        public RelayCommand OkCommand { get; set; }

        /// <summary>
        ///  Команда при нажатии на кнопку Cancel
        /// </summary>
        public RelayCommand CancelCommand { get; set; }

        public AddEditContactWindowViewModel(Contact contact)
        {
            Contact = contact;
        }

        public AddEditContactWindowViewModel():this(null){}

        public bool IsNotEmptyFields()
        {
            const string errorName = "Error";
            var properties = Contact.GetType().GetProperties();
            foreach (var property in properties)
            {
                try
                {
                    if(property.Name == errorName) continue;

                    var propertyValue = property.GetValue(Contact);
                    if (propertyValue is DateTime dateTime)
                    {
                        DateValidator.AssertDate(dateTime);
                    }
                    else if (propertyValue is PhoneNumber phoneNumber)
                    {
                        StringValidator.AssertPhoneNumber(phoneNumber.Number, PhoneNumber.MaxPhoneNumberSymbolsCount);
                    }
                    else
                    {
                        var nameProperty = property.Name;
                        var maxLetters = nameProperty == nameof(Contact.VkId)
                            ? Contact.MaxVkLettersCount
                            : Contact.MaxLettersCount;
                        StringValidator.AssertStringLength(propertyValue.ToString(),
                            maxLetters, nameProperty);
                    }
                }
                catch (ArgumentException)
                {
                    return false;
                }
                catch(TargetParameterCountException){}
            }

            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
