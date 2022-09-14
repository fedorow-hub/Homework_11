using Homework_11.Infrastructure.Commands.Base;
using Homework_11.Models;
using Homework_11.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11.Infrastructure.Commands
{
    internal class CloseApplicationCommand : Command
    {
        public override bool CanExecute(object? parameter) => true;

        public override void Execute(object? parameter)
        {
            Application.Current.Shutdown();
        }
    }
}
