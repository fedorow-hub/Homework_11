using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_11.Models.Worker;
using System.Windows.Input;
using Homework_11.ViewModels.Base;

namespace Homework_11.ViewModels
{
    internal class LoginWindowViewModel : ViewModel
    {

        public LoginWindowViewModel()
        {

        }

        #region Commands

        #region SetWorkerMode
        public ICommand SetConsultantMode { get; }
        private void OnSetConsultantModeExecuted(object p)
        {            
            //OpenMainWindow(new Consultant(), p);
        }
        private bool CanSetConsultantModeExecute(object p) => true;
        #endregion

        #region SetManagerMode
        public ICommand SetManagerMode { get; }
        private void OnSetManagerModeExecuted(object p)
        {            
            //OpenMainWindow(new Manager(), p);
        }
        private bool CanSetManagerModeExecute(object p) => true;
        #endregion

        //private void OpenMainWindow(Worker worker, object p)
        //{
        //    MainWindow mainWindow = new MainWindow();
        //    mainWindow.DataContext = new MainWindowViewModel(worker);
        //    mainWindow.Show();
            

        //    if (p is Window window)
        //    {
        //        window.Close();
                
        //    }
        //}

        #endregion
    }
}
