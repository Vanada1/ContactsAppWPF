using System.ComponentModel;
using ContactsApp;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ViewModel.ControlViewModels;

namespace ViewModel;

/// <summary>
/// ViewModel for window AddEditContactWindow
/// </summary>
public class ContactWindowViewModel : ViewModelBase
{
    private PersonDataControlViewModel _personDataControlViewModel;

    public ContactWindowViewModel(Contact contact)
    {
        contact.PropertyChanged += ContactChanged;
        PersonDataControlViewModel = new PersonDataControlViewModel(false, contact);
    }

    public ContactWindowViewModel() : this(new Contact()) { }

    /// <summary>
    /// Command when clicking the Cancel button
    /// </summary>
    public RelayCommand CancelCommand { get; set; }

    /// <summary>
    /// Command when you click on the Ok button
    /// </summary>
    public RelayCommand OkCommand { get; set; }

    /// <summary>
    /// PersonDataControlViewModel
    /// </summary>
    public PersonDataControlViewModel PersonDataControlViewModel
    {
        get => _personDataControlViewModel;
        set => Set(ref _personDataControlViewModel, value);
    }

    private void ContactChanged(object sender, PropertyChangedEventArgs e)
    {
        OkCommand?.RaiseCanExecuteChanged();
    }
}