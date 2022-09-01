namespace Homework_11.Models;

public class Client //: DependencyObject
{
    private string firstname;
    private string lastname;
    private string patronymic;
    private long phoneNumber;
    private long seriesAndNumberOfPassport;

    public string Firstname { get { return firstname; } set { firstname = value; } }

    public string Lastname { get { return lastname; } set { lastname = value; } }

    public string Patronymic { get { return patronymic; } set { patronymic = value; } }

    public long PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }

    public long SeriesAndNumberOfPassport { get { return seriesAndNumberOfPassport; } set { seriesAndNumberOfPassport = value; } }

    public Client(string firstname, string lastname, string patronymic, long phoneNumber, long seriesAndNumberOfPassport)
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

    //public static readonly DependencyProperty FirstnameProperty;
    //public static readonly DependencyProperty LastnameProperty;
    //public static readonly DependencyProperty PatronymicProperty;
    //public static readonly DependencyProperty PhoneNumberProperty;
    //public static readonly DependencyProperty SeriesAndNumberOfPassportProperty;

    //static Client()
    //{
    //    FirstnameProperty = DependencyProperty.Register("Firstname", typeof(string), typeof(Client));
    //    LastnameProperty = DependencyProperty.Register("Lastname", typeof(string), typeof(Client));
    //    PatronymicProperty = DependencyProperty.Register("Patronymic", typeof(string), typeof(Client));
    //    PhoneNumberProperty = DependencyProperty.Register("PhoneNumber", typeof(long), typeof(Client));
    //    SeriesAndNumberOfPassportProperty = DependencyProperty.Register("SeriesAndNumberOfPassport", typeof(long), typeof(Client));
    //}
    //public string Firstname
    //{
    //    get { return (string)GetValue(FirstnameProperty); }
    //    set { SetValue(FirstnameProperty, value); }
    //}

    //public string Lastname
    //{
    //    get { return (string)GetValue(LastnameProperty); }
    //    set { SetValue(LastnameProperty, value); }
    //}

    //public string Patronymic
    //{
    //    get { return (string)GetValue(PatronymicProperty); }
    //    set { SetValue(PatronymicProperty, value); }
    //}

    //public long PhoneNumber
    //{
    //    get { return (long)GetValue(PhoneNumberProperty); }
    //    set { SetValue(PhoneNumberProperty, value); }
    //}

    //public long SeriesAndNumberOfPassport
    //{
    //    get { return (long)GetValue(SeriesAndNumberOfPassportProperty); }
    //    set { SetValue(SeriesAndNumberOfPassportProperty, value); }
    //}    
}

