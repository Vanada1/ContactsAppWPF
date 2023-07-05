using GalaSoft.MvvmLight.Command;

namespace ViewModel.Services;

/// <summary>
/// Interface to show second window
/// </summary>
public interface IWindowService
{
    /// <summary>
    /// Command for handling the Cancel button
    /// </summary>
    RelayCommand CancelCommand { get; set; }

    /// <summary>
    /// Dialog result
    /// </summary>
    bool DialogResult { get; }

    /// <summary>
    /// Command for processing the Ok button
    /// </summary>
    RelayCommand OkCommand { get; set; }

    /// <summary>
    /// Shows second window
    /// </summary>
    /// <param name="dataContext"> </param>
    void ShowDialog(object dataContext);
}