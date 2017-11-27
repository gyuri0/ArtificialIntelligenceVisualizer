using System;
using System.Windows.Input;

namespace ArtificialIntelligenceVisualizer.UI
{
    public class SimpleCommand : ICommand
    {
        private Action executeAction;

        private Func<bool> canExecuteFunc;

        public SimpleCommand(Action executeAction, Func<bool> canExecuteFunc)
        {
            this.executeAction = executeAction;
            this.canExecuteFunc = canExecuteFunc;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecuteFunc();
        }

        public void Execute(object parameter)
        {
            this.executeAction();
        }

        public void OnCanExecuteChange()
        {
            this.CanExecuteChanged?.Invoke(this, null);
        }

        public event EventHandler CanExecuteChanged;
    }
}
