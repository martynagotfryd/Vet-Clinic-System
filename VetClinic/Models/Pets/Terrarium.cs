namespace VetClinic.Models.Pets;

[Serializable]
public class Terrarium : Pet
{
    private decimal _humidity;
    private decimal _temp;

    public Terrarium(string name, DateTime dateOfBirth, decimal humidity, decimal temp)
        : base(name, dateOfBirth)
    {
        Humidity = humidity;
        Temp = temp;
    }

    public decimal Humidity
    {
        get => _humidity;
        set
        {
            if (value is < 0 or > 100) 
            {
                throw new ArgumentException("Humidity must be between 0 and 100%.");
            }
            _humidity = value;
        }
    }

    public decimal Temp
    {
        get => _temp;
        set
        {
            if (value < 0 || value > 50) // Example range for terrarium temperature
            {
                throw new ArgumentException("Temperature must be between 0 and 50 degrees Celsius.");
            }
            _temp = value;
        }
    }
}
