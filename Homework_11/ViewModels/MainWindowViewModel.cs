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

        //public ObservableCollection<ClientAccessInfo> Clients { get; }

        private ObservableCollection<ClientAccessInfo> clients;

        public ObservableCollection<ClientAccessInfo> Clients
        {
            get => clients;
            set => Set(ref clients, value);
        }

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
            Bank = new Bank("Банк А", new ClientsRepository("clients.json"), worker);            
            this.title = $"{Bank.Name}. Работа с клиентами";
            Worker = worker;

            Clients = new ObservableCollection<ClientAccessInfo>();

            #region commands
            DeleteClientCommand = new LambdaCommand(OnDeleteClientCommandExecute, CanDeleteClientCommandExecute);
            OutLoggingCommand = new LambdaCommand(OnOutLoggingCommandExecute, CanOutLoggingCommandExecute);
            AddClientCommand = new LambdaCommand(OnAddClientCommandExecute, CanAddClientCommandExecute);
            EditClientCommand = new LambdaCommand(OnEditClientCommandExecute, CanEditClientCommandExecute);

            _enableAddClient = Worker.DataAccess.Commands.AddClient;
            _enableDelClient = Worker.DataAccess.Commands.DelClient;
            _enableEditClient = Worker.DataAccess.Commands.EditClient && Clients.Count > 0;

            
            #endregion
            //UpdateClients();
            UpdateClientsList += UpdateClients;
            UpdateClientsList.Invoke();
        }

        /// <summary>
        /// Обновление списка клиентов
        /// </summary>
        private void UpdateClients()
        {
            
            Clients.Clear();            
            foreach (var clientInfo in Bank.GetClientsInfo())
            {
                Clients.Add(clientInfo);
            }                    

           
        }

        #region SelectedClient

        private ClientAccessInfo _SelectedClient;
        /// <summary>
        /// Выбранный клиент
        /// </summary>
        public ClientAccessInfo SelectedClient
        {
            get { return _SelectedClient; }
            set => Set(ref _SelectedClient, value);
        }
        #endregion

        //#region SelectedIndex
        //private int _selectedIndex;
        //public int SelectedIndex
        //{
        //    get => _selectedIndex;
        //    set => Set(ref _selectedIndex, value);
        //}
        //#endregion

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
                
        private bool CanAddClientCommandExecute(object p)
        {
            if (_enableAddClient == true)
                return true;
            else return false;
        }

        private void OnAddClientCommandExecute(object p)
        {
            ClientInfoWindow infoWindow = new ClientInfoWindow();
            ClientInfoViewModel viewModel = new ClientInfoViewModel(new ClientAccessInfo(), Bank, this, Worker.DataAccess);
            infoWindow.DataContext = viewModel;
            infoWindow.Show();            
        }
        #endregion

        #region DeleteClient

        public ICommand DeleteClientCommand { get; }

        //private bool CanDeleteClientCommandExecute(object p) => p is Client client;

        private bool CanDeleteClientCommandExecute(object p) 
        {
            if (_enableDelClient == true && p is Client client)
                return true;
            else return false;            
        }

        private void OnDeleteClientCommandExecute(object p)
        {
            if (SelectedClient is null) return;
            Bank.DeleteClient(SelectedClient);
            UpdateClientsList.Invoke();
        }
        #endregion

        #region EditClient

        public ICommand EditClientCommand { get; }

        
        private bool CanEditClientCommandExecute(object p)
        {
            if (p is Client client)
                return true;
            else return false;
        }

        private void OnEditClientCommandExecute(object p)
        {
            if (SelectedClient is null) return;

            ClientInfoWindow infoWindow = new ClientInfoWindow();
            ClientInfoViewModel viewModel = new ClientInfoViewModel(SelectedClient, Bank, this, Worker.DataAccess);
            infoWindow.DataContext = viewModel;
            infoWindow.Show();
        }
        #endregion

        #endregion

        #region EnableAddClient
        private bool _enableAddClient;
        public bool EnableAddClient
        {
            get => _enableAddClient;
            set => Set(ref _enableAddClient, value);
        }
        #endregion

        #region EnableDelClient
        private bool _enableDelClient;
        public bool EnableDelClient
        {
            get => _enableDelClient;
            set => Set(ref _enableDelClient, value);
        }
        #endregion

        #region EnableEditClient
        private bool _enableEditClient;
        public bool EnableEditClient
        {
            get => _enableEditClient;
            set => Set(ref _enableEditClient, value);
        }
        #endregion

    }
}
