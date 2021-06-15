using System;
using System.Windows.Input;
using Microsoft.Win32;

namespace ImgEDIT.Commands
{
    /*
        Абстрактный класс команды, реализующий ICommand
    */ 
    public abstract class BaseCommand : ICommand
    {
        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

       
    }
}
