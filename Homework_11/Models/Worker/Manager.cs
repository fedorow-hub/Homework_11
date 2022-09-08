using Homework_11.Models.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11.Models.Worker;
public class Manager : Worker
{
    public Manager()
    {
        DataAccess = new RoleDataAccess(
            new CommandsAccess
            {
                AddClient = true,
                EditClient = true,
                DelClient = true
            },
            new EditFieldsAccess()
            {
                FirstName = true,
                LastName = true,
                MidleName = true,
                PassortData = true,
                PhoneNumber = true
            });
    }
    public override Client GetClientInfo(Client client)
    {        
        return client;
    }

    public override string ToString()
    {
        return "Менеджер";
    }
}
