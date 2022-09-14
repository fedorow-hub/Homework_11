using Homework_11.Models.Clients;


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
    public override ClientAccessInfo GetClientInfo(Client client)
    {
        ClientAccessInfo clientInfo = new ClientAccessInfo(client);
        clientInfo.PassportSerie = client.SeriesAndNumberOfPassport.Serie.ToString();
        clientInfo.PassportNumber = client.SeriesAndNumberOfPassport.Number.ToString();
        return clientInfo;
    }

    public override string ToString()
    {
        return "Менеджер";
    }
}
