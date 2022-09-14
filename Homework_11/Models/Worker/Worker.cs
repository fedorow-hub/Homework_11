using Homework_11.Models.Clients;

namespace Homework_11.Models.Worker;
public abstract class Worker
{
    public RoleDataAccess DataAccess { get; protected set; }

    /// <summary>
    /// Получение информации о клиенте
    /// </summary>
    /// <param name="client"></param>
    /// <returns></returns>
    public abstract ClientAccessInfo GetClientInfo(Client client);
}
