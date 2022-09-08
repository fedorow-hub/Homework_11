using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Homework_11.Models.Clients;
public class ClientsRepository : IClientsRep
{
    private static int Id;
    static ClientsRepository()
    {
        Id = 0;
    }
    /// <summary>
    /// Получение следующего свободного идентификатора клиента
    /// </summary>
    /// <returns></returns>
    private static int NextId() => ++Id;




    private List<Client>? _clients;
    /// <summary>
    /// Список клиентов
    /// </summary>
    public List<Client>? Clients => _clients;
    /// <summary>
    /// Файл репозитория
    /// </summary>
    string _path;

    /// <summary>
    /// Конструктор репозитория
    /// </summary>
    /// <param name="path">Путь к файлу-репозиторию</param>
    public ClientsRepository(string path)
    {        
        if (string.IsNullOrEmpty(path) || string.IsNullOrWhiteSpace(path))
        {            
            throw new ArgumentNullException(nameof(path));
        }
        _path = path;

        if (File.Exists(_path)) // если файл существует, подгружаем данные
        {
            Load();
            return;
        }
        // если файл не существует, создаем новый пустой репозиторий
        File.Create(_path);
        NoClientsForLoad();
    }

    /// <summary>
    /// Получение данных о клиенте по ИД
    /// </summary>
    /// <param name="clientId">ИД клиента</param>
    /// <returns></returns>
    public Client? GetClientByID(int clientId)
    {
        if (_clients.Any(c => c.Id == clientId))
        {            
            return _clients.FirstOrDefault(c => c.Id == clientId);
        }
        return null;
    }

    /// <summary>
    /// Кол-во клиентов
    /// </summary>
    public int Count => Clients.Count();

    /// <summary>
    /// Получение списка клиентов
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Client?> GetAllClients() => Clients;

    /// <summary>
    /// Добавление нового клиента
    /// </summary>
    /// <param name="client">клиент</param>
    public void InsertClient(Client client)
    {
        if (client is null)
            return;
        client.Id = NextId();        
        _clients.Add(client);
        Save();
    }

    /// <summary>
    /// Обновление данных о клиенте
    /// </summary>
    /// <param name="client"></param>
    public void UpdateClient(Client client)
    {
        if (!_clients.Any(c => c.Id == client.Id))
        {           
            throw new ArgumentOutOfRangeException(nameof(client), "Такого объекта нет в списке");
        }

        _clients[_clients.IndexOf(_clients.First(c => c.Id == client.Id))] = client;        
        Save();
    }

    /// <summary>
    /// Очистка репозитория
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public void Clear()
    {
        if (Clients is null)
            return;
        Clients.Clear();
    }


    /// <summary>
    /// Удаление клиента
    /// </summary>
    /// <param name="clientId">ИД клиента</param>
    public void DeleteClient(int clientId)
    {
        if (_clients.Any(c => c.Id == clientId))
        {
            _clients.Remove(_clients.FirstOrDefault(c => c.Id == clientId));            
        }        
        Save();
    }

    /// <summary>
    /// Сохранение списка клиентов в файл
    /// </summary>
    void Save()
    {
        string? dirPath = Path.GetFileName(Path.GetDirectoryName(_path));
        if (dirPath is null)
            return;
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }
        string json = JsonSerializer.Serialize(_clients);
        File.WriteAllText(_path, json);        
    }

    /// <summary>
    /// Загрузка списка клиентов
    /// </summary>
    void Load()
    {
        string data = File.ReadAllText(_path);
        if (string.IsNullOrEmpty(data))
        {
            NoClientsForLoad();
            return;
        }
        _clients = JsonSerializer.Deserialize<List<Client>>(data, new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        });

        if (_clients is null)
        {
            NoClientsForLoad();
            return;
        }        
        Id = Count > 0 ? _clients.Max(c => c.Id) : 0;
    }

    /// <summary>
    /// Обработка ситуации, когда не возможно загрузить клиентов
    /// </summary>
    private void NoClientsForLoad()
    {        
        _clients = new List<Client>();
        Id = 0;
    }

    public IEnumerator<Client> GetEnumerator()
    {
        for (int i = 0; i < Clients.Count(); i++)
        {
            yield return Clients[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}
