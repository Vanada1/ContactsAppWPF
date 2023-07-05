using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ContactsApp;
using GalaSoft.MvvmLight;

namespace ViewModel.ControlViewModels;

/// <summary>
/// ViewModel class for a list of people who have a birthday
/// </summary>
public class BirthdayControlViewModel : ViewModelBase
{
    /// <summary>
    /// All names of contacts who have a birthday
    /// </summary>
    private string _birthdayNames;

    /// <summary>
    /// Is the window visible
    /// </summary>
    private int _visibility;

    public BirthdayControlViewModel(IEnumerable<Contact> contacts)
    {
        SearchedContacts = new ObservableCollection<Contact>(contacts);
        BirthdayNames = GetBirthdayNames();
    }

    /// <summary>
    /// Returns and sets the names of found contacts who have birthday today
    /// </summary>
    public string BirthdayNames
    {
        get => _birthdayNames;
        set => Set(ref _birthdayNames, value);
    }

    /// <summary>
    /// Returns and installs found contacts who have DR
    /// </summary>
    public ObservableCollection<Contact> SearchedContacts { get; set; }

    /// <summary>
    /// Returns or sets the visibility of the window
    /// </summary>
    public int Visibility
    {
        get => _visibility;
        set => Set(ref _visibility, value);
    }

    /// <summary>
    /// Makes a string of first and last names of contacts who have DR today
    /// </summary>
    /// <returns>
    /// A string of first and last names of contacts who have a birthday today.
    /// If there are no contacts, then the control is not shown
    /// </returns>
    private string GetBirthdayNames()
    {
        if (SearchedContacts == null || SearchedContacts.Count == 0)
        {
            Visibility = 1;
            return string.Empty;
        }

        var contactsName = string.Empty;
        for (var i = 0; i < SearchedContacts.Count - 1; i++)
        {
            var contact = SearchedContacts[i];
            contactsName += contact.FirstName + " " + contact.LastName + ", ";
        }

        contactsName += SearchedContacts.Last().FirstName + " " + SearchedContacts.Last().LastName;
        return contactsName;
    }
}