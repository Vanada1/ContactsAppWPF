using System;
using System.Windows.Input;

namespace ViewModel.Commands
{
	/// <summary>
	/// Command class
	/// </summary>
	public class RelayCommand : ICommand
	{
		/// <summary>
		/// Method call
		/// </summary>
		private Action<object> _execute;

		/// <summary>
		/// Can call the method
		/// </summary>
		private Func<object, bool> _canExecute;

		/// <inheritdoc />
		public event EventHandler CanExecuteChanged;


		public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
		{
			_execute = execute;
			_canExecute = canExecute;
		}

		/// <inheritdoc />
		public bool CanExecute(object parameter)
		{
			return _canExecute == null || _canExecute(parameter);
		}

		/// <inheritdoc />
		public void Execute(object parameter)
		{
			_execute(parameter);
		}

		/// <summary>
		/// Check could execute
		/// </summary>
		public void RaiseCanExecuteChanged()
		{
			CanExecuteChanged?.Invoke(this, new EventArgs());
		}
	}
}
