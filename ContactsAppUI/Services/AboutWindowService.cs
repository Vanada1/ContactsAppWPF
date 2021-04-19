using ViewModel.Services;

namespace ContactsAppUI.Services
{
    /// <summary>
    /// Service for display about window
    /// </summary>
    class AboutWindowService:IInformationWindow
    {
	    public void Show()
	    {
		    var aboutWindow = new AboutWindow();
		    aboutWindow.ShowDialog();
	    }
    }
}
