using System;
using System.Windows.Input;

namespace GlobalLogic_Solution
{
    public class RelayCommand : ICommand
    {
        #region Private Members

        Action mAction;

        #endregion

        #region Public Events
        /// <summary>
        /// The event thats fired when the <see cref="CanExecute(object)"/> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion

        #region Constructor

        public RelayCommand(Action action)
        {
            mAction = action;
        }

        #endregion

        #region Command Methods

        public bool CanExecute(object parameter)
        {
            return true;
        }


        public void Execute(object parameter)
        {
            mAction();
        }

        #endregion
    }
}
