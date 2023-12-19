using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Task3SqlWpf.MVVM.Core
{
    internal class RelayCommand
    {
        public class Relaycommand : ICommand
        {
            private readonly Action<object> _execute;
            private readonly Func<object, bool> _canExecute;
            private Action<object> value;

            public Relaycommand(Action<object> value)
            {
                this.value = value;
                _execute = value;
            }

            public event EventHandler? CanExecuteChanged;

            public bool CanExecute(object? parameter)
            {
                throw new NotImplementedException();
            }

            public void Execute(object? parameter)
            {
                throw new NotImplementedException();
            }
        }
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            execute = execute ?? throw new ArgumentNullException(nameof(execute));
            canExecute = canExecute;
        }
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        public bool CanExecute(object parameter)
        {
            return this.CanExecute == null || this.CanExecute(parameter);

        }
        public void Execute(object parameter)
        {
            Execute(parameter);
        }
    }
}
