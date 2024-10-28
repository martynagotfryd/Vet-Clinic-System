namespace VetClinic.Models.Pets;

[Serializable]
public class Domestic : Pet
{
    private bool _microchip;

    public Domestic(string name, DateTime dateOfBirth, bool microchip)
        : base(name, dateOfBirth)
    {
        Microchip = microchip; 
    }

    public bool Microchip
    {
        get => _microchip;
        set => _microchip = value;
    }
}
