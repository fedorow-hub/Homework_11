namespace Homework_11.Models.Clients;

public class Client
{
    private int id;
    private string firstname;
    private string lastname;
    private string patronymic;
    private PhoneNumber phoneNumber;
    private Passport seriesAndNumberOfPassport;
    private string timeOfChanging;
    private string workerMakedChange;

    public int Id { get { return id; } set { id = value; } }

    public string Firstname { get { return firstname; } set { firstname = value; } }

    public string Lastname { get { return lastname; } set { lastname = value; } }

    public string Patronymic { get { return patronymic; } set { patronymic = value; } }

    public PhoneNumber PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }

    public Passport SeriesAndNumberOfPassport { get { return seriesAndNumberOfPassport; } set { seriesAndNumberOfPassport = value; } }

    public string TimeOfChanging { get { return timeOfChanging; } set { timeOfChanging = value; } }

    public string WorkerMakedChange { get { return workerMakedChange; } set { workerMakedChange = value; } }

    public Client(){}

    public Client(string firstname, string lastname, string patronymic, 
        PhoneNumber phoneNumber, Passport seriesAndNumberOfPassport, string timeOfChanging, string worker)
    {
        this.firstname = firstname;
        this.lastname = lastname;
        this.patronymic = patronymic;
        this.phoneNumber = phoneNumber;
        this.seriesAndNumberOfPassport = seriesAndNumberOfPassport;
        this.timeOfChanging = timeOfChanging;
        this.workerMakedChange = worker;
    }

    //public override string ToString()
    //{
    //    return $"{firstname} {lastname} {patronymic} {phoneNumber} {seriesAndNumberOfPassport}";
    //}    
}

