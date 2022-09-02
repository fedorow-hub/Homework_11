using Homework_11.Data;
using Homework_11.Infrastructure.Commands;
using Homework_11.Models;
using Homework_11.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Homework_11.ViewModels
{
    internal class MainWindowViewModel: ViewModel
    {
        
        private string _Title = "База данных клиентов";

        private Repository _Repository = new Repository(10);

        /// <summary>Заголовок окна</summary>
        public string Title
        {
            get { return _Title; }
            set => Set(ref _Title, value); 
        }

        public Repository Repository
        {
            get { return _Repository; }
            set => Set(ref _Repository, value);
        }

        #region Команды

        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;

        private void OnCloseApplicationCommandExecute(object p)
        {
            Application.Current.Shutdown();
        }
        #endregion

        #endregion



        public MainWindowViewModel()
        {
            #region Команды
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecute, CanCloseApplicationCommandExecute);
            #endregion
        }



    }
}
