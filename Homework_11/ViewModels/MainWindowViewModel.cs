using Homework_11.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
