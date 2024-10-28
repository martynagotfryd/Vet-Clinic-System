namespace VetClinic.Models;

using System;
using System.Collections.Generic;

[Serializable]
public class Prescription
{
    private static int _id;
    private DateTime? _dueDate;

    private static List<Prescription> _prescriptions = new List<Prescription>();

    public Prescription(int id, DateTime? dueDate = null)
    {
        Id = id;
        DueDate = dueDate;
        AddPrescription(this);
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

    public DateTime? DueDate
    {
        get => _dueDate;
        set
        {
            if (value != null && value < DateTime.Now.Date)
            {
                throw new ArgumentException("Due date cannot be in the past.");
            }
            _dueDate = value; 
        }
    }

    private static void AddPrescription(Prescription prescription)
    {
        if (prescription == null)
        {
            throw new ArgumentException("Prescription cannot be null.");
        }
        _prescriptions.Add(prescription);
    }

    public static List<Prescription> GetPrescriptions() => new List<Prescription>(_prescriptions);
}