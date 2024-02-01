namespace LibLogistica;

public abstract class Persons
{

    private string postalCode;

    private string phoneNumber;

    private string email;

    private string taxCode;

    private string provence;

    private DateTime bornDate;


    public string TaxCode
    {
        get
        {
            return taxCode;
        };
        set
        {
            const string regex = "^[A-Z]{6}\d{2}[A-Z]\d{3}[A-Z]$";
            if (!Regex.IsMatch(value, regex))
                throw new Exception("Invalid tax code");

            taxCode = value;
        }
    }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string HomeAddress { get; set; }
    public string City { get; set; }
    public string Provence
    {
        get
        {
            return provence;
        }
        set
        {
            if (value.Length != 2)
                throw new Exception("Invalid provence");
            provence = value;
        }
    }
    public string PostalCode
    {
        get
        {
            return postalCode;
        }
        set
        {
            if (value.Length != 5)
                throw new Exception("Invalid postal code");

            postalCode = value;
        };
    }
    public int civicNumber { get; set; }
    public string phoneNumber
    {
        get
        {
            return phoneNumber;
        }; set
        {
            if (value.Length < 10 || value.Length > 13)
                throw new Exception("Invalid phone number");

            phoneNumber = value;
        }
    }
    public string Email
    {
        get
        {
            return email;
        }
        set
        {
            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            if (!Regex.IsMatch(value, pattern))
                throw new Exception("Invalid email");

            email = value;
        }
    };
    public Company Company { get; set; }
    public DateTime bornDate
    {
        get
        {
            return bornDate;
        }
        set
        {
            if (value > DateTime.Now)
                throw new Exception("Invalid born date");
            BornDate = value;
        }
    }
    public string birthPlace { get; set; }
    public Sex Sex { get; set; }
    public enum Sex
    {
        Male,
        Female,
        Other
    }

    public int calculateAge()
    {
        DateTime today = DateTime.Today;
        int age = today.Year - bornDate.Year;
        if (bornDate > today.AddYears(-age)) age--;
        return age;
    }
    public string getFullName()
    {
        return Name + " " + Surname;
    }

    public string getFullAddress()
    {
        return HomeAddress + " " + civicNumber + " " + City + " " + PostalCode + " " + Provence;
    }

    public string getFullInfo()
    {
        return getFullName() + " " + getFullAddress() + " " + Email + " " + phoneNumber;
    }

    
    
}


public class Driver : Persons
{
    public Vehicle License { get; set; }  //allowed types of vehicles
}


public class Passenger : Persons
{
  
}