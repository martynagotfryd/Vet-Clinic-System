namespace VetClinic.Models;

using System;
using System.Collections.Generic;

[Serializable]
public class Medication
{
    private int _id;
    private string _name;
    private decimal _price;

    private static List<Medication> _medications = new List<Medication>();

    public Medication(int id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
        AddMedication(this);
    }

    public int Id
    {
        get => _id;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("ID must be a positive integer.");
            }
            _id = value;
        }
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

    public decimal Price
    {
        get => _price;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Price cannot be negative.");
            }
            _price = value;
        }
    }

    private static void AddMedication(Medication medication)
    {
        if (medication == null)
        {
            throw new ArgumentException("Medication cannot be null.");
        }
        _medications.Add(medication);
    }

    public static List<Medication> GetMedications() => new List<Medication>(_medications);
}
