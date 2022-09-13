using Homework_11.Infrastructure.Commands;
using Homework_11.Models;
using Homework_11.Models.Clients;
using Homework_11.Models.Worker;
using Homework_11.ViewModels.Base;
using Homework_11.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Homework_11.ViewModels
{
    internal class ClientInfoViewModel : ViewModel
    {
        private ClientAccessInfo currentClientAccessInfo { get; set; }
        private Bank bank { get; set; }

        
        private MainWindowViewModel MainWindowViewModel { get; set; }

        public ClientInfoViewModel()
        {            
            
        }
        
        public ClientInfoViewModel(ClientAccessInfo clientInfo, Bank bank, MainWindowViewModel mainWindowViewModel, RoleDataAccess dataAccess)
        {
            this.currentClientAccessInfo = clientInfo;
            this.bank = bank;
            MainWindowViewModel = mainWindowViewModel;

            FillFields(currentClientAccessInfo);
            EnableFields(dataAccess);
            CheckSaveClient();
            

           

            OutCommand = new LambdaCommand(OnOutCommandExecute, CanOutCommandExecute);
            SaveCommand = new LambdaCommand(OnSaveCommandExecute, CanSaveCommandExecute);
        }

        /// <summary>
        /// Заполнение данных
        /// </summary>
        /// <param name="clientInfo"></param>
        private void FillFields(ClientAccessInfo clientInfo)
        {
            if (clientInfo is null)
                return;
            _firstname = clientInfo.Firstname ?? String.Empty;
            _lastname = clientInfo.Lastname ?? String.Empty;
            _patronymic = clientInfo.Patronymic ?? String.Empty;
            _phoneNumber = clientInfo.PhoneNumber?.ToString() ?? String.Empty;
            _passportSerie = clientInfo.PassportSerie ?? String.Empty;
            _passportNumber = clientInfo.PassportNumber ?? String.Empty;
        }

        /// <summary>
        /// Включение/отключения возможности ввода данных
        /// </summary>
        /// <param name="dataAccess"></param>
        private void EnableFields(RoleDataAccess dataAccess)
        {
            _enableFirstName = dataAccess.EditFields.FirstName;
            _enableLastName = dataAccess.EditFields.LastName;
            _enablePatronymic = dataAccess.EditFields.MidleName;
            _enablePassportData = dataAccess.EditFields.PassortData;
            _enablePhoneNumber = dataAccess.EditFields.PhoneNumber;

            //_borderFirstName = InputHighlighting(_firstName.Length > 0);
            //_borderLastName = InputHighlighting(_lastName.Length > 0);
            //_borderMiddleName = InputHighlighting(_middleName.Length > 0);
            //_borderPassportSerie = InputHighlighting(Passport.IsSeries(_passportSerie));
            //_borderPassportNumber = InputHighlighting(Passport.IsNumber(_passportNumber));
            _borderPhoneNumber = InputHighlighting(Models.Clients.PhoneNumber.IsPhoneNumber(_phoneNumber));
        }

        private void CheckSaveClient()
        {
            //EnableSaveClient = _borderFirstName != InputValueHighlightingEnum.Error
            //                   && _borderLastName != InputValueHighlightingEnum.Error
            //                   && _borderMiddleName != InputValueHighlightingEnum.Error
            //                   && _borderPassportSerie != InputValueHighlightingEnum.Error
            //                   && _borderPassportNumber != InputValueHighlightingEnum.Error
            //                   && _borderPhoneNumber != InputValueHighlightingEnum.Error;

            EnableSaveClient = _borderPhoneNumber != InputValueHighlightingEnum.Error;
        }

        public enum InputValueHighlightingEnum
        {
            Default = 0,            
            Error
        }

        private InputValueHighlightingEnum InputHighlighting(bool isValid)
        {            
            if (!isValid) return InputValueHighlightingEnum.Error;

            return InputValueHighlightingEnum.Default;
        }


        #region ClientInfo

        #region Firstname
        private string _firstname;
        public string Firstname
        {
            get => _firstname;
            set
            {
                Set(ref _firstname, value);                
            }
        }

        private bool _enableFirstName;
        public bool EnableFirstName
        {
            get => _enableFirstName;
            set => Set(ref _enableFirstName, value);
        }
                
        #endregion

        #region Lastname
        private string _lastname;
        public string Lastname
        {
            get => _lastname;
            set
            {
                Set(ref _lastname, value);                
            }
        }

        private bool _enableLastName;
        public bool EnableLastName
        {
            get => _enableLastName;
            set => Set(ref _enableLastName, value);
        }

        #endregion

        #region Patronymic
        private string _patronymic;
        public string Patronymic
        {
            get => _patronymic;
            set
            {
                Set(ref _patronymic, value);                
            }
        }

        private bool _enablePatronymic;
        public bool EnablePatronymic
        {
            get => _enablePatronymic;
            set => Set(ref _enablePatronymic, value);
        }
                
        #endregion

        #region PhoneNumber
        private string _phoneNumber;

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                Set(ref _phoneNumber, value);                
            }
        }

        private bool _enablePhoneNumber;
        public bool EnablePhoneNumber
        {
            get => _enablePhoneNumber;
            set => Set(ref _enablePhoneNumber, value);
        }

        private InputValueHighlightingEnum _borderPhoneNumber;
        public InputValueHighlightingEnum BorderPhoneNumber
        {
            get => _borderPhoneNumber;
            set
            {
                Set(ref _borderPhoneNumber, value);
                CheckSaveClient();
            }
        }

        #endregion

        #region PassportData
        private string _passportSerie;
        public string PassportSerie
        {
            get => _passportSerie;
            set
            {
                Set(ref _passportSerie, value);                
            }
        }

        private string _passportNumber;
        public string PassportNumber
        {
            get => _passportNumber;
            set
            {
                Set(ref _passportNumber, value);                
            }
        }

        private bool _enablePassportData;
        public bool EnablePassportData
        {
            get => _enablePassportData;
            set => Set(ref _enablePassportData, value);
        }

        #endregion

        #endregion      



        #region Commands
        #region OutCommand

        public ICommand OutCommand { get; }

        private bool CanOutCommandExecute(object p) => true;

        private void OnOutCommandExecute(object p)
        {            
            if (p is Window window)
            {
                window.Close();
            }
        }
        #endregion

        #region SaveCommand

        public ICommand SaveCommand { get; }

        private bool CanSaveCommandExecute(object p) => true;

        private void OnSaveCommandExecute(object p)
        {            
            var client = new Client(_firstname, _lastname, _patronymic,
                new PhoneNumber(_phoneNumber), _enablePassportData ? new Passport(int.Parse(_passportSerie), int.Parse(_passportNumber)) :                
                new Passport(currentClientAccessInfo.SeriesAndNumberOfPassport.Serie, currentClientAccessInfo.SeriesAndNumberOfPassport.Number));

            if (currentClientAccessInfo.Id == 0) // новый клиент
            {
                bank.AddClient(client);
            }
            else
            {
                client.Id = currentClientAccessInfo.Id;
                bank.EditClient(client);
            }
                     
            MainWindowViewModel.UpdateClientsList.Invoke();

            if (p is Window window)
            {
                window.Close();
            }
        }
        #endregion
        #endregion

        #region EnableSaveClient
        private bool _enableSaveClient;
        public bool EnableSaveClient
        {
            get => _enableSaveClient;
            set => Set(ref _enableSaveClient, value);
        }
        #endregion

    }
}
