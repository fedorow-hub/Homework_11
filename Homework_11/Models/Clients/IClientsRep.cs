using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11.Models.Clients;
public interface IClientsRep : IEnumerable<Client>
{
    /// <summary>
    /// Кол-во клиентов
    /// </summary>
    public int Count { get; }

    /// <summary>
    /// Получить список клиентов
    /// </summary>
    /// <returns></returns>
    IEnumerable<Client?> GetAllClients();

    /// <summary>
    /// Получение информации о клиенте по ИД
    /// </summary>
    /// <param name="clientId">ИД клиента</param>
    /// <returns></returns>
    Client? GetClientByID(int clientId);

    /// <summary>
    /// Добавление клиента в репозиторий
    /// </summary>
    /// <param name="client">Клиент</param>
    void InsertClient(Client? client);

    /// <summary>
    /// Удаление клиента
    /// </summary>
    /// <param name="clientId">ИД клиента</param>
    void DeleteClient(int clientId);

    /// <summary>
    /// Обновление данных о клиенте
    /// </summary>
    /// <param name="client">Клиент</param>
    void UpdateClient(Client? client);

    /// <summary>
    /// Удаление всех данных
    /// </summary>
    void Clear();
}
