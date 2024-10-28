namespace VetClinic.Models;

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

[Serializable]
public class Doctor
{
    private string _name;
    private string _surname;
    private string _contact;
    private List<string> _specialties = new List<string>();

    private static List<Doctor> _doctors = new List<Doctor>();

    public Doctor(string name, string surname, string contact, List<string> specialties)
    {
        Name = name;
        Surname = surname;
        Contact = contact;
        Specialties = specialties;
        AddDoctor(this);
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

    public string Surname
    {
        get => _surname;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Surname cannot be null or empty.");
            }
            _surname = value;
        }
    }

    public string Contact
    {
        get => _contact;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Contact cannot be null or empty.");
            }

            if (!Regex.IsMatch(value, @"^\d{9}$"))
            {
                throw new ArgumentException("Phone number is in an invalid format.");
            }

            _contact = value;
        }
    }

    public List<string> Specialties
    {
        get => new List<string>(_specialties);
        set
        {
            if (value == null || value.Count == 0)
            {
                throw new ArgumentException("Specialties cannot be null or empty.");
            }
            _specialties = new List<string>(value);
        }
    }
    
    public void AddSpecialty(string specialty)
    {
        if (string.IsNullOrEmpty(specialty))
        {
            throw new ArgumentException("Specialty cannot be null or empty.");
        }
        
        if (_specialties.Contains(specialty))
        {
            throw new ArgumentException("Specialty already exists for this doctor.");
        }

        _specialties.Add(specialty);
    }

    private static void AddDoctor(Doctor doctor)
    {
        if (doctor == null)
        {
            throw new ArgumentException("Doctor cannot be null.");
        }
        _doctors.Add(doctor);
    }

    public static List<Doctor> GetDoctors() => new List<Doctor>(_doctors);
}
