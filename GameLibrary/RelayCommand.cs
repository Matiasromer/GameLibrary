using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameLibrary
{
    public class RelayCommand : ICommand
    {
        private Action methodToExecute = null;
        private Func<bool> methodToDectectCanExecute = null;

        public RelayCommand(Action methodToExecute, Func<bool> methodToDectectCanExecute)
        {
            this.methodToExecute = methodToExecute;
            this.methodToDectectCanExecute = methodToDectectCanExecute;
        } 

        public void Execute(object parameter)
        {
            this.methodToExecute();
        }

        public bool CanExecute(object parameter)
        {
            if (this.methodToDectectCanExecute == null)
            {
                return true;
            }
            else
            {
                return this.methodToDectectCanExecute();
            }

           
        }

        public event EventHandler CanExecuteChanged;

        
    }
}
