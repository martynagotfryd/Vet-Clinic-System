namespace VetClinic.Models;

using System;
using System.Collections.Generic;

[Serializable]
public class Visit
{
    private static decimal _taxRate = 0.08m; 
    private DateTime _date;
    private string _description;
    private decimal _totalPrice;

    private static List<Visit> _visits = new List<Visit>();

    public Visit(DateTime date, string description, decimal price)
    {
        Date = date;
        Description = description;
        TotalPrice = price * (1 + _taxRate);;
        AddVisit(this);
    }

    public DateTime Date
    {
        get => _date;
        set
        {
            if (value > DateTime.Now)
            {
                throw new ArgumentException("Date cannot be in the future.");
            }
            _date = value;
        }
    }

    public string Description
    {
        get => _description;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Description cannot be null or empty.");
            }
            _description = value;
        }
    }

    public decimal TotalPrice
    {
        get => _totalPrice;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Total price cannot be negative.");
            }
            _totalPrice = value;
        }
    }

    private static void AddVisit(Visit visit)
    {
        if (visit == null)
        {
            throw new ArgumentException("Visit cannot be null.");
        }
        _visits.Add(visit);
    }

    public static List<Visit> GetVisits() => new List<Visit>(_visits);
}
