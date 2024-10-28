namespace VetClinic.Models.Pets;

[Serializable]
public class Aqua : Pet
{
    private decimal _waterTemp;
    private string _waterType;

    public Aqua(string name, DateTime dateOfBirth, decimal waterTemp, string waterType)
        : base(name, dateOfBirth)
    {
        WaterTemp = waterTemp;
        WaterType = waterType;
    }

    public decimal WaterTemp
    {
        get => _waterTemp;
        set
        {
            if (value is < 0 or > 50) 
            {
                throw new ArgumentException("Water temperature must be between 0 and 50 degrees Celsius.");
            }
            _waterTemp = value;
        }
    }

    public string WaterType
    {
        get => _waterType;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Water type cannot be null or empty.");
            }
            _waterType = value;
        }
    }
}
