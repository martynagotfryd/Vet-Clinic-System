namespace VetClinic.Models.Services;

using System;
using System.Collections.Generic;

[Serializable]
public abstract class Service
{
    private decimal _price;
    private string _description;
    private List<Service>? _subServices = new List<Service>(); 
    private static List<Service> _services = new List<Service>();

    protected Service(decimal price, string description, List<Service>? subServices = null)
    {
        Price = price;
        Description = description;
        SubServices = subServices;
        AddService(this);
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

    public List<Service>? SubServices
    {
        get => _subServices;
        set => _subServices = value;
    }
    private static void AddService(Service service)
    {
        if (service == null)
        {
            throw new ArgumentException("Service cannot be null.");
        }
        _services.Add(service);
    }

    public static List<Service> GetAllServices() => new List<Service>(_services);
}
