using Homework_11.Models.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11.Models.Worker;
public class Consultant : Worker
{
    public Consultant()
    {
        DataAccess = new RoleDataAccess(
            new CommandsAccess
            {
                AddClient = false,
                EditClient = true,
                DelClient = false
            },
            new EditFieldsAccess()
            {
                FirstName = false,
                LastName = false,
                MidleName = false,
                PassortData = false,
                PhoneNumber = true
            });
    }

    public override ClientAccessInfo GetClientInfo(Client client)
    {
        ClientAccessInfo clientAccessInfo = new ClientAccessInfo(client);
        clientAccessInfo.PassportSerie = "****";
        clientAccessInfo.PassportNumber = "*******";
              
        return clientAccessInfo;
    }

    public override string ToString()
    {
        return "Консультант";
    }
}
