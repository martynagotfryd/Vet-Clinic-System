namespace VetClinic.Models.Pets;

[Serializable]
public class Other : Pet
{
    public Other(string name, DateTime dateOfBirth)
        : base(name, dateOfBirth)
    {
    }
}
