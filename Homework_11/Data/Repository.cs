using Homework_11.Models.Clients;

namespace Homework_11.Data;
public class Repository
{
    public ObservableCollection<Client> clients { get; set; }

    /// <summary>
    /// База данных имён
    /// </summary>
    static readonly string[] firstNames;

    /// <summary>
    /// База данных фамилий
    /// </summary>
    static readonly string[] lastNames;

    /// <summary>
    /// База данных отчеств
    /// </summary>
    static readonly string[] patronymics;

    /// <summary>
    /// Генератор псевдослучайных чисел
    /// </summary>
    static Random randomize;


    /// <summary>
    /// Статический конструктор, в котором "хранятся"
    /// данные о именах и фамилиях баз данных firstNames и lastNames
    /// </summary>
    static Repository()
    {
        randomize = new Random(); // Размещение в памяти генератора случайных чисел

        // Размещение имен в базе данных firstNames
        firstNames = new string[] {
                "Александр",
                "Алексей",
                "Артем",
                "Артур",
                "Антон",
                "Альберт",
                "Борис",
                "Владимир",
                "Василий",
                "Вениамин",
                "Вячеслав",
                "Виктор",
                "Григорий",
                "Георгий",
                "Геннадий",
                "Дмитрий",
                "Денис",
                "Евгений",
                "Зиновий",
                "Иван",
                "Игнат",
                "Илья",
                "Игорь",
                "Константин",
                "Кондрат",
                "Леонид",
                "Лаврентий",
                "Лука",
                "Михаил",
                "Максим",
                "Николай",
                "Никита",
                "Олег",
                "Петр",
                "Роман",
                "Роберт",
                "Степан",
                "Семен",
                "Сергей",
                "Серафим",
                "Тимофей",
                "Тимур",
                "Федор",
                "Фома",
                "Харитон",
                "Эдуард",
                "Эвклид",
                "Юрий",
                "Яков"
            };

        // Размещение фамилий в базе данных lastNames
        lastNames = new string[]
        {
                "Иванов",
                "Петров",
                "Васильев",
                "Кузнецов",
                "Ковалёв",
                "Попов",
                "Пономарёв",
                "Дьячков",
                "Коновалов",
                "Соколов",
                "Лебедев",
                "Соловьёв",
                "Козлов",
                "Волков",
                "Зайцев",
                "Ершов",
                "Карпов",
                "Щукин",
                "Виноградов",
                "Цветков",
                "Калинин"
        };

        //Размещение отчеств в базе данных patronymic
        patronymics = new string[]
        {
            "Александрович",
            "Алексеевич",
            "Артемович",
            "Артурович",
            "Антонович",
            "Альбертович",
            "Борисович",
            "Владимирович",
            "Васильевич",
            "Вениаминович",
            "Вячеславович",
            "Викторович",
            "Григориевич",
            "Георгиевич",
            "Геннадьевич",
            "Дмитриевич",
            "Денисович",
            "Евгеньевич",
            "Зиновьевич",
            "Иванович",
            "Игнатьевич",
            "Ильич",
            "Игоревич",
            "Константинович",
            "Кондратьевич",
            "Леонидович",
            "Лаврентьевич",
            "Лукич",
            "Михаилович",
            "Максимович",
            "Николаевич",
            "Никитович",
            "Олегович",
            "Петрович",
            "Романович",
            "Робертович",
            "Степанович",
            "Семенович",
            "Сергеевич",
            "Серафимович",
            "Тимофеевич",
            "Тимурович",
            "Федорович",
            "Фомич",
            "Харитонович",
            "Эдуардович",
            "Эвклидович",
            "Юрьевич",
            "Яковлевич"
        };
    }

    public Repository() { }

    /// <summary>
    /// Конструктор, заполняющий базу данных Department
    /// </summary>
    /// <param name="Count">Количество сотрудников, которых нужно создать</param>
    public Repository(int Count)
    {
        Random random = new Random();
        PhoneNumber phoneNumber = new PhoneNumber("+09813413248");

        Passport seriesAndNumberOfPassport = new Passport();
        seriesAndNumberOfPassport.Serie = 0000;
        seriesAndNumberOfPassport.Number = 000000;

        clients = new ObservableCollection<Client>(); // Выделение памяти для хранения базы данных Workers
        for (int i = 0; i < Count; i++)    // Заполнение базы данных Workers. Выполняется Count раз
        {
            // Добавляем нового работника в базы данных Workers
            clients.Add(
                new Client(
                    // выбираем случайное имя из базы данных имён
                    firstNames[randomize.Next(firstNames.Length)],

                    // выбираем случайную фамилию из базы данных фамилий
                    lastNames[randomize.Next(lastNames.Length)],

                    // выбираем случайную фамилию из базы данных фамилий
                    patronymics[randomize.Next(patronymics.Length)],

                    phoneNumber,

                    seriesAndNumberOfPassport
                    ));
        }
    }


}
