namespace VetClinic.Models.Pets;

[Serializable]
public class Cage : Pet
{
    private string _groundType;

    public Cage(string name, DateTime dateOfBirth, string groundType)
        : base(name, dateOfBirth)
    {
        GroundType = groundType;
    }

    public string GroundType
    {
        get => _groundType;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Ground type cannot be null or empty.");
            }
            _groundType = value;
        }
    }
}
