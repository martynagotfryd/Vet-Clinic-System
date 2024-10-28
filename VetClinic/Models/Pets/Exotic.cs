namespace VetClinic.Models.Pets;

[Serializable]
public class Exotic : Pet
{
    private string _licence;

    public Exotic(string name, DateTime dateOfBirth, string licence)
        : base(name, dateOfBirth)
    {
        Licence = licence;
    }

    public string Licence
    {
        get => _licence;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Licence cannot be null or empty.");
            }
            _licence = value;
        }
    }
}

