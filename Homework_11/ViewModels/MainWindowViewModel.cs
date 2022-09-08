using Homework_11.Data;
using Homework_11.Infrastructure.Commands;
using Homework_11.Models.Clients;
using Homework_11.Models.Worker;
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

        /// <summary>Заголовок окна</summary>
        public string Title
        {
            get { return _Title; }
            set => Set(ref _Title, value);
        }

        private Repository _Repository = new Repository(100);

        public Repository Repository
        {
            get { return _Repository; }
            set => Set(ref _Repository, value);
        }

        #region SelectedClient

        private Client _SelectedClient;
        /// <summary>
        /// Выбранный клиент
        /// </summary>
        public Client SelectedClient
        {
            get { return _SelectedClient; }
            set => Set(ref _SelectedClient, value);
        }
        #endregion

        


        #region Команды

        //#region CloseApplicationCommand
        //public ICommand CloseApplicationCommand { get; }

        //private bool CanCloseApplicationCommandExecute(object p) => true;

        //private void OnCloseApplicationCommandExecute(object p)
        //{
        //    Application.Current.Shutdown();
        //}
        //#endregion

        #region CreateNewClient

        //public ICommand CreateNewClientCommand { get; }

        //private bool CanCreateNewClientCommandExecute(object p) => true;

        //private void OnCreateNewClientCommandExecute(object p)
        //{
        //    Repository.clients.Add(new Client());
        //}
        #endregion

        #region DeleteClient

        public ICommand DeleteClientCommand { get; }

        private bool CanDeleteClientCommandExecute(object p) => p is Client client;

        private void OnDeleteClientCommandExecute(object p)
        {
            if(!(p is Client client)) return;
            Repository.clients.Remove(_SelectedClient);
        }
        #endregion

        #endregion



        public MainWindowViewModel()
        {
            #region Команды
            //CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecute, CanCloseApplicationCommandExecute);

            DeleteClientCommand = new LambdaCommand(OnDeleteClientCommandExecute, CanDeleteClientCommandExecute);
            #endregion
        }



    }
}
