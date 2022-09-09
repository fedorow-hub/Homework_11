using Homework_11.Data;
using Homework_11.Infrastructure.Commands;
using Homework_11.Models;
using Homework_11.Models.Clients;
using Homework_11.Models.Worker;
using Homework_11.ViewModels.Base;
using Homework_11.Views.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Homework_11.ViewModels
{
    internal class MainWindowViewModel: ViewModel
    {
        public Action UpdateClientsList;
        public Worker Worker { get; private set; }        
        
        public Bank Bank { get; private set; }

        #region Window title

        private string title;
        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string Title
        {
            get => title;
            set => Set(ref title, value);
        }
        #endregion

        public MainWindowViewModel()
        {
        }
        public MainWindowViewModel(Worker worker)
        {            
            //Bank = new Bank("Банк А", new ClientsRepository("clients.json"), worker);
            Bank = new Bank("Банк А", new Repository(10), worker);
            this.title = $"{Bank.Name}. Работа с клиентами";
            Worker = worker;

            #region commands
            DeleteClientCommand = new LambdaCommand(OnDeleteClientCommandExecute, CanDeleteClientCommandExecute);
            OutLoggingCommand = new LambdaCommand(OnOutLoggingCommandExecute, CanOutLoggingCommandExecute);
            AddClientCommand = new LambdaCommand(OnAddClientCommandExecute, CanAddClientCommandExecute);
            #endregion

            UpdateClientsList += UpdateClients;
        }

        /// <summary>
        /// Обновление списка клиентов
        /// </summary>
        private void UpdateClients()
        {
            var selectedIndex = _selectedIndex;
            Bank.ClientsRepository.Clear();            
            foreach (var clientInfo in Bank.GetClientsInfo())
            {
                Bank.AddClient(clientInfo);
            }

            SelectedIndex = selectedIndex;

           
        }

        //private Repository _Repository = new Repository(100);

        //public Repository Repository
        //{
        //    get { return _Repository; }
        //    set => Set(ref _Repository, value);
        //}




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

        #region SelectedIndex
        private int _selectedIndex;
        public int SelectedIndex
        {
            get => _selectedIndex;
            set => Set(ref _selectedIndex, value);
        }
        #endregion

        #region Команды

        #region OutLoggingCommand
        public ICommand OutLoggingCommand { get; }

        private bool CanOutLoggingCommandExecute(object p) => true;

        private void OnOutLoggingCommandExecute(object p)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();

            if(p is Window window)
            {
                window.Close();
            }
        }
        #endregion

        #region AddClientCommand

        public ICommand AddClientCommand { get; }

        private bool CanAddClientCommandExecute(object p) => true;

        private void OnAddClientCommandExecute(object p)
        {
            ClientInfoWindow infoWindow = new ClientInfoWindow();
            infoWindow.Show();
            if(p is Window window)
            {
                window.Close();
            }
        }
        #endregion

        #region DeleteClient

        public ICommand DeleteClientCommand { get; }

        private bool CanDeleteClientCommandExecute(object p) => p is Client client;

        private void OnDeleteClientCommandExecute(object p)
        {
            if(!(p is Client client)) return;
            Bank.DeleteClient(client);            
        }
        #endregion

        #endregion

    }
}
