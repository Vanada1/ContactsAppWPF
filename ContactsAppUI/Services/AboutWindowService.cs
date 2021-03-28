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
    class AboutWindowService:IInformationWindow
    {
	    public void Show()
	    {
		    var aboutWindow = new AboutWindow();
		    aboutWindow.ShowDialog();
	    }
    }
}
