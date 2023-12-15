﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace practic.Commands
{
    public class Command:ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        private readonly Action<object?> _execute;
        private readonly Predicate<object?>? _canExecute;


        public Command(Action<object?> execute, Predicate<object?>? canExecute = null)
        {
            ArgumentNullException.ThrowIfNull(execute, nameof(execute));

            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
            => _canExecute == null || _canExecute(parameter);

        public void Execute(object? parameter)
            => _execute(parameter);
    }
}
