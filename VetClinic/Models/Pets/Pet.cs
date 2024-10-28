namespace VetClinic.Models.Pets;

using System;

[Serializable]
public abstract class Pet
{
    private string _name;
    private DateTime _dateOfBirth;
    private static List<Pet> _pets = new List<Pet>();

    protected Pet(string name, DateTime dateOfBirth)
    {
        Name = name;
        DateOfBirth = dateOfBirth;
        AddPet(this);
    }

    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name cannot be null or empty.");
            }
            _name = value;
        }
    }

    public DateTime DateOfBirth
    {
        get => _dateOfBirth;
        set
        {
            if (value > DateTime.Now)
            {
                throw new ArgumentException("Date of birth cannot be in the future.");
            }
            _dateOfBirth = value;
        }
    }
    private static void AddPet(Pet pet)
    {
        if (pet == null)
        {
            throw new ArgumentException("Pet cannot be null.");
        }
        _pets.Add(pet);
    }

    public static List<Pet> GetAllPets() => new List<Pet>(_pets);
}
