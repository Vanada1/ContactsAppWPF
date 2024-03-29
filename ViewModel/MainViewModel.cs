﻿using System;
using System.Collections.ObjectModel;
using ContactsApp;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ViewModel.ControlViewModels;
using ViewModel.Services;

namespace ViewModel;

/// <summary>
/// ViewModel for window MainWindow
/// </summary>
public class MainViewModel : ViewModelBase
{
    /// <summary>
    /// Application data
    /// </summary>
    private readonly Project _project;

    /// <summary>
    /// Control with contact list
    /// </summary>
    private ContactsListControlViewModel _contactsListControlViewModel;

    /// <summary>
    /// Control with contacts who have a birthday
    /// </summary>
    private BirthdayControlViewModel _birthdayControlViewModel;

    /// <summary>
    /// Menu control
    /// </summary>
    private MenuControlViewModel _menuControlViewModel;

    /// <summary>
    /// Closing window command
    /// </summary>
    private RelayCommand _closingWindow;

    public MainViewModel(IWindowService windowService, IMessageBoxService messageBoxService)
    {
        _project = ProjectManager.ReadProject();
        ContactsListControlViewModel = new ContactsListControlViewModel(
            _project,
            windowService,
            messageBoxService);
        BirthdayControlViewModel =
            new BirthdayControlViewModel(_project.FindBirthdayContacts(DateTime.Now));
        MenuControlViewModel = new MenuControlViewModel(
            ContactsListControlViewModel,
            windowService,
            messageBoxService);
    }

    /// <summary>
    /// Revives and establishes control with contacts who have birthday
    /// </summary>
    public BirthdayControlViewModel BirthdayControlViewModel
    {
        get => _birthdayControlViewModel;
        set => Set(ref _birthdayControlViewModel, value);
    }

    public RelayCommand ClosingWindow => _closingWindow
                                         ?? (_closingWindow = new RelayCommand(
                                             () =>
                                             {
                                                 _project.Contacts =
                                                     new ObservableCollection<Contact>(
                                                         _project.SortContacts());
                                                 Save();
                                             }));

    /// <summary>
    /// PersonDataControlViewModel list item model
    /// </summary>
    public ContactsListControlViewModel ContactsListControlViewModel
    {
        get => _contactsListControlViewModel;
        set => Set(ref _contactsListControlViewModel, value);
    }

    /// <summary>
    /// Returns and sets Menu control
    /// </summary>
    public MenuControlViewModel MenuControlViewModel
    {
        get => _menuControlViewModel;
        set => Set(ref _menuControlViewModel, value);
    }

    protected void OnPropertyChanged(string propertyName = null)
    {
        base.RaisePropertyChanged(propertyName);
        Save();
    }

    /// <summary>
    /// Save application data
    /// </summary>
    private void Save()
    {
        ProjectManager.SaveProject(_project);
    }
}