namespace Homework_11.Models.Clients;

public class Client
{
    private int id;
    private string firstname;
    private string lastname;
    private string patronymic;
    private long phoneNumber;
    private string seriesAndNumberOfPassport;

    public int Id { get { return id; } set { id = value; } }

    public string Firstname { get { return firstname; } set { firstname = value; } }

    public string Lastname { get { return lastname; } set { lastname = value; } }

    public string Patronymic { get { return patronymic; } set { patronymic = value; } }

    public long PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }

    public string SeriesAndNumberOfPassport { get { return seriesAndNumberOfPassport; } set { seriesAndNumberOfPassport = value; } }

    public Client(string firstname, string lastname, string patronymic, long phoneNumber, string seriesAndNumberOfPassport= "Нет данных")
    {        
        Firstname = firstname;
        Lastname = lastname;
        Patronymic = patronymic;
        PhoneNumber = phoneNumber;
        SeriesAndNumberOfPassport = seriesAndNumberOfPassport;
    }

    public override string ToString()
    {
        return $"{firstname} {lastname} {patronymic} {phoneNumber} {seriesAndNumberOfPassport}";
    }

    
}

